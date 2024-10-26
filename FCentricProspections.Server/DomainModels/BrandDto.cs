
namespace FCentricProspections.Server.DomainModels;

public partial class BrandDto
{
    public long Id { get; set; }

    public string Name { get; set; }

    public ICollection<ProspectionBrand> ProspectionBrands { get; set; }

    public ICollection<ProspectionBrandInterest> ProspectionBrandInterests { get; set; }
}