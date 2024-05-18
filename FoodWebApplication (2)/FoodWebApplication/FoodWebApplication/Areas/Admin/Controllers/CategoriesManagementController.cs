using Common.Enum;
using Common.RestAPI;
using DTO.Category;
using DTO.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace FoodWebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesManagementController : Controller
    {
        private readonly IRestApiServices _restApi;
        public CategoriesManagementController(IRestApiServices restApi)
        {
            _restApi = restApi;
        }
        // GET: UserManagerment
        public async Task<ActionResult> Index(string search)
        {
            var models = new List<CategoryDTO>();
            var result = await _restApi.GetAsJson<List<CategoryDTO>>(string.Format("Category/get?search={0}", search));
            if (result.Success)
            {
                if (result.Data != null)
                    models.AddRange(result.Data);
            }
            return View(models);
        }
        public ActionResult New()
        {
            var model = new CategoryDTO();
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> New(CategoryDTO model)
        {
            if (ModelState.IsValid == false)
            {
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
            var result = await _restApi.PostAsJson<CategoryDTO>("Category/create", model);
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
            var model = new CategoryDTO();
            var result = await _restApi.GetAsJson<CategoryDTO>(string.Format("{0}/{1}", "Category/find", Id));
            if (result.Success)
            {
                model = result.Data;
            }
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(CategoryDTO model)
        {
            if (ModelState.IsValid == false)
            {
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
            var result = await _restApi.PostAsJson<CategoryDTO>(string.Format("{0}/{1}", "Category/update", model.Id), model);
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
            var result = await _restApi.DeleteJson<CategoryDTO>(string.Format("{0}/{1}", "Category/delete", Id));
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
