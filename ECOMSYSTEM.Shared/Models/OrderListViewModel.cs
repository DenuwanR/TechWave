using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECOMSYSTEM.Shared.Models
{
    public class OrderListViewModel
    {
        public IEnumerable<OrderDetails>? orders { get; set; }
        public ItemCartDetails? CartDetails { get; set; }
    }
}
