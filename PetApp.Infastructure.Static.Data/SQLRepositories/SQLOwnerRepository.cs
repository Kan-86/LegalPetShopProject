using Microsoft.EntityFrameworkCore;
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
            /*if (owner.Pets != null
                && _ctx.ChangeTracker.Entries<Owner>()
                .FirstOrDefault(oe => oe.Entity.Id == owner.Id) == null)
            {
                _ctx.Attach(owner);
            }
            var saved =_ctx.Owners.Add(owner).Entity;
            _ctx.SaveChanges();
            return saved;*/

            _ctx.Attach(owner).State = EntityState.Added;
            _ctx.SaveChanges();
            return owner;
        }

        public Owner GetOwnerById(int id)
        {
            return _ctx.Owners.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Owner> ReadOwner()
        {
            return _ctx.Owners.Include(o => o.Pets);
        }

        public Owner ReadyById(int id)
        {
            return _ctx.Owners.Include(p => p.Pets)
                .FirstOrDefault(c => c.Id == id);
        }

        public Owner Update(Owner ownerUpdate)
        {
            _ctx.Owners.Update(ownerUpdate);
            _ctx.SaveChanges();
            return ownerUpdate;
        }

        public void DeleteOwner(int id)
        {
            _ctx.Remove(new Owner() { Id = id });
            _ctx.SaveChanges();
        }

        public Owner ReadyByIdIncludePets(int id)
        {
            return _ctx.Owners
                .Include(o => o.Pets)
                .FirstOrDefault(o => o.Id == id);
        }
    }
}
