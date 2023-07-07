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

namespace ProGarage.KademeServis
{
    //Gecenin bir saatinde sana armağan ettiğim şarkı ile bu kodları yazıyorum.
    //Üzgün müyüm ? Hayır. Mutsuz bile değilim inan ki her şeyi artık rayına sokabildim ben senden sonra.
    //Gelecekte eğer yanımda sen olacaksan bu günleri ders olarak çıkar kendine
    //Ben öyle yaptım en azından. Bu şehiri terk ediyorum bir daha gelmemek üzere.
    //Zafer allahındır. Rızkımı veren de o'dur. Kula kesinlikle minnet eylemem.
    //Şunu unutma, benim için vazgeçilmezdin bir aralar.
    //Ama yapacak pek bir şey yok. Burada sana çokça şey yazmak isterdim, kodların anasını sikmeyelim.

    public partial class FrmAracServisDuzenle : Form
    {
        public string id, markaG, modelG, plakaG, seriG, renkG, kmG, vitesG, yakitG, tutarG, islemG, notG, isimsoyisimG, tcG, telnoG, adresG, parca, parca_gelis, parca_tutar, parca_tur, arac_tur;
        int StokGelenMiktar, stokID;
        private void ıconButton3_Click_1(object sender, EventArgs e)
        {

        }

        private void ıconButton5_Click(object sender, EventArgs e)
        {
            try
            {
                textBox5.Text = dataGridView3.CurrentRow.Cells[1].Value.ToString();
                textBox7.Text = dataGridView3.CurrentRow.Cells[2].Value.ToString();
                textBox6.Text = dataGridView3.CurrentRow.Cells[5].Value.ToString();
                StokGelenMiktar = Convert.ToInt32(dataGridView3.CurrentRow.Cells[3].Value);
                stokID = Convert.ToInt32(dataGridView3.CurrentRow.Cells[0].Value);

            }
            catch (Exception ex)
            {

                MessageBox.Show("Tabloları yenilemeden lütfen atama yapmayınız. Atama yapmadan önce tabloları yenileyiniz. Hata Ayrıntısı : " + ex, "Hata !", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                throw;

            }
        }

        private void ıconButton1_Click_1(object sender, EventArgs e)
        {
            DateTime bugun = DateTime.Now;
            try
            {
                int topla = StokGelenMiktar - 1;
                con = new SqlConnection(dbDegisken);
                con.Open();
                com2.Connection = con;
                com.Connection = con;
                com.CommandText = "update servis set marka = @marka ,model = @model ,plaka = @plaka, sno = @sno ,km = @km , vites = @vites , yakit = @yakit , tutar = @tutar, detay = @detay , islem = @islem, tcno = @tcno , adsoyad = @adsoyad , telno = @telno, adres = @adres, parca = @parca, parca_gelis = @parcagelis, parca_tutar = @parcatutar, parca_tur = @parcatur, islem_tarih=@bugun WHERE id = @id";
                com2.CommandText = "update stok set stok_miktar =@miktar where id=@id2";
                com.Parameters.AddWithValue("@id", GelenID);
                com.Parameters.AddWithValue("@marka", marka.Text);
                com.Parameters.AddWithValue("@model", model.Text);
                com.Parameters.AddWithValue("@plaka", plaka.Text);
                com.Parameters.AddWithValue("@sno", seri.Text);
                com.Parameters.AddWithValue("@km", km.Text);
                com.Parameters.AddWithValue("@vites", vites.Text);
                com.Parameters.AddWithValue("@yakit", yakit.Text);
                com.Parameters.AddWithValue("@tutar", ucret.Text);
                com.Parameters.AddWithValue("@detay", not.Text);
                com.Parameters.AddWithValue("@islem", textBox1.Text);
                com.Parameters.AddWithValue("@tcno", textBox2.Text);
                com.Parameters.AddWithValue("@adsoyad", textBox4.Text);
                com.Parameters.AddWithValue("@telno", textBox3.Text);
                com.Parameters.AddWithValue("@adres", richTextBox1.Text);
                com.Parameters.AddWithValue("@parca", textBox5.Text);
                com.Parameters.AddWithValue("@parcagelis", textBox7.Text);
                com.Parameters.AddWithValue("@parcatutar", textBox6.Text);
                com.Parameters.AddWithValue("@parcatur", textBox6.Text);
                com.Parameters.AddWithValue("@bugun", bugun);
                com2.Parameters.AddWithValue("@miktar", topla);
                com2.Parameters.AddWithValue("@id2", stokID);
                com.ExecuteNonQuery();
                com2.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Kayıt, sisteme başarılı bir şekilde eklendi.", "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Kayıt eklenemedi. Lütfen veri tabanını yada verileri kontrol edin. Hata Ayrıntısı : " + ex, "İşlem Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;

            }
        }

        private void FrmAracServisDuzenle_Load(object sender, EventArgs e)
        {
            VeriGetir();
            MusteriDoldur();
            AracDoldur();
            StokDoldur();
        }

        string dbDegisken;
        SqlConnection con = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        SqlCommand com = new SqlCommand();
        SqlCommand com2 = new SqlCommand();
        DataSet ds = new DataSet();
        string GelenID;
        public void VeriGetir()
        {
            GelenID = id;
            marka.Text = markaG;
            model.Text = modelG;
            plaka.Text = plakaG;
            seri.Text = seriG;
            km.Text = kmG;
            vites.Text = vitesG;
            yakit.Text = yakitG;
            ucret.Text = tutarG;
            textBox1.Text = islemG;
            not.Text = notG;
            textBox4.Text = isimsoyisimG;
            textBox2.Text = tcG;
            textBox3.Text = telnoG;
            richTextBox1.Text = adresG;
            textBox5.Text = parca;
            textBox6.Text = parca_tutar;
            textBox7.Text = parca_gelis;
            metroComboBox1.Text = parca_tur;
            metroComboBox2.Text = arac_tur;

         }
        public FrmAracServisDuzenle()
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
        void StokDoldur()
        {
            try
            {
                con = new SqlConnection(dbDegisken);
                da = new SqlDataAdapter("Select * From stok", con);
                ds = new DataSet();
                con.Open();
                da.Fill(ds, "Stok");
                dataGridView3.DataSource = ds.Tables["Stok"];
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tablonun geldiği veri tabanında veri yok !", "Hata !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
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

            private void ıconButton3_Click(object sender, EventArgs e)
            {
                MusteriDoldur();
                AracDoldur();
                StokDoldur();

            }

        private void ıconButton2_Click(object sender, EventArgs e)
        {

            try
            {
                textBox4.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
                textBox2.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
                textBox3.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
                richTextBox1.Text = dataGridView2.CurrentRow.Cells[5].Value.ToString();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Tabloları yenilemeden lütfen atama yapmayınız. Atama yapmadan önce tabloları yenileyiniz. Hata Ayrıntısı : " + ex, "Hata !", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                throw;

            }
        }

        private void ıconButton1_Click(object sender, EventArgs e)
        {
            try
            {

                con = new SqlConnection(dbDegisken);
                con.Open();
                com.Connection = con;
                com.CommandText = "update servis set marka = @marka ,model = @model ,plaka = @plaka, sno = @sno ,km = @km , vites = @vites , yakit = @yakit , tutar = @tutar, detay = @detay , islem = @islem, tcno = @tcno , adsoyad = @adsoyad , telno = @telno, adres = @adres WHERE id = @id";
                com.Parameters.AddWithValue("@id", GelenID);
                com.Parameters.AddWithValue("@marka", marka.Text);
                com.Parameters.AddWithValue("@model", model.Text);
                com.Parameters.AddWithValue("@plaka", plaka.Text);
                com.Parameters.AddWithValue("@sno", seri.Text);
                com.Parameters.AddWithValue("@km", km.Text);
                com.Parameters.AddWithValue("@vites", vites.Text);
                com.Parameters.AddWithValue("@yakit", yakit.Text);
                com.Parameters.AddWithValue("@tutar", ucret.Text);
                com.Parameters.AddWithValue("@detay", not.Text);
                com.Parameters.AddWithValue("@islem", textBox1.Text);
                com.Parameters.AddWithValue("@tcno", textBox2.Text);
                com.Parameters.AddWithValue("@adsoyad", textBox4.Text);
                com.Parameters.AddWithValue("@telno", textBox3.Text);
                com.Parameters.AddWithValue("@adres", richTextBox1.Text);
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
