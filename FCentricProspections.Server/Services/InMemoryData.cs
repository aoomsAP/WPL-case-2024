using FCentricProspections.Server.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace FCentricProspections.Server.Services
{
    public class InMemoryData : IData
    {
        private static List<Shop> shops;

        private static List<Prospection> prospections;

        static InMemoryData()
        {

            // Shops

            shops = new List<Shop>()
            {
                new Shop { Id = 1, Name = "Coffee Shop", Address = "123 Coffee Lane", Customer = "Alice Smith" },
                new Shop { Id = 2, Name = "Bookstore", Address = "456 Book Ave", Customer = "Bob Johnson" },
                new Shop { Id = 3, Name = "Grocery Store", Address = "789 Grocery Blvd", Customer = "Charlie Davis" },
                new Shop { Id = 4, Name = "Clothing Boutique", Address = "101 Fashion St", Customer = "Diana Moore" },
                new Shop { Id = 5, Name = "Electronics Store", Address = "202 Tech Park", Customer = "Eve Turner" },
                new Shop { Id = 6, Name = "Flower Shop", Address = "303 Blooming Rd", Customer = "Frank White" },
                new Shop { Id = 7, Name = "Music Store", Address = "404 Melody Ave", Customer = "Grace Hill" },
                new Shop { Id = 8, Name = "Hardware Store", Address = "505 Builder St", Customer = "Henry King" },
                new Shop { Id = 9, Name = "Jewelry Store", Address = "606 Gemstone Blvd", Customer = "Ivy Carter" },
                new Shop { Id = 10, Name = "Art Gallery", Address = "707 Canvas Lane", Customer = "Jack Lee" },
            };

            // Prospections

            prospections = new List<Prospection>()
            {
                new Prospection { Id = 1, Comment = "The coffee didn't sell well in summer", Date = new DateTime(2023, 09, 01), ShopId = 1 },
                new Prospection { Id = 2, Comment = "The coffee started selling better in winter", Date = new DateTime(2024, 01, 01), ShopId = 1 },
                new Prospection { Id = 3, Comment = "After ordering new beans, there was a drop in sales", Date = new DateTime(2024, 06, 24), ShopId = 1 },
                new Prospection { Id = 4, Comment = "The new barista was rude and chased customers away", Date = new DateTime(2024, 10, 12), ShopId = 1 },
                new Prospection { Id = 5, Comment = "Something about the shop", Date = new DateTime(2022, 07, 19), ShopId = 2 },
                new Prospection { Id = 6, Comment = "The store is not very successful", Date = new DateTime(2023, 07, 20), ShopId = 2 },
                new Prospection { Id = 7, Comment = "A whole story about the store employee", Date = new DateTime(2024, 07, 14), ShopId = 2 },
                new Prospection { Id = 8, Comment = "Some brands sold well, others sold very badly", Date = new DateTime(2024, 02, 08), ShopId = 3 },
                new Prospection { Id = 9, Comment = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur facilisis sagittis ex, sit amet consectetur purus ornare quis. Morbi vitae orci eu ex hendrerit interdum at quis lorem. Curabitur vehicula vitae augue sit amet posuere. Fusce ornare venenatis magna, vel tincidunt mauris feugiat sit amet. Nullam consequat fringilla tellus vel accumsan. Sed non augue non velit cursus tempus. Integer quis mi feugiat, vehicula turpis vitae, convallis dui. Nulla pretium aliquet eros, sed iaculis arcu pretium sit amet. Morbi tempor mauris eget hendrerit porta. Maecenas vestibulum aliquet dolor, non dignissim libero eleifend non. Praesent mattis euismod finibus. Donec ultricies molestie erat.", Date = new DateTime(2024, 09, 12), ShopId = 4 },
                new Prospection { Id = 10, Comment = "Comment comment comment", Date = new DateTime(2024, 10, 18) },
            };
        }

        // shop data

        public IEnumerable<Shop> GetShops()
        {
            return shops;
        }

        public Shop GetShopDetail(int id)
        {
            return shops.FirstOrDefault(x => x.Id == id);
        }

        // prospection data

        public IEnumerable<Prospection> GetShopProspections(int shopId)
        {
            return prospections.FindAll(x => x.ShopId == shopId);
        }

        public Prospection GetShopProspectionDetail(int id)
        {
            return prospections.FirstOrDefault(x => x.Id == id);
        }

        public void AddShopProspection(Prospection prospection)
        {
            prospection.Id = prospections.Max(x => x.Id) + 1;
            prospections.Add(prospection);
        }
    }
}
