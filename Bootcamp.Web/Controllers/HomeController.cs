using Bootcamp.Web.Models;
using Bootcamp.Web.Models.Response.HotelProduct;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Bootcamp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private string token = "";
        public string GetArrivalAutocompleteUrl = "http://service.stage.paximum.com/v2/api/productservice/getarrivalautocomplete";
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            login();
        }
        void login()
        {
            Models.Request.Authentication.LoginRequest request = new Models.Request.Authentication.LoginRequest();
            request.Agency = "PXM25397";
            request.User = "USR1";
            request.Password = "test!23";
            Models.Response.Authentication.LoginResponse.Body response = Api.Post<Models.Response.Authentication.LoginResponse.Body>(GetArrivalAutocompleteUrl,request);
            this.token = response.token;      
            //response.body.token;
            
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
