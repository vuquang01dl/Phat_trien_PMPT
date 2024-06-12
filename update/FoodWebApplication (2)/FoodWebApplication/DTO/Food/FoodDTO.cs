using DTO.Modifier;
using DTO.Restaurant;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DTO.Food
{
    public class FoodDTO : BaseDTO
    {
        [Required(ErrorMessage = "Required")]
        public string Code { get; set; }
        [Required(ErrorMessage = "Required")]
        public string Name { get; set; }
        public double Price { get; set; }
        [Required(ErrorMessage = "Required")]
        public long RestaurantId { get; set; }
        public string RestaurantName { get; set; }
        public string ImageURL { get; set; }
        [JsonIgnore]

        [DataType(DataType.Upload)]
        public IFormFile PictureUpload { get; set; }
        public List<RestaurantDTO> Restaurants { get; set; } = new List<RestaurantDTO>();
        public List<ModifierDTO> Modifiers { get; set; } = new List<ModifierDTO>();
    }
}
