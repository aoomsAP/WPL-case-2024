﻿namespace FCentricProspections.Server.ViewModels
{
    public class ProspectionCompetitorBrandGetViewModel
    {
        public long Id { get; set; }

        public long CompetitorBrandId { get; set; }
    }

    public class ProspectionCompetitorBrandUpdateViewModel
    {
        public IEnumerable<long> CompetitorBrandIds { get; set; }
    }

}