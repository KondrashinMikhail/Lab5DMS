using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseImplement.Models
{
    public class Patient
    {
        public int Id { get; set; }
        [Required] public int DoctorId { get; set; }
        [Required] public string PatientName { get; set; }
        [Required] public long PhoneNumber { get; set; }
        [Required] public string Address { get; set; }
        [Required] public string CityArea { get; set; }
        public virtual Doctor Doctor { get; set; }
        [ForeignKey("PatientId")] public virtual List<DiseaseStory> DiseaseStories { get; set; }
    }
}
