using MaterialDesignThemes.Wpf;
using MixerAirways.Classes;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace MixerAirways
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public string ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public SolidColorBrush color = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF9800"));
        private Classes.Session session;
        private Classes.User user;
        public Registration()
        {
            InitializeComponent();
            //Uri iconUri = new Uri(@"ML2.png", UriKind.RelativeOrAbsolute);
            //this.Icon = BitmapFrame.Create(iconUri);
        }
        [STAThread]
        public bool RegMethod(string username, string password, string contact_data)
        {
            bool res = false;
            Thread.Sleep(1500);
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd = new SqlCommand("user_reg", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@contact_data", contact_data);
                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        object deb0 = reader.GetValue(0);
                        object deb1 = reader.GetValue(1);
                        object deb2 = reader.GetValue(2);
                        session = new Session(Convert.ToInt32(reader.GetValue(0)),
                                Convert.ToInt32(reader.GetValue(1)), Convert.ToInt32(reader.GetValue(2)));
                        user = new User(Convert.ToString(reader.GetValue(3)), Convert.ToString(reader.GetValue(4)));
                    }
                    reader.Close();
                    res = true;
                }
                catch (Exception ex)
                {

                }
            }
            return res;
        }
        private async void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            bool[] t1 = { RegMailTxt.Text.Equals(""), RegUserNameTxt.Text.Equals(""), RegPasswordTxt.Password.Equals("") };
            PackIcon[] t2 = { RegMail, RegUserName, RegPassword };
            bool AllOk = true;
            bool Res = false;
            ProgressBar1.Visibility = Visibility.Visible;
            int i = 0;
            try
            {
                for (; i < 3; i++)
                {
                    if (t1[i])
                    {
                        t2[i].Foreground = Brushes.Red;
                        break;
                    }
                }

                if (i == 3)
                {
                    string mail = RegMailTxt.Text.Trim();
                    string username = RegUserNameTxt.Text.Trim();
                    string password = RegPasswordTxt.Password.Trim();
                    Res = await Task.Run(() =>
                    {
                        try { return RegMethod(username, password, mail); }
                        catch { throw new Exception(); }
                    });
                }
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message); RegUserName.Foreground = Brushes.Red; AllOk = false;
            }
            ProgressBar1.Visibility = Visibility.Collapsed;
            if (AllOk && (i == 3))
            {
                Complite.IsOpen = true;
            }
            else if (!AllOk)
            {
                RegFail.IsOpen = !Res;
            }
        }
        private void ReadyBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(user, session);
            mainWindow.Show();
            this.Close();
        }

        private void RegMailTxt_GotFocus(object sender, RoutedEventArgs e)
        {
            RegMail.Foreground = color;
        }

        private void RegUserNameTxt_GotFocus(object sender, RoutedEventArgs e)
        {
            RegUserName.Foreground = color;
        }

        private void RegPasswordTxt_GotFocus(object sender, RoutedEventArgs e)
        {
            RegPassword.Foreground = color;
        }

        private void BackToLoginButton_Click(object sender, RoutedEventArgs e)
        {
            Authorization autorization = new Authorization();
            this.Close();
            autorization.Show();
        }
    }
}
