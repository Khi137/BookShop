namespace _02_Layout.Areas.Admin.Models
{
    public class Comments
    {
        public int Id { get; set; }
        public int AccountsID { get; set; }

        public Accounts Accounts { get; set; }
        public int ProductsID { get; set; }
        public Products Products { get; set; }

        public string Comment { get; set; }

        public bool Status { get; set; }
    }
}
