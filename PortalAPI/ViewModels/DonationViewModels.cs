using System.Collections.Generic;

namespace PortalAPI.ViewModels
{
    public class DonationRequest
    {
        public string Name { get; set; }
        public string AuthorId { get; set; }
    }

    public class DonationResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string AuthorId { get; set; }

        public ICollection<ItemResponse> Items { get; set; }
    }
}
