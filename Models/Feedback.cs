namespace Onepoint_Backend.Models
{
public class Feedback
   {
     public int Id { get; set; } 

     public string Message { get; set; }

      public string Status { get; set; }

      public string Response { get; set; }

       public string Type { get; set; }

     public DateTime SubmittedAt { get; set; }
    
     public bool IsRead { get; set; }

     public  User User { get; set; }

    }

}
