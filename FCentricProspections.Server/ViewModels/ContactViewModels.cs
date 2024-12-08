using FCentricProspections.Server.DataModels;

namespace FCentricProspections.Server.ViewModels
{
    public class ContactGetViewModel
    {
        public long Id { get; set; }
        public long? AddressId { get; set; }

        public string Name { get; set; }

        public long UserCreatedId { get; set; }

        public DateTime DateCreated { get; set; }
    }

    public class ContactCreateViewModel
    {
        public long? AddressId { get; set; }

        public string Name { get; set; }

        public long UserCreatedId { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
