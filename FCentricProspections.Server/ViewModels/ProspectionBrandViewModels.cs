namespace FCentricProspections.Server.ViewModels
{
    public class ProspectionBrandGetViewModel
    {
        public long? Id { get; set; }

        public long BrandId { get; set; }

        public string BrandName { get; set; }

        public int? Sellout { get; set; }

        public string? SelloutRemark { get; set; }
    }
    
    public class ProspectionBrandUpdateViewModel
    {
        public IEnumerable<ProspectionBrandGetViewModel> ProspectionBrands { get; set; }
    }
}
