using PetApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetAppCore.ApplicationServices
{
    public interface IPetService
    {
        Pet GetPetInstance();

        List<Pet> GetPets();

        Pet AddPet(Pet pet);

        void DeletePet(int id);

        List<Pet> SortPetByPrice();

        List<Pet> Get5CheapestPets();

        List<Pet> FindPetType();

        Pet FindPetById(int id);

        Pet FindPetByIdIncludOwners(int id);

        Pet UpdatePet(Pet petUpdate);

        List<Pet> GetFilteredPets(Filter filter);
    }
}
