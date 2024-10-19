using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

namespace FCentricProspections.Server.Entities
{
    public class Shop
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Customer {  get; set; }
    }
}
