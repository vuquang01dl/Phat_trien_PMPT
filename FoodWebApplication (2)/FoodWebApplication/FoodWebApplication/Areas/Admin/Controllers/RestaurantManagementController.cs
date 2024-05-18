using Common.RestAPI;
using DTO.Category;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System;
using DTO.Restaurant;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace FoodWebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RestaurantManagementController : Controller
    {
        private readonly IRestApiServices _restApi;
        public RestaurantManagementController(IRestApiServices restApi)
        {
            _restApi = restApi;
        }
        // GET: UserManagerment
        public async Task<ActionResult> Index(string search)
        {
            var models = new List<RestaurantDTO>();
            var result = await _restApi.GetAsJson<List<RestaurantDTO>>(string.Format("Restaurant/get?search={0}", search));
            if (result.Success)
            {
                if (result.Data != null)
                    models.AddRange(result.Data);
            }
            return View(models);
        }
        public ActionResult New()
        {
            var model = new RestaurantDTO();
            model.Categorys = Set_Data_DropdownCategory().Result;
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> New(RestaurantDTO model)
        {
            if (ModelState.IsValid == false)
            {
                model.Categorys = Set_Data_DropdownCategory().Result;
                return View(model);
            }
            var _guid = Guid.NewGuid();
            if (model.PictureUpload != null)
            {
                model.ImageURL = string.Format("/Uploads/Images/{0}", _guid + Path.GetExtension(model.PictureUpload.FileName));
            }
            if (string.IsNullOrEmpty(model.ImageURL))
            {
                model.ImageURL = string.Format("/Uploads/Images/{0}", "default-image.jpg");
            }
            var result = await _restApi.PostAsJson<RestaurantDTO>("Restaurant/create", model);
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
            var model = new RestaurantDTO();
            var result = await _restApi.GetAsJson<RestaurantDTO>(string.Format("{0}/{1}", "Restaurant/find", Id));
            if (result.Success)
            {
                model = result.Data;
            }
            model.Categorys = Set_Data_DropdownCategory().Result;
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(RestaurantDTO model)
        {
            if (ModelState.IsValid == false)
            {
                model.Categorys = Set_Data_DropdownCategory().Result;
                return View(model);
            }
            var _guid = Guid.NewGuid();
            if (model.PictureUpload != null)
            {
                model.ImageURL = string.Format("/Uploads/Images/{0}", _guid + Path.GetExtension(model.PictureUpload.FileName));
            }
            if (string.IsNullOrEmpty(model.ImageURL))
            {
                model.ImageURL = string.Format("/Uploads/Images/{0}", "default-image.jpg");
            }
            var result = await _restApi.PostAsJson<RestaurantDTO>(string.Format("{0}/{1}", "Restaurant/update", model.Id), model);
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
            var result = await _restApi.DeleteJson<RestaurantDTO>(string.Format("{0}/{1}", "Restaurant/delete", Id));
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


        private async Task<List<CategoryDTO>> Set_Data_DropdownCategory()
        {
            var models = new List<CategoryDTO>();
            var result = await _restApi.GetAsJson<List<CategoryDTO>>("Category/GetAllCategory");
            if (result.Success)
            {
                if (result.Data != null)
                {
                    models.AddRange(result.Data);
                }
            }
            return models;
        }
    }
}
