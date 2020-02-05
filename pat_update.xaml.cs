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
    /// Interaction logic for pat_update.xaml
    /// </summary>
    public partial class pat_update : Window
    {
        public pat_update()
        {
            InitializeComponent();
        }

        private void Pr_update_Click(object sender, RoutedEventArgs e)
        {
            string pname, paddress;

            pname = name.Text;
            paddress = address.Text;


            string connectionstring = @"Data Source=DESKTOP-G3VEQT2;Initial Catalog=anik;Integrated Security=True";
            SqlConnection sqlcon = new SqlConnection(connectionstring);

            string commandstring = "update patients_info set p_name=@a , p_address=@b where p_serial='" + s_no.Text + "' ";
            SqlCommand sqlcmd = new SqlCommand(commandstring, sqlcon);
            sqlcmd.Parameters.Add("@a", SqlDbType.VarChar).Value = pname;
            sqlcmd.Parameters.Add("@b", SqlDbType.VarChar).Value = paddress;

            sqlcon.Open();
            int rows = sqlcmd.ExecuteNonQuery();
            sqlcon.Close();

            if (rows>0)
                MessageBox.Show("Information Has Updated.");
            this.Close();

        }

        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
