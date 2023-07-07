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

namespace ProGarage
{
    public partial class FrmKullaniciYonetim : Form
    {
        string dbDegisken;
        SqlConnection con = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        SqlCommand com = new SqlCommand();
        DataSet ds = new DataSet();
        public FrmKullaniciYonetim()
        {
            InitializeComponent(); 
            VeriTabani INI = new VeriTabani(Application.StartupPath + @"\settings\database.ini");
            dbDegisken = INI.Oku("DATA", "database");
        }
        void griddoldur()
        {
            con = new SqlConnection(dbDegisken);
            da = new SqlDataAdapter("Select * From giris", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "Yönetim");
            dataGridView1.DataSource = ds.Tables["Yönetim"];
            con.Close();
        }

        private void FrmKullaniciYonetim_Load(object sender, EventArgs e)
        {
            griddoldur();
        }

        private void ıconButton1_Click(object sender, EventArgs e)
        {
            griddoldur();
        }
        void KayıtSil(int numara)
        {
            string sql = "DELETE FROM giris WHERE id=@numara";
            com = new SqlCommand(sql, con);
            com.Parameters.AddWithValue("@numara", numara);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
        private void ıconButton4_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow drow in dataGridView1.SelectedRows)  //Seçili Satırları Silme
            {
                int numara = Convert.ToInt32(drow.Cells[0].Value);
                KayıtSil(numara);
            }
            griddoldur();
        }

        private void ıconButton3_Click(object sender, EventArgs e)
        {
            try
            {
                Random rnd = new Random();
                int sayi = rnd.Next(999999);
                //id | seri | plaka | model | marka | renk | km | yakit | vites | detail | price
                con = new SqlConnection(dbDegisken);
                con.Open();
                com.Connection = con;
                com.CommandText = "insert into giris(id,username,password) values ('" + sayi + "','" + textBox1.Text + "','" + textBox2.Text + "')";
                com.ExecuteNonQuery(); //www.yazilimkodlama.com
                con.Close();
                MessageBox.Show("Kayıt, sisteme başarılı bir şekilde eklendi.", "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                griddoldur();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Kayıt eklenemedi. Lütfen veri tabanını yada verileri kontrol edin. Hata Ayrıntısı : " + ex, "İşlem Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }
    }
}
