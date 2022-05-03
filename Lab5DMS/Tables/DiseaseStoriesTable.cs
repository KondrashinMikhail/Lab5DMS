using Contracts.BusinessLogicsContracts;
using Contracts.StoragesContracts;
using Unity;
using System.Diagnostics;
using Contracts.BindingModels;

namespace Main
{
    public class DiseaseStoriesTable
    {
        private readonly IDiseaseStoryLogic _diseaseStoryLogic;
        private readonly IDiseaseStoryStorage _diseaseStoryStorage;
        private readonly CmdHelper _cmdHelper;
        public DiseaseStoriesTable(IDiseaseStoryLogic logic, IDiseaseStoryStorage storage)
        {
            _diseaseStoryLogic = logic;
            _diseaseStoryStorage = storage;
            _cmdHelper = Program.Container.Resolve<CmdHelper>();
        }
        public void DiseasyStories(string action) 
        {
            Stopwatch stopWatch = Stopwatch.StartNew();
            if (action.Equals(_cmdHelper.actions[0]))
            {

                Console.WriteLine("ID || PatientId || DoctorId || CureId || DiseaseName || DateOfApplication || DateOfRecovery");
                stopWatch.Restart();
                foreach (var item in _diseaseStoryLogic.Read(null))
                    Console.WriteLine("{0} || {1} || {2} || {3} || {4} || {5} || {6}",
                        item.Id.ToString(), item.PatientId, item.DoctorId, item.CureId, item.DiseaseName, item.DateOfApplication, item.DateOfRecovery);
            }
            else if (action.Equals(_cmdHelper.actions[1]))
            {
                Console.Write("Enter 'PatientId': ");
                var patientIdCreate = Console.ReadLine();
                Console.Write("Enter 'DiseaseName': ");
                var diseaseNameCreate = Console.ReadLine();
                Console.Write("Enter 'DateOfApplication': ");
                var dateOfApplicationCreate = Console.ReadLine();
                stopWatch.Restart();
                _diseaseStoryLogic.CreateOrUpdate(new DiseaseStoryBindingModel
                {
                    PatientId = Convert.ToInt32(patientIdCreate),
                    DiseaseName = diseaseNameCreate,
                    DateOfApplication = DateTime.Parse(dateOfApplicationCreate),
                });
            }
            else if (action.Equals(_cmdHelper.actions[2]))
            {
                Console.Write("Enter 'Id':");
                var IdUpdate = Console.ReadLine();
                Console.Write("Enter new 'PatientId' (previous: {0}): ",
                    _diseaseStoryStorage.GetElement(new DiseaseStoryBindingModel { Id = Convert.ToInt32(IdUpdate) }).PatientId);
                var patientIdUpdate = Console.ReadLine();
                Console.Write("Enter new 'DiseaseName' (previous: {0}): ",
                    _diseaseStoryStorage.GetElement(new DiseaseStoryBindingModel { Id = Convert.ToInt32(IdUpdate) }).DiseaseName);
                var diseaseNameUpdate = Console.ReadLine();
                Console.Write("Enter new 'DateOfApplication' (previous: {0}): ",
                    _diseaseStoryStorage.GetElement(new DiseaseStoryBindingModel { Id = Convert.ToInt32(IdUpdate) }).DateOfApplication);
                var dateOfApplicationUpdate = Console.ReadLine();
                Console.Write("Enter new 'DateOfRecovery', if there is (previous: {0}): ",
                    _diseaseStoryStorage.GetElement(new DiseaseStoryBindingModel { Id = Convert.ToInt32(IdUpdate) }).DateOfRecovery);
                var dateOfRecoveryUpdate = Console.ReadLine();
                stopWatch.Restart();
                _diseaseStoryLogic.CreateOrUpdate(new DiseaseStoryBindingModel
                {
                    Id = Convert.ToInt32(IdUpdate),
                    PatientId = Convert.ToInt32(patientIdUpdate),
                    DiseaseName = diseaseNameUpdate,
                    DateOfApplication = Convert.ToDateTime(dateOfApplicationUpdate),
                    DateOfRecovery = Convert.ToDateTime(dateOfRecoveryUpdate)
                });
            }
            else if (action.Equals(_cmdHelper.actions[3]))
            {
                Console.Write("Enter 'ID': ");
                var IdDelete = Console.ReadLine();
                stopWatch.Restart();
                _diseaseStoryLogic.Delete(new DiseaseStoryBindingModel { Id = Convert.ToInt32(IdDelete) });
            }
            stopWatch.Stop();
            _cmdHelper.Success(action, _cmdHelper.entities[3], stopWatch);
        }
    }
}
