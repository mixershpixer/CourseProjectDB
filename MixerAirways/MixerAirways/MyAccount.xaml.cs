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
    /// Логика взаимодействия для MyAccount.xaml
    /// </summary>
    public partial class MyAccount : UserControl
    {
        public string ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        Classes.User user;
        public MyAccount(Classes.User user)
        {
            InitializeComponent();
            this.user = user;
            UserName.Text = user.username;
            Email.Text = user.email;
            UserNameTxt.Text = user.username;
            EmailTxt.Text = user.email;
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            if(RedStack.Visibility == Visibility.Hidden)
                RedStack.Visibility = Visibility.Visible;
            else RedStack.Visibility = Visibility.Hidden;
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            if (UserNameTxt.Text != "" && PasswordTxt.Password != ""
                && PasswordTxt.Password == ConfPasswordTxt.Password && EmailTxt.Text != "")
                Conf.IsOpen = true;
            else Error.IsOpen = true;
        }

        private void ConfCh_Click(object sender, RoutedEventArgs e)
        {
            int uid = MainWindow.Session.user_id;
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd = new SqlCommand("user_change", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@user_id", uid);
                cmd.Parameters.AddWithValue("@username", UserNameTxt.Text);
                cmd.Parameters.AddWithValue("@password", PasswordTxt.Password);
                cmd.Parameters.AddWithValue("@contact_data", EmailTxt.Text);
                int result = Convert.ToInt32(cmd.ExecuteScalar());
                if (result == 0) Error.IsOpen = true;
                else
                {
                    Authorization authorization = new Authorization();
                    MainWindow.MAIN.Close();
                    authorization.Show();
                }

            }
        }
    }
}
