using Simple_Task_Manager.Enums;
using Simple_Task_Manager.Models.Contracts;
using System.Text;

namespace Simple_Task_Manager.Models
{
    public abstract class Task : ITask
    {
        private string name;
        private ImportanceLevel level;
        private DateTime currentDate;
        private DateTime endDate;

        protected Task(int id, string name, string description, ImportanceLevel importanceLevel, DateTime endDate)
        {
            Id = id;
            Name = name;
            Description = description;
            Level = importanceLevel;
            EndDate = endDate;
            currentDate = DateTime.Now.Date;
        }

        public int Id { get; private set; }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Task name cannot be null, empty or whitespace!");
                }
                name = value;
            }
        }

        public string Description { get; private set; }

        public ImportanceLevel Level
        {
            get => level;
            private set
            {
                if (value != ImportanceLevel.Nagging && value != ImportanceLevel.Standard &&
                    value != ImportanceLevel.Important && value != ImportanceLevel.Urgent)
                {
                    throw new ArgumentException("Error! Please enter a valid importance level!");
                }
                level = value;
            }
        }

        public DateTime CreationDate => currentDate;

        public DateTime EndDate
        {
            get => endDate;
            private set
            {
                if (value < DateTime.Now)
                {
                    throw new ArgumentException("Date cannot be in the past.");
                }
                endDate = value;
            }
        }

        public string Report()
        {
            StringBuilder sb = new();
            sb.AppendLine("=-=-=-=-=-=-=-=-=-=-=-=-=");
            sb.AppendLine($"Task (ID: {Id}) -> Name: {Name} - Description: {Description} - Date of adding: {CreationDate} - End Date {EndDate} - <=(Importance Level: {level})=>");
            sb.AppendLine("=-=-=-=-=-=-=-=-=-=-=-=-=");
            return sb.ToString().TrimEnd();
        }
    }
}
