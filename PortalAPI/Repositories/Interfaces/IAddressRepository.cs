using PortalAPI.Models;
using System.Collections.Generic;

namespace PortalAPI.Repositories.Interfaces
{
    public interface IAddressRepository : IRepository<Address>
    {

        IEnumerable<Address> GetAllByUserId(string id);
    }
}
