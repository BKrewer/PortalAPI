using PortalAPI.Data;
using PortalAPI.Models;
using PortalAPI.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalAPI.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly APIContext _context;

        public ItemRepository(APIContext context)
        {
            _context = context;
        }

        public Item Get(string id)
        {
            return _context.Items.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Item> GetAll()
        {
            return _context.Items.ToList();
        }

        public void Register(Item item)
        {
            _context.Add(item);
            _context.SaveChanges();
        }

        public void Update(Item item)
        {
            _context.Update(item);
            _context.SaveChanges();
        }

        public void Delete(Item item)
        {
            _context.Remove(item);
            _context.SaveChanges();
        }
    }
}
