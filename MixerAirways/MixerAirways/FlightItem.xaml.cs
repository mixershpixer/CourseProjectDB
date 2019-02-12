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
    /// Логика взаимодействия для Flight.xaml
    /// </summary>
    public partial class FlightItem : UserControl
    {
        public SolidColorBrush color1 = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F5F5F5"));
        public SolidColorBrush color2 = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E0E0E0"));
        public FlightItem()
        {
            InitializeComponent();
        }

        public FlightItem(Flight flight)
        {
            InitializeComponent();

            this.ID.Text = Convert.ToString(flight.Flight_Id);
            this.DepAirport.Text = flight.Dep_Airport;
            this.DepCity.Text = flight.Dep_City;
            this.DepTime.Text = flight.Dep_Time;
            this.Model.Text = flight.Aircraft;
            this.ArrAirport.Text = flight.Arr_Airport;
            this.ArrCity.Text = flight.Arr_City;
            this.ArrTime.Text = flight.Arr_Time;
        }
        private void UserControl_MouseUp(object sender, MouseButtonEventArgs e)
        {
            int flight_id = Convert.ToInt32(this.ID.Text);
            string deptime = this.DepTime.Text;
            string depair = this.DepAirport.Text;
            string depcity = this.DepCity.Text;
            string aircraft = this.Model.Text;
            string arrtime = this.ArrTime.Text;
            string arrair = this.ArrAirport.Text;
            string arrcity = this.ArrCity.Text;
            Flight flight = new Flight(flight_id, deptime, depair, depcity, aircraft, arrtime, arrair, arrcity);
            MainWindow.MAIN.ContentGrid.Children.Clear();
            MainWindow.MAIN.ContentGrid.Children.Add(new OpenFlight(flight, ChooseFlight.This));
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
