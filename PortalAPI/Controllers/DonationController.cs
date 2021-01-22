using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PortalAPI.Models;
using PortalAPI.Repositories.Interfaces;
using PortalAPI.ViewModels;

namespace PortalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DonationController : Controller
    {
        private readonly IDonationRepository _donation;
        private readonly IMapper _mapper;

        public DonationController(IDonationRepository donation, IMapper mapper)
        {
            _donation = donation;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            Donation donationDb = _donation.Get(id);
            var donationResponse = _mapper.Map<DonationResponse>(donationDb);
            return Ok(donationResponse);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var donationsDb = _donation.GetAll();
            var donationsResponse = _mapper.Map<ICollection<DonationResponse>>(donationsDb);
            return Ok(donationsResponse);
        }

        [HttpGet("getallactive")]
        [AllowAnonymous]
        public IActionResult GetAllActive()
        {
            var donationsDb = _donation.GetAllActive();
            var donationsResponse = _mapper.Map<ICollection<DonationResponse>>(donationsDb);
            return Ok(donationsResponse);
        }

        [HttpGet("byuserid/{id}")]
        public IActionResult GetAllByUserId(string id)
        {
            var donationsDb = _donation.GetAllByUserId(id);
            var donationsResponse = _mapper.Map<ICollection<DonationResponse>>(donationsDb);
            return Ok(donationsResponse);
        }

        [HttpGet("byuserrequest/{id}")]
        public IActionResult GetAllByUserRequest(string id)
        {
            var donationsDb = _donation.GetAllByUserRequest(id);
            var donationsResponse = _mapper.Map<ICollection<DonationResponse>>(donationsDb);
            return Ok(donationsResponse);
        }

        [HttpPost]
        public IActionResult Add([FromBody] DonationRequest donationRequest)
        {
            Donation newDonation = _mapper.Map<Donation>(donationRequest);
            _donation.Register(newDonation);
            return CreatedAtAction(nameof(Get), new { id = newDonation.Id }, newDonation);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] DonationRequest donationRequest)
        {
            Donation donationDb = _donation.Get(id);

            if (donationDb != null)
            {
                Donation donationUpdated = _mapper.Map(donationRequest, donationDb);
                _donation.Update(donationUpdated);
                return Ok(donationUpdated);
            }

            return NotFound(new { message = "Doação não encontrada" });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            Donation donationDb = _donation.Get(id);

            if (donationDb != null)
            {
                _donation.Delete(donationDb);
            }

            return NotFound(new { message = "Doação não encontrada" });
        }

        [HttpPatch("changestatus/{id}/{status}")]
        [Authorize(Roles = "employee, admin")]
        public IActionResult ChangeStatus(string id, string status)
        {
            Donation donationDb = _donation.Get(id);
            if (donationDb != null)
            {
                status.ToLower();
                donationDb.Status = status;
                _donation.Update(donationDb);

                return Ok(donationDb);
            }

            return NotFound(new { message = "Doação não encontrada" });
        }

        [HttpPatch("userrequest/{id}/{userId}/{status}")]
        public IActionResult UserRequest(string id, string userId, string status)
        {
            Donation donationDb = _donation.Get(id);
            if (donationDb != null)
            {
                donationDb.ApplicantId = userId;
                donationDb.Status = status;
                _donation.Update(donationDb);

                return Ok(donationDb);
            }

            return NotFound(new { message = "Doação não encontrada" });
        }
    }
}