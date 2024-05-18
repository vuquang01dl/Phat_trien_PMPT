using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Order
{
    [Table("Order")]
    public class OrderEntities : BaseEntities
    {
        public decimal Price { get; set; }
        public int Qty { get; set; }
        public string CustomerName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int Status { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }
}