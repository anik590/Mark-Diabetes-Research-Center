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
    /// Interaction logic for update_programs.xaml
    /// </summary>
    public partial class update_programs : Window
    {
        public update_programs()
        {
            InitializeComponent();
        }


        private void StackPanel_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Pr_update_Click(object sender, RoutedEventArgs e)
        {
            int  y;
            string z;

            
            y = int.Parse(up_id.Text);
            z = up_name.Text;


            string connectionstring = @"Data Source=DESKTOP-G3VEQT2;Initial Catalog=anik;Integrated Security=True";
            SqlConnection sqlcon = new SqlConnection(connectionstring);

            string commandstring = "update programs set researcher_id=@a , researcher_name=@b where program_id='" + con_id.Text + "' ";
            SqlCommand sqlcmd = new SqlCommand(commandstring, sqlcon);
            sqlcmd.Parameters.Add("@a", SqlDbType.Int).Value =y;
            sqlcmd.Parameters.Add("@b", SqlDbType.VarChar).Value =z;

            sqlcon.Open();
            int rows = sqlcmd.ExecuteNonQuery();
            sqlcon.Close();

            if (rows == 1)
                MessageBox.Show("Information Has Updated.");
            this.Close();
        }
    }
}
