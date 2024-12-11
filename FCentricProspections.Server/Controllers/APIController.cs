using FCentricProspections.Server.DataModels;
using FCentricProspections.Server.Services;
using FCentricProspections.Server.ViewModels;
using FCentricProspections.Server.DomainModels;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Text.RegularExpressions;

namespace FCentricProspections.Server.Controllers
{
    [Route("api")]
    public class APIController : Controller
    {
        private IData data;

        public APIController(IData data)
        {
            this.data = data;
        }

        // SHOPS ------------------------------------------------------------------------------------------------------------------
        // ------------------------------------------------------------------------------------------------------------------------

        // GET

        [HttpGet()]
        [Route("shops")]
        public IActionResult GetShops()
        {
            // for each shop in the database, collect copy that adheres to viewmodel (excluding all details)
            var shops = new List<ShopGetAllViewModel>();
            foreach (var shop in this.data.GetShops())
            {
                shops.Add(new ShopGetAllViewModel { Id = shop.Id, Name = shop.Name ,City = shop.City });
            }

            // return list of viewmodel shops
            return Ok(shops);
        }

        [HttpGet()]
        [Route("shops/{id}")]
        public IActionResult GetShopDetail(long id)
        {
            var viewModel = new ShopGetDetailViewModel();

            var shop = this.data.GetShopDetail(id);
            if (shop == null)
            {
                return NotFound("Shop not found.");
            }

            var owner = this.data.GetOwner(shop.Id);

            viewModel.Id = shop.Id;
            viewModel.Name = shop.Name;
            viewModel.Address = shop.Address;

            if (shop.Customer is not null)
            {
                viewModel.Customer = shop.Customer.Name;
            }
            
            if (owner is not null)
            {
                viewModel.Owner = owner.Name;
            }
            else
            {
                viewModel.Owner = null;
            }

            if (shop.ShopTypeId is not null)
            {
                viewModel.ShopTypeId = shop.ShopTypeId;
            }           

            // return viewmodel of shop
            return Ok(viewModel);
        }

        [HttpPost()]
        [Route("shops")]
        public IActionResult CreateShop([FromBody] ShopCreateViewModel viewModel)
        {
            // check if modelstate is valid
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // check if user exists
            var user = this.data.GetUser(viewModel.UserCreatedId);
            if (user == null)
            {
                return NotFound("User not found");
            }

            // create new shop object based on view model data
            var newShop = new Shop
            {
                // EF creates Id
                ShopTypeId = 6, // hardcoded 6 = Prospect
                Name = viewModel.Name,
                UserCreatedId = viewModel.UserCreatedId,
                UserCreated = user,
                DateCreated = viewModel.DateCreated,
                IsParallelSales = false, // hardcoded
                CustomerShops = new List<CustomerShop>(),
                Prospections = new List<Prospection>(),
                ShopContacts = new List<ShopContact>(),
                ShopDeliveries = new List<ShopDelivery>(),
                ContactId = viewModel.ContactId,
                Contact = this.data.GetContact(viewModel.ContactId),
                SearchName = Regex.Replace(viewModel.Name, @"[-\s/]", ""), // Aims to filter out hyphens, whitespace and slashes
            };

            // add shop to database
            this.data.AddShop(newShop);

            // return viewmodel of object that was just created
            return CreatedAtAction(
                nameof(this.data.GetShopDetail),
                new { id = newShop.Id },
                new NewShopGetViewModel
                {
                    Id = newShop.Id,
                    ShopTypeId = newShop.ShopTypeId,
                    Name = newShop.Name,
                    UserCreatedId = newShop.UserCreatedId,
                    DateCreated = newShop.DateCreated,
                    ContactId = newShop.ContactId
                });
        }

        // ADDRESS -----------------------------------------------------------------------------------------------------------------------
        // -------------------------------------------------------------------------------------------------------------------------------

        [HttpGet()]
        [Route("addresses/{id}")]
        public IActionResult GetAddress(long id)
        {
            var viewModel = new AddressGetViewModel();

            var address = this.data.GetAddress(id);

            if (address == null)
            {
                return NotFound("Address not found");
            }

            viewModel.Id = address.Id;
            viewModel.Street1 = address.Street1;
            viewModel.PostalCode = address.PostalCode;
            viewModel.DateCreated = address.DateCreated;
            viewModel.CityId = address.CityId;

            // return viewmodel of address
            return Ok(viewModel);
        }

        [HttpGet()]
        [Route("countries")]
        public IActionResult GetCountries()
        {
            // for each country in the database, collect copy that adheres to viewmodel (excluding all details)
            var countries = new List<CountryGetViewModel>();
            foreach (var country in this.data.GetCountries())
            {
                countries.Add(new CountryGetViewModel { Id = country.Id, Name = country.Name });
            }

            // return list of viewmodel countries
            return Ok(countries);
        }

        [HttpGet()]
        [Route("countries/{countryId}/cities")]
        public IActionResult GetCities(long countryId)
        {
            var country = this.data.GetCountry(countryId);
            if (country == null)
            {
                return NotFound("Country not found");
            }

            // for each city in the database, collect copy that adheres to viewmodel (excluding all details)
            var cities = new List<CityGetViewModel>();
            foreach (var city in this.data.GetCities(countryId))
            {
                cities.Add(new CityGetViewModel { Id = city.Id, Name = city.Name, PostalCode = city.PostalCode, CountryId = city.CountryId});
            }

            // return list of viewmodel cities
            return Ok(cities);
        }

        [HttpPost()]
        [Route("addresses")]
        public IActionResult CreateAddress([FromBody] AddressCreateViewModel viewModel)
        {
            // check if modelstate is valid
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // check if user exists
            var user = this.data.GetUser(viewModel.UserCreatedId);
            if (user == null)
            {
                return NotFound("User not found");
            }

            // check if city exists
            var city = this.data.GetCity(viewModel.CityId ?? 0);
            if (city == null)
            {
                return NotFound("City not found");
            }

            // create new address object based on view model data
            var newAddress = new Address
            {
                // EF creates Id
               Name = null,
               Attention = null,
               Street1 = viewModel.Street1,
               Street2 = null,
               CityId = viewModel.CityId,
               City = city,
               PostalCode = viewModel.PostalCode,
               UserCreatedId = viewModel.UserCreatedId,
               UserCreated = user,
               DateCreated = viewModel.DateCreated,
               Contacts = new List<Contact>(),
            };

            // add address to database
            this.data.AddAddress(newAddress);

            // return viewmodel of object that was just created
            return CreatedAtAction(
                nameof(this.data.GetAddress),
                new { id = newAddress.Id },
                new AddressGetViewModel
                {
                    Id = newAddress.Id,
                    Street1 = newAddress.Street1,
                    CityId = newAddress.CityId,
                    PostalCode = newAddress.PostalCode,
                    DateCreated = newAddress.DateCreated
                });
        }

        // CONTACT -----------------------------------------------------------------------------------------------------------------------
        // -------------------------------------------------------------------------------------------------------------------------------

        [HttpGet()]
        [Route("contacts/{id}")]
        public IActionResult GetContact(long id)
        {
            var viewModel = new ContactGetViewModel();

            var contact = this.data.GetContact(id);

            if (contact == null)
            {
                return NotFound("Contact not found");
            }

            viewModel.Id = contact.Id;
            viewModel.Name = contact.Name;
            viewModel.AddressId = contact.AddressId;
            viewModel.DateCreated = contact.DateCreated;
            viewModel.UserCreatedId = contact.UserCreatedId;

            // return viewmodel of contact
            return Ok(viewModel);
        }

        [HttpPost()]
        [Route("contacts")]
        public IActionResult CreateContact([FromBody] ContactCreateViewModel viewModel)
        {
            // check if modelstate is valid
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // check if user exists
            var user = this.data.GetUser(viewModel.UserCreatedId);
            if (user == null)
            {
                return NotFound("User not found");
            }

            // check if address exists
            var address = this.data.GetAddress(viewModel.AddressId ?? 0);
            if (address == null)
            {
                return NotFound("Address not found");
            }

            // create new contact object based on view model data
            var newContact = new Contact
            {
                // EF creates Id
                FirstName = null,
                IsSupplierContact = false,
                AddressId = viewModel.AddressId,
                Remarks = null,
                IsHidden = false,
                Name = viewModel.Name,
                UserCreatedId = viewModel.UserCreatedId,
                UserCreated = user,
                DateCreated = viewModel.DateCreated,
                SearchName = null, // TO BE IMPLEMENTED
                SearchName2 = null, // TO BE IMPLEMENTED
                Address = address,
                ContactChannels = new List<ContactChannel>(),
                ShopContacts = new List<ShopContact>(),
                Shops = new List<Shop>(),
            };

            // add contact to database
            this.data.AddContact(newContact);

            // return viewmodel of object that was just created
            return CreatedAtAction(
                nameof(this.data.GetContact),
                new { id = newContact.Id },
                new ContactGetViewModel
                {
                    Id = newContact.Id,
                    AddressId = newContact.AddressId,
                    DateCreated = newContact.DateCreated,
                    UserCreatedId= newContact.UserCreatedId,
                    Name = newContact.Name
                });
        }


        // CONTACT INFO ------------------------------------------------------------------------------------------------------------------
        // -------------------------------------------------------------------------------------------------------------------------------

        [HttpGet()]
        [Route("contactinfo/{shopId}/{contactTypeId}")]
        public IActionResult GetContactInfo(long shopId, long contactTypeId)
        {
            var viewModel = new ContactInfoGetViewModel();

            var shop = this.data.GetShopDetail(shopId);
            if (shop == null)
            {
                return NotFound("Shop not found.");
            }

            var contacttype = this.data.GetContactType(contactTypeId);
            if (contacttype == null)
            {
                return UnprocessableEntity("ContactType id is not valid");
            }

            var contactinfo = this.data.GetContactInfo(shopId, contactTypeId);
            if (contactinfo == null)
            {
                return NotFound("ContactInfo not found.");
            }

            viewModel.ContactId = contactinfo.ContactId;
            viewModel.ContactTypeId = contactinfo.ContactTypeId;
            viewModel.ContactTypeName = contactinfo.ContactTypeName;
            viewModel.Name = contactinfo.Name;
            viewModel.PhoneNumber = contactinfo.PhoneNumber;
            viewModel.Email = contactinfo.Email;

            // return viewmodel of contact info
            return Ok(viewModel);
        }

        // PROSPECTIONS ------------------------------------------------------------------------------------------------------------------
        // -------------------------------------------------------------------------------------------------------------------------------

        // GET --------------------------------------------------------------

        // all prospections for a given shop
        [HttpGet()]
        [Route("shops/{id}/prospections")]
        public IActionResult GetProspections(long id)
        {
            var shop = this.data.GetShopDetail(id);
            if (shop == null)
            {
                return NotFound("Shop not found.");
            }

            var prospections = new List<ProspectionGetAllViewModel>();

            // get prospections from a shop
            foreach (var prospection in this.data.GetProspectionsByShopId(id))
            {
                // create prospection viewmodel
                prospections.Add(new ProspectionGetAllViewModel { Id = prospection.Id, VisitDate = prospection.VisitDate, ShopId = id });
            }

            // return list of viewmodel prospections
            return Ok(prospections);
        }

        [HttpGet()]
        [Route("prospections/{id}")]
        public IActionResult GetProspectionDetail(long id)
        {
            var viewModel = new ProspectionGetDetailViewModel();

            var prospection = this.data.GetProspectionDetail(id);
            if (prospection == null)
            {
                return NotFound("Prospection not found.");
            }

            viewModel.Id = prospection.Id;
            viewModel.ShopId = prospection.ShopId;
            viewModel.UserId = prospection.UserId;
            viewModel.EmployeeId = prospection.EmployeeId;
            viewModel.VisitDate = prospection.VisitDate;
            viewModel.DateLastUpdated = prospection.DateLastUpdated;
            viewModel.ContactTypeId = prospection.ContactTypeId;
            viewModel.ContactName = prospection.ContactName;
            viewModel.ContactEmail = prospection.ContactEmail;
            viewModel.ContactPhone = prospection.ContactPhone;
            viewModel.VisitTypeId = prospection.VisitTypeId;
            viewModel.VisitContext = prospection.VisitContext;
            viewModel.NewBrands = prospection.NewBrands;
            viewModel.BestBrands = prospection.BestBrands;
            viewModel.WorstBrands = prospection.WorstBrands;
            viewModel.TerminatedBrands = prospection.TerminatedBrands;
            viewModel.Trends = prospection.Trends;
            viewModel.Extra = prospection.Extra;

            // return viewmodel of prospection
            return Ok(viewModel);
        }

        // Relationships

        [HttpGet()]
        [Route("prospections/{id}/brands")]
        public IActionResult GetProspectionBrands(long id)
        {
            // check if prospection exists
            var prospection = this.data.GetProspection(id);
            if (prospection == null)
            {
                return NotFound("Prospection not found.");
            }

            var prospectionBrands = new List<ProspectionBrandGetViewModel>();

            // get brands from prospection
            foreach (var prospectionBrand in prospection.Brands)
            {
                var brand = this.data.GetBrand(prospectionBrand.BrandId);

                // create & add prospection-brand viewmodel
                prospectionBrands.Add(new ProspectionBrandGetViewModel
                {
                    Id = prospectionBrand.Id,
                    BrandId = prospectionBrand.BrandId,
                    BrandName = brand.Name,
                    Sellout = prospectionBrand.Sellout,
                    SelloutRemark = prospectionBrand.SelloutRemark,
                }); ;
            }

            // return viewmodel of prospection-brands list
            return Ok(prospectionBrands);
        }

        [HttpGet()]
        [Route("prospections/{id}/competitorbrands")]
        public IActionResult GetProspectionCompetitorBrands(long id)
        {
            // check if prospection exists
            var prospection = this.data.GetProspection(id);
            if (prospection == null)
            {
                return NotFound("Prospection not found.");
            }

            var prospectionCompetitorBrands = new List<ProspectionCompetitorBrandGetViewModel>();

            // get competitor brands from prospection
            foreach (var prospectionCompetitorBrand in prospection.CompetitorBrands)
            {
                var brand = this.data.GetCompetitorBrand(prospectionCompetitorBrand.CompetitorBrandId);

                // create & add prospection-competitorbrand viewmodel
                prospectionCompetitorBrands.Add(new ProspectionCompetitorBrandGetViewModel
                {
                    Id = prospectionCompetitorBrand.Id,
                    CompetitorBrandId = prospectionCompetitorBrand.CompetitorBrandId,
                    CompetitorBrandName = brand.Name,
                }); ;
            }

            // return viewmodel of prospection-competitorbrand list
            return Ok(prospectionCompetitorBrands);
        }

        [HttpGet()]
        [Route("prospections/{id}/brandinterests")]
        public IActionResult GetProspectionBrandInterests(long id)
        {
            // check if prospection exists
            var prospection = this.data.GetProspection(id);
            if (prospection == null)
            {
                return NotFound("Prospection not found.");
            }

            var prospectionBrandInterests = new List<ProspectionBrandInterestGetViewModel>();

            // get brands from prospection
            foreach (var prospectionBrandInterest in prospection.BrandInterests)
            {
                var brand = this.data.GetBrand(prospectionBrandInterest.BrandId);

                // create & add prospection-brandinterest viewmodel
                prospectionBrandInterests.Add(new ProspectionBrandInterestGetViewModel
                {
                    Id = prospectionBrandInterest.Id,
                    BrandId = prospectionBrandInterest.BrandId,
                    BrandName = brand.Name,
                    Remark = prospectionBrandInterest.Remark
                });
            }

            // return viewmodel of prospection-brandinterest list
            return Ok(prospectionBrandInterests);
        }

        [HttpGet()]
        [Route("prospections/{id}/todos")]
        public IActionResult GetProspectionToDos(long id)
        {
            // check if prospection exists
            var prospection = this.data.GetProspection(id);
            if (prospection == null)
            {
                return NotFound("Prospection not found.");
            }

            var prospectionToDos = new List<ProspectionToDoGetViewModel>();

            // get todos from prospection
            foreach (var prospectionToDo in prospection.ProspectionToDos)
            {
                var toDo = this.data.GetToDo(prospectionToDo.ToDoId);
                if (toDo == null)
                {
                    return NotFound("ToDo not found.");
                }

                // create & add prospection-todo viewmodel
                prospectionToDos.Add(new ProspectionToDoGetViewModel
                {
                    Id = prospectionToDo.Id,
                    ProspectionId = id,
                    ToDoId = prospectionToDo.ToDoId,
                    Remarks = toDo.Remarks,
                    EmployeeId = toDo.EmployeeId,
                    ToDoStatusId = toDo.ToDoStatus.Id,
                    ToDoStatus = toDo.ToDoStatus.Name,
                    Name = toDo.Name,
                });
            }

            // return viewmodel of prospection-todo list
            return Ok(prospectionToDos);
        }


        // POST ------------------------------------------------------------------------

        [HttpPost()]
        [Route("prospections")]
        public IActionResult CreateProspection([FromBody] ProspectionCreateViewModel viewModel)
        {
            // check if modelstate is valid
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // check if shop exists
            var shop = this.data.GetShopDetail(viewModel.ShopId);
            if (shop == null)
            {
                return NotFound("Shop not found");
            }

            var employee = this.data.GetEmployee(viewModel.EmployeeId);
            if (employee == null)
            {
                return UnprocessableEntity("Employee id is not valid");
            }

            // create new prospection object based on view model data
            var newProspection = new Prospection
            {
                // EF creates Id
                ShopId = viewModel.ShopId,
                Shop = this.data.GetShop(viewModel.ShopId),
                UserId = viewModel.UserId,
                User = this.data.GetUser(viewModel.UserId),
                EmployeeId = viewModel.EmployeeId,
                Employee = employee,
                VisitDate = viewModel.VisitDate,
                DateLastUpdated = viewModel.DateLastUpdated,
                ContactType = this.data.GetContactPersonType(viewModel.ContactTypeId),
                ContactTypeId = viewModel.ContactTypeId,
                ContactName = viewModel.ContactName,
                ContactEmail = viewModel.ContactEmail,
                ContactPhone = viewModel.ContactPhone,
                VisitType = this.data.GetVisitType(viewModel.VisitTypeId),
                VisitTypeId = viewModel.VisitTypeId,
                VisitContext = viewModel.VisitContext,
                Brands = new List<ProspectionBrand>(),
                CompetitorBrands = new List<ProspectionCompetitorBrand>(),
                NewBrands = viewModel.NewBrands,
                BestBrands = viewModel.BestBrands,
                WorstBrands = viewModel.WorstBrands,
                TerminatedBrands = viewModel.TerminatedBrands,
                BrandInterests = new List<ProspectionBrandInterest>(),
                Trends = viewModel.Trends,
                Extra = viewModel.Extra,
                ProspectionToDos = new List<ProspectionToDo>(),
            };

            // add prospection to database
            this.data.AddProspection(newProspection);

            // return viewmodel of object that was just created
            return CreatedAtAction(
                nameof(this.data.GetProspectionDetail),
                new { id = newProspection.Id },
                new ProspectionGetDetailViewModel
                {
                    Id = newProspection.Id,
                    ShopId = newProspection.ShopId,
                    UserId = newProspection.UserId,
                    EmployeeId = newProspection.EmployeeId,
                    VisitDate = newProspection.VisitDate,
                    DateLastUpdated = newProspection.DateLastUpdated,
                    ContactTypeId = newProspection.ContactTypeId,
                    ContactName = newProspection.ContactName,
                    ContactEmail = newProspection.ContactEmail,
                    ContactPhone = newProspection.ContactPhone,
                    VisitTypeId = newProspection.VisitTypeId,
                    VisitContext = newProspection.VisitContext,
                    NewBrands = newProspection.NewBrands,
                    BestBrands = newProspection.BestBrands,
                    WorstBrands = newProspection.WorstBrands,
                    TerminatedBrands = newProspection.TerminatedBrands,
                    Trends = newProspection.Trends,
                    Extra = newProspection.Extra,
                });
        }

        // PUT ----------------------------------------------------------------------------------

        [HttpPut]
        [Route("prospections")]
        public IActionResult UpdateProspection(long id, [FromBody] ProspectionUpdateViewModel viewModel)
        {
            // check if modelstate is valid
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // check if propection exists
            var existingProspection = this.data.GetProspection(id);
            if (existingProspection == null)
            {
                return NotFound("Prospection not found");
            }

            // check if shop exists
            var shop = this.data.GetShopDetail(viewModel.ShopId);
            if (shop == null)
            {
                return NotFound("Shop not found");
            }

            var employee = this.data.GetEmployee(viewModel.EmployeeId);
            if (employee == null)
            {
                return UnprocessableEntity("Employee id is not valid");
            }

            // update prospection fields 
            existingProspection.ShopId = viewModel.ShopId;
            existingProspection.Shop = this.data.GetShop(viewModel.ShopId);
            existingProspection.UserId = viewModel.UserId;
            existingProspection.User = this.data.GetUser(viewModel.UserId);
            existingProspection.EmployeeId = viewModel.EmployeeId;
            existingProspection.Employee = employee;
            existingProspection.VisitDate = viewModel.VisitDate;
            existingProspection.DateLastUpdated = viewModel.DateLastUpdated;
            existingProspection.ContactType = this.data.GetContactPersonType(viewModel.ContactTypeId);
            existingProspection.ContactTypeId = viewModel.ContactTypeId;
            existingProspection.ContactName = viewModel.ContactName;
            existingProspection.ContactEmail = viewModel.ContactEmail;
            existingProspection.ContactPhone = viewModel.ContactPhone;
            existingProspection.VisitType = this.data.GetVisitType(viewModel.VisitTypeId);
            existingProspection.VisitTypeId = viewModel.VisitTypeId;
            existingProspection.VisitContext = viewModel.VisitContext;
            existingProspection.NewBrands = viewModel.NewBrands;
            existingProspection.BestBrands = viewModel.BestBrands;
            existingProspection.WorstBrands = viewModel.WorstBrands;
            existingProspection.TerminatedBrands = viewModel.TerminatedBrands;
            existingProspection.Trends = viewModel.Trends;
            existingProspection.Extra = viewModel.Extra;

            // update in database 
            this.data.UpdateProspection(existingProspection);
            return NoContent();
        }

        // RELATIONSHIPS

        [HttpPut()]
        [Route("prospections/{id}/brands")]
        public IActionResult UpdateProspectionBrands(long id, [FromBody] ProspectionBrandUpdateViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            };

            // check if prospection exists
            var existingProspection = this.data.GetProspection(id);
            if (existingProspection == null)
            {
                return NotFound("Prospection not found");
            }

            // update relationship between Prospection and Brand
            var updatedProspectionBrands = new List<ProspectionBrand>();
            foreach (ProspectionBrandGetViewModel b in viewModel.ProspectionBrands)
            {
                // check if brand exists
                var brand = this.data.GetBrand(b.BrandId);
                if (brand == null)
                {
                    return NotFound("Brand not found");
                }

                // create new prospection-brand relationship
                var prospectionBrand = new ProspectionBrand
                {
                    // EF creates Id
                    BrandId = b.BrandId,
                    ProspectionId = id,
                    Brand = brand,
                    Prospection = existingProspection,
                    Sellout = b.Sellout,
                    SelloutRemark = b.SelloutRemark,
                };

                // add relationship to list of relationships
                updatedProspectionBrands.Add(prospectionBrand);
            }

            // update Brands relationships list on the prospection
            existingProspection.Brands = updatedProspectionBrands;

            // update prospection in database
            this.data.UpdateProspectionBrand(existingProspection);
            return NoContent();
        }

        [HttpPut()]
        [Route("prospections/{id}/competitorbrands")]
        public IActionResult UpdateProspectionCompetitorBrands(long id, [FromBody] ProspectionCompetitorBrandUpdateViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            };

            // check if prospection exists
            var existingProspection = this.data.GetProspection(id);
            if (existingProspection == null)
            {
                return NotFound("Prospection not found");
            }

            // update relationship between Prospection and CompetitorBrand
            var updatedProspectionCompetitorBrands = new List<ProspectionCompetitorBrand>();
            foreach (var competitorBrandId in viewModel.CompetitorBrandIds)
            {
                // check if competitor brand exists
                var competitorBrand = this.data.GetCompetitorBrand(competitorBrandId);
                if (competitorBrand == null)
                {
                    return NotFound("Competitor Brand not found");
                }

                // create new prospection-competitorbrand relationship
                var prospectionCompetitorBrand = new ProspectionCompetitorBrand
                {
                    // EF creates Id
                    CompetitorBrandId = competitorBrandId,
                    CompetitorBrand = competitorBrand,
                    ProspectionId = id,
                    Prospection = existingProspection,
                };

                // add relationship to list of relationships
                updatedProspectionCompetitorBrands.Add(prospectionCompetitorBrand);
            }

            // update CompetitorBrands relationships list on the prospection
            existingProspection.CompetitorBrands = updatedProspectionCompetitorBrands;

            // update prospection in database
            this.data.UpdateProspectionCompetitorBrand(existingProspection);
            return NoContent();
        }

        [HttpPut()]
        [Route("prospections/{id}/brandinterests")]
        public IActionResult UpdateProspectionBrandInterests(long id, [FromBody] ProspectionBrandInterestUpdateViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            };

            // check if prospection exists
            var existingProspection = this.data.GetProspection(id);
            if (existingProspection == null)
            {
                return NotFound("Prospection not found");
            }

            // update relationship between Prospection and Brand (interest)
            var updatedProspectionBrandInterests = new List<ProspectionBrandInterest>();
            foreach (var brandInterest in viewModel.ProspectionBrandInterests)
            {
                // check if brand exists
                var brand = this.data.GetBrand(brandInterest.BrandId);
                if (brand == null)
                {
                    return NotFound("Brand not found");
                }

                // create new prospection-brand (interest) relationship
                var prospectionBrandInterest = new ProspectionBrandInterest
                {
                    // EF creates Id
                    BrandId = brandInterest.BrandId,
                    Brand = brand,
                    ProspectionId = id,
                    Prospection = existingProspection,
                    Remark = brandInterest.Remark,
                };

                // add relationship to list of relationships
                updatedProspectionBrandInterests.Add(prospectionBrandInterest);
            }

            // update BrandsInterest relationships list on the prospection
            existingProspection.BrandInterests = updatedProspectionBrandInterests;

            // update prospection in database
            this.data.UpdateProspectionBrandInterest(existingProspection);
            return NoContent();
        }

        [HttpPut()]
        [Route("prospections/{id}/todos")]
        public IActionResult UpdateProspectionToDos(long id, [FromBody] ProspectionToDoUpdateViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            };

            // check if prospection exists
            var existingProspection = this.data.GetProspection(id);
            if (existingProspection == null)
            {
                return NotFound("Prospection not found");
            }

            // update relationship between Prospection and ToDo 
            var updatedProspectionToDos = new List<ProspectionToDo>();
            foreach (var toDoId in viewModel.ToDoIds)
            {
                // check if todo exists
                var toDo = this.data.GetToDo(toDoId);
                if (toDo == null)
                {
                    return NotFound("ToDo not found");
                }

                // create new prospection-todo relationship
                var prospectionToDo = new ProspectionToDo
                {
                    // EF creates Id
                    ToDoId = toDo.Id,
                    ToDo = toDo,
                    ProspectionId = id,
                    Prospection = existingProspection,
                };

                // add relationship to list of relationships
                updatedProspectionToDos.Add(prospectionToDo);
            }

            // update BrandsInterest relationships list on the prospection
            existingProspection.ProspectionToDos = updatedProspectionToDos;

            // update prospection in database
            this.data.UpdateProspectionToDo(existingProspection);
            return NoContent();
        }

        // TODOS ------------------------------------------------------------------------------------------------------------------
        // -------------------------------------------------------------------------------------------------------------------------

        // GET

        [HttpGet()]
        [Route("todos")]
        public IActionResult GetToDos()
        {
            // for each brand in the database, collect copy that adheres to viewmodel (excluding all details)
            var toDos = new List<ToDoGetViewModel>();
            foreach (var toDo in this.data.GetToDos())
            {
                toDos.Add(new ToDoGetViewModel { Id = toDo.Id, Remarks = toDo.Remarks, Name = toDo.Name, EmployeeId = toDo.EmployeeId, ToDoStatus = toDo.ToDoStatus.Name, ToDoStatusId = toDo.ToDoStatus.Id });
            }

            // return list of viewmodel brand
            return Ok(toDos);
        }

        [HttpGet()]
        [Route("todos/{id}")]
        public IActionResult GetToDo(long id)
        {
            var viewModel = new ToDoGetViewModel();

            var toDo = this.data.GetToDo(id);
            if (toDo == null)
            {
                return NotFound("ToDo not found.");
            }

            viewModel.Id = toDo.Id;
            viewModel.Remarks = toDo.Remarks;
            viewModel.EmployeeId = toDo.EmployeeId;
            viewModel.ToDoStatusId = toDo.ToDoStatus.Id;
            viewModel.ToDoStatus = toDo.ToDoStatus.Name;
            viewModel.Name = toDo.Name;

            // return list of viewmodel brand
            return Ok(viewModel);
        }

        // POST

        [HttpPost()]
        [Route("todos")]
        public IActionResult CreateToDo([FromBody] ToDoCreateViewModel viewModel)
        {
            // check if modelstate is valid
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employee = this.data.GetEmployee(viewModel.EmployeeId ?? 0);
            if (employee == null)
            {
                return UnprocessableEntity("Employee id is not valid");
            }

            // create new todo object based on view model data
            var newToDo = new ToDo
            {
                // EF creates Id
                Remarks = viewModel.Remarks,
                EmployeeId = viewModel.EmployeeId,
                Employee = employee,
                ToDoStatusId = viewModel.ToDoStatusId,
                ToDoStatus = this.data.GetToDoStatus(viewModel.ToDoStatusId),
                Name = viewModel.Name,
                UserCreatedId = viewModel.UserCreatedId,
                UserCreated = this.data.GetUser(viewModel.UserCreatedId),
                DateCreated = viewModel.DateCreated,
            };

            // add todo to database
            this.data.AddToDo(newToDo);

            // return viewmodel of object that was just created
            return CreatedAtAction(
                nameof(this.data.GetToDo),
                new { id = newToDo.Id },
                new ToDoGetViewModel
                {
                    Id = newToDo.Id,
                    Remarks = newToDo.Remarks,
                    EmployeeId = newToDo.EmployeeId,
                    ToDoStatus = newToDo.ToDoStatus.Name,
                    Name = newToDo.Name,
                });
        }


        // BRANDS ------------------------------------------------------------------------------------------------------------------
        // -------------------------------------------------------------------------------------------------------------------------

        // GET

        [HttpGet()]
        [Route("brands")]
        public IActionResult GetBrands()
        {
            // for each brand in the database, collect copy that adheres to viewmodel (excluding all details)
            var brands = new List<BrandGetAllViewModel>();
            foreach (var brand in this.data.GetBrands())
            {
                brands.Add(new BrandGetAllViewModel { Id = brand.Id, Name = brand.Name });
            }

            // return list of viewmodel brand
            return Ok(brands);
        }

        [HttpGet()]
        [Route("competitorbrands")]
        public IActionResult GetCompetitorBrands()
        {
            // for each competitor brand in the database, collect copy that adheres to viewmodel (excluding all details)
            var competitorbrands = new List<CompetitorBrandGetAllViewModel>();
            foreach (var competitorBrand in this.data.GetCompetitorBrands())
            {
                competitorbrands.Add(new CompetitorBrandGetAllViewModel { Id = competitorBrand.Id, Name = competitorBrand.Name });
            }

            // return list of viewmodel competitor brand
            return Ok(competitorbrands);
        }

        // USERS ---------------------------------------------------------------------------------------------------------------------
        // ---------------------------------------------------------------------------------------------------------------------------

        [HttpGet()]
        [Route("users")]
        public IActionResult GetUsers()
        {
            // for each user in the database, 
            var userList = new List<UsersGetAllViewModel>();
            foreach (var user in this.data.GetUsers())
            {
                userList.Add(new UsersGetAllViewModel { Id = user.Id, Login = user.Login, Blocked = user.Blocked });
            }

            // return list of viewmodel user
            return Ok(userList);
        }

        [HttpGet()]
        [Route("users/{id}")]
        public IActionResult GetUser(long id)
        {
            var viewModel = new UserGetViewModel();

            var user = this.data.GetUser(id);
            if (user == null)
            {
                return NotFound("User not found");

            }
            viewModel.Id = id;
            viewModel.Login = user.Login;
            viewModel.Blocked = user.Blocked;

            return Ok(viewModel);
        }


        // EMPLOYEES ------------------------------------------------------------------------------------------------------------------
        // -------------------------------------------------------------------------------------------------------------------------

        [HttpGet()]
        [Route("employees")]
        public IActionResult GetEmployees()
        {
            // for each user in the database, 
            var employeeList = new List<EmployeeGetAllViewModel>();
            foreach (var employee in this.data.GetEmployees())
            {
                employeeList.Add(new EmployeeGetAllViewModel { Id = employee.Id, FirstName = employee.FirstName, Name = employee.Name, UserId = employee.UserId });
            }

            // return list of viewmodel user
            return Ok(employeeList);
        }

        [HttpGet()]
        [Route("employees/{id}")]
        public IActionResult GetEmployee(long id)
        {
            var viewModel = new EmployeeGetViewModel();

            var employee = this.data.GetEmployee(id);
            if (employee == null)
            {
                return NotFound("Employee not found");

            }
            viewModel.Id = employee.Id;
            viewModel.Name = employee.Name;
            viewModel.FirstName = employee.FirstName;
            viewModel.UserId = employee.UserId;

            return Ok(viewModel);
        }

        [HttpGet()]
        [Route("employees/user/{userId}")]
        public IActionResult GetEmployeeByUserId(long userId)
        {
            var viewModel = new EmployeeGetViewModel();

            var employee = this.data.GetEmployeeByUserId(userId);
            if (employee == null)
            {
                return NotFound("Employee not found");

            }
            viewModel.Id = employee.Id;
            viewModel.Name = employee.Name;
            viewModel.FirstName = employee.FirstName;
            viewModel.UserId = employee.UserId;

            return Ok(viewModel);
        }

        // APPOINTMENTS ------------------------------------------------------------------------------------------------------------------
        // -------------------------------------------------------------------------------------------------------------------------

        [HttpGet()]
        [Route("employees/{id}/appointments")]
        public IActionResult GetAppointmentsByEmployeeId(long id)
        {
            var employee = this.data.GetEmployeeWithAppointments(id);
            if (employee == null)
            {
                return NotFound("Employee not found");
            }

            var appointments = this.data.GetAppointmentsByEmployeeId(id);

            // for each appointment in the database, 
            var appointmentList = new List<AppointmentGetAllViewModel>();
            foreach (var app in appointments)
            {
                var viewModel = new AppointmentGetAllViewModel
                {
                    Id = app.Id,
                    EmployeeId = app.EmployeeId,
                    StartDate = app.StartDate,
                    EndDate = app.EndDate,
                    Remarks = app.Remarks,
                    Name = app.Name,
                    AppointmentState = app.AppointmentState.Name,
                };
                appointmentList.Add(viewModel);
            }

            // return list of viewmodel user
            return Ok(appointmentList);
        }

        [HttpGet()]
        [Route("appointments/{id}")]
        public IActionResult GetAppointment(long id)
        {
            var viewModel = new AppointmentGetViewModel();

            var appointment = this.data.GetAppointment(id);
            if (appointment == null)
            {
                return NotFound("Appointment not found");
            }

            viewModel.Id = id;
            viewModel.Remarks = appointment.Remarks;
            viewModel.Name = appointment.Name;
            viewModel.StartDate = appointment.StartDate;
            viewModel.EndDate = appointment.EndDate;
            viewModel.EmployeeId = appointment.EmployeeId;
            viewModel.AppointmentState = appointment.AppointmentState.Name;

            return Ok(viewModel);
        }

        // all brands for a given shop
        [HttpGet()]
        [Route("shops/{id}/brands")]
        public IActionResult GetShopBrands(long id)
        {
            var shop = this.data.GetShopDetail(id);
            if (shop == null)
            {
                return NotFound("Shop not found.");
            }

            var brands = new List<BrandGetAllViewModel>();

            // get prospections from a shop
            foreach (var brand in this.data.GetBrandsByShop(id))
            {
                // create prospection viewmodel
                brands.Add(new BrandGetAllViewModel { Id = brand.Id, Name = brand.Name });
            }

            // return list of viewmodel prospections
            return Ok(brands);
        }

        // TYPES ------------------------------------------------------------------------------------------------------------------
        // -------------------------------------------------------------------------------------------------------------------------

        [HttpGet()]
        [Route("contacttypes")]
        public IActionResult GetContactTypes()
        {
            var types = new List<ContactTypesGetViewModel>();
            foreach (var type in this.data.GetContactPersonTypes())
            {
                types.Add(new ContactTypesGetViewModel { Id = type.Id, Name = type.Name });
            }

            return Ok(types);
        }

        [HttpGet()]
        [Route("visittypes")]
        public IActionResult GetVisitTypes()
        {
            var types = new List<VisitTypesGetViewModel>();
            foreach (var type in this.data.GetVisitTypes())
            {
                types.Add(new VisitTypesGetViewModel { Id = type.Id, Name = type.Name });
            }

            return Ok(types);
        }
    }
}
