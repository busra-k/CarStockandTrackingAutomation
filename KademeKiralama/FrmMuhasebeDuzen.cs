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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProGarage.KademeKiralama
{
    public partial class FrmMuhasebeDuzen : Form
    {
        public string tc2, adsyoad2, telno2, adres2, hizmet, hizmet_miktar, hizmet_tarih, hizmet_vergi, hizmet_tutar;

        private void ıconButton2_Click(object sender, EventArgs e)
        {
            try
            {
                Random rnd = new Random();
                int sayi = rnd.Next(999999);
                con = new SqlConnection(dbDegisken);
                con.Open();
                com.Connection = con;
                com.CommandText = "update muhasebe set isimsoyisim = '" + adsoyad.Text + "',tcno = '" + tcno.Text + "',telno = '" + telno.Text + "',adres = '" + adres.Text + "',hizmet = '" + h_ad.Text + "',hizmet_miktar = '" + h_miktar.Text + "',hizmet_tarih = '" + h_tarih.Text + "' ,hizmet_tutar = '" + h_toplam.Text + "' ,hizmet_tax = '" + h_tax.Text + "' where tcno = '" + tc2 + "'; ";
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
        private void FrmMuhasebeDuzen_Load(object sender, EventArgs e)
        {
            VeriYollamaca();
        }
        string dbDegisken;

        SqlConnection con = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        SqlCommand com = new SqlCommand();
        DataSet ds = new DataSet();
        public FrmMuhasebeDuzen()
        {
            InitializeComponent();
            VeriTabani INI = new VeriTabani(Application.StartupPath + @"\settings\database.ini");
            dbDegisken = INI.Oku("DATA", "database");
        }
        public void VeriYollamaca()
        {
            tcno.Text = tc2;
            adsoyad.Text = adsyoad2;
            telno.Text = telno2;
            adres.Text = adres2;
            h_ad.Text = hizmet;
            h_miktar.Text = hizmet_miktar;
            h_tarih.Text = hizmet_tarih;
            h_tax.Text = hizmet_vergi;
            h_toplam.Text = hizmet_tutar;

        }
    }
}
