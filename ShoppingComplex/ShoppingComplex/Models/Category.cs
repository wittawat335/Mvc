    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

public class Category
    {
        public int Id { get; set; }
        public string NameVN { get; set; }
        public string Name { get; set; }
        [FileExtensions(ErrorMessage = "ชนิดไฟล์ไม่ตรงกับที่กำหนดไว้ค่ะ (jpg, jpeg, png)", Extensions = "jpg,jpeg,png")]
        public string Image{ get; set; }

        [FileExtensions(ErrorMessage = "ชนิดไฟล์ไม่ตรงกับที่กำหนดไว้ค่ะ (jpg, jpeg, png)", Extensions = "jpg,jpeg,png")]
        public string Icon { get; set; }
    
        public virtual ICollection<Product> Products { get; set; }
    }