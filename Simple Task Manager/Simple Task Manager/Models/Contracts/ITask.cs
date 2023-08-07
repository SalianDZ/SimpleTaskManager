using Simple_Task_Manager.Enums;

namespace Simple_Task_Manager.Models.Contracts
{
    public interface ITask
    {
        public int Id { get; }
        public string Name { get;}

        public string Description { get; }

        public ImportanceLevel importanceLevel { get; }

        public DateTime CreationDate { get; }

        public DateTime EndDate { get; }

        public string Report();
    }
}
