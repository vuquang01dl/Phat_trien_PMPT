using BLL.IServices;
using DTO.Customer;
using DTO;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using DTO.Restaurant;

namespace Food.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : Controller
    {
        readonly IRestaurantService _restaurantService;

        public RestaurantController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }


        [HttpGet]
        [Route("getDetail/{id}")]
        public ResponseModels GetDetail(long id)
        {
            try
            {
                var order = _restaurantService.GetDetail(id);

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
        [Route("getByCate/{id}")]
        public ResponseModels GetByCate(long id)
        {
            try
            {
                var order = _restaurantService.getByCate(id);

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
        [Route("GetAllRestaurant")]
        public ResponseModels GetAllRestaurant()
        {
            try
            {
                var orders = _restaurantService.GetAllRestaurant();
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
                var order = _restaurantService.GetById(id);

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
                var orders = _restaurantService.Get(search);
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
        public async Task<ResponseModels> Create([FromBody] RestaurantDTO order)
        {
            try
            {
                _restaurantService.Create(order);
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
        public async Task<ResponseModels> Update(long id, [FromBody] RestaurantDTO order)
        {
            try
            {
                _restaurantService.Update(order, id);
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
                _restaurantService.Delete(id);
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