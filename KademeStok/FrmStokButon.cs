using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProGarage.KademeStok
{
    public partial class FrmStokButon : Form
    {
        public FrmStokButon()
        {
            InitializeComponent();
        }
        string gun, ay, yil, gun_basla, gun_bit;
       
        private void ıconButton3_Click(object sender, EventArgs e)
        {
            gun_basla = "1";
            gun_bit = "31";
            yil = comboBox1.SelectedItem.ToString();
            ay = "3";
            KademeStok.FrmStokList stokList = new KademeStok.FrmStokList();
            stokList.gun_basla = gun_basla;
            stokList.gun_bit = gun_bit;
            stokList.yil = yil;
            stokList.ay = ay;
            stokList.Show();

        }

        private void ıconButton4_Click(object sender, EventArgs e)
        {
            gun_basla = "1";
            gun_bit = "30";
            yil = comboBox1.SelectedItem.ToString();
            ay = "4";
            KademeStok.FrmStokList stokList = new KademeStok.FrmStokList();
            stokList.gun_basla = gun_basla;
            stokList.gun_bit = gun_bit;
            stokList.yil = yil;
            stokList.ay = ay;
            stokList.Show();
        }

        private void ıconButton5_Click(object sender, EventArgs e)
        {
            gun_basla = "1";
            gun_bit = "31";
            yil = comboBox1.SelectedItem.ToString();
            ay = "5";
            KademeStok.FrmStokList stokList = new KademeStok.FrmStokList();
            stokList.gun_basla = gun_basla;
            stokList.gun_bit = gun_bit;
            stokList.yil = yil;
            stokList.ay = ay;
            stokList.Show();
        }

        private void ıconButton6_Click(object sender, EventArgs e)
        {
            gun_basla = "1";
            gun_bit = "30";
            yil = comboBox1.SelectedItem.ToString();
            ay = "6";
            KademeStok.FrmStokList stokList = new KademeStok.FrmStokList();
            stokList.gun_basla = gun_basla;
            stokList.gun_bit = gun_bit;
            stokList.yil = yil;
            stokList.ay = ay;
            stokList.Show();
        }

        private void ıconButton7_Click(object sender, EventArgs e)
        {
            gun_basla = "1";
            gun_bit = "31";
            yil = comboBox1.SelectedItem.ToString();
            ay = "7";
            KademeStok.FrmStokList stokList = new KademeStok.FrmStokList();
            stokList.gun_basla = gun_basla;
            stokList.gun_bit = gun_bit;
            stokList.yil = yil;
            stokList.ay = ay;
            stokList.Show();
        }

        private void ıconButton8_Click(object sender, EventArgs e)
        {
            gun_basla = "1";
            gun_bit = "31";
            yil = comboBox1.SelectedItem.ToString();
            ay = "8";
            KademeStok.FrmStokList stokList = new KademeStok.FrmStokList();
            stokList.gun_basla = gun_basla;
            stokList.gun_bit = gun_bit;
            stokList.yil = yil;
            stokList.ay = ay;
            stokList.Show();
        }

        private void ıconButton9_Click(object sender, EventArgs e)
        {
            gun_basla = "1";
            gun_bit = "30";
            yil = comboBox1.SelectedItem.ToString();
            ay = "9";
            KademeStok.FrmStokList stokList = new KademeStok.FrmStokList();
            stokList.gun_basla = gun_basla;
            stokList.gun_bit = gun_bit;
            stokList.yil = yil;
            stokList.ay = ay;
            stokList.Show();
        }

        private void ıconButton10_Click(object sender, EventArgs e)
        {
            gun_basla = "1";
            gun_bit = "31";
            yil = comboBox1.SelectedItem.ToString();
            ay = "10";
            KademeStok.FrmStokList stokList = new KademeStok.FrmStokList();
            stokList.gun_basla = gun_basla;
            stokList.gun_bit = gun_bit;
            stokList.yil = yil;
            stokList.ay = ay;
            stokList.Show();
        }

        private void FrmStokButon_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedItem = DateTime.Now.ToString("yyyy");
        }

        private void ıconButton11_Click(object sender, EventArgs e)
        {
            gun_basla = "1";
            gun_bit = "30";
            yil = comboBox1.SelectedItem.ToString();
            ay = "11";
            KademeStok.FrmStokList stokList = new KademeStok.FrmStokList();
            stokList.gun_basla = gun_basla;
            stokList.gun_bit = gun_bit;
            stokList.yil = yil;
            stokList.ay = ay;
            stokList.Show();
        }

        private void ıconButton12_Click(object sender, EventArgs e)
        {
            gun_basla = "1";
            gun_bit = "31";
            yil = comboBox1.SelectedItem.ToString();
            ay = "12";
            KademeStok.FrmStokList stokList = new KademeStok.FrmStokList();
            stokList.gun_basla = gun_basla;
            stokList.gun_bit = gun_bit;
            stokList.yil = yil;
            stokList.ay = ay;
            stokList.Show();
        }

        private void ıconButton1_Click(object sender, EventArgs e)
        {
            gun_basla = "1";
            gun_bit = "28";
            yil = comboBox1.SelectedItem.ToString();
            ay = "2";
            KademeStok.FrmStokList stokList = new KademeStok.FrmStokList();
            stokList.gun_basla = gun_basla;
            stokList.gun_bit = gun_bit;
            stokList.yil = yil;
            stokList.ay = ay;
            stokList.Show();
        }

        private void ıconButton2_Click(object sender, EventArgs e)
        {
            gun_basla = "1";
            gun_bit = "31";
            yil = comboBox1.SelectedItem.ToString();
            ay = "1";
            KademeStok.FrmStokList stokList = new KademeStok.FrmStokList();
            stokList.gun_basla = gun_basla;
            stokList.gun_bit = gun_bit;
            stokList.yil = yil;
            stokList.ay = ay;
            stokList.Show();
        }
    }
}
