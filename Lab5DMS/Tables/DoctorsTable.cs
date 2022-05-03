using Contracts.BusinessLogicsContracts;
using Contracts.StoragesContracts;
using Unity;
using System.Diagnostics;
using Contracts.BindingModels;

namespace Main
{
    public class DoctorsTable
    {
        private readonly IDoctorLogic _doctorLogic;
        private readonly IDoctorStorage _doctorStorage;
        private readonly CmdHelper _cmdHelper;
        public DoctorsTable(IDoctorLogic logic, IDoctorStorage storage)
        {
            _doctorLogic = logic;
            _doctorStorage = storage;
            _cmdHelper = Program.Container.Resolve<CmdHelper>();
        }
        public void Doctors(string action)
        {
            Stopwatch stopWatch = Stopwatch.StartNew();
            if (action.Equals(_cmdHelper.actions[0])) {
                Console.WriteLine("ID || DoctorName || PhoneNumber || Address || CityArea");
                stopWatch.Restart();
                foreach (var item in _doctorLogic.Read(null))
                    Console.WriteLine("{0} || {1} || {2} || {3} || {4}",
                        item.Id.ToString(), item.DoctorName, item.PhoneNumber, item.Address, item.CityArea);
            }
            else if (action.Equals(_cmdHelper.actions[1])) {
                Console.Write("Enter 'DoctorName': ");
                var doctorNameCreate = Console.ReadLine();
                Console.Write("Enter 'PhoneNumber': ");
                var phoneNumberCreate = Console.ReadLine();
                Console.Write("Enter 'Address': ");
                var addressCreate = Console.ReadLine();
                Console.Write("Enter 'CityArea': ");
                var cityAreaCreate = Console.ReadLine();
                stopWatch.Restart();
                _doctorLogic.CreateOrUpdate(new DoctorBindingModel
                {
                    DoctorName = doctorNameCreate,
                    PhoneNumber = Convert.ToInt64(phoneNumberCreate),
                    Address = addressCreate,
                    CityArea = cityAreaCreate
                });
            }
            else if (action.Equals(_cmdHelper.actions[2])) {
                Console.Write("Enter 'Id': ");
                var IdUpdate = Console.ReadLine();
                Console.Write("Enter new 'DoctorName' (previous: {0}): ",
                    _doctorStorage.GetElement(new DoctorBindingModel { Id = Convert.ToInt32(IdUpdate) }).DoctorName);
                var doctorNameUpdate = Console.ReadLine();
                Console.Write("Enter new 'PhoneNumber' (previous: {0}): ",
                    _doctorStorage.GetElement(new DoctorBindingModel { Id = Convert.ToInt32(IdUpdate) }).PhoneNumber);
                var phoneNumberUpdate = Console.ReadLine();
                Console.Write("Enter new 'Address' (previous: {0}): ",
                    _doctorStorage.GetElement(new DoctorBindingModel { Id = Convert.ToInt32(IdUpdate) }).Address);
                var addressUpdate = Console.ReadLine();
                Console.Write("Enter new 'CityArea' (previous: {0}): ",
                    _doctorStorage.GetElement(new DoctorBindingModel { Id = Convert.ToInt32(IdUpdate) }).CityArea);
                var cityAreaUpdate = Console.ReadLine();
                stopWatch.Restart();
                _doctorLogic.CreateOrUpdate(new DoctorBindingModel
                {
                    Id = Convert.ToInt32(IdUpdate),
                    DoctorName = doctorNameUpdate,
                    PhoneNumber = Convert.ToInt64(phoneNumberUpdate),
                    Address = addressUpdate,
                    CityArea = cityAreaUpdate
                });
            }
            else if (action.Equals(_cmdHelper.actions[3]))
            {
                Console.Write("Enter 'ID': ");
                var IdDelete = Console.ReadLine();
                stopWatch.Restart();
                _doctorLogic.Delete(new DoctorBindingModel { Id = Convert.ToInt32(IdDelete) });
            }
            stopWatch.Stop();
            _cmdHelper.Success(action, _cmdHelper.entities[2], stopWatch);
        }
    }
}
