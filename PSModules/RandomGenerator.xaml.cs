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
using ServiceLibrary;

namespace PSModules
{
    /// <summary>
    /// Логика взаимодействия для Random.xaml
    /// </summary>
    public partial class RandomGenerator : UserControl, IReturnValue
    {
        private readonly Random rand = new Random();
        private int last_value = 0;

        double btnFontSize = 6;         // процент от высоты окна
        double labelFontSize = 12;

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

        public RandomGenerator()
        {
            InitializeComponent();
        }
        public RandomGenerator(string _Title, string _Value)
        {
            InitializeComponent();
            Title = _Title;
            if (_Value == "")
                _Value = "0";
            Value = _Value;
        }

        private void Generate_btn_Click(object sender, RoutedEventArgs e)
        {
            int from, to;

            try
            {
                from = Convert.ToInt32(From_textbox.Text);
                to = Convert.ToInt32(To_textbox.Text);
                last_value = rand.Next(from, to);
                Result_textblock.Text = last_value.ToString();
            }
            catch {
                Result_textblock.Text = "Not a number";
            }

        }

        public string Title { get => (string)ElTitle.Content; set => ElTitle.Content = value; }
        public string Value { get => last_value.ToString(); set => Set_Value(value); }

        public void Set_Value(string _value)
        {
            Result_textblock.Text = _value;
            last_value = Int32.Parse(_value);
        }
    }
}
