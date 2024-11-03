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

        // SHOPS ---------------------------------------------------------------------------------------------------------------------
        // ---------------------------------------------------------------------------------------------------------------------------

        public IEnumerable<ShopListDto> GetShops()
        {
            var ShopList = context.Shops
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
            return this.context.Shops
                .Include(s => s.Prospections)
                .FirstOrDefault(x => x.Id == id);
        }

        // PROSPECTIONS ---------------------------------------------------------------------------------------------------------------------
        // ---------------------------------------------------------------------------------------------------------------------------

        // SELECT -----------

        public IEnumerable<ProspectionListDto> GetProspectionsByShopId(long shopId)
        {
            var prospectionsList = context.Shops
                .Include(s => s.Prospections)
                .FirstOrDefault(x => x.Id == shopId)
                .Prospections
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
                    .Where(p => p.UserId == userId)
                    .Select(s => new ProspectionListDto
                    {
                        Id = s.Id,
                        Date = s.Date,
                    })
                    .ToList();

            return prospectionsList;
        }

        public ProspectionDetailDto GetProspectionDetail(long prospectionId)
        {
            // "projection queries in Entity Framework"
            // https://www.tektutorialshub.com/entity-framework/join-query-entity-framework/

            var prospectionDetail = (from p in this.context.Prospections
                                     join shop in this.context.Shops on p.ShopId equals shop.Id
                                     join contact in this.context.ProspectionContactTypes on p.ContactPersonTypeId equals contact.Id
                                     join visit in this.context.ProspectionVisitTypes on p.VisitTypeId equals visit.Id
                                     where p.Id == prospectionId
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
                                     }).SingleOrDefault();

            return prospectionDetail;
        }

        public Prospection GetProspection(long id)
        {
            return this.context.Prospections
                 .Include(p => p.Shop)
                 .Include(p => p.User)
                 .Include(p => p.ContactPersonType)
                 .Include(p => p.VisitType)
                 .Include(p => p.Brands)
                 .Include(p => p.CompetitorBrands)
                 .Include(p => p.BrandsInterest)
                 .FirstOrDefault(x => x.Id == id);
        }

        // Relationships

        public IEnumerable<ProspectionBrandDto> GetProspectionBrands(long prospectionId)
        {
            return this.context.ProspectionBrands
                .Select(p => new ProspectionBrandDto
                {
                    ProspectionId = p.Id,
                    BrandId = p.BrandId,
                    Sellout = p.Sellout,
                    SalesRepresentative = p.SalesRepresentative,
                    CommercialSupport = p.CommercialSupport
                }).ToList();
        }

        public IEnumerable<ProspectionBrandInterestDto> GetProspectionBrandInterests(long prospectionId)
        {
            return this.context.ProspectionBrandInterests
                .Select(p => new ProspectionBrandInterestDto
                {
                    Id = p.Id,
                    ProspectionId = p.ProspectionId,
                    BrandId = p.BrandId,
                    Sales = p.Sales
                }).ToList();
        }
        public IEnumerable<ProspectionCompetitorBrandDto> GetProspectionCompetitorBrands(long prospectionId)
        {
            return this.context.ProspectionCompetitorBrands
                .Select(p => new ProspectionCompetitorBrandDto
                {
                    Id = p.Id,
                    ProspectionId = p.ProspectionId,
                    CompetitorBrandId = p.CompetitorBrandId
                }).ToList();
        }

        // ADD -----------

        public void AddProspection(Prospection prospection)
        {
            this.context.Prospections.Add(prospection);
            this.context.SaveChanges();
        }

        // UPDATE -----------

        public void UpdateProspection(Prospection prospection)
        {
            var toUpdate = GetProspectionDetail(prospection.Id);
            toUpdate.ShopId = prospection.ShopId;
            toUpdate.UserId = prospection.UserId;
            toUpdate.Date = prospection.Date;
            toUpdate.DateLastUpdated = prospection.DateLastUpdated;
            toUpdate.ContactPersonTypeId = prospection.ContactPersonTypeId;
            toUpdate.ContactPersonName = prospection.ContactPersonName;
            toUpdate.VisitTypeId = prospection.VisitTypeId;
            toUpdate.VisitContext = prospection.VisitContext;
            toUpdate.BestBrands = prospection.BestBrands;
            toUpdate.WorstBrands = prospection.WorstBrands;
            toUpdate.BrandsOut = prospection.BrandsOut;
            toUpdate.Trends = prospection.Trends;
            toUpdate.Extra = prospection.Extra;
            this.context.SaveChanges();
        }

        // Relationships

        public void UpdateProspectionBrand(Prospection prospection)
        {
            var updateProspection = GetProspection(prospection.Id);
            updateProspection.Brands = prospection.Brands;
            this.context.SaveChanges();
        }

        public void UpdateProspectionCompetitorBrand(Prospection prospection)
        {
            var updateProspection = GetProspection(prospection.Id);
            updateProspection.CompetitorBrands = prospection.CompetitorBrands;
            this.context.SaveChanges();
        }

        public void UpdateProspectionBrandInterest(Prospection prospection)
        {
            var updateProspection = GetProspection(prospection.Id);
            updateProspection.BrandsInterest = prospection.BrandsInterest;
            this.context.SaveChanges();
        }

        // BRANDS ---------------------------------------------------------------------------------------------------------------------
        // ---------------------------------------------------------------------------------------------------------------------------

        public IEnumerable<BrandDto> GetBrands()
        {
            var brandList = context.Brands
                .Select(s => new BrandDto
                {
                    Id = s.Id,
                    Name = s.Name,
                }).ToList();

            return brandList;
        }

        public Brand GetBrand(long id)
        {
            return this.context.Brands.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<CompetitorBrandDto> GetCompetitorBrands()
        {
            var competitorBrandList = context.CompetitorBrands
                .Select(s => new CompetitorBrandDto
                {
                    Id = s.Id,
                    Name = s.Name,
                }).ToList();

            return competitorBrandList;
        }

        public CompetitorBrand GetCompetitorBrand(long id)
        {
            return this.context.CompetitorBrands.FirstOrDefault(x => x.Id == id);
        }

        // USERS ---------------------------------------------------------------------------------------------------------------------
        // ---------------------------------------------------------------------------------------------------------------------------

        public UserDto GetUserDto(long id)
        {
            var user = context.Users
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
            return this.context.Users.FirstOrDefault(x => x.Id == id);
        }

        // TYPES ---------------------------------------------------------------------------------------------------------------------
        // ---------------------------------------------------------------------------------------------------------------------------

        public IEnumerable<ProspectionContactType> GetContactPersonTypes()
        {
            var contactPersonTypesList = this.context.ProspectionContactTypes
                .Select(s => new ProspectionContactType
                {
                    Id = s.Id,
                    Name = s.Name,
                }).ToList();

            return contactPersonTypesList;
        }

        public ProspectionContactType GetContactPersonType(long id)
        {
            return this.context.ProspectionContactTypes.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<ProspectionVisitType> GetVisitTypes()
        {
            var visitTypesList = this.context.ProspectionVisitTypes
                .Select(s => new ProspectionVisitType
                {
                    Id = s.Id,
                    Name = s.Name,
                }).ToList();

            return visitTypesList;
        }

        public ProspectionVisitType GetVisitType(long id)
        {
            return this.context.ProspectionVisitTypes.FirstOrDefault(x => x.Id == id);
        }
    }
}
