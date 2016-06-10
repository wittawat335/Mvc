    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

public partial class Product
    {
        public int Id { get; set; }
        
        [Required]
        [Display(Name = "�����Թ���")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "��Ҵ")]
        public string UnitBrief { get; set; }

        [Required]
        [Display(Name = "�Ҥ�")]
        public double UnitPrice { get; set; }

        [Required]
        [Display(Name = "�ٻ�Թ���")]
        [FileExtensions(ErrorMessage = "��Դ������ç�Ѻ����˹������ (jpg, jpeg, png)", Extensions = "jpg,jpeg,png")]
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