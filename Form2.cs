using DevExpress.XtraEditors;
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

namespace MessageApp
{

    
    public partial class Messages : DevExpress.XtraEditors.XtraForm
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-GL50CBO;Initial Catalog=MessageApp;Integrated Security=True;TrustServerCertificate=True");

        public string numara;
        public Messages()
        {
            InitializeComponent();
            
        }

        void gelenKutusu()
        {
            SqlDataAdapter da1 = new SqlDataAdapter("Select * From Tbl_Messages where buyer="+numara,conn);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;
        }

        void gidenKutusu()
        {
            SqlDataAdapter da2 = new SqlDataAdapter("Select * From Tbl_Messages where Sender=" + numara, conn);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            dataGridView2.DataSource = dt2;
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            lblNumaraa.Text = numara;

            gelenKutusu();
            gidenKutusu();

            //Ad Soyad Çekme 
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select Name,LastName From Tbl_Users where Number="+numara,conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lblAdSoyad.Text = dr[0] + " " + dr[1];
            }
            conn.Close();
        }

        private void btnGonder_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand komut = new SqlCommand("insert into Tbl_Messages (Sender,Buyer,Title,Contents) values " +
            "(@p1,@p2,@p3,@p4)", conn);
            komut.Parameters.AddWithValue("@p1", numara);
            komut.Parameters.AddWithValue("@p2", maskedTextBox1.Text);
            komut.Parameters.AddWithValue("@p3", textEdit1.Text);
            komut.Parameters.AddWithValue("@p4", richEditControl1.Text);
            komut.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Mesajınız Başarıyla İletildi");
            gidenKutusu();
        }
    }
}