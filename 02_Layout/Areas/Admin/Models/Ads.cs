using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace _02_Layout.Areas.Admin.Models
{
    public class Ads
    {
        public int Id { get; set; }
        //[RegularExpression(@"^[a-zA-Z0-9]+\.(jpg|JPG|png|PNG|Jpg|jPg|jpG|Png|pNg|pnG)$", ErrorMessage = "Định dạng ảnh phải là .jpg hoặc .png")]
        public string Image { get; set; }
        [NotMapped]
        [DisplayName("Hình ảnh")]
        public IFormFile ImageFile { get; set; }
        public bool Status { get; set; }
    }
}
