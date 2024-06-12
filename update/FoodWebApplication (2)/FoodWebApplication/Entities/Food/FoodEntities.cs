using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Food
{
    [Table("Food")]
    public class FoodEntities : BaseEntities
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public long RestaurantId { get; set; }
        public string ImageURL { get; set; }
    }
}
