using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Логика взаимодействия для dice_d6.xaml
    /// </summary>
    public partial class dice_d6 : UserControl
    {
        bool animation_is_active = false;
        int timer_time = 0;
        long timer_start_time;
        int current_step = 0;
        long animation_timestamp;

        const int anim_time = 200 * 100000;
        const int anim_step = 3 * 100000;

        public dice_d6()
        {
            InitializeComponent();
        }

        private void throw_btn_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToBoolean(animation_checkbox.IsChecked) && !animation_is_active)
            {
                animation_is_active = true;
                timer_time = 0;
                timer_start_time = Stopwatch.GetTimestamp();
                current_step = anim_step;

                animation_timestamp = Stopwatch.GetTimestamp();

                Thread anim_thread = new Thread(throw_animation);
                anim_thread.IsBackground = true;
                anim_thread.Start();
            }
            else if (!Convert.ToBoolean(animation_checkbox.IsChecked))
            {
                int rand = new Random().Next(1, 7);
                dice_img.Source = new BitmapImage(new Uri("/Images/" + rand.ToString() + ".png", UriKind.Relative));
            }
        }

        private void throw_animation()
        {
            //int rand = new Random().Next(1, 7);
            //Application.Current.Dispatcher.BeginInvoke(new Action(() => { dice_img.Source = new BitmapImage(new Uri("/Images/" + rand.ToString() + ".png", UriKind.Relative)); }));
            //dice_img.Source = new BitmapImage(new Uri("/Images/" + rand.ToString() + ".png", UriKind.Relative));
            //timer_time += current_step;
            //current_step *= anim_step + 1;

            if (Stopwatch.GetTimestamp() - animation_timestamp >= current_step)
            {
                timer_time += current_step;
                current_step += anim_step;

                int rand = new Random().Next(1, 7);
                Application.Current.Dispatcher.BeginInvoke(new Action(() => { dice_img.Source = new BitmapImage(new Uri("/Images/" + rand.ToString() + ".png", UriKind.Relative)); }));

                animation_timestamp = Stopwatch.GetTimestamp();
            }

            /*if (!(Stopwatch.GetTimestamp() - timer_start_time + current_step > anim_time))
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(timer_time));
            }*/

            if (Stopwatch.GetTimestamp() - timer_start_time < anim_time)
            {
                Thread tmp = new Thread(throw_animation);
                tmp.IsBackground = true;
                tmp.Start();
            }
            else
            {
                Thread tmp = new Thread(throw_end_animation);
                tmp.IsBackground = true;
                tmp.Start();
            }
        }

        private void throw_end_animation()
        {
            Application.Current.Dispatcher.BeginInvoke((Action)(() => { dice_border.BorderBrush = new SolidColorBrush(Colors.Green);}));
            Thread.Sleep(TimeSpan.FromMilliseconds(100));
            Application.Current.Dispatcher.BeginInvoke((Action)(() => { dice_border.BorderBrush = new SolidColorBrush(Colors.Transparent); }));
            animation_is_active = false;
        }
    }
}
