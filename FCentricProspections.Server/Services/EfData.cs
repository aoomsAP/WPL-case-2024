using FCentricProspections.Server.Models;
using FCentricProspections.Server.Contexts;
using Microsoft.EntityFrameworkCore;

namespace FCentricProspections.Server.Services
{
    public class EfData : IData
    {
        private FCentricSmallContext context;

        public EfData(FCentricSmallContext context)
        {
            this.context = context;
        }

        public IEnumerable<Shop> GetShops()
        {
            return this.context.Shops;
        }

        public Shop GetShopDetail(long id)
        {
            // this does not work, requires more complicated query
            // eager loading / join on Shop - Contact - Address - City?
            // join to include Customers table via CustomerShops? create another context query like GetCustomer?

            return this.context.Shops
                .Include(n => n.Prospections) // eager loading to make sure List of Prospections is loaded as well
                .Include(n => n.Contact)
                .FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Prospection> GetProspections(long shopId)
        {
            return this.context.Shops
                .Include(n => n.Prospections) // eager loading to make sure List of Prospections is loaded as well
                .FirstOrDefault(x => x.Id == shopId)
                .Prospections;
        }

        public Prospection GetProspectionDetail(long id)
        {
            return this.context.Prospections
                .FirstOrDefault(x => x.Id == id);
        }

        public void AddProspection(Prospection prospection)
        {
            this.context.Prospections.Add(prospection);
            this.context.SaveChanges();
        }
    }
}
