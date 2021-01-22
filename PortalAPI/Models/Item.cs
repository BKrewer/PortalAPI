using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortalAPI.Models
{
    public class Item
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "O campo nome é obrigatório")]
        public string Name { get; set; }

        public string Description { get; set; }
        public decimal Value { get; set; }
        public float Weight { get; set; }
        public float Height { get; set; }
        public float Width { get; set; }
        public float Length { get; set; }

        [ForeignKey("Donation")]
        public string DonationId { get; set; }
        public virtual Donation Donation { get; set; }
    }
}
