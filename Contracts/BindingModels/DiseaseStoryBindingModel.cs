namespace Contracts.BindingModels
{
    public class DiseaseStoryBindingModel
    {
        public int? Id { get; set; }
        public string DiseaseName { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public int CureId { get; set; }
        public DateTime DateOfApplication { get; set; }
        public DateTime? DateOfRecovery { get; set; }
    }
}
