using System.Collections.Generic;
using System.ComponentModel;

namespace _02_Layout.Areas.Admin.Models
{
    public class Carts
    {
        public int Id { get; set; }
        public int AccountsID { get; set; }

        public Accounts Accounts { get; set; }

        public int ProductsID { get; set; }

        public Products Products { get; set; }
        [DisplayName("Số lượng")]
        public int Quality { get; set; }

        public List<InvoiceDetails> InvoiceDetailss { get; set; }
    }
}
