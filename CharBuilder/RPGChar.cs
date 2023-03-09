using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharBuilder
{
    internal class RPGChar
    {
        // Fields
        private int _charisma;
        private int _dexterity;
        private int _intelligence;
        private int _luck;
        private int _strength;
        private int _wisdom;

        // Properties
        //name & level
        public string Name { get; set; }
        public int Level { get; set; }
        //stats
        public int Charisma { get { return _charisma; } }
        public int Dexterity { get { return _dexterity; } }
        public int Intelligence { get { return _intelligence; } }
        public int Luck { get { return _luck; } }
        public int Strength { get { return _strength; } }
        public int Wisdom { get { return _wisdom; } }



    }
}
