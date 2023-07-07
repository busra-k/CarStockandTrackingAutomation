using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProGarage.KademeStok
{
    public partial class FrmStokAna : Form
    {
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currentChildForm;

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wmsg, int wParam, int lParam);

        private struct RgbColors
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(254, 138, 114);
            public static Color color4 = Color.FromArgb(95, 77, 221);
            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(24, 161, 251);

        }
        private void ActiveButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableBtn();

                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(37, 36, 81);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;

                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();

                ıconPictureBox1.IconChar = currentBtn.IconChar;
                ıconPictureBox1.IconColor = color;
            }
        }
        private void DisableBtn()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(31, 30, 68);
                currentBtn.ForeColor = Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.Gainsboro;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;

            }
        }

        private void Reset()
        {
            DisableBtn();
            leftBorderBtn.Visible = false;
            ıconPictureBox1.IconChar = IconChar.Home;
            label1.Text = "Anasayfa";
            ıconPictureBox1.IconColor = Color.MediumPurple;

        }
        public FrmStokAna()
        {
            InitializeComponent();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            panel3.Controls.Add(leftBorderBtn);
        }
        private void OpenChildForm(Form childForm)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            label1.Text = childForm.Text;

        }

        private void ıconButton7_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void ıconButton9_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void ıconButton8_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;

                ıconButton8.IconChar = IconChar.WindowRestore;

            }
            else if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                ıconButton8.IconChar = IconChar.WindowMaximize;
            }
        }

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void ıconButton1_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RgbColors.color1);
            OpenChildForm(new KademeServis.FrmServisAna());
        }

        private void ıconButton2_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RgbColors.color2);
            OpenChildForm(new KademeStok.FrmStokButon());
        }

        private void ıconButton3_Click(object sender, EventArgs e)
        {

            ActiveButton(sender, RgbColors.color3);
            OpenChildForm(new KademeStok.FrmStokEkle());
        }

        private void ıconButton4_Click(object sender, EventArgs e)
        {

            ActiveButton(sender, RgbColors.color4);
            OpenChildForm(new KademeStok.FrmMaliyetTakip());
        }

        private void ıconButton5_Click(object sender, EventArgs e)
        {

            ActiveButton(sender, RgbColors.color5);
            OpenChildForm(new KademeStok.FrmMaliyetEkle());
        }
    }
}
