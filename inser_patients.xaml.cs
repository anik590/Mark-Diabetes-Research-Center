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
    /// Interaction logic for inser_patients.xaml
    /// </summary>
    public partial class inser_patients : Window
    {
        public inser_patients()
        {
            InitializeComponent();
        }

        private void Btn_submit_Click(object sender, RoutedEventArgs e)
        {

            int nid, p_sr;
            string name, address, age, mob, type;

            nid = int.Parse(p_nid.Text);
            p_sr = int.Parse(p_serial.Text);
            name = patients_name.Text;
            address = patients_address.Text;
            age = patients_age.Text;
            mob = patients_mob.Text;
            type = d_type.Text;

            string conn = @"Data Source=DESKTOP-G3VEQT2;Initial Catalog=anik;Integrated Security=True";

            SqlConnection sqlcon = new SqlConnection(conn);

            SqlCommand cmd = new SqlCommand("insert into patients_info (p_nid,p_serial,p_name,p_address,p_age,p_mobile,p_dyabatesType ) values(@a,@b,@c,@d,@e,@f,@g)", sqlcon);

            cmd.Parameters.Add("@a", SqlDbType.Int).Value = nid;
            cmd.Parameters.Add("@b", SqlDbType.Int).Value = p_sr;
            cmd.Parameters.Add("@c", SqlDbType.VarChar).Value = name;
            cmd.Parameters.Add("@d", SqlDbType.VarChar).Value = address;
            cmd.Parameters.Add("@e", SqlDbType.VarChar).Value = age;
            cmd.Parameters.Add("@f", SqlDbType.VarChar).Value = mob;
            cmd.Parameters.Add("@g", SqlDbType.VarChar).Value = type;

            sqlcon.Open();
            int rows = cmd.ExecuteNonQuery();
            if (rows > 0)
                MessageBox.Show("Saved");
            sqlcon.Close();
            this.Close();

        }

        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
