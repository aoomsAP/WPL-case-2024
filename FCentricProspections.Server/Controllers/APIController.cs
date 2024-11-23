﻿using FCentricProspections.Server.DataModels;
using FCentricProspections.Server.Services;
using FCentricProspections.Server.ViewModels;
using FCentricProspections.Server.DomainModels;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

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
                shops.Add(new ShopGetAllViewModel { Id = shop.Id, Name = shop.Name });
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

            viewModel.Id = shop.Id;
            viewModel.Name = shop.Name;
            viewModel.Address = shop.Address;
            viewModel.Customer = shop.Customer.Name;

            // return viewmodel of shop
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
                // create & add prospection-brand viewmodel
                prospectionBrands.Add(new ProspectionBrandGetViewModel
                {
                    Id = prospectionBrand.Id,
                    BrandId = prospectionBrand.BrandId,
                    Sellout = prospectionBrand.Sellout,
                    SelloutRemark = prospectionBrand.SelloutRemark,
                });
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
                // create & add prospection-competitorbrand viewmodel
                prospectionCompetitorBrands.Add(new ProspectionCompetitorBrandGetViewModel
                {
                    Id = prospectionCompetitorBrand.Id,
                    CompetitorBrandId = prospectionCompetitorBrand.CompetitorBrandId,
                });
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
                // create & add prospection-brandinterest viewmodel
                prospectionBrandInterests.Add(new ProspectionBrandInterestGetViewModel
                {
                    Id = prospectionBrandInterest.Id,
                    BrandId = prospectionBrandInterest.BrandId,
                    Remark = prospectionBrandInterest.Remark
                });
            }

            // return viewmodel of prospection-brandinterest list
            return Ok(prospectionBrandInterests);
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

            // create new prospection object based on view model data
            var newProspection = new Prospection
            {
                // EF creates Id
                ShopId = viewModel.ShopId,
                Shop = this.data.GetShop(viewModel.ShopId),
                UserId = viewModel.UserId,
                User = this.data.GetUser(viewModel.UserId),
                // EMPLOYEE
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
                // TODOES
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

            // update prospection fields 
            existingProspection.ShopId = viewModel.ShopId;
            existingProspection.Shop = this.data.GetShop(viewModel.ShopId);
            existingProspection.UserId = viewModel.UserId;
            existingProspection.User = this.data.GetUser(viewModel.UserId);
            // EMPLOYEE
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


        // EMPLOYEE ------------------------------------------------------------------------------------------------------------------
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
        [Route("employees/{userId}")]
        public IActionResult GetEmployee(long userId)
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

            // for each appointment in the database, 
            var appointmentList = new List<AppointmentGetAllViewModel>();
            foreach (var app in employee.Appointments)
            {
                var appointment = this.data.GetAppointment(app.Id);
                if (appointment != null)
                {
                    
                    var viewModel = new AppointmentGetAllViewModel
                    {
                        Id = appointment.Id,
                        StartDate = appointment.StartDate,
                        EndDate = appointment.EndDate,
                        Remarks = appointment.Remarks,
                        Name = appointment.Name,
                        AppointmentState = appointment.AppointmentState.Name,
                    };
                    appointmentList.Add(viewModel);
                }               
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
