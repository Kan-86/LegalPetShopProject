using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetApp.Core.Entity;
using PetAppCore.ApplicationServices;
using PetAppCore.ApplicationServices.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PetShopRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnersController : ControllerBase
    {
        private readonly IOwnerServices _ownerService;
        public OwnersController(IOwnerServices ownerService)
        {
            _ownerService = ownerService;
        }

        // GET: api/<controller>
        [HttpGet]
        public ActionResult <IEnumerable<Owner>> Get()
        {
            return _ownerService.GetOwners();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public ActionResult<Owner> Get(int id)
        {
            return _ownerService.FindOwnerById(id);
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult<Owner> Post([FromBody]Owner owner)
        {
            owner.Id = 0;
            if (string.IsNullOrEmpty(owner.Address)||string.IsNullOrEmpty(owner.FirstName) || string.IsNullOrEmpty(owner.LastName))
            {
                return null;
            }
            return _ownerService.AddOwner(owner);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public ActionResult<Owner> Put(int id, [FromBody]Owner owner)
        {
            var entity = _ownerService.UpdateOwner(owner);
            entity.FirstName = owner.FirstName;
            entity.LastName = owner.LastName;
            entity.Address = owner.Address;
            entity.PhoneNumber = owner.PhoneNumber;
            entity.Email = owner.Email;
            return entity;
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _ownerService.DeleteOwner(id);
        }
    }
}
