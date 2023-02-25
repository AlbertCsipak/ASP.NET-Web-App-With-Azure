using Z6O9JF_SOF_2022231.ASP.Data;
using Z6O9JF_SOF_2022231.ASP.Models;

namespace Z6O9JF_SOF_2022231.ASP.Repository
{
    public class AppointmentRepository : IAppointmentRepository
    {
        ApplicationDbContext context;

        public AppointmentRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Create(Appointment appointment)
        {
            context.Appointments.Add(appointment);
            ;
            context.SaveChanges();
            ;
        }

        public IEnumerable<Appointment> Read()
        {
            return context.Appointments;
        }

        public Appointment? Read(string id)
        {
            return context.Appointments.FirstOrDefault(t => t.ID == id);
        }

        public void Delete(string id)
        {
            var appointment = Read(id);
            context.Appointments.Remove(appointment);
            context.SaveChanges();
        }

        public void Update(Appointment appointment)
        {
            var old = Read(appointment.ID);
            old.CarID = appointment.CarID;
            old.MyCar = appointment.MyCar;
            old.Date = appointment.Date;
            old.ServiceType = appointment.ServiceType;

            context.SaveChanges();
        }
    }
}
