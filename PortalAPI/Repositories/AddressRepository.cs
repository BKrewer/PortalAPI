using PortalAPI.Data;
using PortalAPI.Models;
using PortalAPI.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalAPI.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly APIContext _context;

        public AddressRepository(APIContext context)
        {
            _context = context;
        }

        public Address Get(string id)
        {
            return _context.Addresses.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Address> GetAll()
        {
            return _context.Addresses.ToList();
        }

        public IEnumerable<Address> GetAllByUserId(string id)
        {
            return _context.Addresses.Where(x => x.UserId == id)
                .ToList();
        }

        public void Register(Address address)
        {
            _context.Add(address);
            _context.SaveChanges();
        }

        public void Update(Address address)
        {
            _context.Update(address);
            _context.SaveChanges();
        }

        public void Delete(Address address)
        {
            _context.Remove(address);
            _context.SaveChanges();
        }
    }
}
