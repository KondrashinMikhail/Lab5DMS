using Contracts.BindingModels;
using Contracts.StoragesContracts;
using Contracts.ViewModels;
using DatabaseImplement.Models;

namespace DatabaseImplement.Implements
{
    public class DoctorStorage : IDoctorStorage
    {
        public List<DoctorViewModel> GetFullList()
        {
            using var context = new Database();
            return context.Doctors
                .Select(CreateModel)
                .ToList();
        }
        public List<DoctorViewModel> GetFilteredList(DoctorBindingModel model)
        {
            if (model == null) return null;
            using var context = new Database();
            return context.Doctors
                .Where(rec => rec.DoctorName.Contains(model.DoctorName))
                .Select(CreateModel)
                .ToList();
        }
        public DoctorViewModel GetElement(DoctorBindingModel model)
        {
            if (model == null) return null;
            var context = new Database();
            var doctor = context.Doctors.FirstOrDefault(rec => rec.Id == model.Id);
            return doctor != null ? CreateModel(doctor) : null;
        }
        public void Insert(DoctorBindingModel model)
        {
            using var context = new Database();
            context.Doctors.Add(CreateModel(model, new Doctor()));
            context.SaveChanges();
        }
        public void Update(DoctorBindingModel model)
        {
            using var context = new Database();
            var element = context.Doctors.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null) throw new Exception("Доктор не найден");
            CreateModel(model, element);
            context.SaveChanges();
        }
        public void Delete(DoctorBindingModel model)
        {
            using var context = new Database();
            var element = context.Doctors.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.Doctors.Remove(element);
                context.SaveChanges();
            }
            else throw new Exception("Доктор не найден");
        }
        private static Doctor CreateModel(DoctorBindingModel model, Doctor doctor)
        {
            using var context = new Database();
            doctor.DoctorName = model.DoctorName;
            doctor.PhoneNumber = model.PhoneNumber;
            doctor.Address = model.Address;
            doctor.CityArea = model.CityArea;
            return doctor;
        }
        private static DoctorViewModel CreateModel(Doctor doctor)
        {
            return new DoctorViewModel
            {
                Id = doctor.Id,
                DoctorName = doctor.DoctorName,
                PhoneNumber = doctor.PhoneNumber,
                Address = doctor.Address,
                CityArea = doctor.CityArea
            };
        }
    }
}
