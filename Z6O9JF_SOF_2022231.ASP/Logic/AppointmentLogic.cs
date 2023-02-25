using Z6O9JF_SOF_2022231.ASP.Models;
using Z6O9JF_SOF_2022231.ASP.Repository;

namespace Z6O9JF_SOF_2022231.ASP.Logic
{
    public class AppointmentLogic : IAppointmentLogic
    {
        IAppointmentRepository myRepository;
        public AppointmentLogic(IAppointmentRepository entity)
        {
            this.myRepository = entity;
        }
        public IEnumerable<Appointment> ReadAll()
        {
            return myRepository.Read();
        }
        public void Create(Appointment entity)
        {
            myRepository.Create(entity);
        }
        public Appointment Read(string id)
        {
            return myRepository.Read(id);
        }
        public void Update(Appointment entity)
        {
            myRepository.Update(entity);
        }
        public void Delete(string id)
        {
            myRepository.Delete(id);
        }
    }
}
