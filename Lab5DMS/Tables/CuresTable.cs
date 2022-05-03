using Contracts.BusinessLogicsContracts;
using Contracts.StoragesContracts;
using Unity;
using System.Diagnostics;
using Contracts.BindingModels;

namespace Main.Tables
{
    public class CuresTable
    {
        private readonly ICureLogic _cureLogic;
        private readonly ICureStorage _cureStorage;
        private readonly CmdHelper _cmdHelper;
        public CuresTable(ICureLogic logic, ICureStorage storage) 
        {
            _cureLogic = logic;
            _cureStorage = storage;
            _cmdHelper = Program.Container.Resolve<CmdHelper>();
        }
        public void Cures(string action) 
        {
            Stopwatch stopWatch = Stopwatch.StartNew();
            if (action.Equals(_cmdHelper.actions[0]))
            {
                Console.WriteLine("ID || CureName || DiseaseName");
                stopWatch.Restart();
                foreach (var item in _cureLogic.Read(null))
                    Console.WriteLine("{0} || {1} || {2} ",
                        item.Id.ToString(), item.CureName, item.DiseaseName);
            }
            else if (action.Equals(_cmdHelper.actions[1]))
            {
                Console.Write("Enter 'CureName': ");
                var cureNameCreate = Console.ReadLine();
                Console.Write("Enter 'DiseaseName': ");
                var diseaseNameCreate = Console.ReadLine();
                stopWatch.Restart();
                _cureLogic.CreateOrUpdate(new CureBindingModel
                {
                    CureName = cureNameCreate,
                    DiseaseName = diseaseNameCreate
                });
            }
            else if (action.Equals(_cmdHelper.actions[2]))
            {
                Console.Write("Enter 'ID': ");
                var IdUpdate = Console.ReadLine();
                Console.Write("Enter new 'CureName' (previous: {0}): ",
                    _cureStorage.GetElement(new CureBindingModel { Id = Convert.ToInt32(IdUpdate) }).CureName);
                var cureNameUpdate = Console.ReadLine();
                Console.Write("Enter new 'DiseaseName' (previous: {0}): ",
                    _cureStorage.GetElement(new CureBindingModel { Id = Convert.ToInt32(IdUpdate) }).DiseaseName);
                var diseaseNameUpdate = Console.ReadLine();
                stopWatch.Restart();
                _cureLogic.CreateOrUpdate(new CureBindingModel
                {
                    Id = Convert.ToInt32(IdUpdate),
                    CureName = cureNameUpdate,
                    DiseaseName = diseaseNameUpdate
                });
            }
            else if (action.Equals(_cmdHelper.actions[3]))
            {
                Console.Write("Enter 'ID': ");
                var IdDelete = Console.ReadLine();
                stopWatch.Restart();
                _cureLogic.Delete(new CureBindingModel { Id = Convert.ToInt32(IdDelete) });
            }
            stopWatch.Stop();
            _cmdHelper.Success(action, _cmdHelper.entities[0], stopWatch);
        }
    }
}
