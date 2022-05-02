namespace Contracts.BindingModels
{
    public class DoctorBindingModel
    {
        public int? Id { get; set; }
        public string DoctorName { get; set; }
        public long PhoneNumber { get; set; }
        public string Address { get; set; }
        public string CityArea { get; set; }
    }
}
