using Simple_Task_Manager.Enums;

namespace Simple_Task_Manager.Models
{
    public class StandardTask : Task
    {
        private const ImportanceLevel level = ImportanceLevel.Standard;
        public StandardTask(int id, string name, string description, DateTime endDate) 
            : base(id, name, description, level, endDate)
        {
        }
    }
}
