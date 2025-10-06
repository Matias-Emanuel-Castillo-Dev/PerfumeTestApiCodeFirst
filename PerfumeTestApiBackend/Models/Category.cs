namespace PerfumeTestApiBackend.Models

{
    public class Category :BaseModel
    {
        public string Role {  get; set; }

        public ICollection<User> Users { get; set; }

    }
}
