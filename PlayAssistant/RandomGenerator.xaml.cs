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
    /// Логика взаимодействия для Random.xaml
    /// </summary>
    public partial class RandomGenerator : UserControl
    {
        public RandomGenerator()
        {
            InitializeComponent();
        }

        private void Generate_btn_Click(object sender, RoutedEventArgs e)
        {
            Random rand = new Random();
            int res = 0;
            int from, to;

            try
            {
                from = Convert.ToInt32(From_textbox.Text);
                to = Convert.ToInt32(To_textbox.Text);
                Result_textblock.Text = rand.Next(from, to).ToString();
            }
            catch {
                Result_textblock.Text = "Not a number";
            }

        }
    }
}
