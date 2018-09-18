using PetApp.Core.Entity;
using PetAppCore.DomainService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetApp.Infastructure.Static.Data.Repositories
{
    public class PetRepositories : IPetRepositories
    {
        static int id = 1;
        private static List<Pet> _pets = FakeDB.Pets.ToList();

        public Pet CreatePet(Pet pet)
        {
            pet.Id = FakeDB.PetID++;
            var pets = FakeDB.Pets.ToList();
            pets.Add(pet);
            FakeDB.Pets = pets;
            return pet;
        }

        public void DeletePet(int id)
        {
            var pets = FakeDB.Pets.ToList();
            var petToDelete = pets.FirstOrDefault(pet => pet.Id
             == id);
            pets.Remove(petToDelete);
            FakeDB.Pets = pets;
        }

        public IEnumerable<Pet> ReadPets()
        {
            return FakeDB.Pets;
        }

        public Pet ReadyById(int id)
        {
            foreach (var pet in _pets)
            {
                if (pet.Id == id)
                {
                    return pet;
                }
            }
            return null;
        }

        public Pet Update(Pet petUpdate)
        {
            var pet = this.ReadyById(petUpdate.Id);
            if (pet != null)
            {
                pet.PetName = petUpdate.PetName;
                pet.Price = petUpdate.Price;
                pet.PetType = petUpdate.PetType;
                pet.Colour = petUpdate.Colour;
                pet.Details = petUpdate.Details;
                pet.PetBirthDate = petUpdate.PetBirthDate;

                return pet;
            }
            if (pet == null)
                Console.WriteLine("Pet not found");

            return null;
        }
    }
}
