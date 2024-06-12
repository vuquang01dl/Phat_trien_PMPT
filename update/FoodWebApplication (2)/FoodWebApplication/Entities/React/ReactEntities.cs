using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.React
{
    public class ReactEntities : BaseEntities
    {
        public long UserId { get; set; }
        public long ProductId { get; set; }
        public bool IsLike { get; set; }
        public bool IsShare { get; set; }
        public bool IsComment { get; set; }
        public string Comment { get; set; }
    }
}
