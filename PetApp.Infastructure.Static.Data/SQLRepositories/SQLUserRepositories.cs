using Microsoft.EntityFrameworkCore;
using PetAppCore.DomainService;
using PetShopRestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetApp.Infastructure.Static.Data.SQLRepositories
{
    public class SQLUserRepositories : IUserRepositories<User>
    {
        private readonly PetShopAppContext db; 

        public SQLUserRepositories(PetShopAppContext ctx)
        {
            db = ctx;
        }

        public void Add(User entity)
        {
            db.User.Add(entity);
            db.SaveChanges();
        }

        public void Edit(User entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }

        public User Get(long id)
        {
            return db.User.FirstOrDefault(b => b.Id == id);
        }

        public IEnumerable<User> GetAll()
        {
            return db.User.ToList();
        }

        public void Remove(long id)
        {
            var item = db.User.FirstOrDefault(b => b.Id == id);
            db.User.Remove(item);
            db.SaveChanges();
        }
    }
}
