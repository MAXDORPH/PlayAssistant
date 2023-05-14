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

namespace PSModules
{
    /// <summary>
    /// Логика взаимодействия для CounterElement.xaml
    /// </summary>
    public partial class CounterElement : UserControl, IReturnValue
    {
        public int value = 0;

        double btnFontSize = 6;         // процент от высоты окна
        double labelFontSize = 12;

        public CounterElement()
        {
            InitializeComponent();
        }

        private void Element_Loaded(object sender, RoutedEventArgs e)
        {/*
            double labelfontsize = Application.Current.MainWindow.Height * (labelFontSize / 100);
            double btnfontsize = App.Current.MainWindow.Height * (btnFontSize / 100);
            System.Windows.Application.Current.Resources.Remove("LabelFontSize");
            System.Windows.Application.Current.Resources.Add("LabelFontSize", labelfontsize);
            System.Windows.Application.Current.Resources.Remove("BtnFontSize");
            System.Windows.Application.Current.Resources.Add("BtnFontSize", btnfontsize);*/
        }

        private void Element_Resized(object sender, SizeChangedEventArgs e)
        {/*
            double labelfontsize = Application.Current.MainWindow.Height * (labelFontSize / 100);
            double btnfontsize = App.Current.MainWindow.Height * (btnFontSize / 100);
            System.Windows.Application.Current.Resources.Remove("LabelFontSize");
            System.Windows.Application.Current.Resources.Add("LabelFontSize", labelfontsize);
            System.Windows.Application.Current.Resources.Remove("BtnFontSize");
            System.Windows.Application.Current.Resources.Add("BtnFontSize", btnfontsize);*/
        }

        private void Minus_btn_Click(object sender, RoutedEventArgs e)
        {
            value--;
            Update_text();
        }

        private void Reset_btn_Click(object sender, RoutedEventArgs e)
        {
            value = 0;
            Update_text();
        }

        private void Plus_btn_Click(object sender, RoutedEventArgs e)
        {
            value++;
            Update_text();
        }

        private void Update_text()
        {
            Value_label.Content = value.ToString();
        }

        public string Title { get; set; }
        public string Value { get => value.ToString(); set => this.value = Int32.Parse(value); }

        public int GetValue() => value;

        public void SetValue(int _value) => value = _value;
    }
}
