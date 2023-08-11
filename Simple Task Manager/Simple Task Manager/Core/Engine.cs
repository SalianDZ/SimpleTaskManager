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
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("=-=-=-=-=-=-> Complete Task <-=-=-=-=-=-=");
            Console.WriteLine("The command must be in the following order -> (CompleteTask/Task's ID)");
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("=-=-=-=-=-=-> Show Tasks <-=-=-=-=-=-=");
            Console.WriteLine("The command must be in the following order -> (ShowTasks)");
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("=-=-=-=-=-=-> Show All Tasks <-=-=-=-=-=-=");
            Console.WriteLine("The command must be in the following order -> (ShowAllTasks)");
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
                    else if (input[0] == "CompleteTask")
                    {
                       int id = int.Parse(input[1]);
                       result = taskManager.CompleteTask(id);
                    }
                    else if (input[0] == "ShowTasks")
                    {
                        result = taskManager.ShowTasks();
                    }
                    else if (input[0] == "ShowAllTasks")
                    {
                        result = taskManager.ShowAllTasks();
                    }
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
