using FCentricProspections.Server.DataModels;
using FCentricProspections.Server.DomainModels;
using System.Diagnostics.Metrics;

namespace FCentricProspections.Server.Services
{
    public interface IData
    {
        /// <summary>
        /// Shop Data 
        /// </summary>
        IEnumerable<ShopListDto> GetShops();


        ShopDetailDto GetShopDetail(long id);


        /// <summary>
        /// Prospection Data
        /// </summary>
        
        //ProspectionList based on the shopId
        IEnumerable<ProspectionListDto> GetProspections(long shopId);

        //Detail of a prospection based on the prospectionId
        ProspectionDetailDto GetProspectionDetail(long id);

        void AddProspection(Prospection prospection);

        //void UpdateProspection(Prospection prospection);

        /// <summary>
        /// Brands Data
        /// </summary>
        
        //Gives A list of All the Fc70 brands
        IEnumerable<BrandDto> GetBrands();

        IEnumerable<CompetitorBrandDto> GetCompetitorBrands();
        
    }

}
