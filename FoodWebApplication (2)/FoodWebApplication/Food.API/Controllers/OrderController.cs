using BLL.IServices;
using DTO.Category;
using DTO;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using DTO.Order;

namespace Food.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }


        [HttpGet]
        [Route("GetAllOrder")]
        public ResponseModels GetAllOrder()
        {
            try
            {
                var orders = _orderService.GetAllOrder();
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
        [HttpGet]
        [Route("find/{id}")]
        public ResponseModels GetById(long id)
        {
            try
            {
                var order = _orderService.GetById(id);

                return new ResponseModels()
                {
                    Success = true,
                    Data = order
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
        [HttpGet]
        [Route("GetByEmail")]
        public ResponseModels GetByEmail(string email)
        {
            try
            {
                var orders = _orderService.GetByEmail(email);
                return new ResponseModels()
                {
                    Success = true,
                    Data = orders.Items
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
        [HttpGet]
        [Route("get")]
        public ResponseModels Get(string search)
        {
            try
            {
                var orders = _orderService.Get(search);
                return new ResponseModels()
                {
                    Success = true,
                    Data = orders.Items
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


        [HttpPost]
        [Route("create")]
        public async Task<ResponseModels> Create([FromBody] OrderDTO order)
        {
            try
            {
                var _order = _orderService.Create(order);
                return new ResponseModels()
                {
                    Success = true,
                    Data = _order
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


        [HttpPost]
        [Route("update/{id}")]
        public async Task<ResponseModels> Update(long id, [FromBody] OrderDTO order)
        {
            try
            {
                _orderService.Update(order, id);
                return new ResponseModels()
                {
                    Success = true
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

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<ResponseModels> Delete(long id)
        {
            try
            {
                _orderService.Delete(id);
                return new ResponseModels()
                {
                    Success = true
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
