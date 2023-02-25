using Z6O9JF_SOF_2022231.ASP.Models;

namespace Z6O9JF_SOF_2022231.ASP.Repository
{
    public interface IAppointmentRepository
    {
        void Create(Appointment appointment);
        void Delete(string id);
        IEnumerable<Appointment> Read();
        Appointment? Read(string id);
        void Update(Appointment appointment);
    }
}