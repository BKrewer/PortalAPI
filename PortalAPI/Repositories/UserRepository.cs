using PortalAPI.Data;
using PortalAPI.Models;
using PortalAPI.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PortalAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly APIContext _context;

        public UserRepository(APIContext context)
        {
            _context = context;
        }

        public User Get(string id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.Where(x => x.Role == "user").ToList();
        }

        public IEnumerable<User> GetAllAdmins()
        {
            return _context.Users.Where(x => x.Role == "admin").ToList();
        }

        public IEnumerable<User> GetAllEmployees()
        {
            return _context.Users.Where(x => x.Role == "employee").ToList();
        }

        public User GetByEmail(string email)
        {
            User user = _context.Users.Where(x => x.Email == email).FirstOrDefault();
            return user;
        }

        public void Register(User user)
        {
            _context.Add(user);
            _context.SaveChanges();
        }

        public void Update(User user)
        {
            _context.Update(user);
            _context.SaveChanges();
        }

        public void Delete(User user)
        {
            _context.Remove(user);
            _context.SaveChanges();
        }
    }
}
