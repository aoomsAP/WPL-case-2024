using FCentricProspections.Server.Models;
using FCentricProspections.Server.Contexts;

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
            // TO IMPLEMENT
            // include eager loading to include contact info => address => city
            throw new NotImplementedException();
        }

        public IEnumerable<Prospection> GetProspections(long shopId)
        {
            // TO IMPLEMENT
            throw new NotImplementedException();
        }

        public Prospection GetProspectionDetail(long id)
        {
            return this.context.Prospections
                .FirstOrDefault(x => x.Id == id);
        }

        public void AddShopProspection(Prospection prospection)
        {
            this.context.Prospections.Add(prospection);
            this.context.SaveChanges();
        }
    }
}
