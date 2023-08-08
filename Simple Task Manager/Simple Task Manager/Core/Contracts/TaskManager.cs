using Simple_Task_Manager.Models;
using Simple_Task_Manager.Models.Contracts;
using Simple_Task_Manager.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Task_Manager.Core.Contracts
{
    public class TaskManager : ITaskManager
    {
        private TaskRepository taskRepository = new();

        public string AddTask(string name, string taskType, string description, DateTime endDate)
        {
            if (taskRepository.Models.Any(x => x.Name == name))
            {
                throw new ArgumentException("There is already added a task with the given name!");
            }

            int currentId = taskRepository.Models.Count + 1;
            ITask task;
            if (taskType.ToLower() == "nagging")
            {
                task = new NaggingTask(currentId, name, description, endDate);
            }
            else if (taskType.ToLower() == "standard")
            {
                task = new StandardTask(currentId, name, description, endDate);
            }
            else if (taskType.ToLower() == "important")
            {
                task = new ImportantTask(currentId, name, description, endDate);
            }
            else if (taskType.ToLower() == "urgent")
            {
                task = new UrgentTask(currentId, name, description, endDate);
            }
            else
            {
                throw new ArgumentException($"There is no such such task as {taskType}");
            }
            taskRepository.AddTask(task);
            return $"Task with name: {name}, Id: {currentId} and EndDate: {endDate} was added to the TaskManager!";
        }

        public IEnumerable<ITask> GetTasks()
        {
            throw new NotImplementedException();
        }

        public string RemoveTask(string name)
        {
            throw new NotImplementedException();
        }

        public string UpdateTask(string name)
        {
            throw new NotImplementedException();
        }
    }
}
