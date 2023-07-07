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

namespace ProGarage.KademeServis
{
    public partial class FrmAracDuzenle : Form
    {
        public string seri, plaka, marka, model, renk, km, yakit, vites, detail, price;
        string dbDegisken;
        SqlConnection con = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        SqlCommand com = new SqlCommand();
        DataSet ds = new DataSet();
        public FrmAracDuzenle()
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
                com.CommandText = "update araclar set marka = '" + textBox1.Text + "',model = '" + textBox2.Text + "',plaka = '" + textBox3.Text + "',seri = '" + textBox4.Text + "' ,km = '" + textBox6.Text + "' ,vites = '" + textBox9.Text + "' ,yakit = '" + textBox8.Text + "' ,price = '" + textBox7.Text + "' ,detail = '" + richTextBox1.Text + "' where seri = '" + seri + "'; ";
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
        public void VeriYollamaca()
        {
            textBox1.Text = marka;
            textBox2.Text = model;
            textBox3.Text = plaka;
            textBox4.Text = seri;
            textBox6.Text = km;
            textBox7.Text = price;
            textBox8.Text = yakit;
            textBox9.Text = vites;
            richTextBox1.Text = detail;
        }
        private void FrmAracDuzenle_Load(object sender, EventArgs e)
        {
            VeriYollamaca();
        }
    }
}
