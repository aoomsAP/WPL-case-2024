using FCentricProspections.Server.DataModels;

namespace FCentricProspections.Server.ViewModels
{
    public class AddressCreateViewModel
    {
        public string Street1 { get; set; }

        public long? CityId { get; set; }

        public string PostalCode { get; set; }

        public long UserCreatedId { get; set; }

        public DateTime DateCreated { get; set; }

    }
    public class AddressGetViewModel
    {
        public long Id { get; set; }

        public string Street1 { get; set; }

        public long? CityId { get; set; }

        public string PostalCode { get; set; }

        public DateTime DateCreated { get; set; }

    }
}
