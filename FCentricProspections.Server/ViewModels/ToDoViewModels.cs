using FCentricProspections.Server.DataModels;

namespace FCentricProspections.Server.ViewModels
{
    public class ToDoGetViewModel
    {
        public long Id { get; set; }

        public string Remarks { get; set; }

        public long? EmployeeId { get; set; }

        public long? ToDoStatusId { get; set; }

        public string? ToDoStatus { get; set; }

        public string Name { get; set; }
    }

    public class ToDoCreateViewModel
    {
        public string Remarks { get; set; }

        public long? EmployeeId { get; set; }

        public long ToDoStatusId { get; set; }

        public string Name { get; set; }

        public long UserCreatedId {  get; set; }

        public DateTime DateCreated {  get; set; }
    }
}
