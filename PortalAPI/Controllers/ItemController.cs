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
    public class ItemController : Controller
    {
        private readonly IItemRepository _item;
        private readonly IMapper _mapper;

        public ItemController(IItemRepository item, IMapper mapper)
        {
            _item = item;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            Item itemDb = _item.Get(id);
            var itemResponse = _mapper.Map<ItemResponse>(itemDb);
            return Ok(itemResponse);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var itemsDb = _item.GetAll();
            var itemsResponse = _mapper.Map<ICollection<ItemResponse>>(itemsDb);
            return Ok(itemsResponse);
        }

        [HttpPost]
        public IActionResult Add([FromBody] ItemRequest itemRequest)
        {
            Item newItem = _mapper.Map<Item>(itemRequest);
            _item.Register(newItem);
            return CreatedAtAction(nameof(Get), new { id = newItem.Id }, newItem);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] ItemRequest itemRequest)
        {
            Item itemDb = _item.Get(id);

            if (itemDb != null)
            {
                Item itemUpdated = _mapper.Map(itemRequest, itemDb);
                _item.Update(itemUpdated);
                return Ok(itemUpdated);
            }

            return NotFound(new { message = "Item não encontrado" });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            Item itemDb = _item.Get(id);

            if (itemDb != null)
            {
                _item.Delete(itemDb);
            }

            return NotFound(new { message = "Item não encontrado" });
        }
    }
}