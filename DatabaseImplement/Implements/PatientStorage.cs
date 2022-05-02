using Contracts.BindingModels;
using Contracts.StoragesContracts;
using Contracts.ViewModels;
using DatabaseImplement.Models;

namespace DatabaseImplement.Implements
{
    
    public class PatientStorage : IPatientStorage
    {
        public List<PatientViewModel> GetFullList()
        {
            using var context = new Database();
            return context.Patients
                .Select(CreateModel)
                .ToList();
        }
        public List<PatientViewModel> GetFilteredList(PatientBindingModel model)
        {
            if (model == null) return null;
            using var context = new Database();
            return context.Patients
                .Where(rec => rec.PatientName.Contains(model.PatientName))
                .Select(CreateModel)
                .ToList();
        }
        public PatientViewModel GetElement(PatientBindingModel model)
        {
            if (model == null) return null;
            var context = new Database();
            var patient = context.Patients.FirstOrDefault(rec => rec.Id == model.Id);
            return patient != null ? CreateModel(patient) : null;
        }
        public void Insert(PatientBindingModel model)
        {
            using var context = new Database();
            context.Patients.Add(CreateModel(model, new Patient()));
            context.SaveChanges();
        }
        public void Update(PatientBindingModel model)
        {
            using var context = new Database();
            var element = context.Patients.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null) throw new Exception("Пациент не найден");
            CreateModel(model, element);
            context.SaveChanges();
        }
        public void Delete(PatientBindingModel model)
        {
            using var context = new Database();
            var element = context.Patients.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.Patients.Remove(element);
                context.SaveChanges();
            }
            else throw new Exception("Пациент не найден");
        }
        private static Patient CreateModel(PatientBindingModel model, Patient patient)
        {
            using var context = new Database();
            patient.DoctorId = context.Doctors
                .Where(rec => rec.CityArea == model.CityArea).ToArray()[new Random().Next(0, context.Doctors.Where(rec => rec.CityArea == model.CityArea).ToArray().Length)].Id;
            patient.PatientName = model.PatientName;
            patient.PhoneNumber = model.PhoneNumber;
            patient.Address = model.Address;
            patient.CityArea = model.CityArea;
            return patient;
        }
        private static PatientViewModel CreateModel(Patient patient)
        {
            return new PatientViewModel
            {
                Id = patient.Id,
                DoctorId = patient.DoctorId,
                PatientName = patient.PatientName,
                PhoneNumber = patient.PhoneNumber,
                Address = patient.Address,
                CityArea = patient.CityArea
            };
        }
    }
}
