using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

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
        private int _statNumberDice = 1;
        private int _statDiceSides = 20;
        private List<RPGChar> _partyMembers = new List<RPGChar>();
        private Brush _favoriteColor;

        private Random _rng = new Random();
        #endregion
        public RPGChar(Random rng)
        {
            _rng = rng;
            Roll(_rng);
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
        public Brush FavoriteColor
        {
            get { return _favoriteColor; }
            set { _favoriteColor = value; }
        }
        //stats
        public int Charisma { get { return _charisma; } }
        public int Dexterity { get { return _dexterity; } }
        public int Intelligence { get { return _intelligence; } }
        public int Luck { get { return _luck; } }
        public int Strength { get { return _strength; } }
        public int Wisdom { get { return _wisdom; } }
        #endregion

        public void Roll(Random rng)
        {
            Random _rng = rng;
            _charisma = Math.Min(RollDice(_statNumberDice,_statDiceSides, _rng), _maxCharisma);
            _dexterity = Math.Min(RollDice(_statNumberDice, _statDiceSides, _rng), _maxDexterity);
            _intelligence = Math.Min(RollDice(_statNumberDice, _statDiceSides, _rng), _maxIntelligence);
            _luck = Math.Min(RollDice(_statNumberDice, _statDiceSides, _rng), _maxLuck);
            _strength = Math.Min(RollDice(_statNumberDice, _statDiceSides, _rng), _maxStrength);
            _wisdom = Math.Min(RollDice(_statNumberDice, _statDiceSides, _rng), _maxWisdom);

        }

        public static int RollDice(int numberOfDice, int numberOfSides, Random rng)
        {
            int total = 0;

            for(int i=0; i < numberOfDice; i++)
            {
                total += rng.Next(1, numberOfSides+1);
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
