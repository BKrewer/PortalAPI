using AutoMapper;
using PortalAPI.Models;
using PortalAPI.ViewModels;
using System.Collections.ObjectModel;

namespace PortalAPI.AutoMapper
{
    public class ApplicationMapProfile : Profile
    {
        public ApplicationMapProfile()
        {
            CreateMap<User, LoginRequest>();

            CreateMap<User, UserRequest>()
                .ReverseMap()
                .ForMember(x => x.Addresses, opt => opt.Ignore())
                .ForMember(x => x.Donations, opt => opt.Ignore());
            CreateMap<User, UserResponse>();

            CreateMap<Address, AddressRequest>()
                .ReverseMap();
            CreateMap<Address, AddressResponse>();

            CreateMap<Donation, DonationRequest>()
                .ReverseMap()
                .ForMember(d => d.Items, opt => opt.Ignore());
            CreateMap<Donation, DonationResponse>();

            CreateMap<Item, ItemRequest>()
                .ReverseMap();
            CreateMap<Item, ItemResponse>();


        }
    }
}
