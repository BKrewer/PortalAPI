using PortalAPI.Models;
using System.Collections.Generic;

namespace PortalAPI.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        User GetByEmail(string email);
        IEnumerable<User> GetAllUsers();
        IEnumerable<User> GetAllAdmins();
        IEnumerable<User> GetAllEmployees();
    }
}
