using Common.RestAPI;
using DTO.Category;
using DTO.Restaurant;
using FoodWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodWebApplication.Controllers
{
    public class RestaurantController : Controller
    {
        public readonly IRestApiServices _restApi;
        public RestaurantController(IRestApiServices restApi)
        {
            _restApi = restApi;
        }
        public async Task<IActionResult> Index(long id)
        {
            HomeViewModels model = new HomeViewModels();
            var result = await _restApi.GetAsJson<List<RestaurantDTO>>(string.Format("Restaurant/getByCate/{0}", id));
            if (result.Success)
            {
                if (result.Data != null)
                    model.Restaurants.AddRange(result.Data);
            }
            return View(model);
        }
        public async Task<IActionResult> Detail(long q)
        {
            var model = new RestaurantDTO();
            var result = await _restApi.GetAsJson<RestaurantDTO>(string.Format("Restaurant/getDetail/{0}", q));
            if (result.Success)
            {
                if (result.Data != null)
                    model = result.Data;
            }
            return View(model);
        }
    }
}
