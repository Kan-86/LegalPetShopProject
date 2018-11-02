using System;
using System.Collections.Generic;
using System.Text;

namespace PetApp.Infastructure.Static.Data
{
    public class DBInitializer
    {
        public static void SeedDb(PetShopAppContext ctx)
        {
            //ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();
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
            ctx.SaveChanges();
        }
    }
}
