using System;
using System.ComponentModel;

namespace _02_Layout.Areas.Admin.Models
{
    public class Invoices
    {
        public int Id { get; set; }

        public int AccountsID { get; set; }

        public Accounts Accounts { get; set; }

        public DateTime BuyDate { get; set; }
        [DisplayName("Địa chỉ giao hàng")]
        public string AdressOrder { get; set; }
        [DisplayName("Số điện thoại khách hàng")]
        public string PhoneOrder { get; set; }
        [DisplayName("Tổng tiền")]
        public int Total { get; set; }

        public bool Status { get; set; }
    }
}
