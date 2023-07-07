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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace ProGarage.KademeStok
{
    public partial class FrmStokDuzenle : Form
    {
        public string id, stok, stok_miktar, stok_gelis, stok_satis, stok_aciklama, stok_tarih, s_disis, s_mekanik, stok_d_kar, stok_s_kar;
        string dbDegisken, GelenID;

        private void FrmStokDuzenle_Load(object sender, EventArgs e)
        {
            veriYollamaca();
        }

        private void ıconButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string dt = dateTimePicker1.Value.ToString("MM-dd-yyyy");

                con = new SqlConnection(dbDegisken);
                con.Open();
                com.Connection = con;
                com.CommandText = "update stok set  stok_gelis = @sgelis ,stok_miktar = @smiktar, stok_aciklama = @saciklama ,stok_tutar = @stutar, stok_disiscilik = @sdisis, stok_mekanik = @smekanik, stok_tarih = @strh , stok_s_kar = @satiskar, stok_d_kar = @dkar WHERE id = @id";
                com.Parameters.AddWithValue("@id", GelenID);
                com.Parameters.AddWithValue("@sgelis", textBox2.Text);
                com.Parameters.AddWithValue("@smiktar", textBox3.Text);
                com.Parameters.AddWithValue("@saciklama", richTextBox1.Text);
                com.Parameters.AddWithValue("@stutar", textBox4.Text);
                com.Parameters.AddWithValue("@smekanik", textBox5.Text);
                com.Parameters.AddWithValue("@sdisis", textBox6.Text);
                com.Parameters.AddWithValue("@strh", dt);
                com.Parameters.AddWithValue("@satiskar", textBox7.Text);
                com.Parameters.AddWithValue("@dkar", textBox8.Text);


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

        SqlConnection con = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        SqlCommand com = new SqlCommand();
        DataSet ds = new DataSet();
        public FrmStokDuzenle()
        {
            InitializeComponent();
            VeriTabani INI = new VeriTabani(Application.StartupPath + @"\settings\database.ini");
            dbDegisken = INI.Oku("DATA", "database");
        }
        public void veriYollamaca()
        {
            GelenID = id;
            textBox3.Text = stok_miktar;
            textBox2.Text = stok_gelis;
            textBox4.Text = stok_satis;
            richTextBox1.Text = stok_aciklama;
            dateTimePicker1.Text = stok_tarih;
            textBox6.Text = s_disis;
            textBox5.Text = s_mekanik;
            textBox7.Text = stok_s_kar;
            textBox8.Text = stok_d_kar;
        }
    }
}
