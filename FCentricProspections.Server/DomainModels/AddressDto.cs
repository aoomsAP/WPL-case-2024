
namespace FCentricProspections.Server.DomainModels;

public partial class AddressDto
{
    public long Id { get; set; }

    public string? Street1 { get; set; }

    public string? Street2 { get; set; }

    public string? City { get; set; }

    public string? PostalCode { get; set; }
}