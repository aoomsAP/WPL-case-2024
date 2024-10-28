using FCentricProspections.Server.DataModels;
using FCentricProspections.Server.Contexts;
using Microsoft.EntityFrameworkCore;
using FCentricProspections.Server.DomainModels;
using System.Net;

namespace FCentricProspections.Server.Services
{
    public class EfData : IData
    {
        private FCentricSmallContext context;

        public EfData(FCentricSmallContext context)
        {
            this.context = context;
        }

        // Shop ---------------------------------------------------------------------------------------------------------------------

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
            // "projection queries in Entity Framework"
            // https://www.tektutorialshub.com/entity-framework/join-query-entity-framework/

            var shopDetail = (from s in this.context.Shops
                              join contact in this.context.Contacts on s.ContactId equals contact.Id
                              join address in this.context.Addresses on contact.AddressId equals address.Id
                              join city in this.context.Cities on address.CityId equals city.Id
                              join customerShop in this.context.CustomerShops on s.Id equals customerShop.ShopId
                              join customer in this.context.Customers on customerShop.CustomerId equals customer.Id
                              where s.Id == id && customerShop.IsActive == true
                              select new ShopDetailDto
                              {
                                  Id = s.Id,
                                  Name = s.Name,
                                  Address = new AddressDto { Id = address.Id, Street1 = address.Street1, Street2 = address.Street2, PostalCode = address.PostalCode, City = city.Name },
                                  Customer = new CustomerDto { Id = customer.Id, Name = customer.Name },
                              }).SingleOrDefault();

            return shopDetail;
        }

        public Shop GetShop(long id)
        {
            var shop = this.context.Shops
                                   .FirstOrDefault(x => x.Id == id);

            return shop;
        }

        // Prospection ---------------------------------------------------------------------------------------------------------------------

        public IEnumerable<ProspectionListDto> GetProspectionsByShopId(long shopId)
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

        public IEnumerable<ProspectionListDto> GetProspectionsByUserId(long userId)
        {
            var prospectionsList = context.Prospections
                .FromSqlRaw(@$"SELECT Id , Date  FROM dbo.Prospections WHERE UserId = {userId}")
                .Select(s => new ProspectionListDto
                {
                    Id = s.Id,
                    Date = s.Date,
                }).ToList();

            return prospectionsList;
        }

        public ProspectionDetailDto GetProspectionDetail(long id)
        {
            // "projection queries in Entity Framework"
            // https://www.tektutorialshub.com/entity-framework/join-query-entity-framework/

            var prospectionDetail = (from p in this.context.Prospections
                              join shop in this.context.Shops on p.ShopId equals shop.Id
                              join contact in this.context.ProspectionContactTypes on p.ContactPersonTypeId equals contact.Id
                              join visit in this.context.ProspectionVisitTypes on p.VisitTypeId equals visit.Id
                              where p.Id == id
                              select new ProspectionDetailDto
                              {
                                  Id = p.Id,
                                  ShopId = p.ShopId,
                                  Shop = new ShopListDto { Id = p.ShopId, Name = shop.Name },
                                  UserId = p.UserId, 
                                  Date = p.Date,
                                  DateLastUpdated = p.DateLastUpdated,
                                  ContactPersonTypeId = p.ContactPersonTypeId,
                                  ContactPersonType = new ProspectionContactType { Id = p.ContactPersonTypeId, Name = contact.Name },
                                  ContactPersonName = p.ContactPersonName,
                                  VisitTypeId = p.VisitTypeId,
                                  VisitType = new ProspectionVisitType { Id = p.VisitTypeId, Name = visit.Name },
                                  VisitContext = p.VisitContext,
                                  BestBrands = p.BestBrands,
                                  WorstBrands = p.WorstBrands,
                                  BrandsOut = p.BrandsOut,
                                  Trends = p.Trends,
                                  Extra = p.Extra,
                                  // LISTS? ProspectionBrand, ProspectionCompetitorBrand, ProspectionBrandInterest
                              }).SingleOrDefault();

            return prospectionDetail;
        }

        public void AddProspection(Prospection prospection)
        {
            this.context.Prospections.Add(prospection);
            this.context.SaveChanges();
        }

        // Brand ---------------------------------------------------------------------------------------------------------------------

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

        // User ---------------------------------------------------------------------------------------------------------------------

        public UserDto GetUserDto(long id)
        {
            var user = context.Users
                .FromSqlRaw(@$"")
                .Select(u => new UserDto
                {
                    Id = u.Id,
                    Login = u.Login,
                    Blocked = u.Blocked,
                    Prospections = this.GetProspectionsByUserId(u.Id),
                }).SingleOrDefault();

            return user;
        }

        public User GetUser(long id)
        {
            var user = this.context.Users
                                   .FirstOrDefault(x => x.Id == id);

            return user;
        }

        // Types ---------------------------------------------------------------------------------------------------------------------

        public IEnumerable<ProspectionContactType> GetContactPersonTypes()
        {
            var contactPersonTypesList = this.context.ProspectionContactTypes
                .FromSqlRaw(@"SELECT  Id, Name FROM dbo.ProspectionContactTypes ")
                .Select(s => new ProspectionContactType
                {
                    Id = s.Id,
                    Name = s.Name,
                }).ToList();

            return contactPersonTypesList;
        }

        public ProspectionContactType GetContactPersonType(long id)
        {
            var type = this.context.ProspectionContactTypes
                                   .FirstOrDefault(x => x.Id == id);

            return type;
        }

        public IEnumerable<ProspectionVisitType> GetVisitTypes()
        {
            var visitTypesList = this.context.ProspectionVisitTypes
                .FromSqlRaw(@"SELECT  Id, Name FROM dbo.ProspectionVisitTypes ")
                .Select(s => new ProspectionVisitType
                {
                    Id = s.Id,
                    Name = s.Name,
                }).ToList();

            return visitTypesList;
        }

        public ProspectionVisitType GetVisitType(long id)
        {
            var type = this.context.ProspectionVisitTypes
                                   .FirstOrDefault(x => x.Id == id);

            return type;
        }
    }
}
