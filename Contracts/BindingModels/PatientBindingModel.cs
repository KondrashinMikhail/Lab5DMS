namespace Contracts.BindingModels
{
    public class PatientBindingModel
    {
        public int? Id { get; set; }
        public int DoctorId { get; set; }
        public string PatientName { get; set; }
        public long PhoneNumber { get; set; }
        public string Address { get; set; }
        public string CityArea { get; set; }
    }
}
