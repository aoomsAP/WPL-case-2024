using FCentricProspections.Server.DataModels;
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
            viewModel.Date = prospection.Date;
            viewModel.DateLastUpdated = prospection.DateLastUpdated;
            viewModel.ContactPersonTypeId = prospection.ContactPersonTypeId;
            viewModel.ContactPersonName = prospection.ContactPersonName;
            viewModel.VisitTypeId = prospection.VisitTypeId;
            viewModel.VisitContext = prospection.VisitContext;
            viewModel.BestBrands = prospection.BestBrands;
            viewModel.WorstBrands = prospection.WorstBrands;
            viewModel.BrandsOut = prospection.BrandsOut;
            viewModel.Trends = prospection.Trends;
            viewModel.Extra = prospection.Extra;

            // return viewmodel of prospection
            return Ok(viewModel);
        }

        [HttpGet()]
        [Route("prospections")]
        public IActionResult GetProspections(long shopId)
        {
            var prospections = new List<ProspectionGetAllViewModel>();

            // get prospections from a shop
            foreach (var prospection in this.data.GetProspectionsByShopId(shopId))
            {
                // create prospection viewmodel
                prospections.Add(new ProspectionGetAllViewModel { Id = prospection.Id, Date = prospection.Date, ShopId = shopId });
            }

            // return list of viewmodel prospections
            return Ok(prospections);
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
            foreach (var brand in prospection.Brands)
            {
                // create & add prospection-brand viewmodel
                prospectionBrands.Add(new ProspectionBrandGetViewModel
                {
                    BrandId = brand.BrandId,
                    Sellout = brand.Sellout,
                    SalesRepresentative = brand.SalesRepresentative,
                    CommercialSupport = brand.CommercialSupport,
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
            foreach (var competitorBrand in prospection.CompetitorBrands)
            {
                // create & add prospection-competitorbrand viewmodel
                prospectionCompetitorBrands.Add(new ProspectionCompetitorBrandGetViewModel
                {
                    CompetitorBrandId = competitorBrand.CompetitorBrandId,
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
            foreach (var brandInterest in prospection.BrandsInterest)
            {
                // create & add prospection-brandinterest viewmodel
                prospectionBrandInterests.Add(new ProspectionBrandInterestGetViewModel
                {
                    BrandId = brandInterest.BrandId,
                    Sales = brandInterest.Sales
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
                Date = viewModel.Date,
                DateLastUpdated = viewModel.DateLastUpdated,
                ContactPersonType = this.data.GetContactPersonType(viewModel.ContactPersonTypeId),
                ContactPersonTypeId = viewModel.ContactPersonTypeId,
                ContactPersonName = viewModel.ContactPersonName,
                VisitType = this.data.GetVisitType(viewModel.VisitTypeId),
                VisitTypeId = viewModel.VisitTypeId,
                VisitContext = viewModel.VisitContext,
                Brands = new List<ProspectionBrand>(),
                CompetitorBrands = new List<ProspectionCompetitorBrand>(),
                BestBrands = viewModel.BestBrands,
                WorstBrands = viewModel.WorstBrands,
                BrandsOut = viewModel.BrandsOut,
                BrandsInterest = new List<ProspectionBrandInterest>(),
                Trends = viewModel.Trends,
                Extra = viewModel.Extra,
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
                    Date = newProspection.Date,
                    DateLastUpdated = newProspection.DateLastUpdated,
                    ContactPersonTypeId = newProspection.ContactPersonTypeId,
                    ContactPersonName = newProspection.ContactPersonName,
                    VisitTypeId = newProspection.VisitTypeId,
                    VisitContext = newProspection.VisitContext,
                    BestBrands = newProspection.BestBrands,
                    WorstBrands = newProspection.WorstBrands,
                    BrandsOut = newProspection.BrandsOut,
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
            existingProspection.Date = viewModel.Date;
            existingProspection.DateLastUpdated = viewModel.DateLastUpdated;
            existingProspection.ContactPersonType = this.data.GetContactPersonType(viewModel.ContactPersonTypeId);
            existingProspection.ContactPersonTypeId = viewModel.ContactPersonTypeId;
            existingProspection.ContactPersonName = viewModel.ContactPersonName;
            existingProspection.VisitType = this.data.GetVisitType(viewModel.VisitTypeId);
            existingProspection.VisitTypeId = viewModel.VisitTypeId;
            existingProspection.VisitContext = viewModel.VisitContext;
            existingProspection.BestBrands = viewModel.BestBrands;
            existingProspection.WorstBrands = viewModel.WorstBrands;
            existingProspection.BrandsOut = viewModel.BrandsOut;
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
                    CommercialSupport = b.CommercialSupport,
                    SalesRepresentative = b.SalesRepresentative,
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
                    Sales = brandInterest.Sales,
                };

                // add relationship to list of relationships
                updatedProspectionBrandInterests.Add(prospectionBrandInterest);
            }

            // update BrandsInterest relationships list on the prospection
            existingProspection.BrandsInterest = updatedProspectionBrandInterests;

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
