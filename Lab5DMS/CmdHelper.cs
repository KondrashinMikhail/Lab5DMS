using Contracts.BindingModels;
using Contracts.BusinessLogicsContracts;
using Contracts.StoragesContracts;
using DatabaseImplement.Models;

namespace Main
{
    public class CmdHelper
    {
        private readonly IPatientLogic _patientLogic;
        private readonly IDoctorLogic _doctorLogic;
        private readonly ICureLogic _cureLogic;
        private readonly IDiseaseStoryLogic _diseaseStoryLogic;

        private readonly IPatientStorage _patientStorage;
        private readonly IDoctorStorage _doctorStorage;
        private readonly ICureStorage _cureStorage;
        private readonly IDiseaseStoryStorage _diseaseStoryStorage;

        private List<string> entities = new List<string> { "cure", "patient", "doctor", "disease story" };
        private List<string> actions = new List<string> { "read", "create", "update", "delete" };

        public CmdHelper(IPatientLogic patientLogic, IDoctorLogic doctorLogic, ICureLogic cureLogic, IDiseaseStoryLogic diseaseStoryLogic,
            IPatientStorage patientStorage, IDoctorStorage doctorStorage, ICureStorage cureStorage, IDiseaseStoryStorage diseaseStoryStorage) 
        {
            _patientLogic = patientLogic;
            _doctorLogic = doctorLogic;
            _cureLogic = cureLogic;
            _diseaseStoryLogic = diseaseStoryLogic;

            _diseaseStoryStorage = diseaseStoryStorage;
            _patientStorage = patientStorage;
            _cureStorage = cureStorage;
            _doctorStorage = doctorStorage;
        }
        public void Start() 
        {
            string answer = "";
            while (answer != "n")
            {
                Console.WriteLine("Enter table name " +
                    "(" + entities[0] + ", " + entities[1] + ", " + entities[2] + ", " + entities[3] + "): ");
                string entity = Console.ReadLine();
                while (!entities.Contains(entity))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: Wrong table name, type again:");
                    Console.ResetColor();
                    entity = Console.ReadLine();
                }

                Console.WriteLine("Choose action " +
                    "(" + actions[0] + ", " + actions[1] + ", " + actions[2] + ", " + actions[3] + "): ");
                string action = Console.ReadLine();
                while (!actions.Contains(action))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: Wrong action, type again:");
                    Console.ResetColor();
                    action = Console.ReadLine();
                }
                
                switch (entity)
                {
                    case "cure":
                        CuresTable(action);
                        break;
                    case "doctor":
                        DoctorsTable(action);
                        break;
                    case "patient":
                        PatientsTable(action);
                        break;
                    case "disease story":
                        DiseasesStoryTable(action);
                        break;
                }
                Console.WriteLine();
                Console.ForegroundColor= ConsoleColor.Yellow;
                Console.Write("If you want to end type 'n', else don`t type anything: ");
                answer = Console.ReadLine();
                Console.WriteLine();
                Console.ResetColor();
            }
            Environment.Exit(0);
        }
        public void CuresTable(string action) 
        {
            switch (action) 
            {
                case "read":
                    Console.WriteLine("(ID || CureName || DiseaseName)");
                    foreach (var item in _cureLogic.Read(null))
                        Console.WriteLine(item.Id.ToString() + " || " + item.CureName + " || " + item.DiseaseName);
                    break;
                case "create":
                    Console.WriteLine("Enter 'CureName':");
                    var cureNameCreate = Console.ReadLine();
                    Console.WriteLine("Enter 'DiseaseName':");
                    var diseaseNameCreate = Console.ReadLine();
                    _cureLogic.CreateOrUpdate(new CureBindingModel 
                    {
                        CureName = cureNameCreate,
                        DiseaseName = diseaseNameCreate
                    });
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Successfuly created!");
                    Console.ResetColor();
                    break;
                case "update":
                    Console.WriteLine("Enter 'ID':");
                    var IdUpdate = Console.ReadLine();
                    Console.WriteLine("Enter new 'CureName' (previous: " + _cureStorage.GetElement(new CureBindingModel { Id = Convert.ToInt32(IdUpdate) }).CureName + "):");
                    var cureNameUpdate = Console.ReadLine();
                    Console.WriteLine("Enter new 'DiseaseName' (previous: " + _cureStorage.GetElement(new CureBindingModel { Id = Convert.ToInt32(IdUpdate) }).DiseaseName + "):");
                    var diseaseNameUpdate = Console.ReadLine();
                    _cureLogic.CreateOrUpdate(new CureBindingModel
                    {
                        Id = Convert.ToInt32(IdUpdate),
                        CureName = cureNameUpdate,
                        DiseaseName = diseaseNameUpdate
                    });
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Successfuly updated!");
                    Console.ResetColor();
                    break;
                case "delete":
                    Console.WriteLine("Enter 'ID':");
                    var IdDelete = Console.ReadLine();
                    _cureLogic.Delete(new CureBindingModel { Id = Convert.ToInt32(IdDelete) });
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Successfuly deleted!");
                    Console.ResetColor();
                    break;
            }
        }
        public void DoctorsTable(string action) 
        {
            switch (action)
            {
                case "read":
                    Console.WriteLine("ID || DoctorName || PhoneNumber || Address || CityArea");
                    foreach (var item in _doctorLogic.Read(null))
                        Console.WriteLine(item.Id.ToString() + " || " + item.DoctorName + " || " + item.PhoneNumber + " || " + item.Address + " || " + item.CityArea);
                    break;
                case "create":
                    Console.WriteLine("Enter 'DoctorName':");
                    var doctorNameCreate = Console.ReadLine();
                    Console.WriteLine("Enter 'PhoneNumber':");
                    var phoneNumberCreate = Console.ReadLine();
                    Console.WriteLine("Enter 'Address':");
                    var addressCreate = Console.ReadLine();
                    Console.WriteLine("Enter 'CityArea':");
                    var cityAreaCreate = Console.ReadLine();
                    _doctorLogic.CreateOrUpdate(new DoctorBindingModel
                    {
                       DoctorName = doctorNameCreate,
                       PhoneNumber = Convert.ToInt64(phoneNumberCreate),
                       Address = addressCreate,
                       CityArea = cityAreaCreate
                    });
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Successfuly created!");
                    Console.ResetColor();
                    break;
                case "update":
                    Console.WriteLine("Enter 'Id':");
                    var IdUpdate = Console.ReadLine();
                    Console.WriteLine("Enter new 'DoctorName' (previous: " + _doctorStorage.GetElement(new DoctorBindingModel { Id = Convert.ToInt32(IdUpdate) }).DoctorName + "):");
                    var doctorNameUpdate = Console.ReadLine();
                    Console.WriteLine("Enter new 'PhoneNumber' (previous: " + _doctorStorage.GetElement(new DoctorBindingModel { Id = Convert.ToInt32(IdUpdate) }).PhoneNumber + "):");
                    var phoneNumberUpdate = Console.ReadLine();
                    Console.WriteLine("Enter new 'Address' (previous: " + _doctorStorage.GetElement(new DoctorBindingModel { Id = Convert.ToInt32(IdUpdate) }).Address + "):");
                    var addressUpdate = Console.ReadLine();
                    Console.WriteLine("Enter new 'CityArea' (previous: " + _doctorStorage.GetElement(new DoctorBindingModel { Id = Convert.ToInt32(IdUpdate) }).CityArea + "):");
                    var cityAreaUpdate = Console.ReadLine();
                    _doctorLogic.CreateOrUpdate(new DoctorBindingModel
                    {
                        Id = Convert.ToInt32(IdUpdate),
                        DoctorName = doctorNameUpdate,
                        PhoneNumber = Convert.ToInt64(phoneNumberUpdate),
                        Address = addressUpdate,
                        CityArea = cityAreaUpdate
                    });
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Successfuly updated!");
                    Console.ResetColor();
                    break;
                case "delete":
                    Console.WriteLine("Enter 'ID':");
                    var IdDelete = Console.ReadLine();
                    _doctorLogic.Delete(new DoctorBindingModel { Id = Convert.ToInt32(IdDelete) });
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Successfuly deleted!");
                    Console.ResetColor();
                    break;
            }
        }
        public void PatientsTable(string action) 
        {
            switch (action)
            {
                case "read":
                    Console.WriteLine("ID || PatientName || DoctorId || PhoneNumber || Address || CityArea");
                    foreach (var item in _patientLogic.Read(null))
                        Console.WriteLine(item.Id.ToString() + " || " + item.PatientName + " || " + item.DoctorId + " || " + item.PhoneNumber + " || " + item.Address + " || " + item.CityArea);
                    break;
                case "create":
                    Console.WriteLine("Enter 'PatientName':");
                    var patientNameCreate = Console.ReadLine();
                    Console.WriteLine("Enter 'PhoneNumber':");
                    var phoneNumberCreate = Console.ReadLine();
                    Console.WriteLine("Enter 'Address':");
                    var addressCreate = Console.ReadLine();
                    Console.WriteLine("Enter 'CityArea':");
                    var cityAreaCreate = Console.ReadLine();
                    _patientLogic.CreateOrUpdate(new PatientBindingModel
                    {
                        PatientName = patientNameCreate,
                        PhoneNumber = Convert.ToInt64(phoneNumberCreate),
                        Address = addressCreate,
                        CityArea = cityAreaCreate
                    });
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Successfuly created!");
                    Console.ResetColor();
                    break;
                case "update":
                    Console.WriteLine("Enter 'Id':");
                    var IdUpdate = Console.ReadLine();
                    Console.WriteLine("Enter new 'PatientName' (previous: " + _patientStorage.GetElement(new PatientBindingModel { Id = Convert.ToInt32(IdUpdate) }).PatientName + "):");
                    var patientNameUpdate = Console.ReadLine();
                    Console.WriteLine("Enter 'PhoneNumber' (previous: " + _patientStorage.GetElement(new PatientBindingModel { Id = Convert.ToInt32(IdUpdate) }).PhoneNumber + "):");
                    var phoneNumberUpdate = Console.ReadLine();
                    Console.WriteLine("Enter 'Address' (previous: " + _patientStorage.GetElement(new PatientBindingModel { Id = Convert.ToInt32(IdUpdate) }).Address + "):");
                    var addressUpdate = Console.ReadLine();
                    Console.WriteLine("Enter 'CityArea' (previous: " + _patientStorage.GetElement(new PatientBindingModel { Id = Convert.ToInt32(IdUpdate)}).CityArea + "):");
                    var cityAreaUpdate = Console.ReadLine();
                    _patientLogic.CreateOrUpdate(new PatientBindingModel
                    {
                        Id = Convert.ToInt32(IdUpdate),
                        PatientName = patientNameUpdate,
                        PhoneNumber = Convert.ToInt64(phoneNumberUpdate),
                        Address = addressUpdate,
                        CityArea = cityAreaUpdate
                    });
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Successfuly updated!");
                    Console.ResetColor();
                    break;
                case "delete":
                    Console.WriteLine("Enter 'ID':");
                    var IdDelete = Console.ReadLine();
                    _patientLogic.Delete(new PatientBindingModel { Id = Convert.ToInt32(IdDelete) });
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Successfuly deleted!");
                    Console.ResetColor();
                    break;
            }
        }
        public void DiseasesStoryTable(string action) 
        {
            switch (action)
            {
                case "read":
                    Console.WriteLine("(ID || PatientId || DoctorId || CureId || DiseaseName || DateOfApplication || DateOfRecovery");
                    foreach (var item in _diseaseStoryLogic.Read(null))
                        Console.WriteLine(item.Id.ToString() + " || " + item.PatientId + " || " + item.DoctorId + " || " + item.CureId + " || " + item.DiseaseName + " || " + item.DateOfApplication + " || " + item.DateOfRecovery);
                    break;
                case "create":
                    Console.WriteLine("Enter 'PatientId':");
                    var patientIdCreate = Console.ReadLine();
                    Console.WriteLine("Enter 'DiseaseName':");
                    var diseaseNameCreate = Console.ReadLine();
                    Console.WriteLine("Enter 'DateOfApplication':");
                    var dateOfApplicationCreate = Console.ReadLine();
                    Console.WriteLine("Enter 'DateOfRecovery', if there is:");
                    var dateOfRecoveryCreate = Console.ReadLine();
                    _diseaseStoryLogic.CreateOrUpdate(new DiseaseStoryBindingModel 
                    {
                        PatientId = Convert.ToInt32(patientIdCreate),
                        DiseaseName = diseaseNameCreate,
                        DateOfApplication = DateTime.Parse(dateOfApplicationCreate),
                    });
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Successfuly created!");
                    Console.ResetColor();
                    break;
                case "update":
                    Console.WriteLine("Enter 'Id':");
                    var IdUpdate = Console.ReadLine();
                    Console.WriteLine("Enter new 'PatientId' (previous: " + _diseaseStoryStorage.GetElement(new DiseaseStoryBindingModel { Id = Convert.ToInt32(IdUpdate) }).PatientId + "):");
                    var patientIdUpdate = Console.ReadLine();
                    Console.WriteLine("Enter new 'DiseaseName' (previous: " + _diseaseStoryStorage.GetElement(new DiseaseStoryBindingModel { Id = Convert.ToInt32(IdUpdate) }).DiseaseName + "):");
                    var diseaseNameUpdate = Console.ReadLine();
                    Console.WriteLine("Enter new 'DateOfApplication' (previous: " + _diseaseStoryStorage.GetElement(new DiseaseStoryBindingModel { Id = Convert.ToInt32(IdUpdate) }).DateOfApplication + "):");
                    var dateOfApplicationUpdate = Console.ReadLine();
                    Console.WriteLine("Enter new 'DateOfRecovery', if there is (previous: " + _diseaseStoryStorage.GetElement(new DiseaseStoryBindingModel { Id = Convert.ToInt32(IdUpdate) }).DateOfRecovery + "):");
                    var dateOfRecoveryUpdate = Console.ReadLine();
                    _diseaseStoryLogic.CreateOrUpdate(new DiseaseStoryBindingModel
                    {
                        Id = Convert.ToInt32(IdUpdate),
                        PatientId = Convert.ToInt32(patientIdUpdate),
                        DiseaseName = diseaseNameUpdate,
                        DateOfApplication = Convert.ToDateTime(dateOfApplicationUpdate),
                        DateOfRecovery = Convert.ToDateTime(dateOfRecoveryUpdate)
                    });
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Successfuly updated!");
                    Console.ResetColor();
                    break;
                case "delete":
                    Console.WriteLine("Enter 'ID':");
                    var IdDelete = Console.ReadLine();
                    _diseaseStoryLogic.Delete(new DiseaseStoryBindingModel { Id = Convert.ToInt32(IdDelete) });
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Successfuly deleted!");
                    Console.ResetColor();
                    break;
            }
        }
    }
}