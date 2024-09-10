using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Message_Project
{
    public partial class Form1 : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=faruk\\sqlexpress;Initial Catalog=Message_Project;Integrated Security=True;");
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_giris_Click(object sender, EventArgs e)
        {
            conn.Open();

            SqlCommand cmd = new SqlCommand("Select * from TBL_KISILER where NUMARA=@P1 AND SIFRE=@P2", conn);
            cmd.Parameters.AddWithValue("@P1", masked_numara.Text);
            cmd.Parameters.AddWithValue("@P2", masked_sifre.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            
            if (dr.Read())
            {
                MessageBox.Show("Giriş Yapıldı !");
                MessageScreen messageScreen = new MessageScreen();
                messageScreen.numara = masked_numara.Text;

                messageScreen.Show();
            }
            else
            {
                MessageBox.Show("Giriş Başarısız !");
            }
            conn.Close();
        }
    }
}
