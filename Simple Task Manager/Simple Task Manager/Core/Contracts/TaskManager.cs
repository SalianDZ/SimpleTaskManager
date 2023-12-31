﻿using Simple_Task_Manager.Models;
using Simple_Task_Manager.Models.Contracts;
using Simple_Task_Manager.Repositories;
using System.Text;

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
            return $"Task with name: {name}, Id: {currentId} and EndDate: {endDate.Date} was added to the TaskManager!";
        }

        public string CompleteTask(int id)
        {
            if (!taskRepository.Models.Any(x => x.Id == id))
            {
                throw new ArgumentException("There is no task in the repository with this ID!");
            }

            ITask task = taskRepository.FindById(id);

            if (task.IsCompleted)
            {
                throw new ArgumentException("The task is already completed!");
            }
            task.ChangeStatus();
            return "The task is successfully completed!";
        }

        public IEnumerable<ITask> GetTasks()
        {
            return taskRepository.Models;
        }

        public string RemoveTask(string name)
        {
            if (!taskRepository.Models.Any(x => x.Name == name))
            {
                throw new ArgumentException("There is no task to be removed with the given name!");
            }
            ITask taskToRemove = taskRepository.FindByName(name);
            bool result = taskRepository.RemoveTask(taskToRemove);
            if (result)
            {
                return $"Task with name: {taskToRemove.Name} and ID: {taskToRemove.Id} has been removed";
            }
            else
            {
                return "You cannot remove a non-existing task!";
            }
        }

        public string ShowTasks()
        {
            StringBuilder sb = new();
            foreach (var task in taskRepository.Models.OrderByDescending(x => x.Level).Where(x => x.IsCompleted == false))
            {   
                sb.AppendLine("--------------------------------------------------------------------------------------------------------------------------------------");
                sb.AppendLine($"| {task.Id} |      {task.Name}      |   {task.GetType().Name}   |      {task.Description}      |  {task.EndDate.Date}  |");
                sb.AppendLine("--------------------------------------------------------------------------------------------------------------------------------------");
            }
            return sb.ToString().TrimEnd();
        }

        public string ShowAllTasks()
        {
            StringBuilder sb = new();
            foreach (var task in taskRepository.Models.OrderByDescending(x => x.Level))
            {
                if (task.IsCompleted)
                {
                    sb.AppendLine("--------------------------------------------------------------------------------------------------------------------------------------------------");
                    sb.AppendLine($"| {task.Id} |      {task.Name}      |   {task.GetType().Name}   |      {task.Description}      |  {task.EndDate.Date}  |  Completed |");
                    sb.AppendLine("--------------------------------------------------------------------------------------------------------------------------------------------------");
                }
                else
                {
                    sb.AppendLine("--------------------------------------------------------------------------------------------------------------------------------------------------------");
                    sb.AppendLine($"| {task.Id} |      {task.Name}      |   {task.GetType().Name}   |      {task.Description}      |  {task.EndDate.Date}  |  Not Completed |");
                    sb.AppendLine("--------------------------------------------------------------------------------------------------------------------------------------------------------");
                }
            }
            return sb.ToString().TrimEnd();
        }
    }
}
