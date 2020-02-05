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
using System.Windows.Shapes;
using System.Data.SqlClient;
namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Btn_home_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
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


        private void Btn_pr_sr_Click(object sender, RoutedEventArgs e)
        {
            string conn = @"Data Source=DESKTOP-G3VEQT2;Initial Catalog=anik;Integrated Security=True";
            SqlConnection sqlCon = new SqlConnection(conn);
            sqlCon.Open();
            string cmd = "SELECT * FROM programs WHERE program_id= '" + in_sr_pr.Text + "' ";
            SqlCommand sqlCmd = new SqlCommand(cmd, sqlCon);
            SqlDataReader data = sqlCmd.ExecuteReader();



            while (data.Read())
            {
                
                pr_result.Text = "\n\n\nProgram ID : " + data[0].ToString();
                pr_result.Text += "\n Program Name : " + data[1].ToString();
                pr_result.Text += "\nResearcher ID : " + data[2].ToString();
                pr_result.Text += "\nProgram Researcher : " + data[3].ToString();
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

        private void Btn_insert_Click(object sender, RoutedEventArgs e)
        {
            inser_programs ins = new inser_programs();
            ins.Show();
        }

        private void Btn_update_Click(object sender, RoutedEventArgs e)
        {
            update_programs up = new update_programs();
            up.Show();
        }

        private void Btn_delete_Click(object sender, RoutedEventArgs e)
        {
            delete dl = new delete();
            dl.Show();
        }
    }
}
