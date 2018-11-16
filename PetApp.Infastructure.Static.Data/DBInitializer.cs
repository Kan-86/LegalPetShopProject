using PetApp.Core.Entity.Models;
using PetShopRestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetApp.Infastructure.Static.Data
{
    public class DBInitializer
    {
        public static void SeedDb(PetShopAppContext ctx)
        {
            //ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();

            //if (ctx.UserToDo.Any())
            //{
            //    return;   // DB has been seeded
            //}

            List<UserToDoItem> items = new List<UserToDoItem>
            {
                new UserToDoItem { IsComplete=true, Name="Make homework"},
                new UserToDoItem { IsComplete=false, Name="Sleep"}
            };

            // Create two users with hashed and salted passwords
            string password = "1234";
            byte[] passwordHashJoe, passwordSaltJoe, passwordHashAnn, passwordSaltAnn;
            CreatePasswordHash(password, out passwordHashJoe, out passwordSaltJoe);
            CreatePasswordHash(password, out passwordHashAnn, out passwordSaltAnn);

            List<User> users = new List<User>
            {
                new User {
                    Username = "UserJoe",
                    PasswordHash = passwordHashJoe,
                    PasswordSalt = passwordSaltJoe,
                    IsAdmin = false
                },
                new User {
                    Username = "AdminAnn",
                    PasswordHash = passwordHashAnn,
                    PasswordSalt = passwordSaltAnn,
                    IsAdmin = true
                }
            };



            /*
             var owner1 = ctx.Owners.Add(new Owner()
             {
                 FirstName = "Kasper",
                 LastName = "Rask",
                 Address = "Skjoldsgade",
                 Email = "ilovepolser@polser.dk",
                 PhoneNumber = 7878997

             }).Entity;

            var owner2 = ctx.Owners.Add(new Owner()
            {
                FirstName = "Jacob",
                LastName = "Dyrvig",
                Address = "Varde(Somewhere)",
                Email = "ilikebeer@beer.dk",
                PhoneNumber = 69696969
            }).Entity;

            var pet1 = ctx.Pet.Add(new Pet()
            {
                PetName = "Meow",
                PetType = "Cat",
                Colour = "Purple",
                Details = "Wierd cat",
                PetPreviousOwner = owner1,
                PetBirthDate = DateTime.Now,
                Price = 989
            }).Entity;

            var pet2 = ctx.Pet.Add(new Pet()
            {
                PetName = "Bark",
                PetType = "Dog",
                Colour = "Green",
                Details = "Wierd dog",
                PetPreviousOwner = owner2,
                PetBirthDate = DateTime.Now,
                Price = 989
            }).Entity;
            */
            ctx.UserToDo.AddRange(items);
            ctx.User.AddRange(users);
            ctx.SaveChanges();
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
