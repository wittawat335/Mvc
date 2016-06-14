﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ShoppingComplex.Models;

public class Order
    {
        public int Id { get; set; }
    
        public string CustomerId { get; set; }

    
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime OrderDate { get; set; }

        public DateTime RequireDate { get; set; }

        [Display(Name = "ชื่อผู้รับ")]
        public string Receiver { get; set; }

       
        public string Address { get; set; }
    
        public string Description { get; set; }
        
        public bool view { get; set; }
     
        public double Amount { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }

