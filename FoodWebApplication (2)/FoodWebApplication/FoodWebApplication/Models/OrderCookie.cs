using System.Collections.Generic;

namespace FoodWebApplication.Models
{
    public class OrderCookie
    {
        public string ItemId { get; set; }
        public string ModifieCode { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public List<OrderCookie> ListChild { get; set; }
        public OrderCookie()
        {
            ListChild = new List<OrderCookie>();
        }
    }
}
