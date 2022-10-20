using AutoMapper;
using AutoMapper.Configuration.Annotations;
using FridgeClient.FridgeAPI.ApiProvider;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using FridgeClient.ViewModels.Product;
using System.Linq;
using FridgeClient.ViewModels.Entities;
using System;
using FridgeClient.FridgeAPI.DataTransferObjects.Request;
using System.Collections.Generic;
using System.Net;

namespace FridgeClient.Controllers
{
    [Route("/products")]
    public class ProductController : Controller
    {
        private readonly IFridgeApiProvider _apiProvider;

        private readonly IMapper _mapper;


        public ProductController(IFridgeApiProvider apiProvider, IMapper mapper)
        {
            _apiProvider = apiProvider;
            _mapper = mapper;
        }


        [Route("index")]
        public async Task<IActionResult> Index()
        {
            var response = await _apiProvider.GetProducts();
            if (response.HttpStatusCode != HttpStatusCode.OK)
                return RedirectToAction("Error", "Home", new { code = response.HttpStatusCode } );

            var products = response.Data;

            IndexViewModel viewModel = new IndexViewModel()
            {
                Products = products.Select(p => _mapper.Map<ProductViewModel>(p))
            };

            return View(viewModel);
        }

        [HttpGet]
        [Route("new")]
        public IActionResult New()
        {
            NewViewModel viewModel = new NewViewModel();
            return View(viewModel);
        }

        [HttpPost]
        [Route("new")]
        public async Task<IActionResult> New([FromForm] NewViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            var productToCreate = new ProductToCreate()
            {
                Name = viewModel.Name,
                DefaultQuantity = viewModel.DefaultQuantity
            };

            var response = await _apiProvider.AddProductsAsync(new List<ProductToCreate>() { productToCreate } );

            if (response.HttpStatusCode != HttpStatusCode.Created)
                return RedirectToAction("Error", "Home", new { code = response.HttpStatusCode } );

            return RedirectToAction("Index", "Product");
        }

        [Route("{id}/delete")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] Guid productId)
        {
            var response = await _apiProvider.DeleteProductAsync(productId);

            if (response.HttpStatusCode != HttpStatusCode.NoContent)
                return RedirectToAction("Error", "Home", new { code = response.HttpStatusCode } );

            return RedirectToAction("Index", "Product");
        }
    }
}
