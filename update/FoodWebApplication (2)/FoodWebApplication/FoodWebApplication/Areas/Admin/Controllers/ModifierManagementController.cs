using Common.RestAPI;
using DTO.Food;
using DTO.Modifier;
using DTO.Restaurant;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace FoodWebApplication.Areas.Admin.Controllers
{    
    [Area("Admin")]
    public class ModifierManagementController : Controller
    {
        private readonly IRestApiServices _restApi;
        public ModifierManagementController(IRestApiServices restApi)
        {
            _restApi = restApi;
        }
        // GET: UserManagerment
        public async Task<ActionResult> Index(string search)
        {
            var models = new List<ModifierDTO>();
            var result = await _restApi.GetAsJson<List<ModifierDTO>>(string.Format("Modifier/get?search={0}", search));
            if (result.Success)
            {
                if (result.Data != null)
                    models.AddRange(result.Data);
            }
            return View(models);
        }
        public ActionResult New()
        {
            var model = new ModifierDTO();
            model.Foods = Set_Data_DropdownFood().Result;
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> New(ModifierDTO model)
        {
            if (ModelState.IsValid == false)
            {
                model.Foods = Set_Data_DropdownFood().Result;
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
            var result = await _restApi.PostAsJson<ModifierDTO>("Modifier/Create", model);
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
            var model = new ModifierDTO();
            var result = await _restApi.GetAsJson<ModifierDTO>(string.Format("{0}/{1}", "Modifier/find", Id));
            if (result.Success)
            {
                model = result.Data;
            }
            model.Foods = Set_Data_DropdownFood().Result;
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(ModifierDTO model)
        {
            if (ModelState.IsValid == false)
            {
                model.Foods = Set_Data_DropdownFood().Result;
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
            var result = await _restApi.PostAsJson<ModifierDTO>(string.Format("{0}/{1}", "Modifier/update", model.Id), model);
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
            var result = await _restApi.DeleteJson<ModifierDTO>(string.Format("{0}/{1}", "Modifier/delete", Id));
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
        private async Task<List<FoodDTO>> Set_Data_DropdownFood()
        {
            var models = new List<FoodDTO>();
            var result = await _restApi.GetAsJson<List<FoodDTO>>("Food/GetAllFood");
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
