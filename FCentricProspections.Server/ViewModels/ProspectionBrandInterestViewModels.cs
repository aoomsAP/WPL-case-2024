namespace FCentricProspections.Server.ViewModels
{
    public class ProspectionBrandInterestGetViewModel
    {

        public long BrandId { get; set; }

        public string? Sales { get; set; }
    }

    public class ProspectionBrandInterestUpdateViewModel
    {
        public IEnumerable<ProspectionBrandInterestGetViewModel> ProspectionBrandInterests { get; set; }
    }
}
