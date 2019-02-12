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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MixerAirways
{
    /// <summary>
    /// Логика взаимодействия для ChooseFlight.xaml
    /// </summary>
    public partial class ChooseFlight : UserControl
    {
        public static ChooseFlight This;
        public string ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public ChooseFlight()
        {
            InitializeComponent();
            This = this;
        }
        private void Up_Click(object sender, RoutedEventArgs e)
        {
            scroll.LineUp();
        }

        private void Down_Click(object sender, RoutedEventArgs e)
        {
            scroll.LineDown();
        }
        private void Search_Click(object sender, RoutedEventArgs e)
        {
            if (DepCity.Text != "" && DepTme.Text != "" && ArrCity.Text != "")
            {
                ThicknessAnimation anim1 = new ThicknessAnimation();
                anim1.From = new Thickness(0, 0, -20, 0);
                anim1.To = new Thickness(0, 20, -20, 0);
                anim1.FillBehavior = FillBehavior.Stop;
                anim1.Duration = new Duration(TimeSpan.FromSeconds(0.25));
                scroll.BeginAnimation(Label.MarginProperty, anim1);

                try
                {
                    using (SqlConnection con = new SqlConnection(ConnectionString))
                    {
                        if (con.State == ConnectionState.Closed)
                            con.Open();
                        SqlCommand cmd = new SqlCommand("choose_flight", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@departure_date", DepTme.Text);
                        cmd.Parameters.AddWithValue("@departure_city", DepCity.Text);
                        cmd.Parameters.AddWithValue("@arrival_city", ArrCity.Text);
                        int result = Convert.ToInt32(cmd.ExecuteScalar());
                        if (result != 0)
                        {
                            ListFlightsWrapPanel.Children.Clear();
                            SqlDataReader reader = cmd.ExecuteReader();
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    Flight flight = new Flight(
                                    Convert.ToInt32(reader.GetValue(0)),
                                    Convert.ToString(reader.GetValue(1)),
                                    Convert.ToString(reader.GetValue(2)),
                                    Convert.ToString(reader.GetValue(3)),
                                    Convert.ToString(reader.GetValue(4)),
                                    Convert.ToString(reader.GetValue(5)),
                                    Convert.ToString(reader.GetValue(6)),
                                    Convert.ToString(reader.GetValue(7)));

                                    FlightItem flightItem = new FlightItem(flight);
                                    ListFlightsWrapPanel.Children.Add(flightItem);
                                }
                            }
                            reader.Close();

                        }
                        else
                        {
                            SearchFail.IsOpen = true;
                        }
                    }
                }
                catch (SqlException ex)
                {
                    switch (ex.Number)
                    {
                        case 60000:
                            No1.IsOpen = true;
                            break;
                        case 61000:
                            No2.IsOpen = true;
                            break;
                        case 62000:
                            No3.IsOpen = true;
                            break;
                        default:
                            throw;
                    }
                }
            }
        }
    }
}
