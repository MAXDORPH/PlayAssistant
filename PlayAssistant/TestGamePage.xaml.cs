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
    /// Логика взаимодействия для TestGamePage.xaml
    /// </summary>
    public partial class TestGamePage : Page
    {
        private DateTime start_time;

        public event EventHandler PageClose_Click;

        private void PageClose(EventArgs e)
        {
            if (PageClose_Click != null)
            {
                PageClose_Click(this, e);
            }
        }

        public TestGamePage()
        {
            InitializeComponent();

            start_time = DateTime.Now;
            Back_btn.Content = start_time.ToString();
        }

        private void Back_btn_Click(object sender, RoutedEventArgs e)
        {
            PageClose(e);
        }
    }
}
