using MixerAirways.Classes;
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
    public partial class MainWindow : Window
    {
        public static MainWindow MAIN;
        public static User User;
        public static Session Session;    
        public string ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public MainWindow()
        {
            InitializeComponent();
            MAIN = this;
        }
        public MainWindow(User user, Session session)
        {
            InitializeComponent();
            User = user;
            Session = session;
            MAIN = this;
            if(session.account_type == 0) admin.Visibility = Visibility.Visible;
        }
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd = new SqlCommand("user_logout", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@user_id", Session.user_id);
                cmd.ExecuteNonQuery();
            }
            Application.Current.Shutdown();
        }
        private void OpenMenuButton_Click(object sender, RoutedEventArgs e)
        {
            OpenMenuButton.Visibility = Visibility.Collapsed;
            CloseMenuButton.Visibility = Visibility.Visible;
        }
        private void MenuListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = MenuListView.SelectedIndex;
            if (index == -1) return;
            if (GridMenu.Width != 60)
            {
                OpenMenuButton.Visibility = Visibility.Visible;
                CloseMenuButton.Visibility = Visibility.Collapsed;
                DoubleAnimation buttonAnimation = new DoubleAnimation
                {
                    From = GridMenu.ActualWidth,
                    To = 60,
                    Duration = TimeSpan.FromSeconds(0.2),
                    FillBehavior = FillBehavior.Stop
                };
                GridMenu.BeginAnimation(Button.WidthProperty, buttonAnimation);
                Storyboard sb = new Storyboard();
                ThicknessAnimation commGridAnimation = new ThicknessAnimation
                {
                    From = new Thickness(200, 0, 0, 0),
                    To = new Thickness(0, 0, 0, 0),
                    FillBehavior = FillBehavior.Stop,
                    Duration = TimeSpan.FromSeconds(0.3)
                };
                Storyboard.SetTarget(commGridAnimation, ContentGrid);
                Storyboard.SetTargetProperty(commGridAnimation, new PropertyPath(MarginProperty));
                sb.Children.Add(commGridAnimation);
                sb.Begin();
            }
            switch (index)
            {
            case 0:
                ContentGrid.Children.Clear();
                ContentGrid.Children.Add(new MyAccount(User));
                break;
            case 1:
                ContentGrid.Children.Clear();
                MyBookings myBookings = new MyBookings();
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    SqlCommand cmd = new SqlCommand("view_my_books", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@passenger_id", Session.user_id);
                    int result = Convert.ToInt32(cmd.ExecuteScalar());
                    if (result != 0)
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Book book = new Book(
                                Convert.ToString(reader.GetValue(1)),
                                Convert.ToString(reader.GetValue(2)),
                                Convert.ToString(reader.GetValue(3)),
                                Convert.ToString(reader.GetValue(4)),
                                Convert.ToString(reader.GetValue(5)),
                                Convert.ToString(reader.GetValue(6)),
                                Convert.ToString(reader.GetValue(7)),
                                Convert.ToString(reader.GetValue(8)),
                                Convert.ToInt32(reader.GetValue(9)),
                                Convert.ToString(reader.GetValue(10)),
                                Convert.ToInt32(reader.GetValue(11)),
                                Convert.ToInt32(reader.GetValue(12)));
                                myBookings.MyBookWrapPanel.Children.Add(new Booking(book));
                            }
                        }
                        ContentGrid.Children.Clear();
                        ContentGrid.Children.Add(myBookings);
                        reader.Close();
                    }
                    else
                    {
                        Empty.IsOpen = true;
                    }
                }
                break;
            case 2:
                ContentGrid.Children.Clear();
                MyTickets myTickets = new MyTickets();
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    SqlCommand cmd = new SqlCommand("view_my_tickets", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@passenger_id", Session.user_id);
                    int result = Convert.ToInt32(cmd.ExecuteScalar());
                    if (result != 0)
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Ticket ticket = new Ticket(
                                Convert.ToString(reader.GetValue(1)),
                                Convert.ToString(reader.GetValue(2)),
                                Convert.ToString(reader.GetValue(3)),
                                Convert.ToString(reader.GetValue(4)),
                                Convert.ToString(reader.GetValue(5)),
                                Convert.ToString(reader.GetValue(6)),
                                Convert.ToString(reader.GetValue(7)),
                                Convert.ToString(reader.GetValue(8)),
                                Convert.ToInt32(reader.GetValue(9)),
                                Convert.ToString(reader.GetValue(10)),
                                Convert.ToInt32(reader.GetValue(11)),
                                Convert.ToInt32(reader.GetValue(12)));
                                myTickets.MyTicketsWrapPanel.Children.Add(new TicketItem(ticket));
                            }
                        }
                        ContentGrid.Children.Clear();
                        ContentGrid.Children.Add(myTickets);
                        reader.Close();
                    }
                    else
                    {
                        NoTick.IsOpen = true;
                    }
                }
                break;
            case 3:
                {
                    ContentGrid.Children.Clear();
                    ContentGrid.Children.Add(new ChooseFlight());
                }
                break;
            case 4:
                ContentGrid.Children.Clear();
                Notifications notifications = new Notifications();
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    SqlCommand cmd = new SqlCommand("view_all_notifications", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@user_id", Session.user_id);
                    int result = Convert.ToInt32(cmd.ExecuteScalar());
                    if (result != 0)
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Notification notification = new Notification(
                                Convert.ToString(reader.GetValue(1)),
                                Convert.ToString(reader.GetValue(2)),
                                Convert.ToString(reader.GetValue(3)),
                                Convert.ToInt32(reader.GetValue(4)));
                                notifications.NotificationsWrapPanel.Children.Add(new NotificationItem(notification));
                            }
                        }
                        reader.Close();
                        ContentGrid.Children.Clear();
                        ContentGrid.Children.Add(notifications);
                    }
                    else
                    {
                        NoNot.IsOpen = true;
                    }
                }
                break;
            case 5:
                {
                    ContentGrid.Children.Clear();
                    ContentGrid.Children.Add(new Admin());
                }
                break;
            }
        }
        private void CloseMenuButton_Click(object sender, RoutedEventArgs e)
        {
            OpenMenuButton.Visibility = Visibility.Visible;
            CloseMenuButton.Visibility = Visibility.Collapsed;
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        private void LogOutBtn_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd = new SqlCommand("user_logout", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@user_id", Session.user_id);
                cmd.ExecuteNonQuery();
            }
            (new Authorization()).Show();
            Close();
        }

        private void AboutBtn_Click(object sender, RoutedEventArgs e)
        {
            MenuListView.SelectedIndex = -1;
            ContentGrid.Children.Clear();
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            MenuListView.SelectedIndex = -1;
            ContentGrid.Children.Clear();
        }
        private void ReloadBookings_Click(object sender, RoutedEventArgs e)
        {
            MenuListView.SelectedIndex = -1;
            MenuListView.SelectedIndex = 1;
        }
    }
}
