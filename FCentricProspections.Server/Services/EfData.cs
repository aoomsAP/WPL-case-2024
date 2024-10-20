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
            throw new NotImplementedException();
        }

        public IEnumerable<Prospection> GetShopProspections(long shopId)
        {
            throw new NotImplementedException();
        }

        public Prospection GetShopProspectionDetail(long id)
        {
            throw new NotImplementedException();
        }

        public void AddShopProspection(Prospection prospection)
        {
            throw new NotImplementedException();
        }
    }
}
