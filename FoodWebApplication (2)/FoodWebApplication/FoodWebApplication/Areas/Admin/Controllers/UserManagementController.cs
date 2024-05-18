using Common.RestAPI;
using DTO.User;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Common.Enum;

namespace FoodWebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserManagementController : Controller
    {
        private readonly IRestApiServices _restApi;
        private const string SessionName = "UserAdmin";
        public UserManagementController(IRestApiServices restApi)
        {
            _restApi = restApi;
        }
        // GET: UserManagerment
        public async Task<ActionResult> Index(string search)
        {
            var models = new List<UserDTO>();
            var result = await _restApi.GetAsJson<List<UserDTO>>(string.Format("User/get?search={0}", search));
            if (result.Success)
            {
                if (result.Data != null)
                    models.AddRange(result.Data);
            }
            return View(models);
        }
        public ActionResult New()
        {
            var model = new UserDTO();
            Set_Data_DropdownRole(ref model);
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> New(UserDTO model)
        {
            if (ModelState.IsValid == false)
            {
                Set_Data_DropdownRole(ref model);
                return View(model);
            }
            var result = await _restApi.PostAsJson<UserDTO>("User/Create", model);
            if (result.Success)
            {
                TempData["Successful"] = result.Message;
                return RedirectToAction("Index");
            }
            else
            {
                TempData["IntervalServer"] = result.Message;
            }
            return View(model);
        }

        public async Task<ActionResult> Edit(long Id)
        {
            var model = new UserDTO();
            var result = await _restApi.GetAsJson<UserDTO>(string.Format("{0}/{1}", "User/find", Id));
            if (result.Success)
            {
                model = result.Data;
            }
            Set_Data_DropdownRole(ref model);
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(UserDTO model)
        {
            if (ModelState.IsValid == false)
            {
                Set_Data_DropdownRole(ref model);
                return View(model);
            }
            var result = await _restApi.PostAsJson<UserDTO>(string.Format("{0}/{1}", "User/update", model.Id), model);
            if (result.Success)
            {
                TempData["Successful"] = result.Message;
                return RedirectToAction("Index");
            }
            else
            {
                TempData["IntervalServer"] = result.Message;
            }
            return View(model);
        }

        public async Task<ActionResult> Destroy(long Id)
        {
            var result = await _restApi.DeleteJson<UserDTO>(string.Format("{0}/{1}", "User/delete", Id));
            if (result.Success)
            {
                TempData["Successful"] = result.Message;
            }
            else
            {
                TempData["IntervalServer"] = result.Message;
            }
            return RedirectToAction("Index");
        }

        public ActionResult SignIn()
        {
            var model = new LoginDTO();
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> SignIn(LoginDTO model)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }
            var result = await _restApi.GetAsJson<UserDTO>("User/Login?username=" + model.Email + "&pass=" + model.Password);
            if (result.Success)
            {
                UserDTO userInfor = result.Data;
                //----------------------------------------
                var session = HttpContext.Session;
                string jsonSave = JsonConvert.SerializeObject(userInfor);
                session.SetString(SessionName, jsonSave);
                return RedirectToAction("Index", "HomeManagement", new { area = "Admin" });
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
            return RedirectToAction("SignIn", "UserManagement");
        }

        private void Set_Data_DropdownRole(ref UserDTO model)
        {
            model.ListRoles = new List<SelectListItem>();
            model.ListRoles.Add(new SelectListItem()
            {
                Value = RoleEnum.User.ToString("D"),
                Text = "User"
            });
            model.ListRoles.Add(new SelectListItem()
            {
                Value = RoleEnum.Admin.ToString("D"),
                Text = "Admin"
            });
            model.ListRoles.Add(new SelectListItem()
            {
                Value = RoleEnum.Customer.ToString("D"),
                Text = "Customer"
            });
        }
    }
}
