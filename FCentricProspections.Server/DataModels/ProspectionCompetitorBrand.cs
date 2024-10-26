using FCentricProspections.Server.DomainModels;

namespace FCentricProspections.Server.DataModels
{
    public class ProspectionCompetitorBrand
    {
        public string Id { get; set; }

        public long ProspectionId { get; set; }

        public Prospection Prospection { get; set; }

        public long CompetitorBrandId { get; set; }

        public CompetitorBrand CompetitorBrand { get; set; }
    }
}
