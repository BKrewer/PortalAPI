using PortalAPI.Models;
using System.Collections.Generic;

namespace PortalAPI.Repositories.Interfaces
{
    public interface IDonationRepository : IRepository<Donation>
    {
        IEnumerable<Donation> GetAllActive();
        IEnumerable<Donation> GetAllByUserId(string id);
        IEnumerable<Donation> GetAllByUserRequest(string id);  
    }
}
