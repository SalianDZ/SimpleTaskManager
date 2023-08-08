using Simple_Task_Manager.Enums;

namespace Simple_Task_Manager.Models
{
    public class ImportantTask : Task
    {
        private const ImportanceLevel level = ImportanceLevel.Important;
        public ImportantTask(int id, string name, string description, DateTime endDate)
            : base(id, name, description, level, endDate)
        {
        }
    }
}
