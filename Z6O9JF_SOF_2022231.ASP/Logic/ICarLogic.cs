using Z6O9JF_SOF_2022231.ASP.Models;

namespace Z6O9JF_SOF_2022231.ASP.Logic
{
    public interface ICarLogic
    {
        void Create(Car entity);
        void Delete(string id);
        IEnumerable<Car> ReadAll();
        Car Read(string id);
        void Update(Car entity);
    }
}