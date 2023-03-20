using System;
using System.CodeDom;
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
        private Random _rng = new Random();
        private RPGChar _character;

        public MainWindow()
        {
            InitializeComponent();
            _character = new RPGChar(_rng);
            updateStats();
        }

        private void buttonUpdate_Click(object sender, RoutedEventArgs e)
        {
            //update name
            _character.Name = textBoxName.Text;
        }

        private void buttonRoll_Click(object sender, RoutedEventArgs e)
        {
            _character.Roll(_rng);
            updateStats();
            double odds = .5;

            _character.PartyMembers.Clear();
            foreach(ListBoxItem i in listPotentialMembers.Items)
            {
                if (_rng.NextDouble() > odds)
                {
                    RPGChar r = new RPGChar(_rng)
                    {
                        Name = i.Content.ToString(),
                    };


                    _character.PartyMembers.Add(r);
                }
            }
            if(_character.PartyMembers.Count>0)
            {
                _character.PartyMembers[0].FavoriteColor = Brushes.Gray;
            }
            listMembers.Items.Clear();
            int it = 0;
            //adds to party member listbox
            foreach (RPGChar r in _character.PartyMembers)
            {
                it++;
                ListBoxItem i = new ListBoxItem();
                i.Content = $"{r.Name} \n   STR: {r.Strength} \n   INT: {r.Intelligence} \n   DEX: {r.Dexterity}";
                if (r.FavoriteColor == null)
                {
                    if (it % 2 == 0)
                    {
                        i.Background = new SolidColorBrush(Color.FromArgb(100, 200, 200, 200));
                    }
                    else
                    {
                        i.Background = new SolidColorBrush(Color.FromArgb(100, 255, 255, 255));
                    }
                }
                else
                {
                    i.Background = r.FavoriteColor;
                }
                
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
