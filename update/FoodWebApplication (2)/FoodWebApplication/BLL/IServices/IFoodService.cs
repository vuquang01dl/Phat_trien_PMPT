using DTO.Category;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Food;

namespace BLL.IServices
{
    public interface IFoodService
    {
        void Create(FoodDTO input);
        void Update(FoodDTO input, long id);
        void Delete(long id);
        FoodDTO GetById(long id);
        PaginationModels<List<FoodDTO>> Get(string search);
        List<FoodDTO> GetAllFood();
    }
}
