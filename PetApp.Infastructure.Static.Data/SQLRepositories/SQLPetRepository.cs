using PetApp.Core.Entity;
using PetAppCore.DomainService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetApp.Infastructure.Static.Data.SQLRepositories
{
    public class SQLPetRepository : IPetRepositories
    {

        readonly PetShopAppContext _ctx;

        public SQLPetRepository(PetShopAppContext ctx)
        {
            _ctx = ctx;
        }

        public Pet CreatePet(Pet pet)
        {
            _ctx.Add(pet);
            _ctx.SaveChanges();
            return pet;
        }

        public Owner GetOwnerById(int id)
        {
            throw new NotImplementedException();
        }

        public Pet ReadyById(int id)
        {
            return _ctx.Pet.FirstOrDefault(c => c.Id == id);
        }

        public Pet Update(Pet petUpdate)
        {
            _ctx.Pet.Update(petUpdate);
            _ctx.SaveChanges();
            return petUpdate;
        }

        public void DeletePet(int id)
        {
            var pet = ReadyById(id);
            _ctx.Pet.Remove(pet);
            _ctx.SaveChanges();
        }

        public IEnumerable<Pet> ReadPets()
        {
            return _ctx.Pet;
        }
    }
}
