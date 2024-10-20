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
            // for each shop in the database, collect copy that adheres to viewmodel (excluding all details)
            var shops = new List<ShopGetAllViewModel>();
            foreach (var shop in this.data.GetShops())
            {
                shops.Add(new ShopGetAllViewModel { Id = shop.Id, Name = shop.Name });
            }

            // return list of viewmodel shops
            return Ok(shops);
        }

        // GetshopDetail
        // TO IMPLEMENT


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
            viewModel.Comment = prospection.Comment;
            viewModel.Date = prospection.Date;
            viewModel.ShopId = prospection.ShopId;

            // return viewmodel of prospection
            return Ok(viewModel);
        }


        // GetProspections
        // TO IMPLEMENT

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

            // (IMPLEMENT GETSHOPDETAIL FIRST)

            // check if shop exists 
            //var shop = this.data.GetShopDetail(viewModel.ShopId);
            //if (shop == null)
            //{
            //    return NotFound("Shop not found");
            //}

            // create new prospection object based on view model data
            var newProspection = new Prospection
            {
                Comment = viewModel.Comment,
                Date = viewModel.Date,
                ShopId = viewModel.ShopId,
                //Shop = shop, // see above, implement GetShopDetail first
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
                    Comment = newProspection.Comment,
                    Date = newProspection.Date,
                    ShopId = newProspection.ShopId,
                });
        }

        // PUT

        // UpdateProspection
        // TO IMPLEMENT

    }
}
