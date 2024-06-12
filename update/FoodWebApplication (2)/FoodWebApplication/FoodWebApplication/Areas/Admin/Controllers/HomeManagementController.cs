using Microsoft.AspNetCore.Mvc;

namespace FoodWebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeManagementController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
