using PetApp.Core.Entity;
using PetAppCore.DomainService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetApp.Infastructure.Static.Data.Repositories
{
    public class OwnerRepositories : IOwnerRepositories
    {
        static int id = 1;
        private static List<Owner> _owners = FakeDB.Owners.ToList();

        public Owner GetOwnerById(int id)
        {
            return FakeDB.Owners
             .FirstOrDefault(owner => owner.Id == id);
        }

        public Owner CreateOwner(Owner owner)
        {
            owner.Id = FakeDB.OwnerID++;
            var owners = FakeDB.Owners.ToList();
            owners.Add(owner);
            FakeDB.Owners = owners;
            return owner;
        }

        public void DeleteOwner(int id)
        {
            var owners = FakeDB.Owners.ToList();
            var ownerToDelete = owners.FirstOrDefault(pet => pet.Id
             == id);
            owners.Remove(ownerToDelete);
            FakeDB.Owners = owners;

        }

        public IEnumerable<Owner> ReadOwner()
        {
            return FakeDB.Owners;
        }

        public Owner ReadyById(int id)
        {
            foreach (var owner in _owners)
            {
                if (owner.Id == id)
                {
                    return owner;
                }
            }
            return null;
        }

        public Owner Update(Owner ownerUpdate)
        {
            var owner = this.ReadyById(ownerUpdate.Id);
            if (owner != null)
            {
                owner.FirstName = ownerUpdate.FirstName;
                owner.LastName = ownerUpdate.LastName;
                owner.Address = ownerUpdate.Address;
                owner.PhoneNumber = ownerUpdate.PhoneNumber;
                owner.Email = ownerUpdate.Email;
                return owner;
            }
            if (owner == null)
                Console.WriteLine("Pet not found");

            return null;
        }
    }
}
