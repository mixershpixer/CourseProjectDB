using MixerAirways.Classes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
    /// Логика взаимодействия для Booking.xaml
    /// </summary>
    public partial class Booking : UserControl
    {
        public SolidColorBrush color1 = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F5F5F5"));
        public SolidColorBrush color2 = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E0E0E0"));

        public string ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public Booking()
        {
            InitializeComponent();
        }
        public Booking(Book book)
        {
            InitializeComponent();

            this.Bookdate.Text = book.Bookdate;
            this.DepAirport.Text = book.Dep_Airport;
            this.DepCity.Text = book.Dep_City;
            this.DepTime.Text = book.Dep_Time;
            this.Model.Text = book.Aircraft;
            this.ArrAirport.Text = book.Arr_Airport;
            this.ArrCity.Text = book.Arr_City;
            this.ArrTime.Text = book.Arr_Time;
            this.SeatNo.Text = book.Seat_No.ToString();
            this.Class.Text = book.Fare_Cond;
            this.Price.Text = book.Price.ToString();
            this.Flight_Id.Text = book.Flight_Id.ToString();
        }

        private void Grid_MouseEnter(object sender, MouseEventArgs e)
        {
            background.Background = color2;
        }

        private void Grid_MouseLeave(object sender, MouseEventArgs e)
        {
            background.Background = color1;
        }

        private void DelBook_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                int uid = MainWindow.Session.user_id;
                int flight_id = Convert.ToInt32(Flight_Id.Text);
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd = new SqlCommand("revoke_book", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@passenger_id", uid);
                cmd.Parameters.AddWithValue("@flight_id", flight_id);
                cmd.ExecuteNonQuery();
            }
            MainWindow.MAIN.MenuListView.SelectedIndex = -1;
            MainWindow.MAIN.MenuListView.SelectedIndex = 1;
        }

        private void BuyTicket_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                int uid = MainWindow.Session.user_id;
                int flight_id = Convert.ToInt32(Flight_Id.Text);
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd = new SqlCommand("buy_ticket", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@passenger_id", uid);
                cmd.Parameters.AddWithValue("@flight_id", flight_id);
                cmd.ExecuteNonQuery();
            }
            MainWindow.MAIN.SuccessTicket.IsOpen = true;
        }
    }
}
