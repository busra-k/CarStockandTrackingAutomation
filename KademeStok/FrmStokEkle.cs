using MetroFramework.Controls;
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

namespace ProGarage.KademeStok
{
    public partial class FrmStokEkle : Form
    {
        string dbDegisken;
        SqlConnection con = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        SqlCommand com = new SqlCommand();
        DataSet ds = new DataSet();

        public FrmStokEkle()
        {
            InitializeComponent();
            VeriTabani INI = new VeriTabani(Application.StartupPath + @"\settings\database.ini");
            dbDegisken = INI.Oku("DATA", "database");
        }

        private void ıconButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string dt = dateTimePicker1.Value.ToString("MM-dd-yyyy");
                Random rnd = new Random();
                int sayi = rnd.Next(999999);
                con = new SqlConnection(dbDegisken);
                con.Open();
                com.Connection = con;
                com.CommandText = "insert into stok(id,stok_gelis,stok_miktar,stok_aciklama,stok_tutar,stok_disiscilik,stok_mekanik,stok_tarih,stok_d_kar,stok_s_kar) values ('" + sayi + "','" + textBox2.Text + "','" + textBox3.Text + "','" + richTextBox1.Text + "','" + textBox4.Text + "','" + textBox6.Text + "','" + textBox5.Text + "','" + dt + "','" + textBox8.Text + "','" + textBox7.Text + "')";
                com.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Kayıt, sisteme başarılı bir şekilde eklendi.", "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Kayıt eklenemedi. Lütfen veri tabanını yada verileri kontrol edin. Hata Ayrıntısı : " + ex, "İşlem Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;

            }
        }

        private void ıconPictureBox9_Click(object sender, EventArgs e)
        {
        }

        private void FrmStokEkle_Load(object sender, EventArgs e)
        {

        }
    }
}
