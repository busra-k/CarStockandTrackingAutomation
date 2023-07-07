using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace ProGarage.KademeServis
{
    public partial class FrmAracListe : Form
    {
        string dbDegisken;
        SqlConnection con = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        SqlCommand com = new SqlCommand();
        DataSet ds = new DataSet();

        public FrmAracListe()
        {
            InitializeComponent();
            VeriTabani INI = new VeriTabani(Application.StartupPath + @"\settings\database.ini");
            dbDegisken = INI.Oku("DATA", "database");
        }
        void griddoldur()
        {
            con = new SqlConnection(dbDegisken);
            da = new SqlDataAdapter("Select * From araclar", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "Araçlar");
            dataGridView1.DataSource = ds.Tables["Araçlar"];
            con.Close();
        }

        private void FrmAracListe_Load(object sender, EventArgs e)
        {
            griddoldur();
        }

        private void ıconButton1_Click(object sender, EventArgs e)
        {
            griddoldur();

        }

        private void ıconButton3_Click(object sender, EventArgs e)
        {
            FrmAracEkle aracEkle = new FrmAracEkle();
            aracEkle.ShowDialog();
        }
        void KayıtSil(int numara)
        {
            string sql = "DELETE FROM araclar WHERE id=@numara";
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

        private void ıconButton2_Click(object sender, EventArgs e)
        {
            //seri -> textbox4
            //plaka->textbox3
            //model->textbox2
            //marka - > textbox1
            //renk->textbox5
            //km->textbox6
            //yakit->textbox8
            //vites->textbox9
            //detail->richtextbox
            //price->textbox7
            FrmAracDuzenle aracDuzenle = new FrmAracDuzenle();
            aracDuzenle.seri = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            aracDuzenle.plaka = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            aracDuzenle.model = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            aracDuzenle.marka = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            aracDuzenle.km = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            aracDuzenle.yakit = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            aracDuzenle.vites = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            aracDuzenle.detail = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            aracDuzenle.price = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            aracDuzenle.Show();
        }
    }
}
