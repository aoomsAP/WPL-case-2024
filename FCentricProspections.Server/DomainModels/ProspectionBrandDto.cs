namespace FCentricProspections.Server.DomainModels;

public partial class ProspectionBrandDto
{
    public string Id { get; set; } 

    public ProspectionDetailDto Prospection { get; set; } 

    public BrandDto Brand { get; set; } 

    public int? Sellout { get; set; } // int because it's a percentage? string because it should be free text?

    public string? SalesRepresentative { get; set; }

    public string? CommercialSupport { get; set; }
}