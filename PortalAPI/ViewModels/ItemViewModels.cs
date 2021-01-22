namespace PortalAPI.ViewModels
{
    public class ItemRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public float Weight { get; set; }
        public float Height { get; set; }
        public float Width { get; set; }
        public float Length { get; set; }
        public string DonationId { get; set; }
    }

    public class ItemResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public float Weight { get; set; }
        public float Height { get; set; }
        public float Width { get; set; }
        public float Length { get; set; }
        public string DonationId { get; set; }
    }
}
