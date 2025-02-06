using System;
using System.Collections.Generic;

namespace ECOMSYSTEM.DataAccess.EntityModel
{
    public partial class TblProduct
    {
        public TblProduct()
        {
            TblItemCarts = new HashSet<TblItemCart>();
        }

        public long ProductId { get; set; }
        public string? ProductName { get; set; }
        public int? ProductCategoryId { get; set; }
        public int? ProductSubCategoryId { get; set; }
        public string? Description { get; set; }
        public double? Price { get; set; }
        public string? ImageName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<TblItemCart> TblItemCarts { get; set; }
    }
}
