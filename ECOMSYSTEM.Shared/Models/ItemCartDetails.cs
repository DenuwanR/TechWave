using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECOMSYSTEM.Shared.Models
{
    public class ItemCartDetails
    {

        /// <summary>
        /// Gets or sets the item identifier.
        /// </summary>
        /// <value>
        /// The item identifier.
        /// </value>
        public long ItemId { get; set; }

        /// <summary>
        /// Gets or sets the product identifier.
        /// </summary>
        /// <value>
        /// The product identifier.
        /// </value>
        public long ProductId { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public long UserId { get; set; }

        /// <summary>
        /// Gets or sets the item price.
        /// </summary>
        /// <value>
        /// The item price.
        /// </value>
        public float ItemPrice { get; set; }

        public int? ItemQty { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is in cart.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is in cart; otherwise, <c>false</c>.
        /// </value>
        public bool IsInCart { get; set; }

        /// <summary>
        /// Gets or sets the created date.
        /// </summary>
        /// <value>
        /// The created date.
        /// </value>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the name of the item.
        /// </summary>
        /// <value>
        /// The name of the item.
        /// </value>
        public string? ItemName { get; set; }

        public string? ItemDescription { get; set; }

        /// <summary>
        /// Gets or sets the name of the item.
        /// </summary>
        /// <value>
        /// The name of the item.
        /// </value>
        public double? TotalPrice { get; set; }

        public double? TotalAllItems { get; set; }

    }
}
