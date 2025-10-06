namespace PerfumeTestApiBackend.Models.DTOs
{
    public class UserCreateDTO 
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Category {  get; set; }
    }
}
