using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Order
{
    public class OrderDTO : BaseDTO
    {
        public decimal Price { get; set; }
        public int Qty { get; set; }
        [Required(ErrorMessage = "Required")]
        public string CustomerName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int Status { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
