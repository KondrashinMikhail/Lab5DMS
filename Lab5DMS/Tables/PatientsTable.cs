using Contracts.BusinessLogicsContracts;
using Contracts.StoragesContracts;
using Unity;
using System.Diagnostics;
using Contracts.BindingModels;

namespace Main.Tables
{
    public class PatientsTable
    {
        private readonly IPatientLogic _patientLogic;
        private readonly IPatientStorage _patientStorage;
        private readonly CmdHelper _cmdHelper;
        public PatientsTable(IPatientLogic logic, IPatientStorage storage)
        {
            _patientLogic = logic;
            _patientStorage = storage;
            _cmdHelper = Program.Container.Resolve<CmdHelper>();
        }
        public void Patients(string action) 
        {
            Stopwatch stopWatch = Stopwatch.StartNew();
            if (action.Equals(Program.Container.Resolve<CmdHelper>().actions[0]))
            {
                Console.WriteLine("ID || PatientName || DoctorId || PhoneNumber || Address || CityArea");
                stopWatch.Restart();
                foreach (var item in _patientLogic.Read(null))
                    Console.WriteLine("{0} || {1} || {2} || {3} || {4} || {5}",
                        item.Id.ToString(), item.PatientName, item.DoctorId, item.PhoneNumber, item.Address, item.CityArea);
            }
            else if (action.Equals(_cmdHelper.actions[1]))
            {
                Console.Write("Enter 'PatientName': ");
                var patientNameCreate = Console.ReadLine();
                Console.Write("Enter 'PhoneNumber': ");
                var phoneNumberCreate = Console.ReadLine();
                Console.Write("Enter 'Address': ");
                var addressCreate = Console.ReadLine();
                Console.Write("Enter 'CityArea': ");
                var cityAreaCreate = Console.ReadLine();
                stopWatch.Restart();
                _patientLogic.CreateOrUpdate(new PatientBindingModel
                {
                    PatientName = patientNameCreate,
                    PhoneNumber = Convert.ToInt64(phoneNumberCreate),
                    Address = addressCreate,
                    CityArea = cityAreaCreate
                });
            }
            else if (action.Equals(_cmdHelper.actions[2]))
            {
                Console.Write("Enter 'Id':");
                var IdUpdate = Console.ReadLine();
                Console.Write("Enter new 'PatientName' (previous: {0}): ",
                    _patientStorage.GetElement(new PatientBindingModel { Id = Convert.ToInt32(IdUpdate) }).PatientName);
                var patientNameUpdate = Console.ReadLine();
                Console.Write("Enter 'PhoneNumber' (previous: {0}): ",
                    _patientStorage.GetElement(new PatientBindingModel { Id = Convert.ToInt32(IdUpdate) }).PhoneNumber);
                var phoneNumberUpdate = Console.ReadLine();
                Console.Write("Enter 'Address' (previous: {0}): ",
                    _patientStorage.GetElement(new PatientBindingModel { Id = Convert.ToInt32(IdUpdate) }).Address);
                var addressUpdate = Console.ReadLine();
                Console.Write("Enter 'CityArea' (previous:{0}): ",
                    _patientStorage.GetElement(new PatientBindingModel { Id = Convert.ToInt32(IdUpdate) }).CityArea);
                var cityAreaUpdate = Console.ReadLine();
                stopWatch.Restart();
                _patientLogic.CreateOrUpdate(new PatientBindingModel
                {
                    Id = Convert.ToInt32(IdUpdate),
                    PatientName = patientNameUpdate,
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
                _patientLogic.Delete(new PatientBindingModel { Id = Convert.ToInt32(IdDelete) });
            }      
            stopWatch.Stop();
            _cmdHelper.Success(action, _cmdHelper.entities[1], stopWatch);
        }
    }
}
