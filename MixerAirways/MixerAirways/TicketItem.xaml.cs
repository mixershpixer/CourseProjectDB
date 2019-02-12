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
    /// Логика взаимодействия для TicketItem.xaml
    /// </summary>
    public partial class TicketItem : UserControl
    {
        public SolidColorBrush color1 = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F5F5F5"));
        public SolidColorBrush color2 = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E0E0E0"));

        public string ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public TicketItem()
        {
            InitializeComponent();
        }
        public TicketItem(Ticket ticket)
        {
            InitializeComponent();

            this.Bookdate.Text = ticket.Bookdate;
            this.DepAirport.Text = ticket.Dep_Airport;
            this.DepCity.Text = ticket.Dep_City;
            this.DepTime.Text = ticket.Dep_Time;
            this.Model.Text = ticket.Aircraft;
            this.ArrAirport.Text = ticket.Arr_Airport;
            this.ArrCity.Text = ticket.Arr_City;
            this.ArrTime.Text = ticket.Arr_Time;
            this.SeatNo.Text = ticket.Seat_No.ToString();
            this.Class.Text = ticket.Fare_Cond;
            this.Price.Text = ticket.Price.ToString();
            this.Flight_Id.Text = ticket.Flight_Id.ToString();
        }

        private void Grid_MouseEnter(object sender, MouseEventArgs e)
        {
            background.Background = color2;
        }

        private void Grid_MouseLeave(object sender, MouseEventArgs e)
        {
            background.Background = color1;
        }

        private void DelTicket_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                int uid = MainWindow.Session.user_id;
                int flight_id = Convert.ToInt32(Flight_Id.Text);
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd = new SqlCommand("return_ticket_back", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@passenger_id", uid);
                cmd.Parameters.AddWithValue("@flight_id", flight_id);
                cmd.ExecuteNonQuery();
            }
            MainWindow.MAIN.MenuListView.SelectedIndex = -1;
            MainWindow.MAIN.MenuListView.SelectedIndex = 2;
        }
    }
}
