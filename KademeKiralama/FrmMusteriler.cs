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
    public partial class FrmMusteriler : Form
    {
        string dbDegisken;
        SqlConnection con = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        SqlCommand com = new SqlCommand();
        DataSet ds = new DataSet();
        public FrmMusteriler()
        {
            InitializeComponent();
            VeriTabani INI = new VeriTabani(Application.StartupPath + @"\settings\database.ini");
            dbDegisken = INI.Oku("DATA", "database");
        }

        void griddoldur()
        {
            con = new SqlConnection(dbDegisken);
            da = new SqlDataAdapter("Select * From musteriler", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "Müşteriler");
            dataGridView1.DataSource = ds.Tables["Müşteriler"];
            con.Close();
        }

        private void FrmMusteriler_Load(object sender, EventArgs e)
        {
            griddoldur();

        }

        private void ıconButton2_Click(object sender, EventArgs e)
        {
            griddoldur();

        }

        private void ıconButton3_Click(object sender, EventArgs e)
        {
            FrmMusteriEkle musEkle = new FrmMusteriEkle();
            musEkle.Show();
        }
        void KayıtSil(int numara)
        {
            string sql = "DELETE FROM musteriler WHERE id=@numara";
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

        private void ıconButton1_Click(object sender, EventArgs e)
        {
            FrmMusteriDuzen cariDuzen = new FrmMusteriDuzen();
            //CariDuzenle.tc = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            cariDuzen.tc = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            cariDuzen.adsyoad = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            cariDuzen.ehliyet = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            cariDuzen.telno = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            cariDuzen.adres = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            cariDuzen.dosya = dataGridView1.CurrentRow.Cells[6].Value.ToString();

            cariDuzen.Show();
        
        }
    }
}
