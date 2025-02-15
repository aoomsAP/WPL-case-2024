﻿using System.ComponentModel.DataAnnotations;

namespace FCentricProspections.Server.DataModels
{
    public class ShopType
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public long UserCreatedId { get; set; }

        
        public DateTime DateCreated { get; set; }

        [Timestamp]
        public byte[] Timestamp { get; set; }

        public virtual ICollection<Shop> Shops { get; set; } = new List<Shop>();

        public virtual User UserCreated { get; set; }
    }
}
