using ProGarage.KademeKiralama;
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

namespace ProGarage.KademeStok
{
    public partial class FrmStokList : Form
    {
        string dbDegisken;
        public string gun, ay, yil, gun_basla, gun_bit;
        SqlConnection con = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        SqlCommand com = new SqlCommand();
        DataSet ds = new DataSet();
        DataTable tablo = new DataTable();

        public FrmStokList()
        {
            InitializeComponent();
            VeriTabani INI = new VeriTabani(Application.StartupPath + @"\settings\database.ini");
            dbDegisken = INI.Oku("DATA", "database");
        }

        void griddoldur()
        {
            try
            {
                string baslama_tarih = yil + "-" + ay + "-" + gun_basla;
                string bitis_tarih = yil + "-" + ay + "-" + gun_bit;
                tablo.Clear();
                con = new SqlConnection(dbDegisken);
                con.Open();
                SqlDataAdapter adap = new SqlDataAdapter("select * from stok where stok_tarih between '" + baslama_tarih + "' and '" + bitis_tarih + "'", con);
                adap.Fill(tablo);
                dataGridView1.DataSource = tablo;
                con.Close();
                GridViewOzellestir();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        void GridViewOzellestir()
        {
            dataGridView1.Columns[0].HeaderCell.Value = "ID";
            dataGridView1.Columns[1].HeaderCell.Value = "TOPLAM TUTAR";
            dataGridView1.Columns[2].HeaderCell.Value = "KALAN STOK";
            dataGridView1.Columns[3].HeaderCell.Value = "AÇIKLAMA";
            dataGridView1.Columns[4].HeaderCell.Value = "PARÇA TUTARI";
            dataGridView1.Columns[5].HeaderCell.Value = "DIŞ İŞÇİLİK TUTARI";
            dataGridView1.Columns[6].HeaderCell.Value = "MEKANİK İŞÇİLİK TUTARI";
            dataGridView1.Columns[7].HeaderCell.Value = "DIŞ İŞÇİLİK KÂR";
            dataGridView1.Columns[8].HeaderCell.Value = "SATIŞ KÂR";
            dataGridView1.Columns[9].HeaderCell.Value = "TARIH";
        }

        private void ıconButton1_Click(object sender, EventArgs e)
        {
            griddoldur();

        }

        private void FrmStokList_Load(object sender, EventArgs e)
        {
            griddoldur();
            //TarihGetir();

        }
        void KayıtSil(int numara)
        {
            string sql = "DELETE FROM stok WHERE id=@numara";
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
            KademeStok.FrmStokDuzenle stokDuzen = new KademeStok.FrmStokDuzenle();
            stokDuzen.id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            stokDuzen.stok_gelis = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            stokDuzen.stok_miktar = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            stokDuzen.stok_aciklama = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            stokDuzen.stok_satis = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            stokDuzen.stok_tarih = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            stokDuzen.s_disis = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            stokDuzen.s_mekanik = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            stokDuzen.stok_s_kar = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            stokDuzen.stok_d_kar = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            stokDuzen.Show();
        }

        private void ıconButton6_Click(object sender, EventArgs e)
        {
        }

        void TarihGetir()
        {

        }
    }
}
