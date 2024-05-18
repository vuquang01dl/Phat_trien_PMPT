using DTO.Category;
using DTO.Food;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DTO.Restaurant
{
    public class RestaurantDTO : BaseDTO
    {
        [Required(ErrorMessage = "Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Required")]
        public long CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string ImageURL { get; set; }
        [JsonIgnore]

        [DataType(DataType.Upload)]
        public IFormFile PictureUpload { get; set; }
        public List<CategoryDTO> Categorys { get; set; } = new List<CategoryDTO>();
        public List<FoodDTO> Foods { get; set; } = new List<FoodDTO>();
    }
}
