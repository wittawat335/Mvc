    using System;
    using System.Collections.Generic;
    
    public class Customer
    {
        public string Id { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Tel { get; set; }
    
        public virtual ICollection<Order> Orders { get; set; }
    }