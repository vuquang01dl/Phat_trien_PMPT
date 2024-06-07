using Common.RestAPI;
using DTO.Category;
using DTO.Restaurant;
using FoodWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;
using DTO.Customer;

namespace FoodWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRestApiServices _restApi;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IRestApiServices restApi)
        {
            _logger = logger;
            _restApi = restApi;
        }

        public async Task<IActionResult> Index()
        {
            HomeViewModels model = new HomeViewModels();
            var result = await _restApi.GetAsJson<List<RestaurantDTO>>(string.Format("Restaurant/get?search={0}", ""));
            if (result.Success)
            {
                if (result.Data != null)
                    model.Restaurants.AddRange(result.Data);
            }
            var result2 = await _restApi.GetAsJson<List<CategoryDTO>>(string.Format("Category/get?search={0}", ""));
            if (result2.Success)
            {
                if (result2.Data != null)
                    model.Categories.AddRange(result2.Data);
            }
            return View(model);
        }

        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
        {
            var model = new CustomerContactDTO();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Contact(CustomerContactDTO model)
        {
            await _restApi.PostAsJson<CustomerContactDTO>("Customer/CreateContact", model);
            string smtpAddress = "smtp.gmail.com";
            int portNumber = 587;
            bool enableSSL = true;
            string emailFrom = "trinhquangngoc53@gmail.com";
            string password = "trfv vmdw sctt ojvq";
            string body = "<div style='font-weigh: 800'>" + model.Content + "</div>";
            if (model.Email.Contains("@gmail.com"))
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(emailFrom);
                    mail.To.Add(model.Email);
                    mail.Subject = "Chúc mừng bạn đã đặt bàn thành công!!!";
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
            return View(model);
        }
    }
}
