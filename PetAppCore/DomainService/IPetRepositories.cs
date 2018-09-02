using PetApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetAppCore.DomainService
{
    public interface IPetRepositories
    {
        IEnumerable<Pet> ReadPets();

        Pet CreatePet(Pet pet);

        void DeletePet(int id);

        Pet ReadyById(int id);

        Pet Update(Pet customerUpdate);
    }
}
