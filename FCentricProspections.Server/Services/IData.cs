using FCentricProspections.Server.DataModels;
using FCentricProspections.Server.DomainModels;
using System.Diagnostics.Metrics;

namespace FCentricProspections.Server.Services
{
    public interface IData
    {
        // Shop --------------------------------------------------------------------------------------------------------------------------------------------------
        IEnumerable<ShopListDto> GetShops();

        ShopDetailDto GetShopDetail(long id);

        Shop GetShop(long id);

        // Prospection --------------------------------------------------------------------------------------------------------------------------------------------

        IEnumerable<ProspectionListDto> GetProspectionsByShopId(long shopId);

        IEnumerable<ProspectionListDto> GetProspectionsByUserId(long userId);

        ProspectionDetailDto GetProspectionDetail(long id);

        void AddProspection(Prospection prospection);

        // void UpdateProspection(Prospection prospection);

        // Brand --------------------------------------------------------------------------------------------------------------------------------------------

        // Gives A list of All the Fc70 brands
        IEnumerable<BrandDto> GetBrands();

        IEnumerable<CompetitorBrandDto> GetCompetitorBrands();

        // User ---------------------------------------------------------------------------------------------------------------------
        
        UserDto GetUserDto(long id);

        User GetUser(long id);

        // Types ---------------------------------------------------------------------------------------------------------------------

        IEnumerable<ProspectionContactType> GetContactPersonTypes();

        ProspectionContactType GetContactPersonType(long id);

        IEnumerable<ProspectionVisitType> GetVisitTypes();

        ProspectionVisitType GetVisitType(long id);
    }

}
