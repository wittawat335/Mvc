    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

public partial class Supplier
    {
        public string Id { get; set; }
        public string Name { get; set; }

        [FileExtensions(ErrorMessage = "ชนิดไฟล์ไม่ตรงกับที่กำหนดไว้ค่ะ (jpg, jpeg, png)", Extensions = "jpg,jpeg,png")]
        public string Logo { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    
        public virtual ICollection<Product> Products { get; set; }
    }