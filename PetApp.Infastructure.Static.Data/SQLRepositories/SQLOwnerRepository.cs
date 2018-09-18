using PetApp.Core.Entity;
using PetAppCore.DomainService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetApp.Infastructure.Static.Data.SQLRepositories
{
    public class SQLOwnerRepository : IOwnerRepositories
    {
        readonly PetShopAppContext _ctx;

        public SQLOwnerRepository(PetShopAppContext ctx)
        {
            _ctx = ctx;
        }

        public Owner CreateOwner(Owner owner)
        {
            _ctx.Add(owner);
            _ctx.SaveChanges();
            return owner;
        }

        public Owner GetOwnerById(int id)
        {
            return _ctx.Owners.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Owner> ReadOwner()
        {
            return _ctx.Owners;
        }

        public Owner ReadyById(int id)
        {
            return _ctx.Owners.FirstOrDefault(c => c.Id == id);
        }

        public Owner Update(Owner ownerUpdate)
        {
            _ctx.Owners.Update(ownerUpdate);
            _ctx.SaveChanges();
            return ownerUpdate;
        }

        public void DeleteOwner(int id)
        {
            var pet = ReadyById(id);
            _ctx.Owners.Remove(pet);
            _ctx.SaveChanges();
        }
    }
}
