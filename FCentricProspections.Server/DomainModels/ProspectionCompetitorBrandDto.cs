namespace FCentricProspections.Server.DomainModels
{
    public class ProspectionCompetitorBrandDto
    {
        public string Id { get; set; }

        public ProspectionDetailDto Prospection { get; set; }

        public BrandDto Brand { get; set; } 
    }
}
