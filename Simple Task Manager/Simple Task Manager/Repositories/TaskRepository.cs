using Simple_Task_Manager.Models.Contracts;

namespace Simple_Task_Manager.Repositories
{
    public class TaskRepository 
    {
        private List<ITask> incompletedTasks = new();


        public void AddTask(ITask model)
        {
            incompletedTasks.Add(model);
        }

        public bool RemoveTask(ITask model)
        {
            return incompletedTasks.Remove(model);
        }

        public ITask FindById(int id)
        {
            return incompletedTasks.FirstOrDefault(x => x.Id == id);
        }

        public ITask FindByName(string name)
        {
            return incompletedTasks.FirstOrDefault(x => x.Name == name);
        }

        public IReadOnlyCollection<ITask> Models => incompletedTasks.AsReadOnly();
    }
}
