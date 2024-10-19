using System.ComponentModel.DataAnnotations;

namespace FCentricProspections.Server.Entities
{
    public class City
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
