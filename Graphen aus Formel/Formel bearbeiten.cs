using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphen_aus_Formel
{
    public partial class Formel_bearbeiten : Form
    {
        public bool OK = false;
        ColorDialog farbe_wahlen = new ColorDialog();
        Form1 Haupt;

        public Formel_bearbeiten(Form1 haupt)
        {
            InitializeComponent();
            Haupt = haupt;
        }

        private void Formel_bearbeiten_Load(object sender, EventArgs e)
        {
            tbx_formel.Text = "sinx";
            tbx_name.Focus();
        }

        private void pbx_farbe_Click(object sender, EventArgs e)
        {
            farbe_wahlen.Color = pbx_farbe.BackColor;

            if (farbe_wahlen.ShowDialog() == DialogResult.OK)
            {
                pbx_farbe.BackColor = farbe_wahlen.Color;
            }
        }

        private void Formel_bearbeiten_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        private void btn_abb_Click(object sender, EventArgs e)
        {
            Hide();
            OK = false;
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (tbx_name.TextLength > 0)
            {
                if (tbx_formel.TextLength > 0)
                {
                    Haupt.gleich_berechnen(tbx_formel.Text, true);

                    if (!Haupt.fehler)
                    {
                        OK = true;
                        Hide();
                    }
                    else
                        tbx_formel.Focus();
                }
                else
                {
                    MessageBox.Show("Keine Formel eingegeben", "Fehler");
                    tbx_formel.Focus();
                }
   
            }
            else
            {
                MessageBox.Show("Keine Name gewählt", "Fehler");
                tbx_name.Focus();
            }
        }
    }
}
