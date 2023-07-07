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

namespace ProGarage.KademeStok
{
    public partial class FrmMaliyetTakip : Form
    {
        string dbDegisken;
        SqlConnection con = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        SqlCommand com = new SqlCommand();
        DataSet ds = new DataSet();
        public FrmMaliyetTakip()
        {
            InitializeComponent(); 
            VeriTabani INI = new VeriTabani(Application.StartupPath + @"\settings\database.ini");
            dbDegisken = INI.Oku("DATA", "database");
        }
        void griddoldur()
        {
            con = new SqlConnection(dbDegisken);
            da = new SqlDataAdapter("Select * From gider", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "Maliyet");
            dataGridView1.DataSource = ds.Tables["Maliyet"];
            con.Close();
        }
        private void FrmMaliyetTakip_Load(object sender, EventArgs e)
        {
            griddoldur();
        }
    }
}
