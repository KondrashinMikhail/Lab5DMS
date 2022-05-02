using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseImplement.Models
{
    public class Cure
    {
        public int Id { get; set; }
        [Required] public string CureName { get; set; }
        [Required] public string DiseaseName { get; set; }
        [ForeignKey("CureId")] public virtual List<DiseaseStory> DiseaseStories { get; set; }
    }
}
