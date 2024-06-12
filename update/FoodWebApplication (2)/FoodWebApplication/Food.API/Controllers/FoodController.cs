using BLL.IServices;
using DTO.Category;
using DTO;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using DTO.Food;

namespace Food.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        readonly IFoodService _foodService;

        public FoodController(IFoodService foodService)
        {
            _foodService = foodService;
        }


        [HttpGet]
        [Route("GetAllFood")]
        public ResponseModels GetAllFood()
        {
            try
            {
                var orders = _foodService.GetAllFood();
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
                var order = _foodService.GetById(id);

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
                var orders = _foodService.Get(search);
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
        public async Task<ResponseModels> Create([FromBody] FoodDTO order)
        {
            try
            {
                _foodService.Create(order);
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
        public async Task<ResponseModels> Update(long id, [FromBody] FoodDTO order)
        {
            try
            {
                _foodService.Update(order, id);
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
                _foodService.Delete(id);
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
