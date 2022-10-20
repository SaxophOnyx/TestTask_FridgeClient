using FridgeClient.FridgeAPI.DataTransferObjects.Request;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FridgeClient.FridgeAPI.ApiProvider
{
    public interface IFridgeApiProvider
    {
        Task<FridgeApiProviderResponse<IEnumerable<FridgeToReturn>>> GetFridgesAsync();

        Task<FridgeApiProviderResponse<IEnumerable<FridgeModelToReturn>>> GetFridgeModelsAsync();

        Task<FridgeApiProviderResponse<IEnumerable<StoredProductToReturn>>> GetFridgeProductsAsync(Guid fridgeId);

        Task<FridgeApiProviderResponse<IEnumerable<ProductToReturn>>> GetProducts();

        Task<FridgeApiProviderResponse<FridgeToReturn>> AddNewFridgeAsync(FridgeToCreate fridge);

        Task<FridgeApiProviderResponse<IEnumerable<StoredProductToReturn>>> AddProductsToFridgeAsync(Guid fridgeId, IEnumerable<StoredProductToCreate> products);

        Task<FridgeApiProviderResponse<object>> DeleteFridgeAsync(Guid fridgeId);

        Task<FridgeApiProviderResponse<object>> UpdateProductsInFridge(Guid fridgeId, IEnumerable<StoredProductToUpdate> products);

        Task<FridgeApiProviderResponse<IEnumerable<ProductToReturn>>> AddProductsAsync(IEnumerable<ProductToCreate> products);

        Task<FridgeApiProviderResponse<object>> DeleteProductAsync(Guid productId);
    }
}
