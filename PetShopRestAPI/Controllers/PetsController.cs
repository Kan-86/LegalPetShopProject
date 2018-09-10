using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetApp.Core.Entity;
using PetAppCore.ApplicationServices;

namespace PetShopRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private readonly IPetService _petService;
        public PetsController(IPetService petService)
        {
            _petService = petService;
        }

        // GET api/pets
        [HttpGet]
        public ActionResult<IEnumerable<Pet>> Get()
        {
            return _petService.GetPets();
        }

        // GET api/pets/5
        [HttpGet("{id}")]
        public ActionResult<Pet> Get(int id)
        {
            return _petService.FindPetById(id);
        }

        // POST api/values
        [HttpPost]
        public ActionResult<Pet> Post([FromBody] Pet pet)
        {
            pet.Id = 0;
            if (string.IsNullOrEmpty(pet.PetType))
            {
                return null;
            }
            return _petService.AddPet(pet);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Pet pet)
        {
            if (id < 1 || id != pet.Id)
            {
                BadRequest("Parameter Id and Pet ID must match.");
            }
            var entity = _petService.UpdatePet(pet);
            entity.PetName = pet.PetName;
            entity.PetType = pet.PetType;
            entity.Price = pet.Price;
            entity.PetPreviousOwner = pet.PetPreviousOwner;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _petService.DeletePet(id);
        }
    }
}
