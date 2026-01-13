namespace KASHOP.Models
{
    public enum Status{
        Active=1,
        In_Active=2
    }
    public class BaseModel
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }= DateTime.Now;

        public Status status { get; set; }=Status.Active;
    }
}
