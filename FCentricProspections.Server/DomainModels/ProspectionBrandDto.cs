namespace FCentricProspections.Server.DomainModels;

public partial class ProspectionBrandDto
{
    public long Id { get; set; } 

    public long ProspectionId { get; set; } 

    public long BrandId { get; set; } 

    public int? Sellout { get; set; } 

    public string? SelloutRemark { get; set; }
}