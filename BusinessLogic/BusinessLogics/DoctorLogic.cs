using Contracts.BindingModels;
using Contracts.BusinessLogicsContracts;
using Contracts.StoragesContracts;
using Contracts.ViewModels;

namespace BusinessLogic.BusinessLogics
{
    public class DoctorLogic : IDoctorLogic
    {
        private readonly IDoctorStorage _storage;
        public DoctorLogic(IDoctorStorage storage) => _storage = storage;
        public List<DoctorViewModel> Read(DoctorBindingModel model)
        {
            if (model == null) return _storage.GetFullList();
            if (model.Id.HasValue) return new List<DoctorViewModel> { _storage.GetElement(model) };
            return _storage.GetFilteredList(model);
        }
        public void CreateOrUpdate(DoctorBindingModel model)
        {
            var element = _storage.GetElement(new DoctorBindingModel { PhoneNumber = model.PhoneNumber });
            if (element != null && element.Id != model.Id) throw new Exception("Уже есть доктор с таким номером");
            if (model.Id.HasValue) _storage.Update(model);
            else _storage.Insert(model);
        }
        public void Delete(DoctorBindingModel model)
        {
            var element = _storage.GetElement(new DoctorBindingModel { Id = model.Id });
            if (element == null) throw new Exception("Доктор не найден");
            _storage.Delete(model);
        }
    }
}
