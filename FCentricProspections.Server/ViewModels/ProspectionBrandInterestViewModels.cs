﻿namespace FCentricProspections.Server.ViewModels
{
    public class ProspectionBrandInterestGetViewModel
    {
        public long? Id { get; set; }

        public long BrandId { get; set; }

        public string BrandName {get; set;}

        public string? Remark { get; set; }
    }

    public class ProspectionBrandInterestUpdateViewModel
    {
        public IEnumerable<ProspectionBrandInterestGetViewModel> ProspectionBrandInterests { get; set; }
    }
}
