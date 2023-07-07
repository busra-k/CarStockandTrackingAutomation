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
using System.Windows.Controls;
using System.Windows.Forms;

namespace ProGarage.KademeServis
{
    public partial class FrmAracEkle : Form
    {
        string dbDegisken;
        SqlConnection con = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        SqlCommand com = new SqlCommand();
        DataSet ds = new DataSet();
        public FrmAracEkle()
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
                com.CommandText = "insert into araclar(id,seri,plaka,model,marka,km,yakit,vites,detail,price) values ('" + sayi + "','" + seri.Text + "','" + plaka.Text + "','" + model.Text + "','" + marka.Text + "','" + km.Text + "','" + yakit.Text + "','" + vites.Text + "','" + not.Text + "','" + ucret.Text + "')";
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
    }
}
