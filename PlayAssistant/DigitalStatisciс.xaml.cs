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
    /// Логика взаимодействия для DigitalStatiscic.xaml
    /// </summary>
    public partial class DigitalStatiscic : UserControl, IReturnValue
    {
        public DigitalStatiscic(String Title)
        {
            InitializeComponent();
            this.Title.Content = Title;
        }

        private void Value_TextChanged(object sender, TextChangedEventArgs e)
        {
            String text = Value.Text;
            if (!Char.IsDigit(text[-1]))
            {
                Value.Text = text.Substring(0,text.Length - 1);
            }            
        }

        private void UpBtn_Click(object sender, RoutedEventArgs e)
        {
            int val = Int32.Parse(Value.Text);
            val++;
            Value.Text = val.ToString();
        }

        private void DownBtn_Click(object sender, RoutedEventArgs e)
        {
            int val = Int32.Parse(Value.Text);
            val--;
            Value.Text = val.ToString();
        }
        public string GetValue() => Value.Text;

        public void SetByValue(string value) => Value.Text = value;
    }
}
