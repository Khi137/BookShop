using System.ComponentModel;

namespace _02_Layout.Areas.Admin.Models
{
    public class InvoiceDetails
    {
        public int Id { get; set; }
        public int InvoicesID { get; set; }
        public Invoices Invoices { get; set; }
        public int ProductsID { get; set; }
        public Products Products { get; set; }
        [DisplayName("Số lượng")]
        public int Quality { get; set; }
        [DisplayName("Đơn giá")]
        public int Total { get; set; }
    }
}
