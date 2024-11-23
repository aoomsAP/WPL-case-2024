namespace FCentricProspections.Server.ViewModels
{
    public class AppointmentGetAllViewModel
    {
        public long Id { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public long EmployeeId { get; set; }

        public string Remarks { get; set; }

        public string Name { get; set; }

        public string AppointmentState { get; set; }

    }

    public class AppointmentGetViewModel
    {
        public long Id { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public long EmployeeId { get; set; }

        public string Remarks { get; set; }

        public string Name { get; set; }
        public string AppointmentState { get; set; }
    }
}
