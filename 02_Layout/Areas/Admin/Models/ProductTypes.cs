using System.Collections.Generic;
using System.ComponentModel;

namespace _02_Layout.Areas.Admin.Models
{
    public class ProductTypes
    {
        public int Id { get; set; }
        [DisplayName("Tên loại sản phẩm")]
        public string ProductTypeName { get; set; }

        public bool Status { get; set; }

        public List<Products> Productss { get; set; } 
    }
}
