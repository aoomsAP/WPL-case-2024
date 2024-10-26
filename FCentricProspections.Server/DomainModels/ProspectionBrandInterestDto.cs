namespace FCentricProspections.Server.DomainModels;

public partial class ProspectionBrandInterestDto
{
    public string Id { get; set; }

    public ProspectionDetailDto Prospection { get; set; } 

    public BrandDto Brand { get; set; }

    public string? Sales { get; set; }

    
}