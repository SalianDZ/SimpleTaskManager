using Simple_Task_Manager.Core.Contracts;
using Simple_Task_Manager.IO;
using Simple_Task_Manager.IO.Contracts;

namespace Simple_Task_Manager.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private ITaskManager taskManager;
        public Engine()
        {
            this.reader = new Reader();
            this.writer = new Writer();
            this.taskManager = new TaskManager();
        }
        public void Run()
        {
            while (true)
            {
                string[] input = reader.ReadLine().Split();
                if (input[0] == "Exit")
                {
                    Environment.Exit(0);
                }
                try
                {
                    string result = string.Empty;

                    if (input[0] == "AddTask")
                    {
                        string name = input[1];
                        string taskType = input[2];
                        string description = input[3];
                        DateTime endDate = DateTime.Parse(input[4]);
                        result = taskManager.AddTask(name, taskType, description, endDate);
                    }
                    //else if (input[0] == "CreateSupplement")
                    //{
                    //    string typeName = input[1];

                    //    result = taskManager.CreateSupplement(typeName);
                    //}
                    //else if (input[0] == "UpgradeRobot")
                    //{
                    //    string model = input[1];
                    //    string supplementTypeName = input[2];

                    //    result = taskManager.UpgradeRobot(model, supplementTypeName);
                    //}
                    //else if (input[0] == "RobotRecovery")
                    //{
                    //    string model = input[1];
                    //    int minutes = int.Parse(input[2]);

                    //    result = taskManager.RobotRecovery(model, minutes);
                    //}
                    //else if (input[0] == "PerformService")
                    //{
                    //    string serviceName = input[1];
                    //    int interfaceStandard = int.Parse(input[2]);
                    //    int totalPowerNeeded = int.Parse(input[3]);

                    //    result = taskManager.PerformService(serviceName, interfaceStandard, totalPowerNeeded);
                    //}
                    //else if (input[0] == "Report")
                    //{
                    //    result = taskManager.Report();
                    //}
                    writer.WriteLine(result);
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }
        }
    }
}
