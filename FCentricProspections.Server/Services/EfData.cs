using FCentricProspections.Server.DataModels;
using FCentricProspections.Server.Contexts;
using Microsoft.EntityFrameworkCore;
using FCentricProspections.Server.DomainModels;
using System.Net;
using System.Linq;

namespace FCentricProspections.Server.Services
{
    public class EfData : IData
    {
        private Contexts.FCentricContext context;

        public EfData(Contexts.FCentricContext context)
        {
            this.context = context;
        }

        public IEnumerable<ShopListDto> GetShops()
        {
            DateTime oneYearAgo = DateTime.Now.AddYears(-1);

            // First, get the shops created in the last year and project them into ShopListDto
            var recentShops = (from shop in context.Shops
                               where shop.DateCreated > oneYearAgo
                               join contact in context.Contacts on shop.ContactId equals contact.Id
                               join address in context.Addresses on contact.AddressId equals address.Id
                               join city in context.Cities on address.CityId equals city.Id
                               join country in context.Countries on city.CountryId equals country.Id
                               select new ShopListDto
                               {
                                   Name = shop.Name,
                                   Id = shop.Id,
                                   City = city.Name
                               }).ToList(); // Materialize recent shops into memory

            // Second, get the shops associated with fashion documents with a SalesPeriodId > 63
            var fashionDocumentShops = (from fashionDocument in context.FashionDocuments
                                        where fashionDocument.SalesPeriodId > 63
                                        join fashionDocumentShop in context.FashionDocumentShops on fashionDocument.Id equals fashionDocumentShop.FashionDocument_Id
                                        join shop in context.Shops on fashionDocumentShop.ShopId equals shop.Id
                                        join contact in context.Contacts on shop.ContactId equals contact.Id
                                        join address in context.Addresses on contact.AddressId equals address.Id
                                        join city in context.Cities on address.CityId equals city.Id
                                        join country in context.Countries on city.CountryId equals country.Id
                                        select new ShopListDto
                                        {
                                            Name = shop.Name,
                                            Id = shop.Id,
                                            City = city.Name
                                        }).Distinct().ToList(); // Materialize fashion document shops into memory

            // Combine recent shops and those linked with a valid fashion document
            var shopList = recentShops
                .Union(fashionDocumentShops)  // Combine the two lists
                .Distinct()  // Ensure uniqueness
                .OrderBy(shop => shop.Name)  // Order by name descending
                .ThenBy(city => city.Name)
                .ToList();

            return shopList;
        }


        public ShopDetailDto GetShopDetail(long id)
        {
            var shopDetail = (from s in this.context.Shops
                              join contact in this.context.Contacts on s.ContactId equals contact.Id
                              join address in this.context.Addresses on contact.AddressId equals address.Id
                              join city in this.context.Cities on address.CityId equals city.Id
                              join country in this.context.Countries on city.CountryId equals country.Id
                              join customerShop in this.context.CustomerShops.Where(cs => cs.IsActive == true)
                                    on s.Id equals customerShop.ShopId into customerShopGroup
                              from customerShop in customerShopGroup.DefaultIfEmpty() // Left join for customerShop, so it's allowed to be empty
                              join customer in this.context.Customers on customerShop.CustomerId equals customer.Id into customerGroup
                              from customer in customerGroup.DefaultIfEmpty() // Left join for customer, so it's allowed if customer does not exist
                              join shopType in this.context.ShopTypes on s.ShopTypeId equals shopType.Id into shopTypeGroup
                              from shopType in shopTypeGroup.DefaultIfEmpty() // Left join for shopType, so it's allowed to be empty
                              where s.Id == id
                              select new ShopDetailDto
                              {
                                  Id = s.Id,
                                  Name = s.Name,
                                  Address = new AddressDto
                                  {
                                      Id = address.Id,
                                      Street1 = address.Street1,
                                      Street2 = address.Street2,
                                      PostalCode = address.PostalCode,
                                      City = city.Name,
                                      Country = country.Name
                                  },
                                  Customer = customer == null ? null : new CustomerDto
                                  {
                                      Id = customer.Id,
                                      Name = customer.Name
                                  },
                                  ShopTypeId = shopType.Id,
                              }).SingleOrDefault();

            return shopDetail;
        }

        public Shop GetShop(long id)
        {
            return this.context.Shops
                .Include(s => s.Prospections)
                .FirstOrDefault(x => x.Id == id);
        }

        public void AddShop(Shop shop)
        {
            this.context.Shops.Add(shop);
            this.context.SaveChanges();
        }


        // ADDRESS ---------------------------------------------------------------------------------------------------------------------
        // ---------------------------------------------------------------------------------------------------------------------------

        public Address GetAddress(long id)
        {
            return this.context.Addresses
                .Include(a => a.City)
                .ThenInclude(a => a.Country)
                .FirstOrDefault(a => a.Id == id);
        }

        public void AddAddress(Address address)
        {
            this.context.Addresses.Add(address);
            this.context.SaveChanges();
        }

        public Contact GetContact(long id)
        {
            return this.context.Contacts
                .Include(c => c.Address)
                .FirstOrDefault(c => c.Id == id);
        }

        public void AddContact(Contact contact)
        {
            this.context.Contacts.Add(contact);
            this.context.SaveChanges();
        }

        public City GetCity(long id)
        {
            return this.context.Cities
                .Include(c => c.Country)
                .FirstOrDefault(c => c.Id == id);
        }
        public IEnumerable<CityDto> GetCities(long countryId)
        {
            return this.context.Cities
                .Include(c => c.Country)
                .Where(c => c.CountryId == countryId)
                .Select(c => new CityDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    CountryId = c.CountryId,
                    Country = new CountryDto
                    {
                        Id = c.Country.Id,
                        Name = c.Country.Name
                    },
                    PostalCode = c.PostalCode,
                }).ToList();
        }

        public Country GetCountry(long id)
        {
            return this.context.Countries
                .FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<CountryDto> GetCountries()
        {
            var countryList = context.Countries
                .Select(s => new CountryDto
                {
                    Id = s.Id,
                    Name = s.Name
                }).ToList();

            return countryList;
        }



        // CONTACT INFO ---------------------------------------------------------------------------------------------------------------------
        // ---------------------------------------------------------------------------------------------------------------------------

        public OwnerDto GetOwner(long id)
        {
            var owner = (from sc in this.context.ShopContacts
                         join c in this.context.Contacts on sc.ContactId equals c.Id
                         where sc.Shop_Id == id && sc.ContactTypeId == 5
                         select new OwnerDto
                         {
                             Id = sc.ContactId,
                             Name = c.Name
                         })
                         .FirstOrDefault();

            return owner;
        }

        public ContactType GetContactType(long id)
        {
            var contacttype = this.context.ContactTypes
                         .FirstOrDefault(x => x.Id == id);

            return contacttype;
        }

        public ContactInfoDto GetContactInfo(long shopId, long contactTypeId)
        {
            var contactInfo =
              (from shop in this.context.Shops

               join shopContact in this.context.ShopContacts on shop.Id equals shopContact.Shop_Id

               join contactType in this.context.ContactTypes on shopContact.ContactTypeId equals contactType.Id

               join contact in this.context.Contacts on shopContact.ContactId equals contact.Id

               join phoneGroup in this.context.ContactChannels.Where(cc => cc.ContactChannelDescriptionId == 1)
                   on shopContact.ContactId equals phoneGroup.Contact_Id into phoneJoin
               from phone in phoneJoin.DefaultIfEmpty() // Left join for phone

               join emailGroup in this.context.ContactChannels.Where(cc => cc.ContactChannelDescriptionId == 3)
                   on shopContact.ContactId equals emailGroup.Contact_Id into emailJoin
               from email in emailJoin.DefaultIfEmpty() // Left join for email

               where shop.Id == shopId && shopContact.ContactTypeId == contactTypeId

               select new ContactInfoDto
               {
                   ContactId = contact.Id,
                   ContactTypeId = contactType.Id,
                   ContactTypeName = contactType.Name,
                   Name = contact.Name,
                   PhoneNumber = phone != null ? phone.Value : null,
                   Email = email != null ? email.Value : null,
               })
              .FirstOrDefault();

            return contactInfo;
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
                        VisitDate = s.VisitDate,
                    }).ToList();

            return prospectionsList;
        }

        public IEnumerable<ProspectionListDto> GetProspectionsByUserId(long userId)
        {
            var prospectionsList = context.Prospections
                    .Where(p => p.UserCreatedId == userId)
                    .Select(s => new ProspectionListDto
                    {
                        Id = s.Id,
                        VisitDate = s.VisitDate,
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
                                     join user in this.context.Users on p.UserCreatedId equals user.Id
                                     join employee in this.context.Employees on p.EmployeeId equals employee.Id
                                     join contact in this.context.ProspectionContactTypes on p.ContactTypeId equals contact.Id
                                     join visit in this.context.ProspectionVisitTypes on p.VisitTypeId equals visit.Id
                                     where p.Id == prospectionId
                                     select new ProspectionDetailDto
                                     {
                                         Id = p.Id,
                                         ShopId = p.ShopId,
                                         Shop = new ShopListDto { Id = p.ShopId, Name = shop.Name },
                                         UserCreatedId = p.UserCreatedId,
                                         UserCreated = new User { Id = p.ShopId, Login = user.Login, Blocked = user.Blocked },
                                         EmployeeId = p.EmployeeId,
                                         Employee = new Employee { Id = p.EmployeeId, Name = employee.Name, FirstName = employee.FirstName, UserId = employee.UserId },
                                         VisitDate = p.VisitDate,
                                         DateCreated = p.DateCreated,
                                         DateLastUpdated = p.DateLastUpdated,
                                         ContactTypeId = p.ContactTypeId,
                                         ContactType = new ProspectionContactType { Id = p.ContactTypeId, Name = contact.Name },
                                         ContactName = p.ContactName,
                                         ContactEmail = p.ContactEmail,
                                         ContactPhone = p.ContactPhone,
                                         VisitTypeId = p.VisitTypeId,
                                         VisitType = new ProspectionVisitType { Id = p.VisitTypeId, Name = visit.Name },
                                         VisitContext = p.VisitContext,
                                         NewBrands = p.NewBrands,
                                         BestBrands = p.BestBrands,
                                         WorstBrands = p.WorstBrands,
                                         TerminatedBrands = p.TerminatedBrands,
                                         Trends = p.Trends,
                                         Extra = p.Extra,
                                     }).SingleOrDefault();

            return prospectionDetail;
        }

        public Prospection GetProspection(long id)
        {
            return this.context.Prospections
                 .Include(p => p.Shop)
                 .Include(p => p.UserCreated)
                 .Include(p => p.Employee)
                 .Include(p => p.ContactType)
                 .Include(p => p.VisitType)
                 .Include(p => p.Brands)
                 .Include(p => p.CompetitorBrands)
                 .Include(p => p.BrandInterests)
                 .Include(p => p.ProspectionToDos)
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
                    SelloutRemark = p.SelloutRemark,
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
                    Remark = p.Remark
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

        public IEnumerable<ProspectionToDo> GetProspectionToDos(long prospectionId)
        {
            return this.context.ProspectionToDos
                .Where(p => p.ProspectionId == prospectionId)
                .Include(p => p.ToDo).ToList();
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
            toUpdate.UserCreatedId = prospection.UserCreatedId;
            toUpdate.EmployeeId = prospection.EmployeeId;
            toUpdate.VisitDate = prospection.VisitDate;
            toUpdate.DateCreated = prospection.DateCreated;
            toUpdate.DateLastUpdated = prospection.DateLastUpdated;
            toUpdate.ContactTypeId = prospection.ContactTypeId;
            toUpdate.ContactName = prospection.ContactName;
            toUpdate.ContactEmail = prospection.ContactEmail;
            toUpdate.ContactPhone = prospection.ContactPhone;
            toUpdate.VisitTypeId = prospection.VisitTypeId;
            toUpdate.VisitContext = prospection.VisitContext;
            toUpdate.NewBrands = prospection.NewBrands;
            toUpdate.BestBrands = prospection.BestBrands;
            toUpdate.WorstBrands = prospection.WorstBrands;
            toUpdate.TerminatedBrands = prospection.TerminatedBrands;
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
            updateProspection.BrandInterests = prospection.BrandInterests;
            this.context.SaveChanges();
        }

        public void UpdateProspectionToDo(Prospection prospection)
        {
            var updateProspection = GetProspection(prospection.Id);
            updateProspection.ProspectionToDos = prospection.ProspectionToDos;
            this.context.SaveChanges();
        }


        // TODOS ---------------------------------------------------------------------------------------------------------------------
        // ---------------------------------------------------------------------------------------------------------------------------

        public IEnumerable<ToDo> GetToDos()
        {
            return this.context.ToDos
                .Include(t => t.ToDoStatus)
                .Include(t => t.ToDoType)
                .Include(t => t.ToDoEmployees)
                .ToList();
        }

        public ToDo GetToDo(long id)
        {
            return this.context.ToDos
                .Include(t => t.ToDoStatus)
                .Include(t => t.ToDoType)
                .Include(t => t.ToDoEmployees)
                .FirstOrDefault(x => x.Id == id);
        }

        public ToDoStatus GetToDoStatus(long id)
        {
            return this.context.ToDoStatuses
                .FirstOrDefault(x => x.Id == id);
        }

        public ToDoType GetToDoType(long id)
        {
            return this.context.ToDoTypes
                .FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<ToDoEmployee> GetToDoEmployees(long id)
        {
            return this.context.ToDoEmployees
                .Where(t => t.Id == id)
                .Include(t => t.ToDo)
                .Include(t => t.Employee)
                .ToList();
        }

        public void AddToDo(ToDo toDo)
        {
            this.context.ToDos.Add(toDo);
            this.context.SaveChanges();
        }

        public void UpdateToDoEmployee(ToDo toDo)
        {
            var updateToDo = GetToDo(toDo.Id);
            updateToDo.ToDoEmployees = toDo.ToDoEmployees;
            this.context.SaveChanges();
        }

        // BRANDS ---------------------------------------------------------------------------------------------------------------------
        // ---------------------------------------------------------------------------------------------------------------------------

        public IEnumerable<BrandDto> GetBrands()
        {
            var brandList = (from sd in this.context.ShopDeliveries
                             join pld in this.context.ProductLineDeliveries on sd.ProductLineDeliveryId equals pld.Id
                             join pl in this.context.ProductLines on pld.ProductLineId equals pl.Id
                             join b in this.context.Brands on pl.BrandId equals b.Id
                             where sd.SalesPeriodId >= 64
                             select new BrandDto
                             {
                                 Id = b.Id,
                                 Name = b.Name,
                             })
                             .Distinct()
                             .OrderBy(b => b.Name)
                             .ToList();

            return brandList;
        }

        public Brand GetBrand(long id)
        {
            return this.context.Brands.FirstOrDefault(x => x.Id == id);
        }


        public IEnumerable<BrandDto> GetBrandsByShop(long shopId)
        {
            var brandList = (from sd in this.context.ShopDeliveries
                             join pld in this.context.ProductLineDeliveries on sd.ProductLineDeliveryId equals pld.Id
                             join pl in this.context.ProductLines on pld.ProductLineId equals pl.Id
                             join b in this.context.Brands on pl.BrandId equals b.Id
                             where sd.ShopId == shopId && (sd.SalesPeriodId == 66 || sd.SalesPeriodId == 67)
                             select new BrandDto
                             {
                                 Id = b.Id,
                                 Name = b.Name,
                             })
                             .Distinct()
                             .ToList();

            return brandList;
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


        public IEnumerable<UserDto> GetUsers()
        {
            var UserList = context.Users
                .Select(s => new UserDto
                {
                    Id = s.Id,
                    Login = s.Login,
                    Blocked = s.Blocked,

                }).ToList();

            return UserList;
        }

        public Employee GetEmployee(long id)
        {
            return this.context.Employees
                .FirstOrDefault(x => x.Id == id);
        }

        public Employee GetEmployeeByUserId(long userId)
        {
            return this.context.Employees
                .FirstOrDefault(x => x.UserId == userId);
        }

        public EmployeeDto GetEmployeeWithAppointments(long id)
        {
            // TEMPORARY TIME LIMIT

            var startOf2024 = new DateTime(2024, 1, 1);

            return this.context.Employees
                .Where(e => e.Id == id)
                .Select(e => new EmployeeDto
                {
                    Id = e.Id,
                    FirstName = e.FirstName,
                    Name = e.Name,
                    UserId = e.UserId,
                    Appointments = e.Appointments
                        .Where(a => a.StartDate >= startOf2024 || a.EndDate >= startOf2024)
                        .ToList()
                })
                .FirstOrDefault();
        }


        public IEnumerable<EmployeeDto> GetEmployees()
        {
            var EmployeeList = context.Employees
                .Select(s => new EmployeeDto
                {
                    Id = s.Id,
                    FirstName = s.FirstName,
                    Appointments = s.Appointments,
                    Name = s.Name,
                    UserId = s.Id,
                }).ToList();

            return EmployeeList;
        }

        //Appointments-------------------------------------------------------------------------------------------------------------------
        // ------------------------------------------------------------------------------------------------------------------------------

        public Appointment GetAppointment(long id)
        {
            return this.context.Appointments
                .Include(a => a.AppointmentState).FirstOrDefault(a => a.Id == id);
        }


        public IEnumerable<Appointment> GetAppointments()
        {
            return this.context.Appointments
                .Include(a => a.AppointmentState)
                .ToList();
        }

        public IEnumerable<Appointment> GetAppointmentsByEmployeeId(long employeeId)
        {
            // TEMPORARY TIME LIMIT

            var startOf2024 = new DateTime(2024, 1, 1);

            return this.context.Appointments
                .Where(e => e.EmployeeId == employeeId)
                .Where(e => e.IsDeleted == false)
                .Where(a => a.StartDate >= startOf2024 || a.EndDate >= startOf2024)
                .Include(a => a.AppointmentState)
                .ToList();
        }

        public AppointmentState GetAppointmentState(long id)
        {
            return this.context.AppointmentStates
                .FirstOrDefault(a => a.Id == id);
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
