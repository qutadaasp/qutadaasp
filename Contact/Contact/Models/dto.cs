using System.ComponentModel.DataAnnotations;

namespace Contact.Models
{
    public class dto
    {
        
        public string name { get; set; }
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}
