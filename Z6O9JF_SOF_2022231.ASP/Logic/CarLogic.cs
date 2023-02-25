using System.ComponentModel;
using System.Reflection;
using Z6O9JF_SOF_2022231.ASP.Models;
using Z6O9JF_SOF_2022231.ASP.Repository;

namespace Z6O9JF_SOF_2022231.ASP.Logic
{
    public class CarLogic : ICarLogic
    {
        ICarRepository myRepository;
        public CarLogic(ICarRepository entity)
        {
            this.myRepository = entity;
        }
        public IEnumerable<Car> ReadAll()
        {
            return myRepository.Read();
        }
        public void Create(Car entity)
        {
            ;
            if (entity.CN == null)
            {
                throw new ArgumentException("Az alvázszám nem megfelelő.");
            }
            if(entity.Type == null)
            {
                throw new ArgumentException("A típus nem megfelelő.");
            }
            if (entity.LE <= 0)
            {
                throw new ArgumentException("A lóerő nem megfelelő.");
            }
            if (entity.YoM<=0 || entity.YoM > DateTime.Now.Year)
            {
                throw new ArgumentException("A gyártási idő nem megfelelő.");
            }

            var carSame = myRepository.Read().FirstOrDefault(t=>t.CN == entity.CN);
            if (carSame != null)
            {
                throw new ArgumentException("Ez az alvázszám már létezik.");
            }

            myRepository.Create(entity);
        }
        public Car Read(string id)
        {
            return myRepository.Read(id);
        }
        public void Update(Car entity)
        {
            myRepository.Update(entity);
        }
        public void Delete(string id)
        {
            myRepository.Delete(id);
        }
    }
}
