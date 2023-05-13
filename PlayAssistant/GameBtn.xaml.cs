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
    /// Логика взаимодействия для GameBtn.xaml
    /// </summary>
    public partial class GameBtn : UserControl
    {
        private string game = "Game";

        public GameBtn()
        {
            InitializeComponent();

            Select_btn.Content = "TestGame";
        }

        private void Select_btn_Click(object sender, RoutedEventArgs e)
        {
            ((GameChooseMenu)Application.Current.MainWindow.Content).SetPage(new TestGamePage());
        }
    }
}
