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

namespace ProGarage.FrmAracKiralamaDuzen
{
    public partial class FrmAracKiralamaDuzen : Form
    {
        public string id, isimsoyisimG, tcnoG, telnoG, adresG, markaG, modelG, renkG, kiraG, gunG, tutarG, v_tarihG, a_tarihG;
        string dbDegisken;
        SqlConnection con = new SqlConnection();
        string gelenID;
        private void FrmAracKiralamaDuzen_Load(object sender, EventArgs e)
        {
            VeriGetir();
        }

        SqlDataAdapter da = new SqlDataAdapter();
        SqlCommand com = new SqlCommand();
        DataSet ds = new DataSet();
        public void VeriGetir()
        {
            textBox1.Text = isimsoyisimG;
            textBox2.Text = tcnoG;
            textBox3.Text = telnoG;
            richTextBox1.Text = adresG;
            marka.Text = markaG;
            model.Text = modelG;
            renk.Text = renkG;
            textBox8.Text = kiraG;
            textBox9.Text = gunG;
            textBox10.Text = tutarG;
            metroDateTime1.Value.ToString(v_tarihG);
            metroDateTime2.Value.ToString(a_tarihG);
            gelenID = id;


        }
        public FrmAracKiralamaDuzen()
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
                textBox8.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
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
            //Veri Ekleme
            //id | m_isim | m_tc | m_tel | m_adres | a_marka | a_model | a_renk | a_ucret | a_gun | a_tutar | s_trh | ta_trh
            try
            {
                con = new SqlConnection(dbDegisken);

                Random rnd = new Random();
                int sayi = rnd.Next(999999);
                com = new SqlCommand();
                con.Open();
                com.Connection = con;
                com.CommandText = "update kiralama set m_isim = @isim, m_tc = @tc ,m_tel = @tel,m_adres = @adres ,a_marka = @marka,a_model = @model ,sinir = @renk ,a_ucret = @ucret, a_gun = @gun ,a_tutar = @tutar,s_trh = @trh1, ta_trh = @trh2, durum = @durum WHERE id=@id";
                com.Parameters.AddWithValue("@isim", textBox1.Text);
                com.Parameters.AddWithValue("@tc", textBox2.Text);
                com.Parameters.AddWithValue("@tel", textBox3.Text);
                com.Parameters.AddWithValue("@adres", richTextBox1.Text);
                com.Parameters.AddWithValue("@marka", marka.Text);
                com.Parameters.AddWithValue("@model", model.Text);
                com.Parameters.AddWithValue("@renk", renk.Text);
                com.Parameters.AddWithValue("@ucret", textBox8.Text);
                com.Parameters.AddWithValue("@gun", textBox9.Text);
                com.Parameters.AddWithValue("@tutar", textBox10.Text);
                com.Parameters.AddWithValue("@trh1", metroDateTime1.Text);
                com.Parameters.AddWithValue("@trh2", metroDateTime2.Text);
                com.Parameters.AddWithValue("@durum", metroComboBox1.Text);
                com.Parameters.AddWithValue("@id", gelenID);

                com.ExecuteNonQuery(); //www.yazilimkodlama.com
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
