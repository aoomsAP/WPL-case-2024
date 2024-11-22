namespace FCentricProspections.Server.DomainModels;

public partial class ProspectionBrandInterestDto
{
    public long Id { get; set; }

    public long ProspectionId { get; set; } 

    public long BrandId { get; set; }

    public string? Remark { get; set; }
}