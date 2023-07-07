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
    public partial class FrmMuhasebe : Form
    {
        string dbDegisken;
        SqlConnection con = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        SqlCommand com = new SqlCommand();
        DataSet ds = new DataSet();
        public FrmMuhasebe()
        {
            InitializeComponent();
            VeriTabani INI = new VeriTabani(Application.StartupPath + @"\settings\database.ini");
            dbDegisken = INI.Oku("DATA", "database");
        }
        void griddoldur()
        {
            con = new SqlConnection(dbDegisken);
            da = new SqlDataAdapter("Select * From muhasebe", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "Muhasebe");
            dataGridView1.DataSource = ds.Tables["Muhasebe"];
            con.Close();
        }

        private void ıconButton2_Click(object sender, EventArgs e)
        {
            griddoldur();
        }

        private void FrmMuhasebe_Load(object sender, EventArgs e)
        {
            griddoldur();
        }

        private void ıconButton3_Click(object sender, EventArgs e)
        {
            FrmMuhasebeEkran muhasebe = new FrmMuhasebeEkran();
            muhasebe.Show();
        }
        void KayıtSil(int numara)
        {
            string sql = "DELETE FROM muhasebe WHERE id=@numara";
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
            FrmMuhasebeDuzen muhduzen = new FrmMuhasebeDuzen();
            //CariDuzenle.tc = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            muhduzen.adsyoad2 = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            muhduzen.tc2 = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            muhduzen.telno2 = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            muhduzen.adres2 = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            muhduzen.hizmet = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            muhduzen.hizmet_miktar = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            muhduzen.hizmet_tarih = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            muhduzen.hizmet_tutar = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            muhduzen.hizmet_vergi = dataGridView1.CurrentRow.Cells[9].Value.ToString();

            muhduzen.Show();
        }
    }
}
