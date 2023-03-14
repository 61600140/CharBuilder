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
        #region Fields
        private CharacterClasses _characterClass;
        private int _charisma;
        private int _maxCharisma = 20;
        private int _dexterity;
        private int _maxDexterity = 20;
        private int _intelligence;
        private int _maxIntelligence = 20;
        private int _luck;
        private int _maxLuck = 20;
        private int _strength;
        private int _maxStrength = 20;
        private int _wisdom;
        private int _maxWisdom = 20;
        private List<RPGChar> _partyMembers = new List<RPGChar>();

        private Random _rng = new Random();
        #endregion
        public RPGChar()
        {
            Roll();
        }
        #region Properties
        //tl vars
        public string Name { get; set; }
        public int Level { get; set; }
        public CharacterClasses CharacterClasses { get { return _characterClass; } set { _characterClass = value; } }
        public List<RPGChar> PartyMembers
        {
            get { return _partyMembers; }
            set { _partyMembers = value; }
        }
        //stats
        public int Charisma { get { return _charisma; } }
        public int Dexterity { get { return _dexterity; } }
        public int Intelligence { get { return _intelligence; } }
        public int Luck { get { return _luck; } }
        public int Strength { get { return _strength; } }
        public int Wisdom { get { return _wisdom; } }
        #endregion

        public void Roll()
        {
            _charisma = _rng.Next(1, _maxCharisma+1);
            _dexterity = _rng.Next(1, _maxDexterity + 1);
            _intelligence = _rng.Next(1, _maxIntelligence + 1);
            _luck = _rng.Next(1, _maxLuck + 1);
            _strength = _rng.Next(1, _maxStrength + 1);
            _wisdom = _rng.Next(1, _maxWisdom + 1);

        }

        public static int RollDice(int numberOfDice, int numberOfSides)
        {
            Random r = new Random();
            int total = 0;

            for(int i=0; i < numberOfDice; i++)
            {
                total += r.Next(1, numberOfSides+1);
            }

            return total;
        }

    }

    public enum CharacterClasses
    {
        None = 0,
        Cleric,
        Rogue,
        Barbarian,
        Wizard
    }
}
