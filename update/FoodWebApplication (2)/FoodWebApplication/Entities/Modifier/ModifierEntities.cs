using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Modifier
{
    [Table("Modifier")]
    public class ModifierEntities : BaseEntities
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public long FoodId { get; set; }
        public string ImageURL { get; set; }
    }
}