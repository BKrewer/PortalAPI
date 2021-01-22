using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortalAPI.Models;
using PortalAPI.Repositories.Interfaces;
using PortalAPI.ViewModels;

namespace PortalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AddressController : Controller
    {
        private readonly IAddressRepository _address;
        private readonly IMapper _mapper;

        public AddressController(IAddressRepository address, IMapper mapper)
        {
            _address = address;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            Address addressDb = _address.Get(id);
            var addressResponse = _mapper.Map<AddressResponse>(addressDb);
            return Ok(addressResponse);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var addresssDb = _address.GetAll();
            var addresssResponse = _mapper.Map<ICollection<AddressResponse>>(addresssDb);
            return Ok(addresssResponse);
        }

        [HttpGet("byuserid/{id}")]
        public IActionResult GetAllByUserId(string id)
        {
            var addresssDb = _address.GetAllByUserId(id);
            var addresssResponse = _mapper.Map<ICollection<AddressResponse>>(addresssDb);
            return Ok(addresssResponse);
        }

        [HttpPost]
        public IActionResult Add([FromBody] AddressRequest addressRequest)
        {
            Address newAddress = _mapper.Map<Address>(addressRequest);
            _address.Register(newAddress);
            return CreatedAtAction(nameof(Get), new { id = newAddress.Id }, newAddress);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] AddressRequest addressRequest)
        {
            Address addressDb = _address.Get(id);

            if (addressDb != null)
            {
                Address addressUpdated = _mapper.Map(addressRequest, addressDb);
                _address.Update(addressUpdated);
                return Ok(addressUpdated);
            }

            return NotFound(new { message = "Endereço não encontrado" });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            Address addressDb = _address.Get(id);

            if(addressDb != null)
            {
                _address.Delete(addressDb);
            }

            return NotFound(new { message = "Endereço não encontrado" });
        }
    }
}