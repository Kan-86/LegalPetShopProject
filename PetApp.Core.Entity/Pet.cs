using System;
using System.Collections.Generic;
using System.Text;

namespace PetApp.Core.Entity
{
    public class Pet
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public string PetName { get; set; }
        public string PetType { get; set; }
        public string Colour { get; set; }
        public string PetPreviousOwner { get; set; }
        public string Details { get; set; }
        //public DateTime PetBirthDate { get; set; }
        //public DateTime PetSoldDate { get; set; }
    }
}
