    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

public partial class Product
    {
        public int Id { get; set; }
        
        [Required]
        [Display(Name = "ชื่อสินค้า")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "ขนาด")]
        public string UnitBrief { get; set; }

        [Required]
        [Display(Name = "ราคา")]
        public double UnitPrice { get; set; }

      
        [Display(Name = "รูปสินค้า")]
        [FileExtensions(ErrorMessage = "ชนิดไฟล์ไม่ตรงกับที่กำหนดไว้ค่ะ (jpg, jpeg, png)", Extensions = "jpg,jpeg,png")]
        public string Image { get; set; }
        public string ImageLarge { get; set; }
        public System.DateTime ProductDate { get; set; }
        public bool Available { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public string SupplierId { get; set; }
        public int Quantity { get; set; }
        public double Discount { get; set; }
        public bool Special { get; set; }
        public bool Latest { get; set; }
        public int Views { get; set; }
    
        public virtual Category Category { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual Supplier Supplier { get; set; }
    }