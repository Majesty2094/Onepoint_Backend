namespace Onepoint_Backend.Models
{
    public class Notification
    {
        public Guid Id { get; set; }

        public string EmployeeID {get; set; }

        public string Title { get; set; }

        public string Message { get; set; }

        public string Type { get; set; } 

        public DateTime CreatedAt { get; set; }

        public  User User {get; set;}

    }   

}        