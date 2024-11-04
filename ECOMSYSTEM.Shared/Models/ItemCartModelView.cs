using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECOMSYSTEM.Shared.Models
{
    public class ItemCartModelView
    {
        public IEnumerable<ItemCartDetails>? Items { get; set; }
        public ItemCartDetails? CartDetails { get; set; }
    }
}
