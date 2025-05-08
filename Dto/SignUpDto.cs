namespace Onepoint_Backend.Dto
{
    public class SignUpDto
    {
        public string? EmployeeID {get; set;}

        public string Email {get; set;}

        public required long PhoneNumber {get; set;}

        public required string FullName {get; set; } 

        public string Password {get; set;}
    }
}