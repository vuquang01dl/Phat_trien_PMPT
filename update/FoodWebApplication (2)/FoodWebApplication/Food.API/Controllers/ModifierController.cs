using BLL.IServices;
using DTO.Food;
using DTO;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using DTO.Modifier;

namespace Food.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModifierController : ControllerBase
    {
        readonly IModifierService _modifierService;

        public ModifierController(IModifierService modifierService)
        {
            _modifierService = modifierService;
        }


        [HttpGet]
        [Route("GetAllModifier")]
        public ResponseModels GetAllModifier()
        {
            try
            {
                var orders = _modifierService.GetAllModifier();
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
                var order = _modifierService.GetById(id);

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
                var orders = _modifierService.Get(search);
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
        public async Task<ResponseModels> Create([FromBody] ModifierDTO order)
        {
            try
            {
                _modifierService.Create(order);
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
        public async Task<ResponseModels> Update(long id, [FromBody] ModifierDTO order)
        {
            try
            {
                _modifierService.Update(order, id);
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
                _modifierService.Delete(id);
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
