using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseImplement.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        [Required] public string DoctorName { get; set; }
        [Required] public long PhoneNumber { get; set; }
        [Required] public string Address { get; set; }
        [Required] public string CityArea { get; set; }
        [ForeignKey("DoctorId")] public virtual List<Patient> Patients { get; set; }
    }
}
