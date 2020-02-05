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
using System.Data;
using System.Data.SqlClient;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for pat_delete.xaml
    /// </summary>
    public partial class pat_delete : Window
    {
        public pat_delete()
        {
            InitializeComponent();
        }

        private void Sub_delete_Click(object sender, RoutedEventArgs e)
        {

            MessageBoxResult result = MessageBox.Show("Are you sure", "Exit", MessageBoxButton.YesNo);

            switch (result)
            {
                case MessageBoxResult.Yes:

                    string conn = @"Data Source=DESKTOP-G3VEQT2;Initial Catalog=anik;Integrated Security=True";
                    SqlConnection sqlCon = new SqlConnection(conn);

                    string commandString = "delete from patients_info where p_serial ='" + pt_delete.Text + "'";
                    SqlCommand sqlcmd = new SqlCommand(commandString, sqlCon);
                    sqlCon.Open();


                    int row = sqlcmd.ExecuteNonQuery();
                    sqlCon.Close();

                    if (row > 0)
                    {
                        MessageBox.Show("Information has deleted");
                    }
                    break;
                case MessageBoxResult.No:
                    break;
            }
            this.Close();
        }

        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
