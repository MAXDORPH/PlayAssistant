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
    /// Логика взаимодействия для StringStatiscic.xaml
    /// </summary>
    public partial class StringStatiscic : UserControl, IReturnValue
    {
        public StringStatiscic(String Title)
        {
            InitializeComponent();
            this.Title.Content = Title;
        }

        public string GetValue()
        {
            return Field.Text;
        }

        public void SetByValue(string value)
        {
            Field.Text = value;
            return;
        }
    }
}
