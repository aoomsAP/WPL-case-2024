using FCentricProspections.Server.DataModels;

namespace FCentricProspections.Server.DomainModels
{
    public class ToDoDto
    {
        public long Id { get; set; }

        public string Remarks { get; set; }

        public long ToDoTypeId { get; set; }

        public long ToDoStatusId { get; set; }

        public string Name { get; set; }

        public long UserCreatedId { get; set; }

        public virtual ToDoType ToDoType { get; set; }

        public virtual ToDoStatus ToDoStatus { get; set; }

        public virtual User UserCreated { get; set; }

        public ICollection<ToDoEmployee> AssignedEmployees { get; set; }

        public ICollection<ProspectionToDo> ProspectionToDos { get; set; }
    }
}
