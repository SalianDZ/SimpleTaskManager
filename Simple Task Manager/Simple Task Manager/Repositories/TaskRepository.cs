using Simple_Task_Manager.Models.Contracts;

namespace Simple_Task_Manager.Repositories
{
    public class TaskRepository 
    {
        private List<ITask> tasks = new();

        public void AddTask(ITask model)
        {
            tasks.Add(model);
        }

        public bool RemoveTask(ITask model)
        {
            return tasks.Remove(model);
        }

        public ITask FindById(int id)
        {
            return tasks.FirstOrDefault(x => x.Id == id);
        }

        public ITask FindByName(string name)
        {
            return tasks.FirstOrDefault(x => x.Name == name);
        }

        public IReadOnlyCollection<ITask> Models => tasks.AsReadOnly();
    }
}
