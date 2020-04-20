using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasitHesapMakinesi
{
    public partial class Form1 : Form
    {
        Double sonuc = 0;
        bool optDurum = false;
        string opt = ""; //eski operatör bilgisi
        public Form1()
        {
            InitializeComponent();
            txtSonuc.Text = "0";
        }

        private void raklamOlay(object sender, EventArgs e)
        {
            
            if (txtSonuc.Text == "0" || optDurum)
                txtSonuc.Clear();

            optDurum = false;
            Button btn = (Button)sender;
            txtSonuc.Text += btn.Text;
        }

        private void islemOlay(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string yeniOpt = btn.Text;

            lbSonuc.Text = lbSonuc.Text +" "+ txtSonuc.Text+ " " + yeniOpt;
            //önceki operatör bilgisine ihtiyaç var.
            switch(opt)
            {
                case "+": txtSonuc.Text = (sonuc + Double.Parse(txtSonuc.Text)).ToString(); break;
                case "-": txtSonuc.Text = (sonuc - Double.Parse(txtSonuc.Text)).ToString(); break;
                case "/": txtSonuc.Text = (sonuc / Double.Parse(txtSonuc.Text)).ToString(); break;
                case "*": txtSonuc.Text = (sonuc * Double.Parse(txtSonuc.Text)).ToString(); break;
                default:break;
            }
            sonuc = Double.Parse(txtSonuc.Text);
            optDurum = true;
            opt = yeniOpt;
        }

        private void bCE_Click(object sender, EventArgs e)
        {
            txtSonuc.Text = "0";
        }

        private void bC_Click(object sender, EventArgs e)
        {
            txtSonuc.Text = "0";
            sonuc = 0;
            lbSonuc.Text = "";
            opt = "";
        }

        private void bEsit_Click(object sender, EventArgs e)
        {
            lbSonuc.Text = "";
            optDurum = true;
            switch (opt)
            {
                case "+": txtSonuc.Text = (sonuc + Double.Parse(txtSonuc.Text)).ToString(); break;
                case "-": txtSonuc.Text = (sonuc - Double.Parse(txtSonuc.Text)).ToString(); break;
                case "/": txtSonuc.Text = (sonuc / Double.Parse(txtSonuc.Text)).ToString(); break;
                case "*": txtSonuc.Text = (sonuc * Double.Parse(txtSonuc.Text)).ToString(); break;
                default: break;
            }
            sonuc = Double.Parse(txtSonuc.Text);
            
            txtSonuc.Text = sonuc.ToString();
            sonuc = 0; //atama yaptıktan sonra belleği boşaltıyor.
            opt = "";


        }

        private void bNotkta_Click(object sender, EventArgs e)
        {
             if(txtSonuc.Text== "0")
             {
                 txtSonuc.Text = "0";
             }
             else if(optDurum)
            {
                txtSonuc.Text = "0";
            }

            if (!txtSonuc.Text.Contains(","))
            {
                txtSonuc.Text += ",";
            }

            optDurum = false;

        }
    }
}
