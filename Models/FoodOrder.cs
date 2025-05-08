namespace Onepoint_Backend.Models
{

    public class FoodOrder
    {
       public int Id {get; set; }

       public string ItemName {get; set;}

       public string? Description {get; set;}

       public decimal ItemQuantity {get; set; }

       public string Amount {get; set; }

       public string ReferenceNo {get; set; }

       public DateTime Date {get; set; }

       public  User User {get; set;}

       public  FoodMenu FoodMenu {get; set; }

    }
}