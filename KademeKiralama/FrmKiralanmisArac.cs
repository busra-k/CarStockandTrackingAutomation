using MetroFramework.Controls;
using ProGarage.FrmAracKiralamaDuzen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProGarage.KademeKiralama
{
    public partial class FrmKiralanmisArac : Form
    {
        string dbDegisken;
        SqlConnection con = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        SqlCommand com = new SqlCommand();
        DataSet ds = new DataSet();
        DataTable tablo = new DataTable();

        public FrmKiralanmisArac()
        {
            InitializeComponent(); 
            VeriTabani INI = new VeriTabani(Application.StartupPath + @"\settings\database.ini");
            dbDegisken = INI.Oku("DATA", "database");
        }
        void griddoldur()
        {
            con = new SqlConnection(dbDegisken);
            da = new SqlDataAdapter("Select * From kiralama", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "Muhasebe");
            dataGridView1.DataSource = ds.Tables["Muhasebe"];
            con.Close();
        }
        void KayıtSil(int numara)
        {
            string sql = "DELETE FROM kiralama WHERE id=@numara";
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
            griddoldur();
        }

        private void FrmKiralanmisArac_Load(object sender, EventArgs e)
        {
            griddoldur();
            comboBox1.SelectedItem = 0;

        }

        private void ıconButton1_Click(object sender, EventArgs e)
        {
            FrmAracKiralamaDuzen.FrmAracKiralamaDuzen aracKiraDuzen = new FrmAracKiralamaDuzen.FrmAracKiralamaDuzen();
            aracKiraDuzen.id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            aracKiraDuzen.isimsoyisimG = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            aracKiraDuzen.tcnoG = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            aracKiraDuzen.telnoG = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            aracKiraDuzen.adresG = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            aracKiraDuzen.markaG = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            aracKiraDuzen.modelG = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            aracKiraDuzen.renkG = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            aracKiraDuzen.kiraG = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            aracKiraDuzen.gunG = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            aracKiraDuzen.tutarG = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            aracKiraDuzen.v_tarihG = dataGridView1.CurrentRow.Cells[11].Value.ToString();
            aracKiraDuzen.a_tarihG = dataGridView1.CurrentRow.Cells[12].Value.ToString();
            aracKiraDuzen.Show();

        }

        private void ıconButton3_Click(object sender, EventArgs e)
        {
           if(textBox1.Text == "" || comboBox1.SelectedItem =="" )
            {
                MessageBox.Show("Lütfen durum ve isim verisini boş bırakmayın !", "Hata !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           else
            {
                tablo.Clear();
                con = new SqlConnection(dbDegisken);
                con.Open();
                SqlDataAdapter adap = new SqlDataAdapter("select * from kiralama where m_isim=@isim and durum=@g_durum", con);
                adap.SelectCommand.Parameters.AddWithValue("@isim", textBox1.Text);
                adap.SelectCommand.Parameters.AddWithValue("@g_durum", comboBox1.SelectedItem.ToString());
                adap.Fill(tablo);
                dataGridView1.DataSource = tablo;
                con.Close();
            }
        }

        private void ıconButton6_Click(object sender, EventArgs e)
        {
            tablo.Clear();
            con = new SqlConnection(dbDegisken);
            con.Open();
            SqlDataAdapter adap = new SqlDataAdapter("select * from kiralama where ta_trh between @t1 and @t2", con);
            adap.SelectCommand.Parameters.AddWithValue("@t1", metroDateTime1.Value.ToShortDateString());
            adap.SelectCommand.Parameters.AddWithValue("@t2", metroDateTime2.Value.ToShortDateString());
            adap.Fill(tablo);
            dataGridView1.DataSource = tablo;
            con.Close();

        }

        private void ıconButton5_Click(object sender, EventArgs e)
        {
            tablo.Clear();
            con = new SqlConnection(dbDegisken);
            con.Open();
            SqlDataAdapter adap = new SqlDataAdapter("select * from kiralama where s_trh between @t1 and @t2", con);
            adap.SelectCommand.Parameters.AddWithValue("@t1", metroDateTime4.Value.ToShortDateString());
            adap.SelectCommand.Parameters.AddWithValue("@t2", metroDateTime3.Value.ToShortDateString());
            adap.Fill(tablo);
            dataGridView1.DataSource = tablo;
            con.Close();
        }
    }
}
