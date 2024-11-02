using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FCentricProspections.Server.DataModels
{
    public class ProspectionBrand
    {
        [Key]
        public long Id { get; set; }

        public long ProspectionId { get; set; }

        public Prospection Prospection { get; set; }

        public long BrandId { get; set; }

        public Brand Brand { get; set; }

        public int? Sellout { get; set; } // int because it's a percentage? string because it should be free text?

        public string? SalesRepresentative { get; set; }

        public string? CommercialSupport { get; set; }
    }
}
