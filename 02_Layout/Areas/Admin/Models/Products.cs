using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _02_Layout.Areas.Admin.Models
{
    public class Products
    {
        public int Id { get; set; }
        [DisplayName("Tên sản phẩm")]
        [Required(ErrorMessage = "Tên sản phẩm không được bỏ trống")]
        public string ProductName { get; set; }
        [DisplayName("Mô tả")]
        [Required(ErrorMessage = "Mô tả không được bỏ trống")]
        public string Description { get; set; }
        [DisplayName("Giá")]
        public int Price { get; set; }
        [DisplayName("Tồn kho")]
        public int Inventory { get; set; }
        [DisplayName("Loại sản phẩm")]
        public int ProductTypesID { get; set; }
        [DisplayName("Loại sản phẩm")]
        public ProductTypes ProductTypes { get; set; } //Navigation reference property
        [DisplayName("Hình ảnh")]
        //[Required(ErrorMessage = "Vui lòng chọn hình ảnh"), RegularExpression(@"^[a-zA-Z0-9]+\.(jpg|JPG|png|PNG|Jpg|jPg|jpG|Png|pNg|pnG)$", ErrorMessage = "Định dạng ảnh phải là .jpg hoặc .png")]
        //[RegularExpression(@"^[a-zA-Z0-9]+\.(jpg|JPG|png|PNG|Jpg|jPg|jpG|Png|pNg|pnG)$", ErrorMessage = "Định dạng ảnh phải là .jpg hoặc .png")]
        public string Image { get; set; }
        [NotMapped]
        [DisplayName("Hình ảnh")]
        public IFormFile ImageFile {get;set;}
        public bool Status { get; set; }
        public List<Carts> Carts { get; set; }
        public List<InvoiceDetails> InvoicesDetailss { get; set; }

        public List<Rate> Rates { get; set; }

        public List<Comments> Commentss { get; set; }
    }
}
