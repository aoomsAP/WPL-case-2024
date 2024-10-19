using FCentricProspections.Server.Entities;
using System.Diagnostics.Metrics;

namespace FCentricProspections.Server.Services
{
    public interface IData
    {
        // Shop Data

        IEnumerable<Shop> GetShops();
        Shop GetShopDetail(int id);

        // Prospection Data

        IEnumerable<Prospection> GetShopProspections(int shopId);
        Prospection GetShopProspectionDetail(int id);
        void AddShopProspection(Prospection prospection);

        //void UpdateProspection(Prospection prospection);
    }

}
