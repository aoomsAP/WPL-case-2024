﻿using FCentricProspections.Server.Models;
using System.ComponentModel.DataAnnotations;

namespace FCentricProspections.Server.ViewModels
{
    public class ProspectionGetAllViewModel
    {
        // implement
    }

    public class ProspectionGetDetailViewModel
    {
        public long Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(500, ErrorMessage = "Maximum 500 characters")]
        public string Comment { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public long ShopId { get; set; }
    }

    public class ProspectionCreateViewModel
    {
        [Required(AllowEmptyStrings = false)]
        [MaxLength(500, ErrorMessage = "Maximum 500 characters")]
        public string Comment { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public long ShopId { get; set; }
    }

    public class ProspectionUpdateViewModel
    {
        // implement
    }
}
