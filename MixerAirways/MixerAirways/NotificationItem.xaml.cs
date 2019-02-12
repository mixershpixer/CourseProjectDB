using MixerAirways.Classes;
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

namespace MixerAirways
{
    /// <summary>
    /// Логика взаимодействия для NotificationItem.xaml
    /// </summary>
    public partial class NotificationItem : UserControl
    {
        public SolidColorBrush color1 = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F5F5F5"));
        public SolidColorBrush color2 = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E0E0E0"));

        public NotificationItem()
        {
            InitializeComponent();
        }
        public NotificationItem(Notification notification)
        {
            InitializeComponent();

            this.DepTime.Text = notification.Dep_Time;
            this.DepCity.Text = notification.Dep_City;
            this.ArrCity.Text = notification.Arr_City;
            this.Status.Text = (notification.Not_Code == 0) ? "delayed" : "on schedule";
        }
        private void Grid_MouseEnter(object sender, MouseEventArgs e)
        {
            background.Background = color2;
        }

        private void Grid_MouseLeave(object sender, MouseEventArgs e)
        {
            background.Background = color1;
        }
    }
}
