using FCentricProspections.Server.DataModels;
using FCentricProspections.Server.DomainModels;
using System.ComponentModel.DataAnnotations;

namespace FCentricProspections.Server.ViewModels
{
    public class ProspectionGetAllViewModel
    {
        public long Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public long ShopId { get; set; }
    }

    public class ProspectionGetDetailViewModel
    {
        public long Id { get; set; }

        public long ShopId { get; set; }

        public long UserId { get; set; }

        public DateTime Date { get; set; }

        public DateTime DateLastUpdated { get; set; }

        public long ContactPersonTypeId { get; set; }

        public string? ContactPersonName { get; set; }

        public long VisitTypeId { get; set; }

        public string? VisitContext { get; set; }

        public string? BestBrands { get; set; }

        public string? WorstBrands { get; set; }

        public string? BrandsOut { get; set; }

        [MaxLength(500, ErrorMessage = "Maximum 500 characters")]
        public string? Trends { get; set; }

        public string? Extra { get; set; }
    }

    public class ProspectionCreateViewModel
    {
        public long ShopId { get; set; }

        public long UserId { get; set; }

        public DateTime Date { get; set; }

        public DateTime DateLastUpdated { get; set; }

        public long ContactPersonTypeId { get; set; }

        public string? ContactPersonName { get; set; }

        public long VisitTypeId { get; set; }

        public string? VisitContext { get; set; }

        public string? BestBrands { get; set; }

        public string? WorstBrands { get; set; }

        public string? BrandsOut { get; set; }

        [MaxLength(500, ErrorMessage = "Maximum 500 characters")]
        public string? Trends { get; set; }

        public string? Extra { get; set; }
    }

    public class ProspectionUpdateViewModel
    {
        public long ShopId { get; set; }

        public long UserId { get; set; }

        public DateTime Date { get; set; }

        public DateTime DateLastUpdated { get; set; }

        public long ContactPersonTypeId { get; set; }

        public string? ContactPersonName { get; set; }

        public long VisitTypeId { get; set; }

        public string? VisitContext { get; set; }

        public string? BestBrands { get; set; }

        public string? WorstBrands { get; set; }

        public string? BrandsOut { get; set; }

        [MaxLength(500, ErrorMessage = "Maximum 500 characters")]
        public string? Trends { get; set; }

        public string? Extra { get; set; }
    }

    public class ProspectionBrandUpdateViewModel
    {
        public IEnumerable<ProspectionBrandGetViewModel> ProspectionBrands {get ; set;}

    }

    public class ProspectionBrandGetViewModel
    {

        public long BrandId { get; set; }

        public int? Sellout { get; set; } // int because it's a percentage? string because it should be free text?

        public string? SalesRepresentative { get; set; }

        public string? CommercialSupport { get; set; }
    }


    public class ProspectionBrandInterestUpdateViewModel
    {
        public IEnumerable<long> BrandIds { get; set; }
    }

    public class ProspectionCompetitorBrandUpdateViewModel
    {
        public IEnumerable<long> CompetitorBrandIds { get; set; }
    }
}
