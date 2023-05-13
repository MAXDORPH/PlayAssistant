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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PSModules
{
    /// <summary>
    /// Логика взаимодействия для ToggleSwitch.xaml
    /// </summary>
    public partial class ToggleSwitch : UserControl
    {
        private bool state = false;

        public ToggleSwitch()
        {
            InitializeComponent();
        }

        private void Circle_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            state = !state;

            if (state)
            {
                Circle.Margin = new Thickness(ToggleUserControl.ActualWidth - ToggleUserControl.ActualHeight, 0, 0, 0);
                Rect.Fill = new SolidColorBrush(Colors.Blue);
            }
            else
            {
                Circle.Margin = new Thickness(0, 0, 0, 0);
                Rect.Fill = new SolidColorBrush(Colors.Gray);
            }
        }

        public bool GetValue() => state;

        public void SetValue(bool _value) => state = _value;
    }
}
