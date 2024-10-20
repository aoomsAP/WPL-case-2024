using System.ComponentModel.DataAnnotations;

namespace FCentricProspections.Server.Models
{
    // NEW
    public class Prospection
    {
        [Key]
        public long Id { get; set; }

        public string Comment { get; set; }

        public DateTime Date { get; set; }

        public long ShopId { get; set; }

        public virtual Shop Shop { get; set; }
    }
}
