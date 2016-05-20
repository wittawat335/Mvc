    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

public partial class OrderDetail
    {
        public int Id { get; set; }

        [Display(Name = "Order No.")]
        public int OrderId { get; set; }

        
        public int ProductId { get; set; }
        public double UnitPrice { get; set; }
        public int Quantity { get; set; }
        public double Discount { get; set; }
    
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }