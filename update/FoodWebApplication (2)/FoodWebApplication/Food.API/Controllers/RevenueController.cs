using BLL.IServices;
using DTO.Category;
using DTO;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using BLL.Services;

namespace Food.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RevenueController : ControllerBase
    {
        readonly IOrderService _orderService;

        public RevenueController(IOrderService orderService)
        {
            _orderService = orderService;
        }


        [HttpGet]
        [Route("GetRevenue")]
        public ResponseModels GetRevenue(int year)
        {
            try
            {
                var orders = _orderService.GetRevenueAnual(year);
                return new ResponseModels()
                {
                    Success = true,
                    Data = orders
                };
            }
            catch (Exception ex)
            {
                return new ResponseModels()
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }
    }
}
