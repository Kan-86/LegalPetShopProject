using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetApp.Core.Entity.Models;
using PetApp.Infastructure.Static.Data;
using PetAppCore.DomainService;
using PetShopRestAPI.Models;

namespace PetShopRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IUserRepositories<UserToDoItem> repository;

        public UsersController(IUserRepositories<UserToDoItem> repos)
        {
            repository = repos;
        }

        // GET: api/Todo
        [Authorize]
        [HttpGet]
        public IEnumerable<UserToDoItem> GetAll()
        {
            return repository.GetAll();
        }

        // GET: api/Todo/5
        [Authorize(Roles = "Administrator")]
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(long id)
        {
            var item = repository.Get(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        // POST: api/Todo
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public IActionResult Post([FromBody] UserToDoItem item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            repository.Add(item);

            return CreatedAtRoute("Get", new { id = item.Id }, item);
        }

        // PUT: api/Todo/5
        [Authorize(Roles = "Administrator")]
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] UserToDoItem item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var todo = repository.Get(id);
            if (todo == null)
            {
                return NotFound();
            }

            todo.IsComplete = item.IsComplete;
            todo.Name = item.Name;

            repository.Edit(todo);
            return new NoContentResult();
        }

        // DELETE: api/ApiWithActions/5
        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var todo = repository.Get(id);
            if (todo == null)
            {
                return NotFound();
            }

            repository.Remove(id);
            return new NoContentResult();
        }
    }
   
}