namespace _02_Layout.Areas.Admin.Models
{
    public class Rate
    {
        public int Id { get; set; }
        public int AccountID { get; set; }

        public Accounts Accounts { get; set; }

        public int ProductID { get; set; }

        public Products Products { get; set; }

        public int Score { get; set; }
    }
}
