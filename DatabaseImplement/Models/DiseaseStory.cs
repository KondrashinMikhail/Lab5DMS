using System.ComponentModel.DataAnnotations;

namespace DatabaseImplement.Models
{
    public class DiseaseStory
    {
        public int Id { get; set; }
        [Required] public string DiseaseName { get; set; }
        [Required] public int DoctorId { get; set; }
        [Required] public int PatientId { get; set; }
        [Required] public int CureId { get; set; }
        [Required] public DateTime DateOfApplication { get; set; }
        public DateTime? DateOfRecovery { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual Cure Cure { get; set; }
    }
}
