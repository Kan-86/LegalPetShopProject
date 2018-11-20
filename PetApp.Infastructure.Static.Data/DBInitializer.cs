using PetApp.Core.Entity;
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


            //if (ctx.UserToDo.Any())
            //{
            //    return;   // DB has been seeded
            //}

            // Create two users with hashed and salted passwords
            string password = "1234";
            byte[] passwordHashJoe, passwordSaltJoe, passwordHashAnn, passwordSaltAnn;
            CreatePasswordHash(password, out passwordHashJoe, out passwordSaltJoe);
            CreatePasswordHash(password, out passwordHashAnn, out passwordSaltAnn);

            List<User> users = new List<User>
            {
                new User {
                    Username = "krisp",
                    PasswordHash = passwordHashJoe,
                    PasswordSalt = passwordSaltJoe,
                    IsAdmin = true
                },
                new User {
                    Username = "jacob",
                    PasswordHash = passwordHashAnn,
                    PasswordSalt = passwordSaltAnn,
                    IsAdmin = false
                }
            };



            /* lol
            var owner1 = ctx.Owners.Add(new Owner()
             {
                 FirstName = "Bastian",
                 LastName = "Bønkel",
                 Address = "Esbjerg",
                 Email = "ilovepika@pika.dk",
                 PhoneNumber = 454545

             }).Entity;

            var owner2 = ctx.Owners.Add(new Owner()
            {
                FirstName = "Nikolai",
                LastName = "Something",
                Address = "Esbjerg(Somewhere)",
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
            }).Entity;*/
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
