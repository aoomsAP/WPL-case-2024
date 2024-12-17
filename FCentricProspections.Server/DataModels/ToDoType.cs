using System.ComponentModel.DataAnnotations;

namespace FCentricProspections.Server.DataModels
{
    public class ToDoType
    {
        [Key]
        public long Id { get; set; }

        public string Name { get; set; }

        public string? AssignEmployeesQuery { get; set; }

        public long UserCreatedId { get; set; }

        public DateTime DateCreated { get; set; }

        [Timestamp]
        public byte[] Timestamp { get; set; }

        public virtual ICollection<ToDo> ToDos { get; set; } = new List<ToDo>();

        public virtual User UserCreated { get; set; }
    }
}
