using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECOMSYSTEM.Shared.Models
{
    public class OrderDetails
    {
        public long OrderId { get; set; }
        public long UserId { get; set; }
        public long ItemId { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? Mobile { get; set; }
        public double? OderValue { get; set; }
        public bool? IsActive { get; set; }
        public string? OrderStatus { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsOrderAccept { get; set; }
        public long? SupplierId { get; set; }
        public string? Type { get; set; }
        public string? ItemName { get; set; }
        public string? ItemDescription { get; set; }
        public int? ItemQty { get; set; }
    }
}