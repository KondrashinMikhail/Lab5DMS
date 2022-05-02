using Contracts.BindingModels;
using Contracts.StoragesContracts;
using Contracts.ViewModels;
using DatabaseImplement.Models;

namespace DatabaseImplement.Implements
{
    public class CureStorage : ICureStorage
    {
        public List<CureViewModel> GetFullList()
        {
            using var context = new Database();
            return context.Cures
                .Select(CreateModel)
                .ToList();
        }
        public List<CureViewModel> GetFilteredList(CureBindingModel model)
        {
            if (model == null) return null;
            using var context = new Database();
            return context.Cures
                .Where(rec => rec.CureName.Contains(model.CureName))
                .Select(CreateModel)
                .ToList();
        }
        public CureViewModel GetElement(CureBindingModel model)
        {
            if (model == null) return null;
            var context = new Database();
            var patient = context.Cures.FirstOrDefault(rec => rec.Id == model.Id);
            return patient != null ? CreateModel(patient) : null;
        }
        public void Insert(CureBindingModel model)
        {
            using var context = new Database();
            context.Cures.Add(CreateModel(model, new Cure()));
            context.SaveChanges();
        }
        public void Update(CureBindingModel model)
        {
            using var context = new Database();
            var element = context.Cures.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null) throw new Exception("Лекарство не найдено");
            CreateModel(model, element);
            context.SaveChanges();
        }
        public void Delete(CureBindingModel model)
        {
            using var context = new Database();
            var element = context.Cures.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.Cures.Remove(element);
                context.SaveChanges();
            }
            else throw new Exception("Лекарство не найдено");
        }
        private static Cure CreateModel(CureBindingModel model, Cure cure)
        {
            cure.CureName = model.CureName;
            cure.DiseaseName = model.DiseaseName;
            return cure;
        }
        private static CureViewModel CreateModel(Cure cure)
        {
            return new CureViewModel
            {
                Id = cure.Id,
                CureName = cure.CureName,
                DiseaseName = cure.DiseaseName
            };
        }
    }
}
