using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MessageApp
{
    public partial class Logins : DevExpress.XtraEditors.XtraForm
    {
        
        public Logins()
        {
            InitializeComponent();
        }
        
        private void Logins_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Bir Sorun Olduğunda İletişime Geçebilirsiniz");
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-GL50CBO;Initial Catalog=MessageApp;Integrated Security=True;TrustServerCertificate=True");
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select * From Tbl_Users Where Number=@p1 and Password=@p2", conn);
            cmd.Parameters.AddWithValue("@p1", txtNumara.Text);
            cmd.Parameters.AddWithValue("@p2", txtSifre.Text);
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                Messages form = new Messages();
                form.numara = txtNumara.Text;
                form.Show();
                this.Hide();
            }

            else
            {
                MessageBox.Show("Hatalı Kullanıcı Adı veya Şifre!");
            }
            conn.Close();
        }

        private void ımageEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}