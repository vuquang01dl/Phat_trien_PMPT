using DTO.Food;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DTO.Modifier
{
    public class ModifierDTO : BaseDTO
    {
        [Required(ErrorMessage = "Required")]
        public string Code { get; set; }
        [Required(ErrorMessage = "Required")]
        public string Name { get; set; }
        public double Price { get; set; }
        [Required(ErrorMessage = "Required")]
        public long FoodId { get; set; }
        public List<FoodDTO>  Foods { get; set; }
        public string FoodName { get; set; }
        public string ImageURL { get; set; }
        [JsonIgnore]

        [DataType(DataType.Upload)]
        public IFormFile PictureUpload { get; set; }
    }
}
