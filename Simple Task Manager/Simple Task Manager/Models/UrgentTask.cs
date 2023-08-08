using Simple_Task_Manager.Enums;

namespace Simple_Task_Manager.Models
{
    public class UrgentTask : Task
    {
        private const ImportanceLevel level = ImportanceLevel.Urgent;
        public UrgentTask(int id, string name, string description, DateTime endDate)
            : base(id, name, description, level, endDate)
        {
        }
    }
}
