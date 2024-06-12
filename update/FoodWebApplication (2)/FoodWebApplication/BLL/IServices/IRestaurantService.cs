using DTO.Category;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Restaurant;

namespace BLL.IServices
{
    public interface IRestaurantService
    {
        RestaurantDTO GetDetail(long id);
        void Create(RestaurantDTO input);
        void Update(RestaurantDTO input, long id);
        void Delete(long id);
        RestaurantDTO GetById(long id);
        List<RestaurantDTO> getByCate(long id);
        PaginationModels<List<RestaurantDTO>> Get(string search);
        List<RestaurantDTO> GetAllRestaurant();
    }
}
