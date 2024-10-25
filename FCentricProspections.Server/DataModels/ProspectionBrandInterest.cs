namespace FCentricProspections.Server.DataModels
{
    public class ProspectionBrandInterest
    {
        public string Id { get; set; }

        public long ProspectionId { get; set; }

        public Prospection Propsection { get; set; }

        public long BrandId { get; set; }

        public Brand Brand { get; set; }

        public string? Sales { get; set; }
    }
}
