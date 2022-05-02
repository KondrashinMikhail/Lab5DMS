using Contracts.BindingModels;
using Contracts.StoragesContracts;
using Contracts.ViewModels;
using DatabaseImplement.Models;

namespace DatabaseImplement.Implements
{
    public class DiseaseStoryStorage : IDiseaseStoryStorage
    {
        public List<DiseaseStoryViewModel> GetFullList()
        {
            using var context = new Database();
            return context.DiseaseStories
                .Select(CreateModel)
                .ToList();
        }
        public List<DiseaseStoryViewModel> GetFilteredList(DiseaseStoryBindingModel model)
        {
            if (model == null) return null;
            using var context = new Database();
            return context.DiseaseStories
                .Where(rec => rec.DiseaseName.Contains(model.DiseaseName))
                .Select(CreateModel)
                .ToList();
        }
        public DiseaseStoryViewModel GetElement(DiseaseStoryBindingModel model)
        {
            if (model == null) return null;
            var context = new Database();
            var doctor = context.DiseaseStories.FirstOrDefault(rec => rec.Id == model.Id);
            return doctor != null ? CreateModel(doctor) : null;
        }
        public void Insert(DiseaseStoryBindingModel model)
        {
            using var context = new Database();
            context.DiseaseStories.Add(CreateModel(model, new DiseaseStory()));
            context.SaveChanges();
        }
        public void Update(DiseaseStoryBindingModel model)
        {
            using var context = new Database();
            var element = context.DiseaseStories.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null) throw new Exception("История болезни не найдена");
            CreateModel(model, element);
            context.SaveChanges();
        }
        public void Delete(DiseaseStoryBindingModel model)
        {
            using var context = new Database();
            var element = context.DiseaseStories.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.DiseaseStories.Remove(element);
                context.SaveChanges();
            }
            else throw new Exception("История болезни не найдена");
        }
        private static DiseaseStory CreateModel(DiseaseStoryBindingModel model, DiseaseStory diseaseStory)
        {
            using var context = new Database();
            diseaseStory.DiseaseName = model.DiseaseName;
            diseaseStory.PatientId = model.PatientId;
            diseaseStory.DoctorId = context.Patients.FirstOrDefault(rec => rec.Id == model.PatientId).DoctorId;
            diseaseStory.CureId = context.Cures.FirstOrDefault(rec => rec.DiseaseName == model.DiseaseName).Id;
            diseaseStory.DateOfApplication = model.DateOfApplication;
            diseaseStory.DateOfRecovery = model.DateOfRecovery;
            return diseaseStory;
        }
        private static DiseaseStoryViewModel CreateModel(DiseaseStory diseaseStory)
        {
            return new DiseaseStoryViewModel
            {
                Id = diseaseStory.Id,
                DiseaseName = diseaseStory.DiseaseName,
                DoctorId = diseaseStory.DoctorId,
                PatientId = diseaseStory.PatientId,
                CureId = diseaseStory.CureId,
                DateOfApplication = diseaseStory.DateOfApplication,
                DateOfRecovery = diseaseStory.DateOfRecovery
            };
        }
    }
}
