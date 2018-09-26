using PetApp.Core.Entity;
using PetAppCore.ApplicationServices;
using PetAppCore.DomainService;
using System;
using System.Collections.Generic;
using System.IO;
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
            return _petRepository.ReadPets().ToList();
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
            var pet = _petRepository.Update(petUpdate);
            pet.PetName = petUpdate.PetName;
            pet.PetType = petUpdate.PetType;
            pet.Price = petUpdate.Price;
            return pet;
        }

        public Pet FindPetByIdIncludOwners(int id)
        {
            throw new NotImplementedException();
        }

        public List<Pet> GetFilteredPets(Filter filter)
        {
            if (filter.CurrentPage < 0 || filter.ItemsPrPage < 0)
            {
                throw new InvalidDataException("Current page and Items page must be zero or more");
            }
            if ((filter.CurrentPage -1 * filter.ItemsPrPage) >= _petRepository.Count())
            {
                throw new InvalidDataException("Index out of bounds, Curret page is too high");
            }
            return _petRepository.ReadPets(filter).ToList();
        }

        /* public Pet FindPetByIdIncludOwners(int id)
         {
             var pet = _petRepositories.ReadyById(id);
             pet.Pets = _ownerRepositories.ReadPets()
                 .Where(p => p.PetPreviousOwner !=
                 null && p.PetPreviousOwner.Id == pet.Id)
                 .ToList();
             return pet;
         }*/
    }
}
