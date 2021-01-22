namespace PortalAPI.ViewModels
{
    public class AddressRequest
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string Complement { get; set; }
        public string State { get; set; }
        public string CEP { get; set; }
        public string Country { get; set; }
        public string UserId { get; set; }
    }

    public class AddressResponse
    {
        public string Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Complement { get; set; }
        public string State { get; set; }
        public string CEP { get; set; }
        public string Country { get; set; }
        public string UserId { get; set; }
    }
}
