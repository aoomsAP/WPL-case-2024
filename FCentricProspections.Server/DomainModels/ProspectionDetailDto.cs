
using FCentricProspections.Server.DataModels;

namespace FCentricProspections.Server.DomainModels
{
    public class ProspectionDetailDto
    {
        public long Id { get; set; }

        public ShopDetailDto Shop { get; set; }

        public UserDto User { get; set; }

        public DateTime Date { get; set; }

        public DateTime DateLastUpdated { get; set; }

        public ProspectionContactType? ContactPersonType { get; set; }

        public string? ContactPersonName { get; set; }

        public ProspectionVisitType? VisitType { get; set; }

        public string? VisitContext { get; set; }

        public ICollection<ProspectionBrand> BrandReports { get; set; }

        public ICollection<ProspectionCompetitorBrandDto> CompetitorBrands { get; set; }

        public string? BestBrands { get; set; } // potentially in the future two lists of brands + competitor brands?

        public string? WorstBrands { get; set; } // potentially in the future two lists of brands + competitor brands?

        public string? BrandsOut {  get; set; } // potentially in the future two lists of brands + competitor brands?

        public ICollection<ProspectionBrandInterestDto> BrandInterests { get; set; }

        public string? Trends { get; set; }

        public string? Extra { get; set; }
    }
}
