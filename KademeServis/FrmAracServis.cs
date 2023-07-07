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
    public partial class FrmAracServis : Form
    {
        DateTime bugun = DateTime.Now;

        string dbDegisken;
        SqlConnection con = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        SqlCommand com = new SqlCommand();
        SqlCommand com2 = new SqlCommand();
        DataSet ds = new DataSet();
        public FrmAracServis()
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
            int topla = StokGelenMiktar - 1;


            try
            {
                Random rnd = new Random();
                int sayi = rnd.Next(999999);
                com = new SqlCommand();
                con.Open();
                com.Connection = con;
                com2.Connection = con;
                com.CommandText = "insert into servis(id,marka,model,plaka,sno,km,vites,yakit,tutar,detay,islem,tcno,adsoyad,telno,adres,arac_tur,parca_tur,parca_gelis,parca_tutar,parca,islem_tarih) values ('" + sayi + "','" + marka.Text + "','" + model.Text + "','" + plaka.Text + "','" + seri.Text + "','" + km.Text + "','" + vites.Text + "','" + yakit.Text + "','" + ucret.Text + "','" + not.Text + "','" + textBox1.Text + "','" + textBox4.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + richTextBox1.Text + "','" + metroComboBox2.Text + "','" + metroComboBox1.Text + "','" + textBox7.Text + "','" + textBox6.Text + "','" + textBox5.Text + "','" + bugun + "')";
                com2.CommandText = "update stok set stok_miktar =@miktar where id=@id2";
                com2.Parameters.AddWithValue("@miktar", topla);
                com2.Parameters.AddWithValue("@id2", stokID);
                com.ExecuteNonQuery(); 
                com2.ExecuteNonQuery(); 
                con.Close();
                MessageBox.Show("Kayıt, sisteme başarılı bir şekilde eklendi.", "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                com.CommandText = "";

               

            }
            catch (Exception ex)
            {

                MessageBox.Show("Kayıt eklenemedi. Lütfen veri tabanını yada verileri kontrol edin. Hata Ayrıntısı : " + ex, "İşlem Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;

            }

            

        }
        int StokGelenMiktar, stokID;

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

        private void ıconButton4_Click(object sender, EventArgs e)
        {
            try
            {
                marka.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                model.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                plaka.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                seri.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                yakit.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                km.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                vites.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();



            }
            catch (Exception ex)
            {

                MessageBox.Show("Tabloları yenilemeden lütfen atama yapmayınız. Atama yapmadan önce tabloları yenileyiniz. Hata Ayrıntısı : " + ex, "Hata !", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                throw;

            }

        }
    }
}
