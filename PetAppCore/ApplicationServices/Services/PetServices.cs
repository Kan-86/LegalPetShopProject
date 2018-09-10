using PetApp.Core.Entity;
using PetAppCore.ApplicationServices;
using PetAppCore.DomainService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetAppCore.Services
{
    public class PetServices : IPetService
    {
        readonly IPetRepositories _petRepository;
        readonly IOwnerRepositories _ownerRepositories;

        public PetServices(IPetRepositories petRepositories,
            IOwnerRepositories ownerRepositories)
        {
            _petRepository = petRepositories;
            _ownerRepositories = ownerRepositories;
        }

        public Pet AddPet(Pet pet)
        {
            if (string.IsNullOrEmpty(pet.Colour))
            {
                throw new InvalidOperationException("Pet needs a Colour");
            }
            return _petRepository.CreatePet(pet);
        }

        public void DeletePet(int id)
        {
            if (id < 1)
            {
                throw new InvalidOperationException("Pet Id needs to be larger then 0");
            }
            _petRepository.DeletePet(id);
        }

        public Pet GetPetInstance()
        {
            return new Pet();
        }

        public List<Pet> GetPets()
        {
            var listPets = _petRepository.ReadPets().ToList();
            foreach (var pet in listPets)
            {
                pet.PetPreviousOwner = _ownerRepositories.ReadyById(pet.PetPreviousOwner.Id);
            }
            return listPets;
        }

        public List<Pet> SortPetByPrice()
        {
            return _petRepository.ReadPets()
            .OrderBy(pet => pet.Price)
            .ToList();
        }

        public List<Pet> Get5CheapestPets()
        {
            return _petRepository.ReadPets()
            .OrderBy(pet => pet.Price).Take(5)
            .ToList();
        }

        public List<Pet> FindPetType()
        {
            return _petRepository.ReadPets()
            .Where(pet => pet.PetType.Equals(pet.PetType))
            .ToList();
        }

        public Pet FindPetById(int id)
        {
            return _petRepository.ReadyById(id);
        }

        public Pet UpdatePet(Pet petUpdate)
        {
            var pet = FindPetById(petUpdate.Id);
            pet.PetName = petUpdate.PetName;
            pet.PetType = petUpdate.PetType;
            pet.Price = petUpdate.Price;
            return pet;
        }
    }
}
