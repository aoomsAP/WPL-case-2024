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

        public long EmployeeId { get; set; }

        public Employee Employee { get; set; }

        public DateTime VisitDate { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateLastUpdated { get; set; }

        public long ContactTypeId { get; set; }

        public ProspectionContactType ContactType { get; set; }

        public string? ContactName { get; set; }

        public string? ContactEmail { get; set; }

        public string? ContactPhone { get; set; }

        public long VisitTypeId { get; set; }

        public ProspectionVisitType VisitType { get; set; }

        public string? VisitContext { get; set; }

        public ICollection<ProspectionBrand> Brands { get; set; }

        public ICollection<ProspectionCompetitorBrand> CompetitorBrands { get; set; }

        public string? NewBrands { get; set; } 

        public string? BestBrands { get; set; }

        public string? WorstBrands { get; set; }

        public string? TerminatedBrands { get; set; }

        public ICollection<ProspectionBrandInterest> BrandInterests { get; set; }

        public string? Trends { get; set; }

        public string? Extra { get; set; }

        public ICollection<ToDo> ToDoes { get; set; }
    }
}
