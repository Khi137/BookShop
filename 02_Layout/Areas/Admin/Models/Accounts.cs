using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _02_Layout.Areas.Admin.Models
{
    public class Accounts
    {
        public int Id { get; set; }
        [DisplayName("Tên tài khoản")]
        [Required(ErrorMessage = "Tên tài khoản không được bỏ trống")]
        [MinLength(5, ErrorMessage = "Kí tự tối thiểu là 5"), MaxLength(20, ErrorMessage = "Kí tự tối đa là 20")]
        public string UserName { get; set; }
        [DisplayName("Mật khẩu")]
        [MinLength(6, ErrorMessage = "Kí tự tối thiểu là 6"), MaxLength(30, ErrorMessage = "Kí tự tối đa là 30")]
        public string Password { get; set; }

        [DisplayName("Số điện thoại")]
        [Required(ErrorMessage = "Số điện thoại không được bỏ trống")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Số điện thoại không hợp lệ,bắt buộc 10 số!")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Địa chỉ không được bỏ trống")]
        [DisplayName("Địa chỉ")]
        public string Adress { get; set; }
        [Required(ErrorMessage = "Họ và tên không được bỏ trống")]
        [DisplayName("Họ và tên")]
        public string FullName { get; set; }
        [DisplayName("Quản trị viên")]
        public bool IsAdmin { get; set; }
        [DisplayName("Ảnh đại diện")]

        //[Required(ErrorMessage = "Vui lòng chọn hình ảnh"), RegularExpression(@"^[a-zA-Z0-9]+\.(jpg|JPG|png|PNG|Jpg|jPg|jpG|Png|pNg|pnG)$", ErrorMessage = "Định dạng ảnh phải là .jpg hoặc .png")]
        public string Avatar { get; set; }
        [NotMapped]
        [DisplayName("Hình ảnh")]
        public IFormFile AvatarFile { get; set; }
        public bool Status { get; set; }

        public List<Carts> Cartss { get; set; }

        public List<Invoices> Invoicess { get; set; }

        public List<Rate> Rates { get; set; }
        public List<Comments> Commentss { get; set; }
    }
}
