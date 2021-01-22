using Microsoft.EntityFrameworkCore;
using PortalAPI.Data;
using PortalAPI.Models;
using PortalAPI.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PortalAPI.Repositories
{
    public class DonationRepository : IDonationRepository
    {
        private readonly APIContext _context;

        public DonationRepository(APIContext context)
        {
            _context = context;
        }

        public Donation Get(string id)
        {
            return _context.Donations.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Donation> GetAll()
        {
            return _context.Donations
                .Include(donation => donation.Items)
                .ToList();
        }

        public IEnumerable<Donation> GetAllActive()
        {
            return _context.Donations.Where(x => x.Status == "ativo")
                .Include(donation => donation.Items)
                .ToList();
        }

        public IEnumerable<Donation> GetAllByUserId(string id)
        {
            return _context.Donations.Where(x => x.AuthorId == id)
                .Include(donation => donation.Items)
                .ToList();
        }

        public IEnumerable<Donation> GetAllByUserRequest(string id)
        {
            return _context.Donations.Where(x => x.ApplicantId == id)
                .Include(donation => donation.Items)
                .ToList();
        }

        public void Register(Donation donation)
        {
            _context.Add(donation);
            _context.SaveChanges();
        }

        public void Update(Donation donation)
        {
            _context.Update(donation);
            _context.SaveChanges();
        }

        public void Delete(Donation donation)
        {
            _context.Remove(donation);
            _context.SaveChanges();
        }
    }
}
