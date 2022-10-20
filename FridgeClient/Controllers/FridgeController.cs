using Microsoft.AspNetCore.Mvc;
using FridgeClient.ViewModels.Fridge;
using System;
using System.Threading.Tasks;
using System.Linq;
using FridgeClient.ViewModels.Entities;
using AutoMapper;
using FridgeClient.FridgeAPI.ApiProvider;
using FridgeClient.FridgeAPI.DataTransferObjects.Request;
using System.Net;

namespace FridgeClient.Controllers
{
    [Route("/fridges")]
    public class FridgeController : Controller
    {
        private readonly IFridgeApiProvider _apiProvider;

        private readonly IMapper _mapper;


        public FridgeController(IFridgeApiProvider apiProvider, IMapper mapper)
        {
            _apiProvider = apiProvider;
            _mapper = mapper;
        }


        [Route("index")]
        public async Task<IActionResult> Index()
        {
            var response = await _apiProvider.GetFridgesAsync();

            if (response.HttpStatusCode != HttpStatusCode.OK)
                return RedirectToAction("Error", "Home", new { code = response.HttpStatusCode } );

            var fridges = response.Data;

            IndexViewModel viewModel = new IndexViewModel()
            {
                Fridges = fridges.Select(f => _mapper.Map<FridgeViewModel>(f))
            };

            return View(viewModel);
        }

        [Route("{id}")]
        public async Task<IActionResult> Details([FromRoute(Name = "id")] Guid fridgeId)
        {
            var response = await _apiProvider.GetFridgeProductsAsync(fridgeId);

            if (response.HttpStatusCode != HttpStatusCode.OK)
                return RedirectToAction("Error", "Home", new { code = response.HttpStatusCode });

            var products = response.Data;

            DetailsViewModel viewModel = new DetailsViewModel()
            {
                Products = products.Select(p => _mapper.Map<StoredProductViewModel>(p))
            };

            return View(viewModel);
        }

        [HttpGet]
        [Route("new")]
        public async Task<IActionResult> New()
        {
            var modelResponse = await _apiProvider.GetFridgeModelsAsync();

            if (modelResponse.HttpStatusCode != HttpStatusCode.OK)
                return RedirectToAction("Error", "Home", new { code = modelResponse.HttpStatusCode });

            var models = modelResponse.Data;
            var productResponse = await _apiProvider.GetProducts();

            if (productResponse.HttpStatusCode != HttpStatusCode.OK)
                return RedirectToAction("Error", "Home", new { code = productResponse.HttpStatusCode });

            var products = productResponse.Data;

            NewViewModel viewModel = new NewViewModel
            (
                models.Select(m => _mapper.Map<FridgeModelViewModel>(m)),
                products.Select(p => _mapper.Map<StoredProductViewModel>(p)).ToList()
            );

            return View(viewModel);
        }

        [HttpPost]
        [Route("new")]
        public async Task<IActionResult> New([FromForm] NewViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            var fridge = new FridgeToCreate()
            {
                ModelId = viewModel.FridgeModelId,
                Name = viewModel.FridgeName,
                OwnerName = viewModel.OwnerName
            };

            var productsToAdd = viewModel.AvaliableProducts.Where(p => p.Quantity > 0)
                                                           .Select(p => _mapper.Map<StoredProductToCreate>(p));


            var createFridgeResponse = await _apiProvider.AddNewFridgeAsync(fridge);

            if (createFridgeResponse.HttpStatusCode != HttpStatusCode.Created)
                return RedirectToAction("Error", "Home", new { code = createFridgeResponse.HttpStatusCode } );

            var addProductsResponse = await _apiProvider.AddProductsToFridgeAsync(createFridgeResponse.Data.Id, productsToAdd);

            if (addProductsResponse.HttpStatusCode != HttpStatusCode.Created)
                return RedirectToAction("Error", "Home", new { code = addProductsResponse.HttpStatusCode } );

            return Redirect("/fridges/index");
        }

        [HttpGet]
        [Route("{id}/edit")]
        public async Task<IActionResult> Edit([FromRoute(Name = "id")] Guid fridgeId)
        {
            var fridgesResponse = await _apiProvider.GetFridgesAsync();

            if (fridgesResponse.HttpStatusCode != HttpStatusCode.OK)
                return RedirectToAction("Error", "Home", new { code = fridgesResponse.HttpStatusCode } );

            var fridges = fridgesResponse.Data;
            var fridge = fridges.First(f => f.Id == fridgeId);
            var modelsResponse = await _apiProvider.GetFridgeModelsAsync();

            if (modelsResponse.HttpStatusCode != HttpStatusCode.OK)
                return RedirectToAction("Error", "Home", new { code = modelsResponse.HttpStatusCode } );

            var models = modelsResponse.Data;
            var fridgeProductsResponse = await _apiProvider.GetFridgeProductsAsync(fridgeId);

            if (fridgeProductsResponse.HttpStatusCode != HttpStatusCode.OK)
                return RedirectToAction("Error", "Home", new { code = fridgeProductsResponse.HttpStatusCode } );

            var fridgeProducts = fridgeProductsResponse.Data;
            var productsResponse = await _apiProvider.GetProducts();

            if (productsResponse.HttpStatusCode != HttpStatusCode.OK)
                return RedirectToAction("Error", "Home", new { code = productsResponse.HttpStatusCode } );

            var products = productsResponse.Data;
            var viewModel = new EditViewModel(models.Select(m => _mapper.Map<FridgeModelViewModel>(m)).ToList(),
                                              products.Select(p => _mapper.Map<StoredProductViewModel>(p)).ToList())
            {
                FridgeModelId = fridge.Model.Id,
                FridgeName = fridge.Name,
                OwnerName = fridge.OwnerName
            };

            return View(viewModel);
        }

        [HttpPost]
        [Route("{id}/edit")]
        public async Task<IActionResult> Edit([FromRoute(Name = "id")] Guid fridgeId, [FromForm] EditViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            var fridgeToCreate = new FridgeToCreate()
            {
                Name = viewModel.FridgeName,
                OwnerName = viewModel.OwnerName,
                ModelId = viewModel.FridgeModelId
            };

            var productsToCreate = viewModel.AvaliableProducts.Where(p => p.Quantity > 0)
                                                      .Select(p => _mapper.Map<StoredProductToCreate>(p));

            var deleteResponse = await _apiProvider.DeleteFridgeAsync(fridgeId);
            var createResponse = await _apiProvider.AddNewFridgeAsync(fridgeToCreate);
            var addResponse = await _apiProvider.AddProductsToFridgeAsync(createResponse.Data.Id, productsToCreate);

            return RedirectToAction("Index", "Fridge");
        }

        [Route("{id}/delete")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] Guid fridgeId)
        {
            var response = await _apiProvider.DeleteFridgeAsync(fridgeId);
            if (response.HttpStatusCode != HttpStatusCode.NoContent)
                return RedirectToAction("Error", "Home", new { code = response.HttpStatusCode } );

            return RedirectToAction("Index", "Fridge");
        }

        [Route("fill")]
        public IActionResult FillFridges()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
