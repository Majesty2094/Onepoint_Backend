namespace Onepoint_Backend.Models
{
    public class FoodMenu
    {
        public int Id {get; set; } 

        public string ItemName {get; set; }

        public string Description {get; set; }

        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

    }
}