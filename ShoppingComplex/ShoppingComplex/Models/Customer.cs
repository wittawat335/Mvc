﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingComplex.Models
{
    public class Customer
    {
        public string Id { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Tel { get; set; }
        public DateTime DateRegister { get; set; }
        public bool Activated { get; set; } 
    }
}