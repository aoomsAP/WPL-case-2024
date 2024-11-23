using FCentricProspections.Server.DomainModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FCentricProspections.Server.DataModels
{
    public class ProspectionCompetitorBrand // Referentiemerken
    {
        [Key]
        public long Id { get; set; }

        public long ProspectionId { get; set; }

        public Prospection Prospection { get; set; }

        public long CompetitorBrandId { get; set; }

        public CompetitorBrand CompetitorBrand { get; set; }
    }
}
