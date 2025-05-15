using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoApi.Models;
using ToDoApi.Services;

namespace ToDoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ToDoController : ControllerBase
    {
        private readonly ITodoService _todoService;

        public ToDoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var items = _todoService.GetAll();
            return Ok(items);
        }

        [HttpGet("pending")]
        public IActionResult GetPending()
        {
            var items = _todoService.GetPendingItems();
            return Ok(items);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ToDoItem item)
        {

            var createdItem = _todoService.Add(item);
            return CreatedAtAction(nameof(Get), new { id = createdItem.Id }, createdItem);
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id)
        {
            _todoService.MarkAsCompleted(id);
            return NoContent();
        }
    }

}
