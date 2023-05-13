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

namespace clown_mega_project
{
    /// <summary>
    /// Логика взаимодействия для GameList.xaml
    /// </summary>
    public partial class GameList : Page
    {
        public void SelectPage(string _game)
        {
            Application.Current.MainWindow.Dispatcher.Invoke(new Action(() =>
            {
                ((GameChooseMenu)Application.Current.MainWindow.Content).SetPage(new TestGamePage());
            }));
            //((GameChooseMenu)LogicalTreeHelper.GetParent(GameList_element)).SetPage(new TestGamePage());
        }

        public GameList()
        {
            InitializeComponent();

            GameBtn btn1 = new GameBtn();
            GameBtn btn2 = new GameBtn();
            GameBtn btn3 = new GameBtn();

            btn1.SetValue(Grid.ColumnProperty, 0);
            btn2.SetValue(Grid.ColumnProperty, 1);
            btn3.SetValue(Grid.ColumnProperty, 2);

            GameList_element.MainGrid.Children.Add(btn1);
            GameList_element.MainGrid.Children.Add(btn2);
            GameList_element.MainGrid.Children.Add(btn3);
        }
    }
}
