using BLL.IServices;
using DTO.Category;
using DTO;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using DTO.Customer;

namespace Food.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }


        [HttpGet]
        [Route("GetAllCustomer")]
        public ResponseModels GetAllCustomer()
        {
            try
            {
                var orders = _customerService.GetAllCustomer();
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
                var order = _customerService.GetById(id);

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
        [Route("get")]
        public ResponseModels Get(string search)
        {
            try
            {
                var orders = _customerService.Get(search);
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
        public async Task<ResponseModels> Create([FromBody] CustomerDTO order)
        {
            try
            {
                _customerService.Create(order);
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
        [HttpPost]
        [Route("CreateContact")]
        public async Task<ResponseModels> CreateContact([FromBody] CustomerContactDTO cus)
        {
            try
            {
                _customerService.CreateContact(cus);
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

        [HttpPost]
        [Route("update/{id}")]
        public async Task<ResponseModels> Update(long id, [FromBody] CustomerDTO order)
        {
            try
            {
                _customerService.Update(order, id);
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
                _customerService.Delete(id);
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
