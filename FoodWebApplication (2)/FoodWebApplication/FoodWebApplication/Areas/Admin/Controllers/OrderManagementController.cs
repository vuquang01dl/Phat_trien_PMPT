using Common.RestAPI;
using DTO.Food;
using DTO.Order;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System;
using DTO.Order;
using Common.Enum;
using System.Net.Mail;
using System.Net;

namespace FoodWebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderManagementController : Controller
    {
        private readonly IRestApiServices _restApi;
        public OrderManagementController(IRestApiServices restApi)
        {
            _restApi = restApi;
        }
        // GET: UserManagerment
        public async Task<ActionResult> Index(string search)
        {
            var models = new List<OrderDTO>();
            var result = await _restApi.GetAsJson<List<OrderDTO>>(string.Format("Order/get?search={0}", search));
            if (result.Success)
            {
                if (result.Data != null)
                    models.AddRange(result.Data);
            }
            return View(models);
        }
        public ActionResult New()
        {
            var model = new OrderDTO();
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> New(OrderDTO model)
        {
            if (ModelState.IsValid == false)
            { 
                return View(model);
            }
            var result = await _restApi.PostAsJson<OrderDTO>("Order/Create", model);
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

        public async Task<ActionResult> Edit(string Id)
        {
            var model = new OrderDTO();
            var result = await _restApi.GetAsJson<OrderDTO>(string.Format("{0}/{1}", "Order/find", Id));
            if (result.Success)
            {
                model = result.Data;
            }
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(OrderDTO model)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }
            var result = await _restApi.PostAsJson<OrderDTO>(string.Format("{0}/{1}", "Order/update", model.Id), model);
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
            var result = await _restApi.DeleteJson<OrderDTO>(string.Format("{0}/{1}", "Order/delete", Id));
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
        public async Task<ActionResult> Approved(long Id)
        {
            var model = new OrderDTO();
            var result = await _restApi.GetAsJson<OrderDTO>(string.Format("{0}/{1}", "Order/find", Id));
            if (result.Success)
            {
                model = result.Data;
                model.Status = (int)OrderStatus.Approved;
                model.UpdatedBy = "admin";
                var response = await _restApi.PostAsJson<OrderDTO>(string.Format("{0}/{1}", "Order/update", model.Id), model);
                if (response.Success == false)
                {
                    TempData["IntervalServer"] = string.Format("Duyệt đơn hàng {0} không thành công. Vui lòng liên hệ admin.", model.Code);
                }
                else
                {
                    string smtpAddress = "smtp.gmail.com";
                    int portNumber = 587;
                    bool enableSSL = true;
                    string emailFrom = "vuquang01dl@gmail.com";
                    string password = "kvyz gumz rimx kcdn";
                    if (model.Email.Contains("@gmail.com"))
                    {
                        using (MailMessage mail = new MailMessage())
                        {
                            mail.From = new MailAddress(emailFrom);
                            mail.To.Add(model.Email);
                            mail.Subject = "Đơn hàng của bạn đã được duyệt!!!";
                            mail.Body = "";
                            mail.IsBodyHtml = true;
                            using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                            {
                                smtp.Credentials = new NetworkCredential(emailFrom, password);
                                smtp.EnableSsl = enableSSL;
                                smtp.Send(mail);
                            }
                        }
                    }
                    TempData["Successful"] = string.Format("Duyệt đơn hàng {0} thành công.", model.Code);
                }
            }               
            return RedirectToAction("Index");
        }
        public async Task<ActionResult> Rejected(long Id)
        {
            var model = new OrderDTO();
            var result = await _restApi.GetAsJson<OrderDTO>(string.Format("{0}/{1}", "Order/find", Id));
            if (result.Success)
            {
                model = result.Data;
                model.Status = (int)OrderStatus.Cancelled;
                model.UpdatedBy = "admin";
                var response = await _restApi.PostAsJson<OrderDTO>(string.Format("{0}/{1}", "Order/update", model.Id), model);
                if (response.Success == false)
                {
                    TempData["IntervalServer"] = string.Format("Hủy đơn hàng {0} không thành công. Vui lòng liên hệ admin.", model.Code);
                }
                else
                {
                    model = response.Data;
                    string smtpAddress = "smtp.gmail.com";
                    int portNumber = 587;
                    bool enableSSL = true;
                    string emailFrom = "vuquang01dl@gmail.com";
                    string password = "kvyz gumz rimx kcdn";
                    if (model.Email.Contains("@gmail.com"))
                    {
                        using (MailMessage mail = new MailMessage())
                        {
                            mail.From = new MailAddress(emailFrom);
                            mail.To.Add(model.Email);
                            mail.Subject = "Đơn hàng của bạn đã bị hủy!!!";
                            mail.Body = "";
                            mail.IsBodyHtml = true;
                            using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                            {
                                smtp.Credentials = new NetworkCredential(emailFrom, password);
                                smtp.EnableSsl = enableSSL;
                                smtp.Send(mail);
                            }
                        }
                    }
                    TempData["Successful"] = string.Format("Hủy đơn hàng {0} thành công.", model.Code);
                }
            }
            return RedirectToAction("Index");
        }
    }
}
