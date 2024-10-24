﻿using FCentricProspections.Server.Models;
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

            viewModel.Name = shop.Name; // for now only getting name works

            viewModel.Address = "Address"; // requires more complicated join/query to create something like below
            //viewModel.Address = $"{shop.Contact.Address.Street1} {shop.Contact.Address.Street2}, {shop.Contact.Address.PostalCode} {shop.Contact.Address.City}";

            viewModel.Customer = "Customer"; // requires GetCustomer query by using CustomerShops Foreign Key table?

            // return viewmodel of prospection
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
            viewModel.Comment = prospection.Comment;
            viewModel.Date = prospection.Date;
            viewModel.ShopId = prospection.ShopId;

            // return viewmodel of prospection
            return Ok(viewModel);
        }


        // GetProspections
        [HttpGet()]
        [Route("prospections")]
        public IActionResult GetProspections(long shopId)
        {
            var prospections = new List<ProspectionGetAllViewModel>();

            // get prospections from a shop
            foreach (var prospection in this.data.GetProspections(shopId))
            {
                // create prospection viewmodel
                prospections.Add(new ProspectionGetAllViewModel { Id = prospection.Id, Date = prospection.Date, ShopId = shopId });
            }

            // return list of viewmodel prospections
            return Ok(prospections);
        }

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
                Comment = viewModel.Comment,
                Date = viewModel.Date,
                ShopId = viewModel.ShopId,
                Shop = shop,
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
