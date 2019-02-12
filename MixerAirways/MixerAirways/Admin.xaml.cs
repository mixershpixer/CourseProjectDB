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
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : UserControl
    {
        public string ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public Admin()
        {
            InitializeComponent();
        }

        private void AddNewFlight_Click(object sender, RoutedEventArgs e)
        {
            try
            { 
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("new_flight", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@departure_time", Departure_time.Text);
                    cmd.Parameters.AddWithValue("@departure_airport", Convert.ToInt32(Departure_airport.Text));
                    cmd.Parameters.AddWithValue("@aircraft_code", Convert.ToInt32(Aircraft_code.Text));
                    cmd.Parameters.AddWithValue("@arrival_time", Arrival_time.Text);
                    cmd.Parameters.AddWithValue("@arrival_airport", Convert.ToInt32(Arrival_airport.Text));
                    cmd.ExecuteNonQuery();
                    Success.IsOpen = true;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddNewAircraft_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("new_aircraft", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@model", Model.Text);
                    cmd.Parameters.AddWithValue("@a_class_seats", Convert.ToInt32(A_class.Text));
                    cmd.Parameters.AddWithValue("@b_class_seats", Convert.ToInt32(B_class.Text));
                    cmd.Parameters.AddWithValue("@c_class_seats", Convert.ToInt32(C_class.Text));
                    cmd.ExecuteNonQuery();
                    Success.IsOpen = true;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ChangeAircraft_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("change_aircraft", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@aircraft_code", Convert.ToInt32(Ch_AirCode.Text));
                    cmd.Parameters.AddWithValue("@model", Ch_Model.Text);
                    cmd.Parameters.AddWithValue("@a_class_seats", Convert.ToInt32(Ch_A_class.Text));
                    cmd.Parameters.AddWithValue("@b_class_seats", Convert.ToInt32(Ch_B_class.Text));
                    cmd.Parameters.AddWithValue("@c_class_seats", Convert.ToInt32(Ch_C_class.Text));
                    cmd.ExecuteNonQuery();
                    Success.IsOpen = true;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DelAircraft_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("del_aircraft", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@aircraft_code", Convert.ToInt32(Air_Code_Del.Text));
                    cmd.ExecuteNonQuery();
                    Success.IsOpen = true;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DelFlight_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("del_flight", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@flight_id", Convert.ToInt32(Flight_id_1.Text));
                    cmd.ExecuteNonQuery();
                    Success.IsOpen = true;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ChangeFlight_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("moder_change_flight_status", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@user_id", MainWindow.Session.user_id);
                    cmd.Parameters.AddWithValue("@flight_id", Convert.ToInt32(Flight_id_2.Text));
                    cmd.ExecuteNonQuery();
                    Success.IsOpen = true;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Aircrafts_Click(object sender, RoutedEventArgs e)
        {
            if (AircraftPage.Visibility == Visibility.Collapsed)
            {
                AircraftPage.Visibility = Visibility.Visible;
                UserPage.Visibility = Visibility.Collapsed;
                FlightPage.Visibility = Visibility.Collapsed;
            }
        }

        private void Flights_Click(object sender, RoutedEventArgs e)
        {
            if (FlightPage.Visibility == Visibility.Collapsed)
            {
                FlightPage.Visibility = Visibility.Visible;
                UserPage.Visibility = Visibility.Collapsed;
                AircraftPage.Visibility = Visibility.Collapsed;
            }
        }

        private void Users_Click(object sender, RoutedEventArgs e)
        {
            if (UserPage.Visibility == Visibility.Collapsed)
            {
                UserPage.Visibility = Visibility.Visible;
                FlightPage.Visibility = Visibility.Collapsed;
                AircraftPage.Visibility = Visibility.Collapsed;
            }
        }

        private void Del_user_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("user_del", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@user_id", Convert.ToInt32(User_Id.Text));
                    cmd.ExecuteNonQuery();
                    Success.IsOpen = true;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
