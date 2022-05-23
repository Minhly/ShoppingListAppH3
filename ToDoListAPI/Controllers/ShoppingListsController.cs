using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoListAPI.Dtos;
using ToDoListAPI.Services;
using ToDoListClassLibrary.Models;

namespace ToDoListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingListsController : ControllerBase
    {
        private IShoppingListRepository _shoppingListRepository;
        public ShoppingListsController(IShoppingListRepository shoppingListRepository)
        {
            _shoppingListRepository = shoppingListRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetShoppingList(int id)
        {
            if (!await _shoppingListRepository.entityExists(id))
                return NotFound();
            var product = await _shoppingListRepository.GetById(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(product);
        }

        [HttpGet]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetShoppingLists()
        {
            var shoppinglists = await _shoppingListRepository.GetAllAsync();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var shoppinglistDto = new List<ShoppingListDto>();

            foreach (var shoppinglist in shoppinglists)
            {
                shoppinglistDto.Add(new ShoppingListDto
                {
                    Id = shoppinglist.Id,
                    Title = shoppinglist.Title,
                    Date = shoppinglist.Date
                });
            }
            return Ok(shoppinglistDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateShoppingList([FromBody] Shoppinglist shoppingListToCreate)
        {
            if (shoppingListToCreate == null)
            {
                return BadRequest(ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _shoppingListRepository.Insert(shoppingListToCreate);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.GetBaseException().Message);
                return StatusCode(500, ModelState);
            }

            return CreatedAtAction("GetShoppingList", new { id = shoppingListToCreate.Id }, shoppingListToCreate);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateShoppingList(int id, [FromBody] Shoppinglist updateShoppingList)
        {
            if (updateShoppingList == null)
            {
                return BadRequest(ModelState);
            }
            if (id != updateShoppingList.Id)
            {
                return BadRequest(ModelState);
            }
            if (!await _shoppingListRepository.entityExists(id))
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _shoppingListRepository.Update(updateShoppingList);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.GetBaseException().Message);
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShoppingList(int id)
        {
            if (!await _shoppingListRepository.entityExists(id))
                return NotFound();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _shoppingListRepository.Delete(id);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.GetBaseException().Message);
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}

