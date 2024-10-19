using System.ComponentModel.DataAnnotations;

namespace FCentricProspections.Server.ViewModels
{
    public class ShopGetAllViewModel
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }

    public class ShopGetDetailViewModel
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Customer { get; set; }
    }
}
