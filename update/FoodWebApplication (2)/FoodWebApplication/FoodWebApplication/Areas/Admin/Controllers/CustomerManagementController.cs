using Common.RestAPI;
using DTO.Food;
using DTO.Customer;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System;

namespace FoodWebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CustomerManagementController : Controller
    {
        private readonly IRestApiServices _restApi;
        public CustomerManagementController(IRestApiServices restApi)
        {
            _restApi = restApi;
        }
        // GET: UserManagerment
        public async Task<ActionResult> Index(string search)
        {
            var models = new List<CustomerDTO>();
            var result = await _restApi.GetAsJson<List<CustomerDTO>>(string.Format("Customer/get?search={0}", search));
            if (result.Success)
            {
                if (result.Data != null)
                    models.AddRange(result.Data);
            }
            return View(models);
        }
        public ActionResult New()
        {
            var model = new CustomerDTO();
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> New(CustomerDTO model)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }
            var _guid = Guid.NewGuid();
            if (model.PictureUpload != null)
            {
                model.Avartar = string.Format("/Uploads/Images/{0}", _guid + Path.GetExtension(model.PictureUpload.FileName));
            }
            if (string.IsNullOrEmpty(model.Avartar))
            {
                model.Avartar = string.Format("/Uploads/Images/{0}", "default-image.jpg");
            }
            var result = await _restApi.PostAsJson<CustomerDTO>("Customer/Create", model);
            if (result.Success)
            {
                if (model.PictureUpload != null)
                {
                    string extensionName = Path.GetExtension(model.PictureUpload.FileName);
                    string fileName = string.Format("{0}{1}", _guid.ToString(), extensionName);
                    string path = Path.Combine(string.Format("{0}/{1}", "wwwroot/Uploads/Images", fileName));
                    if (!Directory.Exists("wwwroot/Uploads/Images"))
                    {
                        // Try to create the directory.
                        Directory.CreateDirectory("wwwroot/Uploads/Images");
                    }
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await model.PictureUpload.CopyToAsync(stream);
                    }
                }
                TempData["Successful"] = result.Message;
                return RedirectToAction("Index");
            }
            else
            {
                TempData["IntervalServer"] = result.Message;
            }
            return View(model);
        }

        public async Task<ActionResult> Edit(string Id)
        {
            var model = new CustomerDTO();
            var result = await _restApi.GetAsJson<CustomerDTO>(string.Format("{0}/{1}", "Customer/find", Id));
            if (result.Success)
            {
                model = result.Data;
            }
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(CustomerDTO model)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }
            var _guid = Guid.NewGuid();
            if (model.PictureUpload != null)
            {
                model.Avartar = string.Format("/Uploads/Images/{0}", _guid + Path.GetExtension(model.PictureUpload.FileName));
            }
            if (string.IsNullOrEmpty(model.Avartar))
            {
                model.Avartar = string.Format("/Uploads/Images/{0}", "default-image.jpg");
            }
            var result = await _restApi.PostAsJson<CustomerDTO>(string.Format("{0}/{1}", "Customer/update", model.Id), model);
            if (result.Success)
            {
                if (model.PictureUpload != null)
                {
                    string extensionName = Path.GetExtension(model.PictureUpload.FileName);
                    string fileName = string.Format("{0}{1}", _guid.ToString(), extensionName);
                    string path = Path.Combine(string.Format("{0}/{1}", "wwwroot/Uploads/Images", fileName));
                    if (!Directory.Exists("wwwroot/Uploads/Images"))
                    {
                        // Try to create the directory.
                        Directory.CreateDirectory("wwwroot/Uploads/Images");
                    }
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await model.PictureUpload.CopyToAsync(stream);
                    }
                }
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
            var result = await _restApi.DeleteJson<CustomerDTO>(string.Format("{0}/{1}", "Customer/delete", Id));
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
    }
}
