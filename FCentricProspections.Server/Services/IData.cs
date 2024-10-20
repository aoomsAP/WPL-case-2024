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

        IEnumerable<Prospection> GetProspections(long shopId);
        Prospection GetProspectionDetail(long id);
        void AddProspection(Prospection prospection);

        //void UpdateProspection(Prospection prospection);
    }

}
