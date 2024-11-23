namespace FCentricProspections.Server.ViewModels
{
    public class EmployeeGetAllViewModel
    {
        public long Id { get; set; }

        public string FirstName { get; set; }

        public string Name { get; set; }

        public long? UserId { get; set; }
    }

    public class EmployeeGetViewModel
    {
        public long Id { get; set; }

        public string FirstName { get; set; }

        public string Name { get; set; }

        public long? UserId {get; set;}
    }
}
