using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Modifier
{
    [Table("ModifierFood")]
    public class ModifierFoodEntities : BaseEntities
    {
        public string ModifierId { get; set; }
        public string FoodId { get; set; }
    }
}