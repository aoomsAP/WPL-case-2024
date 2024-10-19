using System.ComponentModel.DataAnnotations;

namespace FCentricProspections.Server.Entities
{
    public class Prospection
    {
        [Key]
        public int Id { get; set; }

        public string Comment { get; set; }

        public DateTime Date { get; set; }

        public int ShopId { get; set; }
    }
}
