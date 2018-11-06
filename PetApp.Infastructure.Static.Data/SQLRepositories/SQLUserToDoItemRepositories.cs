using Microsoft.EntityFrameworkCore;
using PetApp.Core.Entity.Models;
using PetAppCore.DomainService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetApp.Infastructure.Static.Data.SQLRepositories
{
    public class SQLUserToDoItemRepositories : IUserRepositories<UserToDoItem>
    {
        private readonly PetShopAppContext db;

        public SQLUserToDoItemRepositories(PetShopAppContext ctx)
        {
            db = ctx;
        }

        public void Add(UserToDoItem entity)
        {
            db.UserToDo.Add(entity);
            db.SaveChanges();
        }

        public void Edit(UserToDoItem entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }

        public UserToDoItem Get(long id)
        {
            return db.UserToDo.FirstOrDefault(b => b.Id == id);
        }

        public IEnumerable<UserToDoItem> GetAll()
        {
            return db.UserToDo.ToList();
        }

        public void Remove(long id)
        {
            var item = db.UserToDo.FirstOrDefault(b => b.Id == id);
            db.UserToDo.Remove(item);
            db.SaveChanges();
        }
    }
}
