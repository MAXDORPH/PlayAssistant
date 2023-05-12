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

namespace PlayAssistant
{
    /// <summary>
    /// Логика взаимодействия для CharacterCreate.xaml
    /// </summary>
    public partial class CharacterCreate : UserControl
    {
        Character character;
        public CharacterCreate()
        {
            InitializeComponent();

            Characteristic.Items.Add(character.GetAttributes());
        }

        public bool NameCorrect()
        {
            if (Name.Text.Length > 0) { 
                return true;
            }
            else{
                return false;   
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (NameCorrect())
            {
                MainWindow parentWindow = Window.GetWindow(this) as MainWindow;
                parentWindow.AddCharacter();
            }
        }

        private void AddGeneralCharacteriscit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
