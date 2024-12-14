namespace FCentricProspections.Server.ViewModels
{
    public class ToDoEmployeeGetViewModel
    {
        public long? Id { get; set; }

        public long EmployeeId { get; set; }

        public string Name { get; set; }

        public string Remarks { get; set; }

        public long? ToDoTypeId { get; set; }

        public string? ToDoType { get; set; }

        public long? ToDoStatusId { get; set; }

        public string? ToDoStatus { get; set; }
    }

    public class ToDoEmployeeUpdateViewModel
    {
        public IEnumerable<long> EmployeeIds { get; set; }
    }
}
