using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProGarage
{
    public partial class FrmLobby : Form
    {
        int Move;
        int Mouse_X;
        int Mouse_Y;
        public FrmLobby()
        {
            InitializeComponent();
            VeriTabani INI = new VeriTabani(Application.StartupPath + @"\settings\database.ini");
            dbDegisken = INI.Oku("DATA", "database");
        }
        string dbDegisken;

        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        private void metroTile1_MouseUp(object sender, MouseEventArgs e)
        {
            Move = 0;

        }

        private void metroTile1_MouseMove(object sender, MouseEventArgs e)
        {
            if (Move == 1)
            {
                this.SetDesktopLocation(MousePosition.X - Mouse_X, MousePosition.Y - Mouse_Y);
            }
        }

        private void metroTile1_MouseDown(object sender, MouseEventArgs e)
        {
            Move = 1;
            Mouse_X = e.X;
            Mouse_Y = e.Y;
        }

        private void ıconPictureBox4_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void ıconPictureBox5_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult =  MessageBox.Show("Programdan Çıkmak İstiyormusunuz ?","Çıkış",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                Environment.Exit(0);
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            KademeKiralama.FrmServis frmServis = new KademeKiralama.FrmServis();
            frmServis.Show();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            KademeKiralama.FrmKiralama frmKiralama = new KademeKiralama.FrmKiralama();
            frmKiralama.Show();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            KademeStok.FrmStokAna frmStok = new KademeStok.FrmStokAna();
            frmStok.Show();
        }

        private void ıconButton1_Click(object sender, EventArgs e)
        {
            FrmKullaniciYonetim frmKullanici = new FrmKullaniciYonetim();
            frmKullanici.Show();   
        }

        private void ıconButton1_MouseHover(object sender, EventArgs e)
        {

        }

        private void ıconPictureBox7_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Oturumu sonlandırmak istiyor musunuz ?", "Oturumu Sonlandır", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                FrmGiris logout = new FrmGiris();
                this.Hide();
                logout.Show();
            }
           
        }

        private void ıconPictureBox6_Click(object sender, EventArgs e)
        {
            KademeKiralama.FrmKiralanmisArac kiraliklar = new KademeKiralama.FrmKiralanmisArac();
            kiraliklar.Show();
        }
        public void yaklasanOdeme()
        {
            string durum = "Teslim Alinmadi";
            string sorgu = "SELECT * FROM kiralama WHERE durum=@pass";

            con = new SqlConnection(dbDegisken);
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@pass", durum);
            con.Open();

            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                panel1.Show();
                ıconPictureBox8.Show();
                label1.Show();
                label1.Text = "Ödemesi yapılmamış bakiyeler bulunmakta. Sağ üst köşedeki\r\nçan simgesine tıklayarak tablodan görebilirsiniz.\r\n";
            }
            else
            {
                panel1.Hide();
                ıconPictureBox8.Hide();
                label1.Hide();
            }
        }
        private void FrmLobby_Load(object sender, EventArgs e)
        {
            yaklasanOdeme();
            string guncelTarih = DateTime.Now.ToShortDateString();
            string durum = "Teslim Alinmadi";
            string sorgu = "SELECT * FROM kiralama WHERE s_trh=@user AND durum=@pass";

            con = new SqlConnection(dbDegisken);
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@user", guncelTarih);
            cmd.Parameters.AddWithValue("@pass", durum);
            con.Open();

            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                panel1.Show();
                ıconPictureBox8.Show();
                label1.Show();
            }
            else
            {
                panel1.Hide();
                ıconPictureBox8.Hide();
                label1.Hide();
            }
        }

        private void ıconPictureBox9_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            ıconPictureBox8.Hide();
            label1.Hide();
        }

        private void ıconPictureBox10_Click(object sender, EventArgs e)
        {
            var request = (FtpWebRequest)WebRequest.Create
            ("ftp://5.180.81.164/ftpdizin/projeler/progarage/ProGarageSetup.msi");
            request.Credentials = new NetworkCredential("emersoft.com.tr_cw5h7mgd6n", "$qQ9&65SfqpqysUa");
            request.Method = WebRequestMethods.Ftp.GetFileSize;

            try
            {
                //FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                DialogResult dialogResult = MessageBox.Show("Yeni bir güncelleme paketi bulundu. Şimdi güncellemek ister misiniz ?", "Sistem Bildirimi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.Yes)
                {
                    Updater guncelle = new Updater();
                    this.Hide();
                    guncelle.Show();
                }

            }
            catch (WebException ex)
            {
                FtpWebResponse response = (FtpWebResponse)ex.Response;
                if (response.StatusCode ==
                    FtpStatusCode.ActionNotTakenFileUnavailable)
                {
                    MessageBox.Show("Sürümünüz güncel durumdadır. Yeni güncel bir sürüm bulunamadı.","Sistem Bildirimi",MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
