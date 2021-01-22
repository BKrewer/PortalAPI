using System.ComponentModel.DataAnnotations.Schema;

namespace PortalAPI.Models
{
    public class Address 
    {
        public string Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Complement { get; set; }
        public string State { get; set; }
        public string CEP { get; set; }
        public string Country { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public virtual User User { get; set; }
    }
}
