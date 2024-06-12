using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.User
{
    public class UserDTO : BaseDTO
    {
        [Required(ErrorMessage = "Required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Required")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Required")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Required")]
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Address { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime BirthDay { get; set; } = DateTime.Now.AddDays(-1);
        public int Role { get; set; }
        public List<SelectListItem> ListRoles { get; set; }
        public int Type { get; set; }
    }
}
