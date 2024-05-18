using DTO.Category;
using DTO.Restaurant;
using System.Collections.Generic;

namespace FoodWebApplication.Models
{
    public class HomeViewModels
    {
        public RestaurantDTO Restaurant { get; set; }
        public List<CategoryDTO> Categories { get; set; }
        public List<RestaurantDTO> Restaurants { get; set; }
        public HomeViewModels()
        {
            Categories = new List<CategoryDTO>();
            Restaurants = new List<RestaurantDTO>();
        }
    }
}
