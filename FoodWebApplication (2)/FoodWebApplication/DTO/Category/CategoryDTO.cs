using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DTO.Category
{
    public class CategoryDTO : BaseDTO
    {
        [Required(ErrorMessage = "Required")]
        public string Name { get; set; }
        public int Type { get; set; }
        public string ImageURL { get; set; }
        [JsonIgnore]

        [DataType(DataType.Upload)]
        public IFormFile PictureUpload { get; set; }
    }
}
