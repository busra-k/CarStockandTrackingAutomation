using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace ProGarage.KademeKiralama
{
    public partial class FrmMuhasebeEkran : Form
    {
        string dbDegisken;
        SqlConnection con = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        SqlCommand com = new SqlCommand();
        DataSet ds = new DataSet();
        public FrmMuhasebeEkran()
        {
            InitializeComponent();
            VeriTabani INI = new VeriTabani(Application.StartupPath + @"\settings\database.ini");
            dbDegisken = INI.Oku("DATA", "database");
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

        }

        private void FrmMuhasebeEkran_Load(object sender, EventArgs e)
        {
            MusteriDoldur();

        }

        private void ıconButton1_Click(object sender, EventArgs e)
        {
            try
            {
                adsoyad.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
                tcno.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
                telno.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
                adres.Text = dataGridView2.CurrentRow.Cells[5].Value.ToString();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Tabloları yenilemeden lütfen atama yapmayınız. Atama yapmadan önce tabloları yenileyiniz. Hata Ayrıntısı : " + ex, "Hata !", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                throw;

            }
        }

        private void ıconButton2_Click(object sender, EventArgs e)
        {
            //id | isimsoyisim | tcno | telno | adres | hizmet | hizmet_miktar | hizmet_tarih | hizmet_tutar | hizmet_tax
            try
            {
                Random rnd = new Random();
                int sayi = rnd.Next(999999);
                com = new SqlCommand();
                con.Open();
                com.Connection = con;
                com.CommandText = "insert into muhasebe(id,isimsoyisim,tcno,telno,adres,hizmet,hizmet_miktar,hizmet_tarih,hizmet_tutar,hizmet_tax) values ('" + sayi + "','" + adsoyad.Text + "','" + tcno.Text + "','" + telno.Text + "','" + adres.Text + "','" + h_ad.Text + "','" + h_miktar.Text + "','" + h_tarih.Text + "','" + h_toplam.Text + "','" + h_tax.Text + "')";
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
    }
}
