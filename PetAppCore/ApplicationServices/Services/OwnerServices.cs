using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetApp.Core.Entity;
using PetAppCore.DomainService;

namespace PetAppCore.ApplicationServices.Services
{
    public class OwnerServices : IOwnerServices
    {
        readonly IOwnerRepositories _ownerRepository;

        public OwnerServices(IOwnerRepositories ownerRepositories)
        {
            _ownerRepository = ownerRepositories;
        }

        public Owner AddOwner(Owner owner)
        {
            if (string.IsNullOrEmpty(owner.Address))
            {
                throw new InvalidOperationException("Owner needs an address");
            }
            return _ownerRepository.CreateOwner(owner);
        }

        public void DeleteOwner(int id)
        {
            if (id < 1)
            {
                throw new InvalidOperationException("Owner Id needs to be larger then 0");
            }
            _ownerRepository.DeleteOwner(id);
        }

        public Owner FindOwnerById(int id)
        {
            return _ownerRepository.ReadyById(id);
        }

        public List<Owner> FindOwnerName()
        {
            return _ownerRepository.ReadOwner()
                .Where(owner => owner.FirstName.Equals(owner.FirstName))
                .ToList();
        }

        public Owner GetOwnerInstance()
        {
            return new Owner();
        }

        public List<Owner> GetOwners()
        {
            return _ownerRepository.ReadOwner().ToList();
        }

        public Owner UpdateOwner(Owner ownerUpdate)
        {
            var owner = _ownerRepository.Update(ownerUpdate);
            owner.FirstName = ownerUpdate.FirstName;
            owner.LastName = ownerUpdate.LastName;
            owner.Address = ownerUpdate.Address;
            owner.Email = ownerUpdate.Email;
            owner.PhoneNumber = ownerUpdate.PhoneNumber;
            return owner;
        }
    }
}
