using FCentricProspections.Server.DataModels;
using FCentricProspections.Server.DomainModels;
using System.ComponentModel.DataAnnotations;

namespace FCentricProspections.Server.ViewModels
{
    public class ProspectionGetAllViewModel
    {
        public long Id { get; set; }

        [Required]
        public DateTime VisitDate { get; set; }

        public long ShopId { get; set; }
    }

    public class ProspectionGetDetailViewModel
    {
        public long Id { get; set; }

        public long ShopId { get; set; }

        public long UserCreatedId { get; set; }

        public long EmployeeId { get; set; }

        public DateTime VisitDate { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateLastUpdated { get; set; }

        public long ContactTypeId { get; set; }

        public string? ContactName { get; set; }

        public string? ContactEmail { get; set; }

        public string? ContactPhone { get; set; }

        public long VisitTypeId { get; set; }

        public string? VisitContext { get; set; }

        public string? NewBrands { get; set; }

        public string? BestBrands { get; set; }

        public string? WorstBrands { get; set; }

        public string? TerminatedBrands { get; set; }

        public string? Trends { get; set; }

        public string? Extra { get; set; }
    }


    public class ProspectionCreateViewModel
    {
        public long ShopId { get; set; }

        public long UserCreatedId { get; set; }

        public long EmployeeId { get; set; }

        public DateTime VisitDate { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateLastUpdated { get; set; }

        public long ContactTypeId { get; set; }

        public string? ContactName { get; set; }

        public string? ContactEmail { get; set; }

        public string? ContactPhone { get; set; }

        public long VisitTypeId { get; set; }

        public string? VisitContext { get; set; }

        public string? NewBrands { get; set; }

        public string? BestBrands { get; set; }

        public string? WorstBrands { get; set; }

        public string? TerminatedBrands { get; set; }

        public string? Trends { get; set; }

        public string? Extra { get; set; }
    }

    public class ProspectionUpdateViewModel
    {
        public long ShopId { get; set; }

        public long UserCreatedId { get; set; }

        public long EmployeeId { get; set; }

        public DateTime VisitDate { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateLastUpdated { get; set; }

        public long ContactTypeId { get; set; }

        public string? ContactName { get; set; }

        public string? ContactEmail { get; set; }

        public string? ContactPhone { get; set; }

        public long VisitTypeId { get; set; }

        public string? VisitContext { get; set; }

        public string? NewBrands { get; set; }

        public string? BestBrands { get; set; }

        public string? WorstBrands { get; set; }

        public string? TerminatedBrands { get; set; }

        public string? Trends { get; set; }

        public string? Extra { get; set; }
    }

}
