using FridgeClient.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Net;

namespace FridgeClient.Controllers
{
    [Route("")]
    [Route("Home")]
    public class HomeController : Controller
    {
        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("Error/{code}")]
        public IActionResult Error([FromRoute(Name = "code")] HttpStatusCode code)
        {
            var viewModel = new ErrorViewModel()
            {
                StatusCode = (int)code,
                StatusCodeDescription = ReasonPhrases.GetReasonPhrase((int)code),
                Message = "Something went wrong..."
            };

            return View(viewModel);
        }
    }
}
