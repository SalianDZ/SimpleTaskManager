﻿using Simple_Task_Manager.Models.Contracts;

namespace Simple_Task_Manager.Core.Contracts
{
    public interface ITaskManager
    {
        public string AddTask(string name,string taskType, string description, DateTime endDate);
        public string RemoveTask(string name);
        public string UpdateTask(string name);
        public IEnumerable<ITask> GetTasks();
    }
}