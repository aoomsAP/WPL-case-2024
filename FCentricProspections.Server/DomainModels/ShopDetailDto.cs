namespace FCentricProspections.Server.DomainModels;

public partial class ShopDetailDto
{
    public long Id { get; set; }

    public string Name { get; set; }

    public AddressDto Address { get; set; }

    public CustomerDto Customer { get; set; }

    public virtual ICollection<ProspectionListDto> Prospections { get; set; } = new List<ProspectionListDto>();
}