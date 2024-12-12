using System.ComponentModel.DataAnnotations;
using FCentricProspections.Server.DataModels;
using FCentricProspections.Server.DomainModels;

namespace FCentricProspections.Server.ViewModels
{
    public class ShopGetAllViewModel
    {
        [Key]
        public long Id { get; set; }

        public string Name { get; set; }

        public string City { get; set; }
    }

    public class ShopGetDetailViewModel
    {
        [Key]
        public long Id { get; set; }

        public string Name { get; set; }

        public AddressDto Address { get; set; }

        public string Customer { get; set; }

        public string? Owner { get; set; }

        public long? ShopTypeId { get; set; }
    }

    public class ShopCreateViewModel
    {
        public long? ShopTypeId { get; set; }

        public string Name { get; set; }

        public long UserCreatedId { get; set; }

        public DateTime DateCreated { get; set; }

        public bool IsParallelSales { get; set; }

        public long ContactId { get; set; }

    }

    public class NewShopGetViewModel
    {
        public long Id { get; set; }

        public long? ShopTypeId { get; set; }

        public string Name { get; set; }

        public long UserCreatedId { get; set; }

        public DateTime DateCreated { get; set; }

        public bool IsParallelSales { get; set; }

        public long? ContactId { get; set; }
    }
}
