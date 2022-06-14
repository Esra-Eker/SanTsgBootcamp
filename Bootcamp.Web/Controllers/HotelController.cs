using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bootcamp.Web.Controllers
{
    public class HotelController : Controller
    {
        public string GetArrivalAutocompleteUrl = "http://service.stage.paximum.com/v2/api/productservice/getarrivalautocomplete";
        private string token = "";
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult HotelList()
        {

            Models.Request.HotelProduct.GetArrivalAutocompleteRequest request = new Models.Request.HotelProduct.GetArrivalAutocompleteRequest();
            request.Culture = "en-US";
            request.ProductType = 2;
            request.Query = "Antalya";

            Models.Response.HotelProduct.GetArrivalAutocompleteResponse response = Api.Post<Models.Response.HotelProduct.GetArrivalAutocompleteResponse>(GetArrivalAutocompleteUrl, request, token);

            var hotelList = response.body.items.Where(a => a.type == 2).ToList();

            return View(hotelList);
        }
    }
}
