namespace FCentricProspections.Server.ViewModels
{
    public class ProspectionBrandGetViewModel
    {
        public long Id { get; set; }

        public long BrandId { get; set; }

        public int? Sellout { get; set; } // int because it's a percentage? string because it should be free text?

        public string? SalesRepresentative { get; set; }

        public string? CommercialSupport { get; set; }
    }
    
    public class ProspectionBrandUpdateViewModel
    {
        public IEnumerable<ProspectionBrandGetViewModel> ProspectionBrands { get; set; }
    }
}
