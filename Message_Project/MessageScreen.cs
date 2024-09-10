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
    public partial class MessageScreen : Form
    {

        SqlConnection conn = new SqlConnection("Data Source=faruk\\sqlexpress;Initial Catalog=Message_Project;Integrated Security=True;");
        public MessageScreen()
        {
            InitializeComponent();
        }
        public string numara;
        private void lbl_adSoyad_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void MessageScreen_Load(object sender, EventArgs e)
        {
            conn.Open();
            lbl_numara.Text = numara;
            GelenKutusu();
            GidenKutusu();

            // ad soyad çekme

            SqlCommand cmd = new SqlCommand("select ad,soyad from TBL_KISILER where numara=" + numara, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lbl_adSoyad.Text = dr[0] + " " + dr[1];
            }
            conn.Close();
        }

        void GelenKutusu()
        {
            SqlDataAdapter da1 = new SqlDataAdapter("Select * from TBL_MESAJLAR WHERE  ALICI =" + numara, conn);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;
            numaralar();


        }
        void numaralar()
        {
          // inner join kullanarak gönderen gelen kısmındaki sayıları isimlere çevir 

            // yeni kullanıcı olayını ekle
        }

        void GidenKutusu()
        {
            SqlDataAdapter da2 = new SqlDataAdapter("Select * from TBL_MESAJLAR WHERE GONDEREN =" + numara, conn);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            dataGridView2.DataSource = dt2;
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into TBL_MESAJLAR(GONDEREN,ALICI,BASLIK,ICERIK) values (@P1,@P2,@P3,@P4) ", conn);
            cmd.Parameters.AddWithValue("@P1", numara);
            cmd.Parameters.AddWithValue("@P2", masked_AlıcıAdı.Text);
            cmd.Parameters.AddWithValue("@P3", Txt_title.Text);
            cmd.Parameters.AddWithValue("@P4",richBox_Message.Text);

            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Mesajınız Gönderildi ");
            GidenKutusu();
        }
    }
}
