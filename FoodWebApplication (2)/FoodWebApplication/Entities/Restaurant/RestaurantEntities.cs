using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Restaurant
{
    [Table("Restaurant")]
    public class RestaurantEntities : BaseEntities
    {
        public string Name { get; set; }
        public long CategoryId { get; set; }
        public string ImageURL { get; set; }
    }
}