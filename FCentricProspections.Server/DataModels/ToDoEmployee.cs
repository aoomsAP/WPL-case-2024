using System.ComponentModel.DataAnnotations;

namespace FCentricProspections.Server.DataModels
{
    public class ToDoEmployee
    {
        [Key]
        public long Id { get; set; }

        public long ToDoId { get; set; }

        public ToDo ToDo { get; set; }

        public long EmployeeId { get; set; }

        public Employee Employee { get; set; }
    }
}
