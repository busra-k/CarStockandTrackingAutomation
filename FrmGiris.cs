using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ProGarage
{
    public partial class FrmGiris : Form
    {
        string dbDegisken;

        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public FrmGiris()
        {
            InitializeComponent();
            VeriTabani INI = new VeriTabani(Application.StartupPath + @"\settings\database.ini");
            dbDegisken = INI.Oku("DATA", "database");
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            string sorgu = "SELECT * FROM giris where username=@user AND password=@pass";

            con = new SqlConnection(dbDegisken);
            con.Open();

            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@user", txtUser.Text);
            cmd.Parameters.AddWithValue("@pass", txtPass.Text);

            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                FrmLobby lobby = new FrmLobby();
                lobby.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı adını ve şifrenizi kontrol ediniz.","Hata !", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            string username, password;


        }
    }
}
