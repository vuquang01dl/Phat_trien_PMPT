using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DTO.Customer
{
    public class CustomerDTO : BaseDTO
    {
        [Required(ErrorMessage = "Required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Required")]
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Required")]
        public string LastName { get; set; }
        public string Address { get; set; }
        [Required(ErrorMessage = "Required")]
        public string Email { get; set; }
        public string Phone { get; set; }
        public int Gender { get; set; }
        public string Avartar { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DateOfBirth { get; set; }
        [JsonIgnore]

        [DataType(DataType.Upload)]
        public IFormFile PictureUpload { get; set; }
    }
}
