using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Z6O9JF_SOF_2022231.ASP.Logic;
using Z6O9JF_SOF_2022231.ASP.Models;

namespace Z6O9JF_SOF_2022231.ASP.Controllers
{
    public class CarController : Controller
    {
        ICarLogic carLogic;
        private readonly UserManager<SiteUser> _userManager;

        public CarController(ICarLogic carLogic, UserManager<SiteUser> userManager)
        {
            this.carLogic = carLogic;
            _userManager = userManager;
        }
        [Authorize]

        [OutputCache(Duration = 1, VaryByParam = "none")]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);

            if (await _userManager.IsInRoleAsync(user, "Admin"))
            {
                return View(carLogic.ReadAll());
            }   
            else
            {
                return View(user.Cars);

            }


        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Creator(Car car)
        {
            var user = await _userManager.GetUserAsync(User);

            if (user is null)
            {
                return RedirectToAction(nameof(Index));
            }

			car.OwnerID = user.Id;
            car.Owner = user;
            
            ModelState.MaxAllowedErrors = 2;
            ;
            if (ModelState.ErrorCount>ModelState.MaxAllowedErrors)
            {
                return RedirectToAction(nameof(Index));
            }

            carLogic.Create(car);

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

            carLogic.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Authorize]
        public IActionResult Update(string id)
        {
            return View(carLogic.Read(id));
        }

        [HttpPost]
        [Authorize]
        public IActionResult Update(Car car)
        {

            carLogic.Update(car);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Error()
        {
            var exceptionHandlerPathFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            var msg = exceptionHandlerPathFeature.Error.Message;
            return View("Error", msg);
        }

    }
}
