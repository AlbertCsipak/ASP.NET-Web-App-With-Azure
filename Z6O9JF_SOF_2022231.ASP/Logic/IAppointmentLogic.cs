using Z6O9JF_SOF_2022231.ASP.Models;

namespace Z6O9JF_SOF_2022231.ASP.Logic
{
    public interface IAppointmentLogic
    {
        void Create(Appointment entity);
        void Delete(string id);
        IEnumerable<Appointment> ReadAll();
        Appointment Read(string id);
        void Update(Appointment entity);
    }
}