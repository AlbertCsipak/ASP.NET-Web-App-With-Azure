using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Z6O9JF_SOF_2022231.ASP.Models
{
    public enum ServiceType
    {
        OilChange, TireChange, LightAdjustment, WheelAlignment
    }
    public enum WorkDays
    {
        Hétfő, Kedd, Szerda, Csütörtök, Péntek
    }
    public class Appointment
    {
        [Key]
        public string ID { get; set; }

        public DateTime Date { get; set; }
        public ServiceType ServiceType { get; set; }

        [NotMapped]
        public virtual Car MyCar { get; set; }

        [ForeignKey(nameof(Car))]
        public virtual string CarID { get; set; }

        public Appointment()
        {
            ID = Guid.NewGuid().ToString();
        }
    }
}
