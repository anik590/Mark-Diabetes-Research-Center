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
using System.Data;
using System.Data.SqlClient;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Programs_Click(object sender, RoutedEventArgs e)
        {
            Window1 nw = new Window1();
            nw.Show();
            this.Close();
        }

        private void Btn_home_Click(object sender, RoutedEventArgs e)
        {

        }


        private void Btn_logout_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure ?", "Logout", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    Log_in lg = new Log_in();
                    lg.Show();
                    this.Close();
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            string conn = @"Data Source=DESKTOP-G3VEQT2;Initial Catalog=anik;Integrated Security=True";
            SqlConnection sqlCon = new SqlConnection(conn);
            sqlCon.Open();
            string cmd = "SELECT * FROM patients_info WHERE p_serial= '" + in_search.Text + "' ";
            SqlCommand sqlCmd = new SqlCommand(cmd , sqlCon);
            SqlDataReader data = sqlCmd.ExecuteReader();

    

            while (data.Read())
            {
                sr_result.Text = "\n\n\nPatients NID : " + data[0].ToString();
                sr_result.Text += "\n Serial NO : " + data[1].ToString();
                sr_result.Text += "\nName : " + data[2].ToString();
                sr_result.Text += "\nAddress : " + data[3].ToString();
                sr_result.Text += "\nAge: " + data[4].ToString();
                sr_result.Text += "\nMobile : " + data[5].ToString();
                sr_result.Text += "\nD Type : " + data[5].ToString();

            }

            sqlCon.Close();
        }

        private void Close_app_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure ?", "Exit", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    Application.Current.Shutdown();
                    break;
                case MessageBoxResult.No:
                    break;

            }
        }

        private void X_Click(object sender, RoutedEventArgs e)
        {
            inser_patients ip = new inser_patients();
            ip.Show();
        }

        private void Btn_up_Click(object sender, RoutedEventArgs e)
        {
            pat_update pat = new pat_update();
            pat.Show();
        }

        private void Btn_delete_Click(object sender, RoutedEventArgs e)
        {
            pat_delete pd = new pat_delete();
            pd.Show();
        }
    }
}
