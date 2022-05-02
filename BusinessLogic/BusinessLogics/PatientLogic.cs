using Contracts.BindingModels;
using Contracts.BusinessLogicsContracts;
using Contracts.StoragesContracts;
using Contracts.ViewModels;

namespace BusinessLogic.BusinessLogics
{
    public class PatientLogic : IPatientLogic
    {
        private readonly IPatientStorage _storage;
        public PatientLogic(IPatientStorage storage) => _storage = storage;
        public List<PatientViewModel> Read(PatientBindingModel model)
        {
            if (model == null) return _storage.GetFullList();
            if (model.Id.HasValue) return new List<PatientViewModel> { _storage.GetElement(model) };
            return _storage.GetFilteredList(model);
        }
        public void CreateOrUpdate(PatientBindingModel model)
        {
            var element = _storage.GetElement(new PatientBindingModel { PhoneNumber = model.PhoneNumber });
            if (element != null && element.Id != model.Id) throw new Exception("Уже есть пациент с таким номером");
            if (model.Id.HasValue) _storage.Update(model);
            else _storage.Insert(model);
        }
        public void Delete(PatientBindingModel model)
        {
            var element = _storage.GetElement(new PatientBindingModel { Id = model.Id });
            if (element == null) throw new Exception("Пациент не найден");
            _storage.Delete(model);
        }
    }
}
