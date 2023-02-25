using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Z6O9JF_SOF_2022231.ASP.Models
{
    public class SiteUser : IdentityUser
    {

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Range(1000, 9999)]
        public int PostalCode { get; set; }


        [NotMapped]
        public virtual ICollection<Car> Cars { get; set; }
        [NotMapped]
        public virtual ICollection<Appointment> Appointments { get; set; }

        public SiteUser()
        {

            Cars = new HashSet<Car>();
            Appointments = new HashSet<Appointment>();

        }
    }
}