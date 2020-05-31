using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kalkulator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        double hasil=0;
        string operasi = "";
        string sincos = "";
        bool angkaBaru = true;
        bool operasiBerjalan = false;
        bool operasiSelesai = false;

        Hitung ht = new Hitung();

        private void buttonAngka_click(object sender, EventArgs e)
        {
            if (txtMain.Text == "0" || operasiBerjalan == true && angkaBaru == true || operasiSelesai == true)
            {
                txtMain.Clear();
                if (operasiSelesai == true)
                {
                    txtSub.Clear();
                }
            }
            angkaBaru = false; operasiSelesai = false;
            Button btn = (Button)sender;
            txtMain.Text = txtMain.Text + btn.Text;
        }

        private void buttonOperator_click(object sender, EventArgs e)
        {
            operasiSelesai = false;
            if(operasiBerjalan == false)
            {
                Button btn = (Button)sender;
                operasi = btn.Text;
                hasil = Double.Parse(txtMain.Text);
                txtSub.Text = hasil.ToString() + " " + operasi;
                txtMain.Text = "0";
            }
            else
            {
                switch (operasi)
                {
                    case "+":
                        txtMain.Text = Convert.ToString(ht.tambah(hasil, Double.Parse(txtMain.Text)));
                        break;
                    case "−":
                        txtMain.Text = Convert.ToString(ht.kurang(hasil, Double.Parse(txtMain.Text)));
                        break;
                    case "×":
                        txtMain.Text = Convert.ToString(ht.kali(hasil, Double.Parse(txtMain.Text)));
                        break;
                    case "÷":
                        txtMain.Text = Convert.ToString(ht.bagi(hasil, Double.Parse(txtMain.Text)));
                        break;
                    case "^":
                        txtMain.Text = Convert.ToString(ht.pangkat(hasil, Double.Parse(txtMain.Text)));
                        break;
                }
                hasil = Double.Parse(txtMain.Text);
                txtSub.Text = txtMain.Text + " " + operasi;
                txtMain.Text = "0";
                Button btn = (Button)sender;
                operasi = btn.Text;
            }
            operasiBerjalan = true; angkaBaru = true;
        }

        private void buttonHasil_click(object sender, EventArgs e)
        {
            if (operasiSelesai == true) { }
            else
                txtSub.Text = txtSub.Text + " " + txtMain.Text + " =";
            switch (operasi)
            {
                case "+":
                    txtMain.Text = Convert.ToString(ht.tambah(hasil, Double.Parse(txtMain.Text)));
                    break;
                case "−":
                    txtMain.Text = Convert.ToString(ht.kurang(hasil, Double.Parse(txtMain.Text)));
                    break;
                case "×":
                    txtMain.Text = Convert.ToString(ht.kali(hasil, Double.Parse(txtMain.Text)));
                    break;
                case "÷":
                    txtMain.Text = Convert.ToString(ht.bagi(hasil, Double.Parse(txtMain.Text)));
                    break;
                case "^":
                    txtMain.Text = Convert.ToString(ht.pangkat(hasil, Double.Parse(txtMain.Text)));
                    break;
                case "√":
                    sincos = txtMain.Text.Remove(0, 1);
                    hasil = Double.Parse(sincos);
                    txtMain.Text = Convert.ToString(ht.akar(hasil));
                    break;
                case "Sin":
                    sincos = txtMain.Text.Remove(0, 3);
                    hasil = Double.Parse(sincos);
                    txtMain.Text = Convert.ToString(ht.sin(hasil));
                    break;
                case "Cos":
                    sincos = txtMain.Text.Remove(0, 3);
                    hasil = Double.Parse(sincos);
                    txtMain.Text = Convert.ToString(ht.cos(hasil));
                    break;
            }
            operasiBerjalan = false; angkaBaru = true; operasiSelesai = true; hasil = 0;
        }

        private void buttonKoma_click(object sender, EventArgs e)
        {
            if (txtMain.Text.Contains("."))
            {
                txtMain.Text = txtMain.Text;
            }
            else
            {
                txtMain.Text = txtMain.Text + ".";
            }
        }

        private void buttonNegatif_click(object sender, EventArgs e)
        {
            if (txtMain.Text == "0")
            {
                txtMain.Text = "-";
            }
            else if (txtMain.Text == "-")
            {
                txtMain.Text = "0";
            }
            else
            {
                txtMain.Text = Convert.ToString(Double.Parse(txtMain.Text) * (-1));
            }
        }

        private void buttonSincosAkar_click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            operasi = btn.Text;
            if (txtMain.Text == "0")
            {
                txtMain.Text = operasi;
            }
            else
            {
                txtMain.Text = operasi + txtMain.Text;
            }
        }

        private void buttonClear_click(object sender, EventArgs e)
        {
            txtMain.Text = "0"; txtSub.Clear();
            hasil = 0;
            operasiBerjalan = false; angkaBaru = true;
        }

        private void buttonDel_click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtMain.Text))
            {
                int i = txtMain.TextLength;
                txtMain.Text = txtMain.Text.Remove(i - 1, 1);
                if (String.IsNullOrEmpty(txtMain.Text) || operasiSelesai==true)
                {
                    txtMain.Text = "0";
                    if (operasiSelesai == true)
                    {
                        txtSub.Clear();
                    }
                }
            }
        }

    }
}
