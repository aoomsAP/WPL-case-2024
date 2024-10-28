using System.ComponentModel.DataAnnotations;

namespace FCentricProspections.Server.ViewModels
{
    public class BrandViewModels
    {
        public class BrandGetAllViewModel
        {
            [Key]
            public long Id { get; set; }

            public string Name { get; set; }
        }
    }
}
