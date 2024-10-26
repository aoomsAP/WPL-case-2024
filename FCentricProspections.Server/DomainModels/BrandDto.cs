
namespace FCentricProspections.Server.DomainModels;

public partial class BrandDto
{
    public long Id { get; set; }

    public string Name { get; set; }

    public ICollection<ProspectionBrandDto> ProspectionBrands { get; set; }

    public ICollection<ProspectionBrandInterestDto> ProspectionBrandInterests { get; set; }
}