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

namespace ProGarage.KademeKiralama
{
    public partial class FrmMusteriEkle : Form
    {
        string dbDegisken, dosyayolu;
        SqlConnection con = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        SqlCommand com = new SqlCommand();
        DataSet ds = new DataSet();
        public FrmMusteriEkle()
        {
            InitializeComponent();
            VeriTabani INI = new VeriTabani(Application.StartupPath + @"\settings\database.ini");
            dbDegisken = INI.Oku("DATA", "database");
        }

        private void ıconButton1_Click(object sender, EventArgs e)
        {
            try
            {
                Random rnd = new Random();
                int sayi = rnd.Next(999999);
                //id | seri | plaka | model | marka | renk | km | yakit | vites | detail | price
                con = new SqlConnection(dbDegisken);
                con.Open();
                com.Connection = con;
                com.CommandText = "insert into musteriler(id,tc,isim_soyisim,ehliyet,telno,adres,dosya) values ('" + sayi + "','" + textBox2.Text + "','" + textBox1.Text + "','" + textBox4.Text + "','" + textBox3.Text + "','" + richTextBox1.Text + "','" + textBox5.Text + "')";
                com.ExecuteNonQuery(); //www.yazilimkodlama.com
                con.Close();
                MessageBox.Show("Kayıt, sisteme başarılı bir şekilde eklendi.", "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kayıt eklenemedi. Lütfen veri tabanını yada verileri kontrol edin. Hata Ayrıntısı : " + ex, "İşlem Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private void ıconPictureBox7_Click(object sender, EventArgs e)
        {
            OpenFileDialog dosya = new OpenFileDialog();
            dosya.Filter = "Resim Dosyası |*.jpg;*.nef;*.png |  Tüm Dosyalar |*.*";
            dosya.ShowDialog();
            dosyayolu = dosya.FileName;
            textBox5.Text = dosyayolu;
            pictureBox1.ImageLocation = dosyayolu;
        }
    }
}
