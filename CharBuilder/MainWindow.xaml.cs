using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CharBuilder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private RPGChar _character = new RPGChar();
        private Random _rng = new Random();

        public MainWindow()
        {
            InitializeComponent();
            updateStats();
        }

        private void buttonUpdate_Click(object sender, RoutedEventArgs e)
        {
            //update name
            _character.Name = textBoxName.Text;
        }

        private void buttonRoll_Click(object sender, RoutedEventArgs e)
        {
            _character.Roll();
            updateStats();
            double odds = .5;

            _character.PartyMembers.Clear();
            foreach(ListBoxItem i in listPotentialMembers.Items)
            {
                if (_rng.NextDouble() > odds)
                {
                    RPGChar r = new RPGChar()
                    {
                        Name = i.Content.ToString(),
                    };


                    _character.PartyMembers.Add(r);
                }
            }
            listMembers.Items.Clear();
            foreach (RPGChar r in _character.PartyMembers)
            {
                ListBoxItem i = new ListBoxItem();
                i.Content = $"{r.Name} \n STR: {r.Strength} \n INT: {r.Intelligence}";
                listMembers.Items.Add(i);
            }
        }
        private void updateStats()
        {
            textBoxStr.Text = _character.Strength.ToString();
            textBoxDex.Text = _character.Dexterity.ToString();
            textBoxInt.Text = _character.Intelligence.ToString();
            textBoxChr.Text = _character.Charisma.ToString();
            textBoxWis.Text = _character.Wisdom.ToString();
            textBoxLuk.Text = _character.Luck.ToString();
        }
    }
}
