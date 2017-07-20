using KenticoCloudLocalizationDemo.Models;
using KenticoCloud.Delivery;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace KenticoCloudLocalizationDemo.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IDeliveryClient deliveryClient) : base(deliveryClient)
        {

        }

        public async Task<ViewResult> Index()
        {
            List<IQueryParameter> filters = new List<IQueryParameter>();
            filters.Add(new EqualsFilter("system.type", "movie"));
            filters.Add(new OrderParameter("system.name"));

            // Check if a culture code is specified
            if(Request.Path != "/")
            {
                string strPath = Request.Path.ToString().Replace("/", "").ToLower();
                filters.Add(new LanguageParameter(strPath));
                filters.Add(new EqualsFilter("system.language", strPath));
            }

            var response = await DeliveryClient.GetItemsAsync<Movie>(
                filters
            );

            return View(response.Items);
        }

    }
}
