using Common.RestAPI;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;
using System;
using DTO.Customer;
using Microsoft.AspNetCore.Hosting.Server;
using Newtonsoft.Json;
using System.Collections.Generic;
using FoodWebApplication.Models;
using System.Linq;
using DTO.Food;
using System.Threading.Tasks;
using DTO.Modifier;
using DTO.Order;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Common.Enum;
using DTO.User;
using Microsoft.AspNetCore.Http;

namespace FoodWebApplication.Controllers
{
    public class CartsController : Controller
    {
        private readonly IRestApiServices _restApi;
        private const string SessionNameWeb = "UserWeb";
        public CartsController(IRestApiServices restApi)
        {
            _restApi = restApi;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> ListOrderCustomer()
        {
            var session = HttpContext.Session;
            var cus = JsonConvert.DeserializeObject<UserDTO>(session.GetString(SessionNameWeb));
            var models = new List<OrderDTO>();
            if (cus != null)
            {
                var result = await _restApi.GetAsJson<List<OrderDTO>>(string.Format("Order/GetByEmail?email={0}", cus.Email));
                if (result.Success)
                {
                    models = result.Data;
                }
            }
            return View(models);
        }
        public async Task<ActionResult> CheckOut()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> CheckOut(CustomerDTO model)
        {
            OrderDTO input = new OrderDTO();
            string body = string.Empty;
            try
            {
                var foods = new List<FoodDTO>();
                var result = await _restApi.GetAsJson<List<FoodDTO>>(string.Format("Food/GetAllFood"));
                if (result.Success)
                {
                    if (result.Data != null)
                        foods.AddRange(result.Data);
                }
                var modifiers = new List<ModifierDTO>();
                var result2 = await _restApi.GetAsJson<List<ModifierDTO>>(string.Format("Modifier/GetAllModifier"));
                if (result2.Success)
                {
                    if (result2.Data != null)
                        modifiers.AddRange(result2.Data);
                }

                var _Orders = GetListOrderCookie();
                if (_Orders != null && _Orders.Count > 0)
                {
                    _Orders = _Orders.Where(w=>w.ModifieCode == "").GroupBy(o => new { o.ItemId, o.Name }).Select(s => new OrderCookie()
                    {
                        ItemId = s.Key.ItemId,
                        Name = s.Key.Name,
                        Quantity = s.Sum(y => y.Quantity),
                        Price = s.Sum(y => y.Quantity * y.Price),
                        ListChild = _Orders.Where(w => w.ItemId == s.Key.ItemId).ToList()
                    }).ToList();
                    var ItemFoods = _Orders.Select(x => x.ItemId).ToList();
                    var ItemModifies = _Orders.Select(x => x.ItemId).ToList();
                    var dataFood = foods.ToList().Where(o => ItemFoods.Contains(o.Code.ToString()))
                                             .Select(o => new ItemModels
                                             {
                                                 ItemCode = o.Code.ToString(),
                                                 ProductName = o.Name,
                                             }).ToList();
                    var dataModifies = modifiers.ToList().Where(o => ItemModifies.Contains(o.Code.ToString()))
                                             .Select(o => new ItemModels
                                             {
                                                 ItemCode = o.Code.ToString(),
                                                 ProductName = o.Name,
                                             }).ToList();
                    if (dataFood != null && dataFood.Any())
                    {
                        dataFood.ForEach(o =>
                        {
                            var item = _Orders.FirstOrDefault(z => z.ItemId.Equals(o.ItemCode));
                            o.Quantity = item.Quantity;
                            o.ImageUrl = item.ImageUrl;
                            o.Price = item.Price;
                            o.TotalPrice = Convert.ToDouble(o.Price * item.Quantity);
                        });

                    }
                    input.Qty = _Orders.Sum(s => s.Quantity);
                    input.Price = Convert.ToDecimal(_Orders.Sum(s => s.Quantity * s.Price));
                }
                input.CustomerName = string.Format("{0} - {1}", model.FirstName, model.LastName);
                input.Phone = model.Phone;
                input.Email = model.Email;
                input.Status = (int)OrderStatus.Inprocessing;
                input.Address = model.Address;
                input.CreatedAt= DateTime.Now;
                //Tạo đơn hàng
                var resultOrder = await _restApi.PostAsJson<OrderDTO>("Order/Create", input);
                //send mail
                body = "<div>" + model.FirstName + " " + model.LastName + " - " + "Email: " + model.Email + "</br>"
                       + "Sđt: " + model.Phone + " </div></br>" + "<div>"
                       + "<strong>Address: </strong>" + model.Address + " </div>"
                       + "<div><h3>Order information</h3></div>"
                       + "</br>"
                       + "<table class='table' style='border: 1px solid black'>"
                       + "<tr>"
                       + "<th style='border: 1px solid black'>Food code</th>"
                       + "<th style='border: 1px solid black'>Modifie code</th>"
                       + "<th style='border: 1px solid black'>Name</th>"
                       + "<th style='border: 1px solid black'>Price</th>"
                       + "<th style='border: 1px solid black'>Quantity</th>"
                       + "<th style='border: 1px solid black'>Total</th>"
                       + "</tr>";
                decimal TotalPrice = 0;
                foreach (var item in _Orders)
                {
                    var _Prices = Convert.ToDecimal(item.Price * item.Quantity);
                    TotalPrice = TotalPrice + _Prices;
                    body = body + "<tr>"
                        + "<td style='border: 1px solid black'>" + item.ItemId + "</td>"
                        + "<td style='border: 1px solid black'>" + item.ModifieCode + "</td>"
                        + "<td style='border: 1px solid black'>" + item.Name + "</td>"
                        + "<td style='border: 1px solid black'>" + string.Format("{0:c0}", item.Price) + "</td>"
                        + "<td style='border: 1px solid black'>" + string.Format("{0:c0}", _Prices) + "</td>"
                        + "</tr>";
                    if (item.ListChild != null && item.ListChild.Any())
                    {
                        foreach (var item2 in item.ListChild)
                        {
                            var _Prices2 = Convert.ToDecimal(item2.Price * item2.Quantity);
                            TotalPrice = TotalPrice + _Prices2;
                            body = body + "<tr>"
                            + "<td style='border: 1px solid black'>" + item2.ItemId + "</td>"
                            + "<td style='border: 1px solid black'>" + item2.ModifieCode + "</td>"
                            + "<td style='border: 1px solid black'>" + item2.Name + "</td>"
                            + "<td style='border: 1px solid black'>" + string.Format("{0:c0}", item2.Price) + "</td>"
                            + "<td style='border: 1px solid black'>" + string.Format("{0:c0}", _Prices2) + "</td>"
                            + "</tr>";
                        }
                    }
                }
                body = body + "<tr>"
                    + "<td style='border: 1px solid black; text-align:right' colspan='3'> Money:</td>"
                    + "<td style='border: 1px solid black' colspan='2'>" + string.Format("{0:c0}", TotalPrice) + "</td>"
                    + "</tr>";
                body = body + "</table>";
                string smtpAddress = "smtp.gmail.com";
                int portNumber = 587;
                bool enableSSL = true;
                string emailFrom = "studysendmail993@gmail.com";
                string password = "hhrxlxaizkuyplap";
                if (model.Email.Contains("@gmail.com"))
                {
                    using (MailMessage mail = new MailMessage())
                    {
                        mail.From = new MailAddress(emailFrom);
                        mail.To.Add(model.Email);
                        mail.Subject = "Thanks you have visted my restaurant";
                        mail.Body = body;
                        mail.IsBodyHtml = true;
                        using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                        {
                            smtp.Credentials = new NetworkCredential(emailFrom, password);
                            smtp.EnableSsl = enableSSL;
                            smtp.Send(mail);
                        }
                    }
                }               
            }
            catch (Exception ex) { }
            return RedirectToAction("Index", "Home");
        }

        public List<OrderCookie> GetListOrderCookie()
        {
            if (Request.Cookies["cms-order"] != null)
            {
                var _Orders = Request.Cookies["cms-order"];
                var strOrder = System.Net.WebUtility.UrlDecode(_Orders);
                var ListOrder = JsonConvert.DeserializeObject<List<OrderCookie>>(strOrder);
                return ListOrder;
            }
            return null;
        }
    }
    public class ItemModels
    {
        public string ItemCode { get; set; }
        public double Quantity { get; set; }
        public double Price { get; set; }
        public string ProductName { get; set; }
        public double TotalPrice { get; set; }
        public string ImageUrl { get; set; }
    }
}