using BusinessLogic.BusinessLogics;
using Contracts.BusinessLogicsContracts;
using Contracts.StoragesContracts;
using DatabaseImplement.Implements;
using Unity;
using Unity.Lifetime;

namespace Main
{
    static class Program
    {
        private static IUnityContainer container = null;
        public static IUnityContainer Container
        {
            get
            {
                if (container == null) container = BuildUnityContainer();
                return container;
            }
        }
        private static IUnityContainer BuildUnityContainer()
        { 
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<IDoctorStorage, DoctorStorage>(new HierarchicalLifetimeManager());
           
            currentContainer.RegisterType<IPatientStorage, PatientStorage>(new HierarchicalLifetimeManager()); currentContainer.RegisterType<ICureStorage, CureStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IDiseaseStoryStorage, DiseaseStoryStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IDoctorLogic, DoctorLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IPatientLogic, PatientLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ICureLogic, CureLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IDiseaseStoryLogic, DiseaseStoryLogic>(new HierarchicalLifetimeManager());
            return currentContainer;
        }
        [STAThread]
        static void Main()
        {
            Container.Resolve<CmdHelper>().Start();
            Console.Read();
        }
    }
}