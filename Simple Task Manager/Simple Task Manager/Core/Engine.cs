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
            Console.WriteLine("To make a task you need to write the command in correct order.");
            Console.WriteLine("The order of the tokens for each command are shown below.");
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("=-=-=-=-=-=-> Add Task <-=-=-=-=-=-=");
            Console.WriteLine("The command must be in the following order -> (AddTask/Name/TaskType/Comment/EndDate)");
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("=-=-=-=-=-=-> Remove Task <-=-=-=-=-=-=");
            Console.WriteLine("The command must be in the following order -> (RemoveTask/Name)");
            Console.WriteLine("========================================================");
            while (true)
            {
                string[] input = reader.ReadLine().Split("/");
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
                    else if (input[0] == "RemoveTask")
                    {
                        string taskName = input[1];
                        result = taskManager.RemoveTask(taskName);
                    }
                    //else if (input[0] == "UpdateTask")
                    //{
                    //    string nameUpdate = input[1];
                    //    string taskTypeUpdate = input[2];
                    //    string commentUpdate = input[3];
                    //    string endDateUpdate = input[4];
                    //    result = taskManager.UpgradeRobot(model, supplementTypeName);
                    //}
                    else if (input[0] == "ShowTasks")
                    {
                        result = taskManager.ShowTasks();
                    }
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
