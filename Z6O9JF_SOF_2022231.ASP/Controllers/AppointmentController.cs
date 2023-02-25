using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Z6O9JF_SOF_2022231.ASP.Logic;
using Z6O9JF_SOF_2022231.ASP.Models;

namespace Z6O9JF_SOF_2022231.ASP.Controllers
{
    public class AppointmentController : Controller
    {
        ICarLogic carLogic;
        IAppointmentLogic appointmentLogic;
        private readonly UserManager<SiteUser> _userManager;
        private readonly IEmailSender emailSender;

        public AppointmentController(ICarLogic carLogic, IAppointmentLogic appointmentLogic, UserManager<SiteUser> userManager, IEmailSender emailSender)
        {
            this.carLogic = carLogic;
            this.appointmentLogic = appointmentLogic;
            _userManager = userManager;
            this.emailSender = emailSender;
        }

        [Authorize]
        [OutputCache(Duration = 1, VaryByParam = "none")]
        public async Task<IActionResult> Index()
        {
            ;
            var user = await _userManager.GetUserAsync(User);

            AppointmentCreateViewModel appointmentCreateViewModel = new AppointmentCreateViewModel();
            if ( await _userManager.IsInRoleAsync(user,"Admin"))
            {
                appointmentCreateViewModel.Appointments = appointmentLogic.ReadAll();
                appointmentCreateViewModel.MyCars = carLogic.ReadAll();
                appointmentCreateViewModel.MyAppointments = appointmentLogic.ReadAll();

            }
            else
            {
                appointmentCreateViewModel.Appointments = appointmentLogic.ReadAll();
                appointmentCreateViewModel.MyCars = user.Cars;
                appointmentCreateViewModel.MyAppointments = appointmentLogic.ReadAll().Where(t => t.MyCar.OwnerID == user.Id);

            }

            return View(appointmentCreateViewModel);
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Creator(Appointment appointment)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user is null)
            {
				return RedirectToAction(nameof(Index));
			}

            appointment.ID = Guid.NewGuid().ToString();
			ModelState.MaxAllowedErrors = 2;

			if (ModelState.ErrorCount > ModelState.MaxAllowedErrors)
            {
                return RedirectToAction(nameof(Index));
            }

            appointmentLogic.Create(appointment);

            await emailSender.SendEmailAsync(user.Email,"FiatVida Időpontfoglalás", "Rögzítettük foglalását a következő időpontra: " + appointment.Date.ToShortDateString());
            var email = emailSender;
            ;
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Delete(string id)
        {
            ;
            var user = await _userManager.GetUserAsync(User);
            ;
            if (user is null)
            {
                return RedirectToAction(nameof(Index));
            }

            appointmentLogic.Delete(id);

            return RedirectToAction(nameof(Index));
        }
		public async Task<IActionResult> Reminder()
		{
            ;
            foreach (var user in _userManager.Users)
            {
                ;
				if (appointmentLogic.ReadAll().Where(t => t.MyCar.OwnerID == user.Id).Count()!=0)
				{
                    ;
					await emailSender.SendEmailAsync(user.Email, "FiatVida Időpontfoglalás Emlékeztető", "Önnek foglalása van hozzánk, kérjük ne felejtsen el jönni!");
				}
			}

			return Ok();

		}
	}
}
