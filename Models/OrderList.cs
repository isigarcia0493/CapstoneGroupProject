using System.ComponentModel.DataAnnotations;

namespace CapstoneGroupProject.Models
{
    public class OrderList
    {
        [Key]
        public int ID { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
    }
}
