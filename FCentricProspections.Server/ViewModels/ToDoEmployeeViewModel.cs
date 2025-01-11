namespace FCentricProspections.Server.ViewModels
{
    public class ToDoEmployeeGetViewModel
    {
        public long? Id { get; set; }

        public long ToDoId { get; set; }

        public long EmployeeId { get; set; }
    }

    public class ToDoEmployeeUpdateViewModel
    {
        public IEnumerable<long> EmployeeIds { get; set; }
    }
}
