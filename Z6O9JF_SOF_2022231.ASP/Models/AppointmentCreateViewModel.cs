namespace Z6O9JF_SOF_2022231.ASP.Models
{
    public class AppointmentCreateViewModel
    {
        public IEnumerable<Appointment> MyAppointments { get; set; }
        public IEnumerable<Appointment> Appointments { get; set; }
        public IEnumerable<Car> MyCars { get; set; }
        public AppointmentCreateViewModel()
        {
            MyAppointments = new HashSet<Appointment>();
            Appointments = new HashSet<Appointment>();
            MyCars = new HashSet<Car>();
        }
    }
}
