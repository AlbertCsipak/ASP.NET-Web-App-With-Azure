using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Z6O9JF_SOF_2022231.ASP.Models
{

    public enum FT
    {
        Diesel, Gasoline, Electric
    }
    public enum Brand
    {
        Seat, Opel, VolksWagen, Mercedes, BMW, Audi
    }
    public class Car
    {
        [DisplayName("Alvázszám*")]
        [Key]
        [Required]
        public string CN { get; set; } //chassis number
        [DisplayName("Márka*")]
        [Required]
        public Brand Brand { get; set; }
        [DisplayName("Típus*")]
        [Required]
        public string Type { get; set; }
        [DisplayName("Lóerő")]
        public int LE { get; set; }
        [DisplayName("Üzemanyag típus")]
        public FT FuelType { get; set; }
        [DisplayName("Gyártási év")]
        public int YoM { get; set; } //Year of manufacture

        [NotMapped]
        public virtual SiteUser Owner { get; set; }

        [ForeignKey(nameof(SiteUser))]
        public virtual string OwnerID { get; set; }
        [NotMapped]
        public virtual IEnumerable<Appointment> Appointments { get; set; }

        public override string ToString()
        {
            return CN;
        }

        public Car()
        {
            Appointments = new HashSet<Appointment>();
        }
    }
}
