using FridgeClient.FridgeAPI.DataTransferObjects.Request;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net;

namespace FridgeClient.FridgeAPI.ApiProvider
{
    public delegate T TestDelegate<T>(int a);

    public class FridgeApiProvider : IFridgeApiProvider
    {
        private readonly IHttpClientFactory _httpClientFactory;


        public FridgeApiProvider(IHttpClientFactory factory)
        {
            _httpClientFactory = factory;
        }


        public async Task<FridgeApiProviderResponse<IEnumerable<FridgeToReturn>>> GetFridgesAsync()
        {
            
            return await ExceptionWrapper<IEnumerable<FridgeToReturn>>(async () =>
            {
                var http = _httpClientFactory.CreateClient();
                var response = await http.GetAsync("http://localhost:56676/api/fridges");
                string json = await response.Content.ReadAsStringAsync();
                var fridges = JsonSerializer.Deserialize<IEnumerable<FridgeToReturn>>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

                return new FridgeApiProviderResponse<IEnumerable<FridgeToReturn>>()
                {
                    Data = fridges,
                    HttpStatusCode = response.StatusCode
                };
            });
            
            /*
            var http = _httpClientFactory.CreateClient();
            var response = await http.GetAsync("http://localhost:56676/api/fridges");
            string json = await response.Content.ReadAsStringAsync();
            var fridges = JsonSerializer.Deserialize<IEnumerable<FridgeToReturn>>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            return new FridgeApiProviderResponse<IEnumerable<FridgeToReturn>>()
            {
                Data = fridges,
                HttpStatusCode = response.StatusCode
            };
            */
            
        }

        public async Task<FridgeApiProviderResponse<IEnumerable<FridgeModelToReturn>>> GetFridgeModelsAsync()
        {
            /*
            var http = _httpClientFactory.CreateClient();
            var response = await http.GetAsync("http://localhost:56676/api/fridgemodels");
            string json = await response.Content.ReadAsStringAsync();
            var models = JsonSerializer.Deserialize<IEnumerable<FridgeModelToReturn>>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            return new FridgeApiProviderResponse<IEnumerable<FridgeModelToReturn>>()
            {
                Data = models,
                HttpStatusCode = response.StatusCode
            };
            */

            return await ExceptionWrapper<IEnumerable<FridgeModelToReturn>>(async () =>
            {
                var http = _httpClientFactory.CreateClient();
                var response = await http.GetAsync("http://localhost:56676/api/fridgemodels");
                string json = await response.Content.ReadAsStringAsync();
                var models = JsonSerializer.Deserialize<IEnumerable<FridgeModelToReturn>>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

                return new FridgeApiProviderResponse<IEnumerable<FridgeModelToReturn>>()
                {
                    Data = models,
                    HttpStatusCode = response.StatusCode
                };
            });
        }

        public async Task<FridgeApiProviderResponse<IEnumerable<StoredProductToReturn>>> GetFridgeProductsAsync(Guid fridgeId)
        {
            /*
            var http = _httpClientFactory.CreateClient();
            var response = await http.GetAsync($"http://localhost:56676/api/fridges/{fridgeId}/products");
            string json = await response.Content.ReadAsStringAsync();
            var products = JsonSerializer.Deserialize<IEnumerable<StoredProductToReturn>>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            return new FridgeApiProviderResponse<IEnumerable<StoredProductToReturn>>()
            {
                Data = products,
                HttpStatusCode = response.StatusCode
            };
            */

            return await ExceptionWrapper<IEnumerable<StoredProductToReturn>>(async () =>
            {
                var http = _httpClientFactory.CreateClient();
                var response = await http.GetAsync($"http://localhost:56676/api/fridges/{fridgeId}/products");
                string json = await response.Content.ReadAsStringAsync();
                var products = JsonSerializer.Deserialize<IEnumerable<StoredProductToReturn>>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

                return new FridgeApiProviderResponse<IEnumerable<StoredProductToReturn>>()
                {
                    Data = products,
                    HttpStatusCode = response.StatusCode
                };
            });
        }

        public async Task<FridgeApiProviderResponse<IEnumerable<ProductToReturn>>> GetProducts()
        {
            /*
            var http = _httpClientFactory.CreateClient();
            var response = await http.GetAsync($"http://localhost:56676/api/products");
            string json = await response.Content.ReadAsStringAsync();
            var products = JsonSerializer.Deserialize<IEnumerable<ProductToReturn>>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            return new FridgeApiProviderResponse<IEnumerable<ProductToReturn>>()
            {
                Data = products,
                HttpStatusCode = response.StatusCode
            };
            */

            return await ExceptionWrapper<IEnumerable<ProductToReturn>>(async () =>
            {
                var http = _httpClientFactory.CreateClient();
                var response = await http.GetAsync($"http://localhost:56676/api/products");
                string json = await response.Content.ReadAsStringAsync();
                var products = JsonSerializer.Deserialize<IEnumerable<ProductToReturn>>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

                return new FridgeApiProviderResponse<IEnumerable<ProductToReturn>>()
                {
                    Data = products,
                    HttpStatusCode = response.StatusCode
                };
            });
        }

        public async Task<FridgeApiProviderResponse<FridgeToReturn>> AddNewFridgeAsync(FridgeToCreate fridge)
        {
            /*
            var json = JsonSerializer.Serialize(fridge);
            var content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var http = _httpClientFactory.CreateClient();
            var response = await http.PostAsync($"http://localhost:56676/api/fridges", content);
            string newFridgeJson = await response.Content.ReadAsStringAsync();
            var newFridge = JsonSerializer.Deserialize<FridgeToReturn>(newFridgeJson, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            return new FridgeApiProviderResponse<FridgeToReturn>()
            {
                Data = newFridge,
                HttpStatusCode = response.StatusCode
            };
            */
            return await ExceptionWrapper<FridgeToReturn>(async () =>
            {
                var json = JsonSerializer.Serialize(fridge);
                var content = new StringContent(json);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var http = _httpClientFactory.CreateClient();
                var response = await http.PostAsync($"http://localhost:56676/api/fridges", content);
                string newFridgeJson = await response.Content.ReadAsStringAsync();
                var newFridge = JsonSerializer.Deserialize<FridgeToReturn>(newFridgeJson, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

                return new FridgeApiProviderResponse<FridgeToReturn>()
                {
                    Data = newFridge,
                    HttpStatusCode = response.StatusCode
                };
            });
        }

        public async Task<FridgeApiProviderResponse<IEnumerable<StoredProductToReturn>>> AddProductsToFridgeAsync(Guid fridgeId, IEnumerable<StoredProductToCreate> products)
        {
            /*
            var json = JsonSerializer.Serialize(products);
            var content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var http = _httpClientFactory.CreateClient();
            var response = await http.PostAsync($"http://localhost:56676/api/fridges/{fridgeId}/products", content);

            string storedProductsJson = await response.Content.ReadAsStringAsync();
            var storedProducts = JsonSerializer.Deserialize<IEnumerable<StoredProductToReturn>>(storedProductsJson, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            return new FridgeApiProviderResponse<IEnumerable<StoredProductToReturn>>()
            {
                Data = storedProducts,
                HttpStatusCode = response.StatusCode
            };
            */
            return await ExceptionWrapper<IEnumerable<StoredProductToReturn>>(async () =>
            {
                var json = JsonSerializer.Serialize(products);
                var content = new StringContent(json);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var http = _httpClientFactory.CreateClient();
                var response = await http.PostAsync($"http://localhost:56676/api/fridges/{fridgeId}/products", content);

                string storedProductsJson = await response.Content.ReadAsStringAsync();
                var storedProducts = JsonSerializer.Deserialize<IEnumerable<StoredProductToReturn>>(storedProductsJson, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

                return new FridgeApiProviderResponse<IEnumerable<StoredProductToReturn>>()
                {
                    Data = storedProducts,
                    HttpStatusCode = response.StatusCode
                };
            });
        }

        public async Task<FridgeApiProviderResponse<object>> DeleteFridgeAsync(Guid fridgeId)
        {
            return await ExceptionWrapper<object>(async () =>
            {
                var http = _httpClientFactory.CreateClient();
                var response = await http.DeleteAsync($"http://localhost:56676/api/fridges/{fridgeId}");

                return new FridgeApiProviderResponse<object>()
                {
                    Data = null,
                    HttpStatusCode = response.StatusCode
                };
            });

            /*
            var http = _httpClientFactory.CreateClient();
            var response = await http.DeleteAsync($"http://localhost:56676/api/fridges/{fridgeId}");

            return new FridgeApiProviderResponse<object>()
            {
                HttpStatusCode = response.StatusCode
            };
            */
        }

        public async Task<FridgeApiProviderResponse<object>> UpdateProductsInFridge(Guid fridgeId, IEnumerable<StoredProductToUpdate> products)
        {
            /*
            var json = JsonSerializer.Serialize(products);
            var content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var http = _httpClientFactory.CreateClient();
            var response = await http.PutAsync($"http://localhost:56676/api/fridges/{fridgeId}", content);

            return new FridgeApiProviderResponse<object>()
            {
                Data = null,
                HttpStatusCode = response.StatusCode
            };
            */
            return await ExceptionWrapper<object>(async () =>
            {
                var json = JsonSerializer.Serialize(products);
                var content = new StringContent(json);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var http = _httpClientFactory.CreateClient();
                var response = await http.PutAsync($"http://localhost:56676/api/fridges/{fridgeId}", content);

                return new FridgeApiProviderResponse<object>()
                {
                    Data = null,
                    HttpStatusCode = response.StatusCode
                };
            });
        }

        public async Task<FridgeApiProviderResponse<IEnumerable<ProductToReturn>>> AddProductsAsync(IEnumerable<ProductToCreate> products)
        {
            /*
            var json = JsonSerializer.Serialize(products);
            var content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var http = _httpClientFactory.CreateClient();
            var response = await http.PostAsync($"http://localhost:56676/api/products", content);

            string productsToReturnJson = await response.Content.ReadAsStringAsync();
            var productsToReturn = JsonSerializer.Deserialize<IEnumerable<ProductToReturn>>(productsToReturnJson, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            return new FridgeApiProviderResponse<IEnumerable<ProductToReturn>>()
            {
                Data = productsToReturn,
                HttpStatusCode = response.StatusCode
            };
            */
            return await ExceptionWrapper<IEnumerable<ProductToReturn>>(async () =>
            {
                var json = JsonSerializer.Serialize(products);
                var content = new StringContent(json);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var http = _httpClientFactory.CreateClient();
                var response = await http.PostAsync($"http://localhost:56676/api/products", content);

                string productsToReturnJson = await response.Content.ReadAsStringAsync();
                var productsToReturn = JsonSerializer.Deserialize<IEnumerable<ProductToReturn>>(productsToReturnJson, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

                return new FridgeApiProviderResponse<IEnumerable<ProductToReturn>>()
                {
                    Data = productsToReturn,
                    HttpStatusCode = response.StatusCode
                };
            });
        }

        public async Task<FridgeApiProviderResponse<object>> DeleteProductAsync(Guid productId)
        {
            return await ExceptionWrapper<object>(async () =>
            {
                var http = _httpClientFactory.CreateClient();
                var response = await http.DeleteAsync($"http://localhost:56676/api/products/{productId}");

                return new FridgeApiProviderResponse<object>()
                {
                    Data = null,
                    HttpStatusCode = response.StatusCode
                };
            });
        }

        public async Task<FridgeApiProviderResponse<T>> ExceptionWrapper<T>(Func<Task<FridgeApiProviderResponse<T>>> del)
            where T : class
        {
            try
            {
                return await del();
            }
            catch (HttpRequestException)
            {
                return new FridgeApiProviderResponse<T>()
                {
                    Data = null,
                    HttpStatusCode = HttpStatusCode.NotFound
                };
            }
            catch (JsonException)
            {
                return new FridgeApiProviderResponse<T>()
                {
                    Data = null,
                    HttpStatusCode = HttpStatusCode.BadRequest
                };
            }
            catch (Exception)
            {
                return new FridgeApiProviderResponse<T>()
                {
                    Data = null,
                    HttpStatusCode = HttpStatusCode.InternalServerError
                };
            }
        }
    }
}
