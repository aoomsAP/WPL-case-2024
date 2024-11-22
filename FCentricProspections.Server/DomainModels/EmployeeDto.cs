using FCentricProspections.Server.DataModels;

namespace FCentricProspections.Server.DomainModels
{
    public class EmployeeDto
    {
        public long Id { get; set; }

        public string FirstName { get; set; }

        public string Name { get; set; }

        public long UserId { get; set; }

        public IEnumerable<Appointment> Appointments { get; set; }
    }
}
