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
    public partial class FrmAracServisList : Form
    {
        string dbDegisken;
        SqlConnection con = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        SqlCommand com = new SqlCommand();
        DataSet ds = new DataSet();
        public FrmAracServisList()
        {
            InitializeComponent();
            VeriTabani INI = new VeriTabani(Application.StartupPath + @"\settings\database.ini");
            dbDegisken = INI.Oku("DATA", "database");
        }
        void griddoldur()
        {
            con = new SqlConnection(dbDegisken);
            da = new SqlDataAdapter("Select * From servis", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "Servis");
            dataGridView1.DataSource = ds.Tables["Servis"];
            con.Close();
        }

        private void FrmAracServisList_Load(object sender, EventArgs e)
        {
            griddoldur();

        }

        private void ıconButton2_Click(object sender, EventArgs e)
        {
            griddoldur();

        }

        private void ıconButton1_Click(object sender, EventArgs e)
        {

        }
        void KayıtSil(int numara)
        {
            string sql = "DELETE FROM servis WHERE id=@numara";
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

        private void ıconButton1_Click_1(object sender, EventArgs e)
        {
           FrmAracServisDuzenle aracServisDuzen = new FrmAracServisDuzenle();
            aracServisDuzen.id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            aracServisDuzen.markaG = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            aracServisDuzen.modelG = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            aracServisDuzen.plakaG = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            aracServisDuzen.seriG = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            aracServisDuzen.kmG = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            aracServisDuzen.vitesG = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            aracServisDuzen.yakitG = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            aracServisDuzen.tutarG = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            aracServisDuzen.notG = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            aracServisDuzen.tcG = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            aracServisDuzen.isimsoyisimG = dataGridView1.CurrentRow.Cells[11].Value.ToString();
            aracServisDuzen.telnoG = dataGridView1.CurrentRow.Cells[12].Value.ToString();
            aracServisDuzen.adresG = dataGridView1.CurrentRow.Cells[13].Value.ToString();
            aracServisDuzen.islemG = dataGridView1.CurrentRow.Cells[14].Value.ToString();
            aracServisDuzen.arac_tur = dataGridView1.CurrentRow.Cells[15].Value.ToString();
            aracServisDuzen.parca_tur = dataGridView1.CurrentRow.Cells[16].Value.ToString();
            aracServisDuzen.parca_tutar = dataGridView1.CurrentRow.Cells[17].Value.ToString();
            aracServisDuzen.parca_gelis = dataGridView1.CurrentRow.Cells[18].Value.ToString();
            aracServisDuzen.parca = dataGridView1.CurrentRow.Cells[19].Value.ToString();

            aracServisDuzen.Show();

        }
    }
}
