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
    /// Interaction logic for inser_programs.xaml
    /// </summary>
    public partial class inser_programs : Window
    {
        public inser_programs()
        {
            InitializeComponent();
        }

        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Btn_submit_Click(object sender, RoutedEventArgs e)
        {
            int x, y;
            string  pr_name, rs_name;

            x = int.Parse(programid.Text);
            y = int.Parse(researcher_id.Text);

            pr_name = program_name.Text;

            rs_name = researcher_name.Text;


            //MessageBox.Show(pr_id + "\n" + sr_id + "\n" + pr_name + "\n" + rs_name);

            string conn = @"Data Source=DESKTOP-G3VEQT2;Initial Catalog=anik;Integrated Security=True";

            SqlConnection sqlcon = new SqlConnection(conn);

            SqlCommand cmd = new SqlCommand("insert into programs(program_id,program_name,researcher_id,researcher_name) values(@a,@b,@c,@d)", sqlcon);

            cmd.Parameters.Add("@a", SqlDbType.Int).Value = x;
            cmd.Parameters.Add("@b", SqlDbType.VarChar).Value = pr_name;
            cmd.Parameters.Add("@c", SqlDbType.Int).Value = y;
            cmd.Parameters.Add("@d", SqlDbType.VarChar).Value = rs_name;

            sqlcon.Open();
            int rows = cmd.ExecuteNonQuery();
            if (rows > 0)
                MessageBox.Show("Save");
            sqlcon.Close();
            this.Close();
        }
    }
}
