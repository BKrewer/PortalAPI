using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortalAPI.Models
{
    public class Donation
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string ApplicantId { get; set; }

        public ICollection<Item> Items { get; set; }

        [ForeignKey("User")]
        public string AuthorId { get; set; }
        public virtual User User { get; set; }

        public Donation()
        {
            Status = "pendente";
        }
    }
}
