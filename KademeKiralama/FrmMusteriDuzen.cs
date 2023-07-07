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

namespace ProGarage.KademeKiralama
{
    public partial class FrmMusteriDuzen : Form
    {
        public string tc, adsyoad, ehliyet, telno, adres, dosya;
        string dbDegisken, dosyayolu;

        SqlConnection con = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        SqlCommand com = new SqlCommand();
        DataSet ds = new DataSet();

        private void ıconPictureBox7_Click(object sender, EventArgs e)
        {
            OpenFileDialog dosya = new OpenFileDialog();
            dosya.Filter = "Resim Dosyası |*.jpg;*.nef;*.png |  Tüm Dosyalar |*.*";
            dosya.ShowDialog();
            dosyayolu = dosya.FileName;
            textBox5.Text = dosyayolu;
            pictureBox1.ImageLocation = dosyayolu;
        }

        private void ıconButton1_Click(object sender, EventArgs e)
        {
            try
            {
                Random rnd = new Random();
                int sayi = rnd.Next(999999);
                con = new SqlConnection(dbDegisken);
                con.Open();
                com.Connection = con;
                com.CommandText = "update musteriler set tc = '" + textBox2.Text + "',isim_soyisim = '" + textBox1.Text + "',ehliyet = '" + textBox4.Text + "',telno = '" + textBox3.Text + "',adres = '" + richTextBox1.Text + "' ,dosya = '" + textBox5.Text + "' where tc = '" + tc + "'; ";
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

        private void FrmMusteriDuzen_Load(object sender, EventArgs e)
        {
            VeriYollamaca();
        }

        public void VeriYollamaca()
        {
            textBox2.Text = tc;
            textBox1.Text = adsyoad;
            textBox4.Text = ehliyet;
            textBox3.Text = telno;
            richTextBox1.Text = adres;
            textBox5.Text = dosya;
            pictureBox1.ImageLocation = textBox5.Text;

        }
        public FrmMusteriDuzen()
        {
            InitializeComponent();

            VeriTabani INI = new VeriTabani(Application.StartupPath + @"\settings\database.ini");
            dbDegisken = INI.Oku("DATA", "database");
        }
    }
}
