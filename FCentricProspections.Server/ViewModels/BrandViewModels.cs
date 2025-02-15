﻿using FCentricProspections.Server.DataModels;
using FCentricProspections.Server.DomainModels;
using System.ComponentModel.DataAnnotations;

namespace FCentricProspections.Server.ViewModels
{
        public class BrandGetAllViewModel
        {
            [Key]
            public long Id { get; set; }

            public string Name { get; set; }
        }
}
