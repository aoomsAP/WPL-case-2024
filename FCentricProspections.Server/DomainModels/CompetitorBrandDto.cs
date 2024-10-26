namespace FCentricProspections.Server.DomainModels;

public partial class CompetitorBrandDto
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public ICollection<ProspectionCompetitorBrand> ProspectionCompetitorBrands { get; set; }
}