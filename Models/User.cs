namespace Onepoint_Backend.Models
{
    public class User
    {
        public Guid Id { get; set; } 
        public string? EmployeeID { get; set; }

        public required string Email { get; set; }

        public required long PhoneNumber {get; set;}

        public required string FullName {get; set; } 

        public required string PasswordHash {get; set; }

        public string? Role {get; set; }

        public  ICollection<Attendance> Attendances {get; set; }
        public  ICollection<FoodOrder> FoodOrders {get; set; } 
        public  ICollection<Feedback> Feedbacks {get; set; }
        
    }
}