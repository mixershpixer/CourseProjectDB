using MaterialDesignThemes.Wpf;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace MixerAirways
{
    /// <summary>
    /// Логика взаимодействия для Autorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        public string ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public SolidColorBrush color = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF9800"));
        private Classes.Session session;
        private Classes.User user;

        public bool AuthorizationMethod(string username, string password)
        {
            bool res = false;
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("user_auth", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                    session = new Classes.Session(Convert.ToInt32(reader.GetValue(0)),
                            Convert.ToInt32(reader.GetValue(1)), Convert.ToInt32(reader.GetValue(2)));
                    user = new Classes.User(Convert.ToString(reader.GetValue(3)), Convert.ToString(reader.GetValue(4)));
                }
                reader.Close();
                res = true;

            }
            return res;
        }

        public Authorization()
        {
            InitializeComponent();
        }
        private async void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            string[] t1 = { UserNameTxt.Text, PasswordTxt.Password };
            PackIcon[] t2 = { Icon1, Icon2 };
            ProgressBar1.Visibility = Visibility.Visible;
            try
            {
                int i = 0;
                for (; i < 2; i++)
                {
                    if (t1[i].Equals(""))
                    {
                        t2[i].Foreground = Brushes.Red;
                        break;
                    }
                }

                if (i == 2)
                {
                    if (await Task.Run(() => AuthorizationMethod(t1[0], t1[1])))
                    {
                        (new MainWindow(user, session)).Show();
                        Close();
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
            }
            catch
            {
                AutFail.IsOpen = true;
                t2[0].Foreground = t2[1].Foreground = Brushes.Red;
            }
            ProgressBar1.Visibility = Visibility.Collapsed;
        }

        private void CreateAccButton_Click(object sender, RoutedEventArgs e)
        {
            Registration registration = new Registration();
            this.Close();
            registration.Show();
        }

        private void UserNameTxt_GotFocus(object sender, RoutedEventArgs e)
        {
            Icon1.Foreground = color;
        }

        private void PasswordTxt_GotFocus(object sender, RoutedEventArgs e)
        {
            Icon2.Foreground = color;
        }
    }
}
