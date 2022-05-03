using Contracts.BindingModels;
using Contracts.BusinessLogicsContracts;
using Contracts.StoragesContracts;
using Main.Tables;
using System.Diagnostics;
using Unity;

namespace Main
{
    public class CmdHelper
    {
        private CuresTable _cureTable;
        private PatientsTable _patientsTable;
        private DoctorsTable _doctorsTable;
        private DiseaseStoriesTable _diseaseStoriesTable;

        private string table;
        private string action;

        public List<string> entities = new() { "cure", "patient", "doctor", "disease story" };
        public List<string> actions = new() { "read", "create", "update", "delete" };
        public void Start() 
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Press <Enter> to continue; ");
            Console.WriteLine("Press <Escape> to exit;");
            Console.ResetColor();
            Console.WriteLine();
            while (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                Console.Write("Enter table name ( {0} , {1}, {2}, {3} ): ",
                    entities[0], entities[1], entities[2], entities[3]);
                table = Console.ReadLine();
                while (!entities.Contains(table))
                {
                    Error(table);
                    table = Console.ReadLine();
                }
                
                Console.Write("Choose action ( {0}, {1}, {2}, {3} ): ",
                    actions[0], actions[1], actions[2], actions[3]);
                action = Console.ReadLine();
                while (!actions.Contains(action))
                {
                    Error(action);
                    action = Console.ReadLine();
                }
                Console.WriteLine();

                if (table.Equals(entities[0]))
                    Program.Container.Resolve<CuresTable>().Cures(action);
                else if (table.Equals(entities[1]))
                    Program.Container.Resolve<PatientsTable>().Patients(action);
                else if (table.Equals(entities[2]))
                    Program.Container.Resolve<DoctorsTable>().Doctors(action);
                else if (table.Equals(entities[3]))
                    Program.Container.Resolve<DiseaseStoriesTable>().DiseasyStories(action);
            }
            if (Console.ReadKey().Key == ConsoleKey.Escape)
                Environment.Exit(0);
        }
        public void Error(string parameter) 
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Error: {0} doesn`t exists, type again: ", parameter);
            Console.ResetColor();
        }
        public void Success(string action, string table, Stopwatch stopWatch) 
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Successful request '{0}' from '{1}';",
                action, table);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Request comleted in {0}ms;", 
                stopWatch.ElapsedMilliseconds);
            Console.ResetColor();
        }
    }
}