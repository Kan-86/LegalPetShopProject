using PetApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetApp.Infastructure.Static.Data.Repositories
{
    public static class FakeDB
    {
        public static int PetID = 1;
        public static IEnumerable<Pet> Pets;

        public static void InitData()
        {
            var pet1 = new Pet()
            {
                Id = PetID++,
                Price = 759.50,
                PetName = "mr.Snuggles",
                PetType = "Cat",
                Colour = "Black and white",
                PetPreviousOwner = "Daniel Petersen",
                //PetBirthDate = new DateTime(22, 07, 2014),
                //PetSoldDate = new DateTime(23, 08, 2014 ),
                Details = "Details:  \n\tlooks like a regular cat, it's white, fluffy" +
                "\nand his name is mr. Snuggles..."
            };

            var pet2 = new Pet()
            {
                Id = PetID++,
                Price = 200,
                PetName = "Robbit",
                PetType = "Bunny The Jumping Flash",
                Colour = "White",
                PetPreviousOwner = "Koji Tada",
                //PetBirthDate = new DateTime(28, 04, 1995),
                //PetSoldDate = new DateTime(01, 11, 1995),
                Details = "Details:  \n\tat closer inspection, I don't think it" +
                "\nis an actual rabbit, but somekind of robotic rabbit, unlike other rabbits, this one" +
                "\nseems to be able to jump extreme heights."
            };

            var pet3 = new Pet()
            {
                Id = PetID++,
                Price = 390.50,
                PetName = "DogMeat",
                PetType = "Dog",
                Colour = "Black and brown",
                PetPreviousOwner = "The Chosen One",
                //PetBirthDate = new DateTime(10, 10, 1997),
                //PetSoldDate = new DateTime(10, 10, 1997),
                Details = "Details:  \n\tIt's a male German Shepherd, what seems to" +
                "\nbe strange about this dog is that when an electric device" +
                "\nsuch as a radio is placed close to him, you can hear " +
                "\ninterference sound, like the dog is radioactive"
            };

            var pet4 = new Pet()
            {
                Id = PetID++,
                Price = 89.50,
                PetName = "Boo",
                PetType = "Space Hamster",
                Colour = "Brown and white",
                PetPreviousOwner = "Minsc Balursson",
                //PetBirthDate = new DateTime(21, 12, 1998),
                //PetSoldDate = new DateTime(03, 06, 1999),
                Details = "Details:  \n\tPrevious owner was a strange one," +
                "\nhe said the hamster was a special \"Space Hamster\"" +
                "\nit just looks like a regular hamster to me."
            };

            var pet5 = new Pet()
            {
                Id = PetID++,
                Price = 2990.50,
                PetName = "Bowser",
                PetType = "Crocodile",
                Colour = "Gree and yellow, with red hair",
                PetPreviousOwner = "Shigeru Miyamoto",
                //PetBirthDate = new DateTime(01, 01, 1985),
                Details = "Details:  \n\tDon't think we can classify" +
                "\nit as a pet, but store owner wanted him to be sold.  He has spikes" +
                "\non his back, and I swear to go he can spit fireballs.  Makes" +
                "\ngurgling sounds, tried to attack our plummer the other day!"
            };

            var pet6 = new Pet()
            {
                Id = PetID++,
                Price = 390.50,
                PetName = "Little Miss Muffet",
                PetType = "Spider",
                Colour = "Black and white",
                PetPreviousOwner = "Daniel Petersen",
                //PetBirthDate = new DateTime(18, 06, 2018),
                //PetSoldDate = new DateTime(21, 08, 2018),
                Details = "Details:  \n\tThe only normal pet we actuall have, except " +
                "\nfor the cat and the hamster."
            };

            var pet7 = new Pet()
            {
                Id = PetID++,
                Price = 5990.50,
                PetName = "mr.Snuggles",
                PetType = "Xenomorph",
                Colour = "Black and white",
                PetPreviousOwner = "Ridley Scott",
                //PetBirthDate = new DateTime(06, 09, 1979),
                Details = "Details:  \n\tIt's OUT OF THIS WORLD, I don't know" +
                "\nwhat this thing is, but it's dangerous, eats GOATs! " +
                "\nPrevious owner told us not to let him out, no matter what," +
                "\nhe mumbled something about doomsday."
            };

            var pet8 = new Pet()
            {
                Id = PetID++,
                Price = 9999,
                PetName = "Choco",
                PetType = "Chocobo",
                Colour = "Yellow",
                PetPreviousOwner = "Cloud Strife",
                //PetBirthDate = new DateTime(31, 01, 1997),
                //PetSoldDate = new DateTime(27, 05, 1998),
                Details = "Details:  \n\tIt's a big yellow bird, the previous" +
                "\nowner rode him to our store, told us they really love to eat" +
                "\nGysahl Greens, whatever that is..."
            };

            Pets = new List<Pet>
            {
                pet1,
                pet2,
                pet3,
                pet4,
                pet5,
                pet6,
                pet7,
                pet8,
            };
        }
    }
}
