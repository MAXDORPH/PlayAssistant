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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GameChooseMenu gcm = new GameChooseMenu();
        object mainWindow;

        public MainWindow()
        {
            InitializeComponent();

            mainWindow = Application.Current.MainWindow.Content;

            Application.Current.MainWindow.Content = gcm;
        }

        public void OpenGameCreationWindow()
        {
            Application.Current.MainWindow.Content = mainWindow;
        }

        public void OpenGameChoosePage()
        {
            Application.Current.MainWindow.Content = gcm;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //code
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //code
        }

        internal void AddCharacter(Character character)
        {
            lb_players.Items.Add(new CharacterForList(character));
            return;
        }

        public void AddPS(IReturnValue PS)
        {
            return;
        }

        public void RemoveList(bool NeedToHide)
        {
            var lst = MainGrid.Children.OfType<ListOfUserControls>().ToList();
            foreach (var item in lst)
            {
                MainGrid.Children.Remove(item);
            }
            if(NeedToHide) UnStels();
            return;
        }

        public void RemoveCreateCharacter()
        {
            var lst = MainGrid.Children.OfType<CharacterCreate>().ToList();
            foreach (var item in lst)
            {
                MainGrid.Children.Remove(item);
            }
            UnStels();
            return;
        }

        public void CreateList(bool IsPSList, bool InMainWindow, Character curCh = null)
        {
            var list = new List<IReturnValue>();
            if (IsPSList)
            {
                list = HelpfulClass.GetParams();
            }
            else
            {
                list = HelpfulClass.GetAttributes();
            }

            Stels();
            MainGrid.Children.Add(new ListOfUserControls(list, IsPSList, InMainWindow, curCh));
            return;
        }

        public void Stels()
        {
            Hide.IsEnabled= true;
            Hide.Visibility= Visibility.Visible;
        }

        public void UnStels()
        {
            Hide.IsEnabled= false;
            Hide.Visibility= Visibility.Hidden;
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            Stels();
            MainGrid.Children.Add(new CharacterCreate());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            CreateList(true, true);
        }
        public void Refrash()
        {
            foreach (var item in MainGrid.Children.OfType<CharacterCreate>()) {
                item.Refrash();
            }
            foreach(var item in lb_players.Items.OfType<CharacterForList>())
            {
                item.Refresh();
            }
        }

        public void OpenGameCreate(object sender, RoutedEventArgs e)
        {
            Stels();
            GameCreate_grid.Visibility = Visibility.Visible;
            GameCreate_grid.IsEnabled = true;
            GameCreateMenu gcm = new GameCreateMenu();
            
            Grid.SetRow(gcm, 1);
            Grid.SetColumn(gcm, 1);

            GameCreate_grid.Children.Add(gcm);
        }

        public void CloseGameCreate()
        {
            GameCreate_grid.Visibility = Visibility.Hidden;
            GameCreate_grid.IsEnabled = false;

            GameCreate_grid.Children.Clear();

            UnStels();
        }

        private void Exit_btn_Click(object sender, RoutedEventArgs e)
        {
            OpenGameChoosePage();
        }
    }
}
