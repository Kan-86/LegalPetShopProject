using System;
using System.Collections.Generic;
using System.Text;

namespace PetApp.Core.Entity.Models
{
    public class UserToDoItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
    }
}
