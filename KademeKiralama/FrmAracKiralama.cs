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
    public partial class FrmAracKiralama : Form
    {
        string dbDegisken;
        SqlConnection con = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        SqlCommand com = new SqlCommand();
        DataSet ds = new DataSet();

        public FrmAracKiralama()
        {
            InitializeComponent();
            VeriTabani INI = new VeriTabani(Application.StartupPath + @"\settings\database.ini");
            dbDegisken = INI.Oku("DATA", "database");

        }
        void AracDoldur()
        {
            try
            {
                con = new SqlConnection(dbDegisken);
                da = new SqlDataAdapter("Select * From araclar", con);
                ds = new DataSet();
                con.Open();
                da.Fill(ds, "Araçlar");
                dataGridView1.DataSource = ds.Tables["Araçlar"];
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tablonun geldiği veri tabanında veri yok !", "Hata !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }

        }
        void MusteriDoldur()
        {

            try
            {
                con = new SqlConnection(dbDegisken);
                da = new SqlDataAdapter("Select * From musteriler", con);
                ds = new DataSet();
                con.Open();
                da.Fill(ds, "Müşteriler");
                dataGridView2.DataSource = ds.Tables["Müşteriler"];
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tablonun geldiği veri tabanında veri yok !", "Hata !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private void ıconButton3_Click(object sender, EventArgs e)
        {
            MusteriDoldur();
            AracDoldur();
        }

        private void ıconButton2_Click(object sender, EventArgs e)
        {
            try
            {
                marka.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                model.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                renk.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                textBox8.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tabloları yenilemeden lütfen atama yapmayınız. Atama yapmadan önce tabloları yenileyiniz. Hata Ayrıntısı : "+ex, "Hata !", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                throw;
            }
            



        }

        private void ıconButton1_Click(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
                textBox2.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
                textBox3.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
                richTextBox1.Text = dataGridView2.CurrentRow.Cells[5].Value.ToString();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Tabloları yenilemeden lütfen atama yapmayınız. Atama yapmadan önce tabloları yenileyiniz. Hata Ayrıntısı : "+ex, "Hata !", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                throw;
                
            }
           


        }

        private void ıconButton4_Click(object sender, EventArgs e)
        {
            try
            {
                string paraDurum = "Teslim Alınmadı";
                Random rnd = new Random();
                int sayi = rnd.Next(999999);
                com = new SqlCommand();
                con.Open();
                com.Connection = con;
                com.CommandText = "insert into kiralama(id,m_isim,m_tc,m_tel,m_adres,a_marka,a_model,sinir,a_ucret,a_gun,a_tutar,s_trh,ta_trh,durum) values ('"+sayi+"','" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + richTextBox1.Text + "','" + marka.Text + "','" + model.Text + "','" + renk.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + textBox10.Text + "','" + metroDateTime1.Text + "','" + metroDateTime2.Text + "' ,'" + paraDurum + "')";
                com.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Kayıt, sisteme başarılı bir şekilde eklendi.", "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Kayıt eklenemedi. Lütfen veri tabanını yada verileri kontrol edin. Hata Ayrıntısı : "+ex, "İşlem Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;

            }
        }
    }
}
