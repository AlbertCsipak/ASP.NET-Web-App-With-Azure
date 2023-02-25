using Z6O9JF_SOF_2022231.ASP.Models;

namespace Z6O9JF_SOF_2022231.ASP.Repository
{
    public interface ICarRepository
    {
        void Create(Car car);
        void Delete(string cn);
        IEnumerable<Car> Read();
        Car? Read(string cn);
        void Update(Car car);
    }
}