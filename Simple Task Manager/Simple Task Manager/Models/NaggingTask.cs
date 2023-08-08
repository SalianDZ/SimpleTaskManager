using Simple_Task_Manager.Enums;
namespace Simple_Task_Manager.Models
{
    public class NaggingTask : Task
    {
        private const ImportanceLevel level = ImportanceLevel.Nagging;
        public NaggingTask(int id, string name, string description,  DateTime endDate)
            : base(id, name, description, level, endDate)
        {
        }
    }
}
