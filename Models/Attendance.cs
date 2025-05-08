namespace Onepoint_Backend.Models
{
    public class Attendance
    {

     public int Id { get; set; }

     public string? EmployeeID {get; set;}

     public required string Name { get; set; }

     public required string LaptopSerialNo { get; set; } 

     public required DateTime CheckInTime { get; set; }

     public DateTime? CheckOutTime { get; set; }

     public  string CheckInQrCode { get; set; }

     public  string CheckOutQrCode { get; set; }

     public string Wifissid {get; set;}

     public string Ipaddress {get; set;}

      public  User User { get; set; }


    }
}