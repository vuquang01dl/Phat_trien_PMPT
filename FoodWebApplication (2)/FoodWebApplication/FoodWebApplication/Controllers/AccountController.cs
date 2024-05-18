using Common.RestAPI;
using DTO.Customer;
using DTO.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace FoodWebApplication.Controllers
{
    public class AccountController : Controller
    {
        private readonly IRestApiServices _restApi;
        private const string SessionName = "UserAdmin";
        private const string SessionNameWeb = "UserWeb";
        public AccountController(IRestApiServices restApi)
        {
            _restApi = restApi;
        }
        [HttpGet]
        public async Task<IActionResult> SignIn()
        {
            var model = new LoginDTO();
            return View(model);
        }
        public async Task<IActionResult> SignIn(LoginDTO model)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }
            var result = await _restApi.GetAsJson<UserDTO>("User/Login?username=" + model.Email + "&pass=" + model.Password);
            if (result.Success)
            {
                UserDTO userInfor = result.Data;
                if (userInfor.Type == 1)
                {
                    //----------------------------------------
                    var session = HttpContext.Session;
                    string jsonSave = JsonConvert.SerializeObject(userInfor);
                    session.SetString(SessionName, jsonSave);
                    return RedirectToAction("Index", "HomeManagement", new { area = "Admin" });
                }
                else
                {
                    //----------------------------------------
                    var session = HttpContext.Session;
                    string jsonSave = JsonConvert.SerializeObject(userInfor);
                    session.SetString(SessionNameWeb, jsonSave);
                    return RedirectToAction("Index", "Home", new { area = "" });
                }
            }
            else
            {
                TempData["LockLogin"] = "The Infomation Users Not Correct";
                return View(model);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Register()
        {
            var model = new RegisterDTO();
            return View(model);
        }
        public async Task<IActionResult> Register(RegisterDTO model)
        {
            var input = new CustomerDTO();
            input.FirstName= model.FirstName;
            input.LastName= model.LastName;
            input.UserName = model.Email;
            input.Email= model.Email;
            input.Password= model.Password;
            input.Phone= model.Phone;
            input.Address= model.Address;
            input.DateOfBirth = DateTime.Now;
            input.CreatedAt = DateTime.Now;
            var result = await _restApi.PostAsJson<CustomerDTO>("Customer/Create", input);
            if (result.Success)
            {
                return RedirectToAction("SignIn", "Account", new { area = "" });
            }
            else
            {
                TempData["LockLogin"] = "The Infomation Users Not Correct";
                return View(model);
            }
        }
        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("SignIn", "Account");
        }
    }
}
