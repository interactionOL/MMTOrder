using System.ComponentModel.DataAnnotations;

namespace MMT.Orders.Business
{
    public class Product
    {
        public int ProductId { get; set; }

        [MaxLength( 50 )]
        public string ProductName { get; set; }
        public decimal PackHeight { get; set; }
        public decimal PackWidth { get; set; }

        [MaxLength( 20 )]
        public string Colour { get; set; }

        [MaxLength( 20 )]
        public string Size { get; set; }
    }

}
