using PetApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetAppCore.DomainService
{
    public interface IOwnerRepositories
    {
        Owner GetOwnerById(int id);

        IEnumerable<Owner> ReadOwner();

        Owner CreateOwner(Owner owner);

        void DeleteOwner(int id);

        Owner ReadyById(int id);

        Owner Update(Owner ownerUpdate);

        Owner ReadyByIdIncludePets(int id);
    }
}
