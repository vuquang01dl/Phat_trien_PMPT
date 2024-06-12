using Common.RestAPI;
using DTO.Restaurant;
using DTO.Revenue;
using DTO.User;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodWebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RevenueManagementController : Controller
    {
        private readonly IRestApiServices _restApi;
        public RevenueManagementController(IRestApiServices restApi)
        {
            _restApi = restApi;
        }
        public async Task<IActionResult> Index()
        {
            int year = DateTime.Now.Year; //mặc định lấy năm hiện tại
            var models = new RevenueAnual();
            var result = await _restApi.GetAsJson<RevenueAnual>(string.Format("Revenue/GetRevenue?year={0}", year));
            if (result.Success)
            {
                if (result.Data != null)
                    models = result.Data;
            }
            return View(models);
        }
    }
}
