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

        public static int OwnerID = 1;
        public static IEnumerable<Owner> Owners;

        public static void InitData()
        {
            var owner1 = new Owner()
            {
                Id = OwnerID++,
                FirstName = "Jacob Dyrvig",
                LastName = "Sorensen",
                PhoneNumber = 6666969,
                Address = "Varde(Somewhere)",
                Email = "ilovekebab@kebab.com"
            };

            var owner2 = new Owner()
            {
                Id = OwnerID++,
                FirstName = "Kaser ",
                LastName = "Rask",
                PhoneNumber = 696969696,
                Address = "Esbjerg(Somewhere)",
                Email = "ilovepolser@polser.com"
            };

            var owner3 = new Owner()
            {
                Id = OwnerID++,
                FirstName = "Krisp Krisp",
                LastName = "Andersen",
                PhoneNumber = 010101001,
                Address = "Esbjerg(Somewhere)",
                Email = "imadad@nosleep.com"
            };

            var owner4 = new Owner()
            {
                Id = OwnerID++,
                FirstName = "Jesus ",
                LastName = "Christ",
                PhoneNumber = 33333333,
                Address = "Jerusalem(Somewhere)",
                Email = "walkonwater@faith.com"
            };

            var owner5 = new Owner()
            {
                Id = OwnerID++,
                FirstName = "Donald ",
                LastName = "Trump",
                PhoneNumber = 1,
                Address = "Washington DC",
                Email = "mybuttonisbiggerthanyours@boom.com"
            };

            var owner6 = new Owner()
            {
                Id = OwnerID++,
                FirstName = "Donald ",
                LastName = "Trump",
                PhoneNumber = 1,
                Address = "Washington DC",
                Email = "mybuttonisbiggerthanyours@boom.com"
            };

            var owner7 = new Owner()
            {
                Id = OwnerID++,
                FirstName = "Ronald ",
                LastName = "Regan",
                PhoneNumber = 1,
                Address = "Washington DC",
                Email = "ididsomething@shake.com"
            };

            var owner8 = new Owner()
            {
                Id = OwnerID++,
                FirstName = "Loops ",
                LastName = "Hoops",
                PhoneNumber = 1,
                Address = "MainFrame DC",
                Email = "hackeman@yeah.com"
            };

            Owners = new List<Owner>
            {
                owner1,
                owner2,
                owner3,
                owner4,
                owner5,
                owner6,
                owner7,
                owner8
            };

            var pet1 = new Pet()
            {
                Id = PetID++,
                Price = 759.50,
                PetName = "mr.Snuggles",
                PetType = "Cat",
                Colour = "Black and white",
                PetPreviousOwner = owner1,
                PetBirthDate = new DateTime(2014, 6, 29),
                //PetSoldDate = new DateTime(2014, 08,  24),
                Details = "Details:  \tlooks like a regular cat, it's white, fluffy" +
                "\nand his name is mr. Snuggles..."
            };

            var pet2 = new Pet()
            {
                Id = PetID++,
                Price = 200,
                PetName = "Robbit",
                PetType = "Bunny The Jumping Flash",
                Colour = "White",
                PetPreviousOwner = new Owner() {Id = 2},
                //PetBirthDate = new DateTime(28, 04, 1995),
                //PetSoldDate = new DateTime(01, 11, 1995),
                Details = "Details:  \tat closer inspection, I don't think it" +
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
                PetPreviousOwner = new Owner() { Id = 3},
                //PetBirthDate = new DateTime(10, 10, 1997),
                //PetSoldDate = new DateTime(10, 10, 1997),
                Details = "Details:  \tIt's a male German Shepherd, what seems to" +
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
                PetPreviousOwner = new Owner() { Id = 4 },
                //PetBirthDate = new DateTime(21, 12, 1998),
                //PetSoldDate = new DateTime(03, 06, 1999),
                Details = "Details:  \tPrevious owner was a strange one," +
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
                PetPreviousOwner = new Owner() { Id = 5 },
                //PetBirthDate = new DateTime(01, 01, 1985),
                Details = "Details:  \tDon't think we can classify" +
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
                PetPreviousOwner = new Owner() {Id = 6},
                //PetBirthDate = new DateTime(18, 06, 2018),
                //PetSoldDate = new DateTime(21, 08, 2018),
                Details = "Details:  \tThe only normal pet we actuall have, except " +
                "\nfor the cat and the hamster."
            };

            var pet7 = new Pet()
            {
                Id = PetID++,
                Price = 5990.50,
                PetName = "mr.Snuggles",
                PetType = "Xenomorph",
                Colour = "Black and white",
                PetPreviousOwner = new Owner() {Id = 7},
                // PetBirthDate = new DateTime(06, 09, 1979),
                Details = "Details:  \tIt's OUT OF THIS WORLD, I don't know" +
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
                PetPreviousOwner = new Owner() {Id = 8},
                //PetBirthDate = new DateTime(31, 01, 1997),
                //PetSoldDate = new DateTime(27, 05, 1998),
                Details = "Details:  \tIt's a big yellow bird, the previous" +
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
