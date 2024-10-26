namespace FCentricProspections.Server.DomainModels;

public partial class ShopDetailDto
{
    public long Id { get; set; }

    public string Name { get; set; }

    public AddressDto Address { get; set; }

    // in database CustomerShop is a tabel connecting the FK of Customer and Shop
    // implying it's a many-to-many relationship, which could complicate things
    // so if we follow the database this should contain a list of CustomerShops like below
    // public virtual ICollection<CustomerShop> CustomerShops { get; set; } = new List<CustomerShop>();

    // but for now we'll just act like a shop can only have one customer
    // and we'll just use a new CustomerDto object and hope for the best?
    public CustomerDto Customer { get; set; }

    public virtual ICollection<ProspectionListDto> Prospections { get; set; } = new List<ProspectionListDto>();
}