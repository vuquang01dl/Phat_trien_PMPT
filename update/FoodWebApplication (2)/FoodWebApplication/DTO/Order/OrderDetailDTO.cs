using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Order
{
    public class OrderDetailDTO : BaseDTO
    {
        public string ProductId { get; set; }
        public int Qty { get; set; }
        public decimal Price { get; set; }
        public string OrderId { get; set; }
        public string ImageURL { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
    }
}
