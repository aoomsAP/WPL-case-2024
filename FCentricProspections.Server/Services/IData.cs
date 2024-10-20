using FCentricProspections.Server.Models;
using System.Diagnostics.Metrics;

namespace FCentricProspections.Server.Services
{
    public interface IData
    {
        // Shop Data

        IEnumerable<Shop> GetShops();
        Shop GetShopDetail(long id);

        // Prospection Data

        IEnumerable<Prospection> GetShopProspections(long shopId);
        Prospection GetShopProspectionDetail(long id);
        void AddShopProspection(Prospection prospection);

        //void UpdateProspection(Prospection prospection);
    }

}
