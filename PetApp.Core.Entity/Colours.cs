using System;
using System.Collections.Generic;
using System.Text;

namespace PetApp.Core.Entity
{
    public class Colours
    {
        public int ColourId { get; set; }
        public PetColour PetColour { get; set; }

        public int PetId { get; set; }
        public Pet Pet { get; set; }
    }
}
