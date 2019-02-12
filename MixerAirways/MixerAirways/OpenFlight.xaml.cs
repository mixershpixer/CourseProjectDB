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
    /// Логика взаимодействия для NewBook.xaml
    /// </summary>
    public partial class OpenFlight : UserControl
    {
        public static OpenFlight THIS;
        public string ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public OpenFlight()
        {
            InitializeComponent();
        }
        public OpenFlight(Flight flight, ChooseFlight chooseFlight)
        {
            InitializeComponent();
            THIS = this;
            ID.Text = Convert.ToString(flight.Flight_Id);
            DepAirport.Text = flight.Dep_Airport;
            DepCity.Text = flight.Dep_City;
            DepTime.Text = flight.Dep_Time;
            ArrAirport.Text = flight.Arr_Airport;
            ArrCity.Text = flight.Arr_City;
            ArrTime.Text = flight.Arr_Time;
            Model.Text = flight.Aircraft;
        }

        private void MakeBook_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    string classcond = "";
                    int uid = MainWindow.Session.user_id;
                    int ind = ChooseClass.SelectedIndex;
                    switch (ind)
                    {
                        case 0:
                            classcond = "A";
                            break;
                        case 1:
                            classcond = "B";
                            break;
                        case 2:
                            classcond = "C";
                            break;
                        default: NoClass.IsOpen = true;
                            break;
                    }
                    int flight_id = Convert.ToInt32(ID.Text);
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    SqlCommand cmd = new SqlCommand("new_book", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@passenger_id", uid);
                    cmd.Parameters.AddWithValue("@fare_condition", classcond);
                    cmd.Parameters.AddWithValue("@flight_id", flight_id);
                    cmd.ExecuteNonQuery();
                    BookOk.IsOpen = true;
                }
            }
            catch (SqlException ex)
            {
                switch (ex.Number)
                {
                    case 53000:
                        NoFreePlaces.IsOpen = true;
                        break;
                    case 54000:
                        AlreadyExist.IsOpen = true;
                        break;
                    case 57000:
                        NoPlacesAtAll.IsOpen = true;
                        break;
                }
            }
        }

        private void ChangeStatus_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
