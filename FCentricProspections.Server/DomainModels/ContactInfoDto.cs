namespace FCentricProspections.Server.DomainModels
{
    public class ContactInfoDto
    {
        public long ContactId { get; set; }

        public long ContactTypeId { get; set; }

        public string? ContactTypeName { get; set; }

        public string? Name { get; set; }

        public string? Email {  get; set; }

        public string? PhoneNumber { get; set; }
    }
}
