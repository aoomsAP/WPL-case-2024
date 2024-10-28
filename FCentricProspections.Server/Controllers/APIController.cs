using FCentricProspections.Server.DataModels;
using FCentricProspections.Server.Services;
using FCentricProspections.Server.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using static FCentricProspections.Server.ViewModels.BrandViewModels;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        // SHOPS ----------------------------------------------

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

            viewModel.Address = $"{shop.Address.Street1}, {shop.Address.PostalCode} {shop.Address.City}";

            viewModel.Customer = shop.Customer.Name;

            // return viewmodel of shop
            return Ok(viewModel);
        }

        // PROSPECTIONS ----------------------------------------------

        // GET

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


        // GetProspections With shop Id
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


        /*Test Route */
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
        /**/

        // POST

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

        // PUT

        // UpdateProspection
        // TO IMPLEMENT

        // UpdateProspectionBrands

        // UpdateProspectionCompetitorBrands

        // UpdateProspectionInterests

    }
}
