using Microsoft.EntityFrameworkCore;
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
            /*if (pet.PetPreviousOwner != null
                && _ctx.ChangeTracker.Entries<Pet>()
                .FirstOrDefault(pe => pe.Entity.Id == pet.Id) == null)
            {
                _ctx.Attach(pet.PetPreviousOwner);
            }
            var saved =_ctx.Pet.Add(pet).Entity;
            _ctx.SaveChanges();
            return saved;*/
            _ctx.Attach(pet).State = EntityState.Added;
            _ctx.SaveChanges();
            return pet;
        }

        public Owner GetOwnerById(int id)
        {
            throw new NotImplementedException();
        }

        public Pet ReadyById(int id)
        {
            return _ctx.Pet.Include(o => o.PetPreviousOwner).FirstOrDefault(c => c.Id == id);
        }

        public Pet Update(Pet petUpdate)
        {
            if (petUpdate.PetPreviousOwner != null
                && _ctx.ChangeTracker.Entries<Pet>()
                .FirstOrDefault(pe => pe.Entity.Id == petUpdate.Id) == null)
            {
                _ctx.Attach(petUpdate.PetPreviousOwner);
            }
            else
            {
                _ctx.Entry(petUpdate)
                    .Reference(p => p.PetPreviousOwner).IsModified = true;
            }
            var updated = _ctx.Pet.Update(petUpdate).Entity;
            _ctx.SaveChanges();
            return updated;
        }

        public void DeletePet(int id)
        {
            _ctx.Remove(new Pet() {Id = id});
            _ctx.SaveChanges();
            /*var pet = ReadyById(id);
            _ctx.Pet.Remove(pet);
            _ctx.SaveChanges();*/
        }

        public Pet FindPetByIdIncludeOwners(int id)
        {
            return _ctx.Pet.Include(o => o.PetPreviousOwner)
                .FirstOrDefault(p => p.Id == id);
        }

        public int Count()
        {
            return _ctx.Pet.Count();
        }

        public IEnumerable<Pet> ReadPets(Filter filter)
        {
            if (filter == null)
            {
                return _ctx.Pet.Include(o => o.PetPreviousOwner);
            }
            return _ctx.Pet.Include(o => o.PetPreviousOwner)
                .Skip((filter.CurrentPage - 1) * filter.ItemsPrPage)
                .Take(filter.ItemsPrPage);
        }
    }
}
