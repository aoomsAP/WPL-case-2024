using FCentricProspections.Server.DomainModels;
using System.ComponentModel.DataAnnotations;

namespace FCentricProspections.Server.DataModels
{
    public class Prospection
    {
        [Key]

        public long Id { get; set; }

        public long ShopId { get; set; }

        public virtual Shop Shop { get; set; }

        public long UserId { get; set; }

        public User User { get; set; }

        public DateTime Date { get; set; }

        public DateTime DateLastUpdated { get; set; }

        public long ContactPersonTypeId { get; set; }

        public ProspectionContactType ContactPersonType { get; set; }

        public string? ContactPersonName { get; set; }

        public long VisitTypeId { get; set; }

        public ProspectionVisitType VisitType { get; set; }

        public string? VisitContext { get; set; }

        public ICollection<ProspectionBrand> Brands { get; set; } //Perhaps ProspectionBrands as name?

        public ICollection<ProspectionCompetitorBrand> CompetitorBrands { get; set; }

        public string? BestBrands { get; set; } // potentially in the future two lists of brands + competitor brands?

        public string? WorstBrands { get; set; } // potentially in the future two lists of brands + competitor brands?

        public string? BrandsOut { get; set; } // potentially in the future two lists of brands + competitor brands?

        public ICollection<ProspectionBrandInterest> BrandsInterest { get; set; }

        public string? Trends { get; set; }

        public string? Extra { get; set; }
    }
}
