using Z6O9JF_SOF_2022231.ASP.Data;
using Z6O9JF_SOF_2022231.ASP.Models;

namespace Z6O9JF_SOF_2022231.ASP.Repository
{
    public class CarRepository : ICarRepository
    {
        ApplicationDbContext context;

        public CarRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Create(Car car)
        {
            context.Cars.Add(car);
            context.SaveChanges();
        }

        public IEnumerable<Car> Read()
        {
            return context.Cars;
        }

        public Car? Read(string cn)
        {
            return context.Cars.FirstOrDefault(t => t.CN == cn);
        }

        public void Delete(string cn)
        {
            var car = Read(cn);
            context.Cars.Remove(car);
            context.SaveChanges();
        }

        public void Update(Car car)
        {
            var old = Read(car.CN);
            old.Brand = car.Brand;
            old.FuelType = car.FuelType;
            old.Type = car.Type;
            old.LE = car.LE;
            old.YoM = car.YoM;
            context.SaveChanges();
        }


    }
}
