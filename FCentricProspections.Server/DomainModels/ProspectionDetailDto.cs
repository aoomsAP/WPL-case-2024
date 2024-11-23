
using FCentricProspections.Server.DataModels;

namespace FCentricProspections.Server.DomainModels
{
    public class ProspectionDetailDto
    {
        public long Id { get; set; }

        public ShopListDto Shop { get; set; }

        public long ShopId { get; set; }

        public User User { get; set; }

        public long UserId { get; set; }

        public Employee Employee { get; set; }

        public long EmployeeId { get; set; }

        public DateTime VisitDate { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateLastUpdated { get; set; }

        public long ContactTypeId { get; set; }

        public ProspectionContactType? ContactType { get; set; }

        public string? ContactName { get; set; }

        public string? ContactEmail { get; set; }

        public string? ContactPhone { get; set; }

        public long VisitTypeId { get; set; }

        public ProspectionVisitType? VisitType { get; set; }

        public string? VisitContext { get; set; }

        public IEnumerable<ProspectionBrandDto> ProspectionBrands { get; set; }

        public IEnumerable<ProspectionCompetitorBrandDto> CompetitorBrands { get; set; }

        public string? NewBrands { get; set; } 

        public string? BestBrands { get; set; } 

        public string? WorstBrands { get; set; }

        public string? TerminatedBrands {  get; set; }

        public IEnumerable<ProspectionBrandInterestDto> ProspectionBrandInterests { get; set; }

        public string? Trends { get; set; }

        public string? Extra { get; set; }

        public IEnumerable<ToDo> ToDoes { get; set; }
    }
}
