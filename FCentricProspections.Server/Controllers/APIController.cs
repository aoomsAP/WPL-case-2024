using FCentricProspections.Server.Services;
using FCentricProspections.Server.ViewModels;
using Microsoft.AspNetCore.Mvc;
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

        // implement all the rest
    }
}
