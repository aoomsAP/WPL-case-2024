using FCentricProspections.Server.DataModels;

namespace FCentricProspections.Server.DomainModels
{
    public class ContactDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long? AddressId { get; set; }
        public Address Address { get; set; }
    }
}
