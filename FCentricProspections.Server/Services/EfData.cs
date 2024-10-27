using FCentricProspections.Server.DataModels;
using FCentricProspections.Server.Contexts;
using Microsoft.EntityFrameworkCore;
using FCentricProspections.Server.DomainModels;

namespace FCentricProspections.Server.Services
{
    public class EfData : IData
    {
        private FCentricSmallContext context;

        public EfData(FCentricSmallContext context)
        {
            this.context = context;
        }

        public IEnumerable<ShopListDto> GetShops()
        {
            var ShopList = context.Shops
                .FromSqlRaw(@"SELECT  Id, Name FROM dbo.Shops ")
                .Select(s => new ShopListDto
                {
                    Id = s.Id,
                    Name = s.Name,  
                }).ToList();

            return ShopList;
        }

        public ShopDetailDto GetShopDetail(long id)
        {
            // this does not work, requires more complicated query
            // eager loading / join on Shop - Contact - Address - City?
            // join to include Customers table via CustomerShops? create another context query like GetCustomer?
            var shopDetail = context.Shops
                .FromSqlRaw(@$"")
                .Select(p => new ShopDetailDto 
                {
                    
                }).SingleOrDefault();


            return shopDetail;
        }

        public IEnumerable<ProspectionListDto> GetProspections(long shopId)
        {
            var prospectionsList = context.Prospections
                .FromSqlRaw(@$"SELECT Id , Date  FROM dbo.Prospections WHERE ShopId = {shopId}")
                .Select(s => new ProspectionListDto
                {
                    Id = s.Id,
                    Date = s.Date,
                }).ToList();


            return prospectionsList;
        }

        public ProspectionDetailDto GetProspectionDetail(long id)
        {
            var prospectionDetail = context.Prospections
                .FromSqlRaw($@"SELECT 
                p.ShopId, p.Date, p.DateLastUpdated, p.UserId, p.ContactPersonTypeId, 
                p.ContactPersonName, p.VisitTypeId, p.VisitContext, p.BestBrands, p.WorstBrands, 
                p.BrandsOut, p.Trends, p.Extra,
                s.Id AS ShopId, s.Name AS ShopName, s.Address AS ShopAddress
                 FROM dbo.Prospections AS p
                 JOIN dbo.Shops AS s ON p.ShopId = s.Id
                 WHERE p.Id = {id}")
                .Select( p => new ProspectionDetailDto
                {
                    Id = p.Id,
                    //ShopDetailDTO?

                    Shop = GetShopDetail(p.ShopId),
                    //UserDTO?
                    User = new UserDto { },

                    Date = p.Date,
                    DateLastUpdated = p.DateLastUpdated,
                    ContactPersonType = new ProspectionContactType { Id = p.ContactPersonTypeId, Name = null/*wat moet hier?*/ },
                    VisitType = new ProspectionVisitType { Id = p.VisitTypeId, Name = null },
                    VisitContext = p.VisitContext,

                    BestBrands = p.BestBrands,
                    WorstBrands = p.WorstBrands,
                    BrandsOut = p.BrandsOut,
                    Trends = p.Trends,
                    Extra = p.Extra,




                }).SingleOrDefault();

            return prospectionDetail;
        }

        public void AddProspection(Prospection prospection)
        {
            this.context.Prospections.Add(prospection);
            this.context.SaveChanges();
        }

        ///Brands
        ///

        public IEnumerable<BrandDto> GetBrands()
        {
            var brandList = context.Brands
                .FromSqlRaw(@"SELECT  Id, Name FROM dbo.Brands ")
                .Select(s => new BrandDto
                {
                    Id = s.Id,
                    Name = s.Name,
                }).ToList();

            return brandList;
        }

        public IEnumerable<CompetitorBrandDto> GetCompetitorBrands()
        {
            var competitorBrandList = context.CompetitorBrands
                .FromSqlRaw(@"SELECT  Id, Name FROM dbo.CompetitorBrands ")
                .Select(s => new CompetitorBrandDto
                {
                    Id = s.Id,
                    Name = s.Name,
                }).ToList();

            return competitorBrandList;
        }

    }
}
