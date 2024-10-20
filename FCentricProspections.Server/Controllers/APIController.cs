using FCentricProspections.Server.Models;
using FCentricProspections.Server.Services;
using FCentricProspections.Server.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
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
            // for each shop in the database, collect copy that adheres to view model
            var shops = new List<ShopGetAllViewModel>();
            foreach (var shop in this.data.GetShops())
            {
                shops.Add(new ShopGetAllViewModel { Id = shop.Id, Name = shop.Name });
            }

            // return list of view model countries
            return Ok(shops);
        }

        // implement GetshopDetail


        // PROSPECTIONS ----------------------------------------------

        // GET

        [HttpGet()]
        [Route("prospections/{id}")]
        public IActionResult GetProspectionDetail(long id)
        {
            var viewModel = new ProspectionGetDetailViewModel();

            var prospection = this.data.GetShopProspectionDetail(id);
            if (prospection == null)
            {
                return NotFound("Prospection not found.");
            }

            viewModel.Id = prospection.Id;
            viewModel.Comment = prospection.Comment;
            viewModel.Date = prospection.Date;
            viewModel.ShopId = prospection.ShopId;

            // return viewmodel of a prospection
            return Ok(viewModel);
        }


        // implement GetProspections

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
            //var shop = this.data.GetShopDetail(viewModel.ShopId);
            //if (shop == null)
            //{
            //    return NotFound("Shop not found");
            //}

            // create new prospection based on view model data
            var newProspection = new Prospection
            {
                Comment = viewModel.Comment,
                Date = viewModel.Date,
                ShopId = viewModel.ShopId,
            };

            // add prospection to database
            this.data.AddShopProspection(newProspection);

            // return VIEWMODEL of object that was just created
            return CreatedAtAction(
                nameof(GetProspectionDetail),
                new { id = newProspection.Id },
                new ProspectionGetDetailViewModel 
                { 
                    Id = newProspection.Id,
                    Comment = newProspection.Comment,
                    Date = newProspection.Date,
                    ShopId = newProspection.ShopId,
                });
        }

        // PUT

        // implement

    }
}
