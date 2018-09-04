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
    public partial class Form1 : Form
    {
        string anzeige = "";
        double bug;

        Formel_bearbeiten Editor;

        BackgroundWorker[,] worker;
        BackgroundWorker warter;

        Point[,] achsen_punkte = new Point[2, 2];
        Point[, ,] einteilungen_punkte = new Point[2, 2, 0];
        Point[][][] graphen = new Point[0][][];
        Point[][][] graphen2 = new Point[0][][];
        Rectangle[,] einteil_text = new Rectangle[2, 0];

        Pen stift_koor = new Pen(Color.Black, 1);
        Font schrift = new Font("Microsoft Sans Serif", 8);
        Brush farbe = new SolidBrush(Color.Black);

        Pen[] stift_graph = new Pen[0];

        string[,] text_einteilung;
        bool scroll_an_en = false, load = true, gelesen = false, noch_nicht = true;
        int oben = 15, rechts = 28, links = 28, formel_pbx;
        int[] davor_ein = new int[2] { 0, 0 }, anzahl_einteilung = new int[2], text_anzahl = new int[2], ba_koor = new int[2];
        int[] koor = new int[2], koor2, anzeigen_einteilungen = new int[2], ur_wo = new int[2], scb_val = new int[3];
        int[,] lenght, verschiebung = new int[2, 2] { { 15, -26 }, { -15, 15 } };
        double[] mitte_wert = new double[2], spt = new double[2];
        double[,] werte_scb = new double[3, 3], endwerte = new double[2, 2], ba_end = new double[2, 2], endwerte2 = new double[2, 2], endwerte3 = new double[2, 2];

        char[] gleich_zeichen, was_schritte, backup_was_schritte, zeichen = new char[4] { 't', 'm', 'a', 'e' };
        string gleichung = "";
        string[] schritte, backup_schritte;
        string[][] schritte_tabelle = new string[0][], schritte_tabelle2;
        int klammern = 0, w_work, w_work2, lastselcted, hinzu;
        int[] rechenzeichen, wo_rechenzeichen = new int[0];
        int[,] wo_zahlenwerte = new int[2, 0];
        int[][] rechenzeichen_tabelle = new int[0][], rechenzeichen_tabelle2, wo_rechenzeichen_tabelle = new int[0][], wo_rechenzeichen_tabelle2;
        int[][,] wo_zahlenwerte_tabelle = new int[0][,], wo_zahlenwerte_tabelle2;
        int[][][] var_wo = new int[0][][], var_wo2;
        bool resize = false, bearbeiten = false, kopieren = false, focoused = false;
        public bool fehler = false;
        bool[] vorhanden_wert, backup_vorhanden_wert, geb_be = new bool[0], geb_be2, gra_be = new bool[0], gra_be2;
        double genau = 100;
        double[] zahlenwerte, backup_zahlenwerte, zahlenwerte_fertig, var_w = new double[3];
        double[][] zahlenwerte_tabelle = new double[0][], zahlenwerte_tabelle2, ergebnisse = new double[0][], ergebnisse2;

        public Form1()
        {
            InitializeComponent();
            Editor = new Formel_bearbeiten(this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            warter = new BackgroundWorker();
            warter.WorkerSupportsCancellation = true;
            warter.WorkerReportsProgress = true;
            warter.DoWork += new DoWorkEventHandler(warter_DoWork);
            warter.RunWorkerCompleted += new RunWorkerCompletedEventHandler(warter_RunWorkerCompleted);
            warter.ProgressChanged += new ProgressChangedEventHandler(warter_ProgressChanged);

            backgroundworker_erstellen();

            //tbx_formel.Text = "2x+|x|";       //-x^3+6x^2+3x-8          3/2+6/pi*(sinx+sin(3x)/3+sin(5x)/5+sin(7x)/7+sin(9x)/9+sin(11x)/11+sin(13x)/13+sin(15x)/15+sin(17x)/17+sin(19x)/19+sin(21x)/21+sin(23x)/23)
            tbx_x_achse.Text = "1";             // 6+3j+2x-8k+xx-lxjk
            tbx_y_achse.Text = "2";

            scb_wert_changen();

            formel_pbx = dgv.Width - dgv.Columns[2].Width;

            btns_Enabled();
            achsen_anpassen();

            load = false;
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            sct_graph_angab.Panel1.Focus();
            dgv.Columns[2].Width = dgv.Width - formel_pbx;

            if (noch_nicht)
            {
                gelesen = false;
                achsen_anpassen();
            }

            if (!resize)
            {
                focoused = true;
                rechnen_lassen();
            }

            noch_nicht = true;
        }

        private void Form1_ResizeBegin(object sender, EventArgs e)
        {
            resize = true;
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            resize = false;
            rechnen_lassen();
        }

        private void tbx_Steuerung_Leave(object sender, EventArgs e)
        {
            gelesen = false;
            achsen_anpassen();
        }

        private void Sterung_CheckedChanged(object sender, EventArgs e)
        {
            gelesen = false;
            einteilung_steuern();
            achsen_anpassen();
        }

        private void einteilung_steuern()
        {
            tbx_verhaltnis.Enabled = ckb_x_y.Checked;

            ckb_b_y_von.Enabled = !ckb_b_y_bis.Checked || !ckb_x_y.Checked;
            ckb_b_y_bis.Enabled = !ckb_b_y_von.Checked || !ckb_x_y.Checked;

            ckb_e_x_manuell.Enabled = Convert.ToInt32(ckb_b_x_von.Checked) + Convert.ToInt32(ckb_b_x_bis.Checked) + Convert.ToInt32(ckb_n_x_manuell.Checked && ckb_n_x_manuell.Enabled) > 1;
            ckb_e_y_manuell.Enabled = !ckb_x_y.Checked;
            tbx_x_achse.Enabled = Convert.ToInt32(ckb_b_x_von.Checked) + Convert.ToInt32(ckb_b_x_bis.Checked) + Convert.ToInt32(ckb_n_x_manuell.Checked && ckb_n_x_manuell.Enabled) < 2 || (ckb_e_x_manuell.Enabled && ckb_e_x_manuell.Checked);
            tbx_y_achse.Enabled = ckb_e_y_manuell.Checked && ckb_e_y_manuell.Enabled && !ckb_x_y.Checked;

            ckb_n_x_manuell.Enabled = !ckb_b_x_von.Checked || !ckb_b_x_bis.Checked;
            ckb_n_y_manuell.Enabled = (!ckb_b_y_von.Checked || !ckb_b_y_bis.Checked) && (!ckb_x_y.Checked || !ckb_b_y_von.Checked || ckb_b_y_bis.Checked);
            tbx_null_x.Enabled = ckb_n_x_manuell.Checked && ckb_n_x_manuell.Enabled;
            tbx_null_y.Enabled = ckb_n_y_manuell.Checked && ckb_n_y_manuell.Enabled;

            tbx_x_von.Enabled = ckb_b_x_von.Checked;
            tbx_x_bis.Enabled = ckb_b_x_bis.Checked;
            tbx_y_von.Enabled = ckb_b_y_von.Checked && ckb_b_y_von.Enabled;
            tbx_y_bis.Enabled = ckb_b_y_bis.Checked && ckb_b_y_bis.Enabled;

            if (!load)
                achsen_anpassen();
        }

        private void achsen_anpassen()
        {
            bool ch_x = false, ch_y = false;
            bearbeiten = true;

            while (kopieren)
            { }

            if (!gelesen)
            {
                gelesen = false;


                koor[0] = sct_graph_angab.Panel1.Width - links - rechts + 1 - (sct_graph_angab.Panel1.Width - links - rechts) % 2;
                koor[1] = sct_graph_angab.Panel1.Height - 2 * oben + 1 - (sct_graph_angab.Panel1.Height - 2 * oben) % 2;

                spt[0] = zahl_lesen(tbx_x_achse.Text, 1, 0) * Convert.ToInt32(tbx_x_achse.Enabled);
                spt[1] = zahl_lesen(tbx_y_achse.Text, 1, 0) * Convert.ToInt32(tbx_y_achse.Enabled) + Convert.ToInt32(!ckb_x_y.Checked && !tbx_y_achse.Enabled && !(ckb_b_y_von.Checked && ckb_b_y_bis.Checked));

                endwerte[0, 0] = zahl_lesen(tbx_x_von.Text, -10, Double.NaN) * Convert.ToInt32(tbx_x_von.Enabled);
                endwerte[0, 1] = zahl_lesen(tbx_x_bis.Text, 10, Double.NaN) * Convert.ToInt32(tbx_x_bis.Enabled);
                endwerte[1, 0] = zahl_lesen(tbx_y_von.Text, -10, Double.NaN) * Convert.ToInt32(tbx_y_von.Enabled);
                endwerte[1, 1] = zahl_lesen(tbx_y_bis.Text, 10, Double.NaN) * Convert.ToInt32(tbx_y_bis.Enabled);

                mitte_wert[0] = zahl_lesen(tbx_null_x.Text, 0, Double.NaN) * Convert.ToInt32(ckb_n_x_manuell.Checked && ckb_n_x_manuell.Enabled);
                mitte_wert[1] = zahl_lesen(tbx_null_y.Text, 0, Double.NaN) * Convert.ToInt32(ckb_n_y_manuell.Checked && ckb_n_y_manuell.Enabled);

                if (tbx_x_von.Enabled && tbx_null_x.Enabled)
                    endwerte[0, 1] = mitte_wert[0] * 2 - endwerte[0, 0];

                if (tbx_x_von.Enabled && tbx_null_x.Enabled)
                    endwerte[0, 0] = mitte_wert[0] * 2 - endwerte[0, 1];

                if (tbx_y_von.Enabled && tbx_null_y.Enabled)
                    endwerte[1, 1] = mitte_wert[1] * 2 - endwerte[1, 0];

                if (tbx_y_bis.Enabled && tbx_null_y.Enabled)
                    endwerte[1, 0] = mitte_wert[1] * 2 - endwerte[1, 1];
            }

            for (int i = 0, j = 12; i < 2; i++)
            {
                if ((i == 0 && tbx_x_bis.Enabled && tbx_x_von.Enabled && endwerte[0, 0] == endwerte[0, 1]))
                    endwerte[0, 1] += 10;

                if (i == 0 && tbx_x_achse.Enabled && ckb_b_x_von.Checked && ckb_b_x_bis.Checked)
                {
                    spt[0] = zahl_lesen(tbx_x_achse.Text, 1, 0);

                    if (dazwischen(endwerte[0, 0], endwerte[0, 1], endwerte[0, 0] - endwerte[0, 0] % spt[0]) && dazwischen(endwerte[0, 0], endwerte[0, 1], endwerte[0, 1] - endwerte[0, 1] % spt[0]))
                        anzahl_einteilung[0] = Convert.ToInt32(Math.Abs((endwerte[0, 0] - endwerte[0, 0] % spt[0]) - (endwerte[0, 1] - endwerte[0, 1] % spt[0])) / spt[0]) + 1;
                    else
                        anzahl_einteilung[0] = Convert.ToInt32(Math.Abs((endwerte[0, 0] - endwerte[0, 0] % spt[0]) - (endwerte[0, 1] - endwerte[0, 1] % spt[0])) / spt[0]);

                    i++;
                }

                if (i == 1 && tbx_y_bis.Enabled && tbx_y_von.Enabled && endwerte[1, 0] == endwerte[1, 1])
                    endwerte[1, 1] += 10;

                if (i == 1 && ckb_x_y.Checked)
                    break;

                if (i == 1 && ckb_e_y_manuell.Checked && ckb_b_y_von.Checked && ckb_b_y_bis.Checked)
                {
                    spt[1] = zahl_lesen(tbx_y_achse.Text, 1, 0);

                    if (dazwischen(endwerte[1, 0], endwerte[1, 1], endwerte[1, 0] - endwerte[1, 0] % spt[1]) && dazwischen(endwerte[1, 0], endwerte[1, 1], endwerte[1, 1] - endwerte[1, 1] % spt[1]))
                        anzahl_einteilung[1] = Convert.ToInt32(Math.Abs((endwerte[1, 0] - endwerte[1, 0] % spt[1]) - (endwerte[1, 1] - endwerte[1, 1] % spt[1])) / spt[1]) + 1;
                    else
                        anzahl_einteilung[1] = Convert.ToInt32(Math.Abs((endwerte[1, 0] - endwerte[1, 0] % spt[1]) - (endwerte[1, 1] - endwerte[1, 1] % spt[1])) / spt[1]);

                    break;
                }

                if (koor[i] / (j + 1) >= 30)
                {
                    anzahl_einteilung[i] = koor[i] / 30 + 1 + (koor[i] / 30) % 2 * Convert.ToInt32((i == 0 && tbx_null_x.Enabled) || (i == 1 && tbx_null_y.Enabled));
                }
                else if (koor[i] / (j + 1) < 10)
                {
                    anzahl_einteilung[i] = koor[i] / 10 - 1 - (koor[i] / 10) % 2 * Convert.ToInt32((i == 0 && tbx_null_x.Enabled) || (i == 1 && tbx_null_y.Enabled));
                }
                else
                {
                    anzahl_einteilung[i] = j + (-1 + 2 * Convert.ToInt32(koor[i] / (j + 1) >= 10)) * Convert.ToInt32((i == 0 && tbx_null_x.Enabled) || (i == 1 && tbx_null_y.Enabled));
                }
            }

            if (!tbx_x_von.Enabled && tbx_x_bis.Enabled)
                endwerte[0, 0] = endwerte[0, 1] - spt[0] * (anzahl_einteilung[0] - anzahl_einteilung[0] % 2);
            else if (!tbx_x_von.Enabled && !(ckb_b_x_bis.Checked && tbx_null_x.Enabled))
                endwerte[0, 0] = mitte_wert[0] - spt[0] * (anzahl_einteilung[0] - anzahl_einteilung[0] % 2) / 2.0;

            if (!tbx_x_bis.Enabled && tbx_x_von.Enabled)
                endwerte[0, 1] = endwerte[0, 0] + spt[0] * (anzahl_einteilung[0] - anzahl_einteilung[0] % 2);
            else if (!tbx_x_bis.Enabled && !(ckb_b_x_von.Checked && tbx_null_x.Enabled))
                endwerte[0, 1] = mitte_wert[0] + spt[0] * (anzahl_einteilung[0] - anzahl_einteilung[0] % 2) / 2.0;

            if (!tbx_y_von.Enabled && tbx_y_bis.Enabled)
                endwerte[1, 0] = endwerte[1, 1] - spt[1] * (anzahl_einteilung[1] - anzahl_einteilung[1] % 2);
            else if (!tbx_y_von.Enabled && !(ckb_b_y_bis.Checked && tbx_null_y.Enabled) && !ckb_x_y.Checked && !gelesen)
                endwerte[1, 0] = mitte_wert[1] - spt[1] * (anzahl_einteilung[1] - anzahl_einteilung[1] % 2) / 2.0;

            if (!tbx_y_von.Enabled && tbx_y_bis.Enabled)
                endwerte[1, 1] = endwerte[1, 0] - spt[1] * (anzahl_einteilung[1] - anzahl_einteilung[1] % 2);
            else if (!tbx_y_bis.Enabled && !(ckb_b_y_von.Checked && tbx_null_y.Enabled) && !ckb_x_y.Checked && !gelesen)
                endwerte[1, 1] = mitte_wert[1] + spt[1] * (anzahl_einteilung[1] - anzahl_einteilung[1] % 2) / 2.0;

            if (!ckb_n_x_manuell.Checked || !ckb_n_x_manuell.Enabled)
                mitte_wert[0] = (endwerte[0, 1] + endwerte[0, 0]) / 2.0;

            if (!ckb_n_y_manuell.Checked || !ckb_n_y_manuell.Enabled && !ckb_x_y.Checked)
                mitte_wert[1] = (endwerte[1, 1] + endwerte[1, 0]) / 2.0;

            if (!tbx_x_achse.Enabled)
                spt[0] = (endwerte[0, 1] - endwerte[0, 0]) / Convert.ToDouble(anzahl_einteilung[0]);

            if ((!tbx_y_achse.Enabled && ckb_b_y_von.Checked && ckb_b_y_bis.Checked) || gelesen)
                spt[1] = (endwerte[1, 1] - endwerte[1, 0]) / Convert.ToDouble(anzahl_einteilung[1]);

            if (ckb_x_y.Checked)
            {
                spt[1] = spt[0] * zahl_lesen(tbx_verhaltnis.Text, 1, Double.NaN);

                if (!tbx_y_von.Enabled && !tbx_y_bis.Enabled)
                {
                    endwerte[1, 0] = mitte_wert[1] - (endwerte[0, 1] - endwerte[0, 0]) / 2.0 / Convert.ToDouble(koor[0]) * Convert.ToDouble(koor[1]) * spt[1] / spt[0];
                    endwerte[1, 1] = mitte_wert[1] + (endwerte[0, 1] - endwerte[0, 0]) / 2.0 / Convert.ToDouble(koor[0]) * Convert.ToDouble(koor[1]) * spt[1] / spt[0];
                }
                else if (!tbx_y_von.Enabled && !tbx_null_y.Enabled)
                {
                    endwerte[1, 0] = endwerte[1, 1] - (endwerte[0, 1] - endwerte[0, 0]) / Convert.ToDouble(koor[0]) * Convert.ToDouble(koor[1]) * spt[1] / spt[0];
                    mitte_wert[1] = endwerte[1, 1] - (endwerte[0, 1] - endwerte[0, 0]) / 2.0 / Convert.ToDouble(koor[0]) * Convert.ToDouble(koor[1]);
                }
                else if (!tbx_y_bis.Enabled && !tbx_null_y.Enabled)
                {
                    endwerte[1, 1] = endwerte[1, 0] + (endwerte[0, 1] - endwerte[0, 0]) / Convert.ToDouble(koor[0]) * Convert.ToDouble(koor[1]);
                    mitte_wert[1] = endwerte[1, 0] + (endwerte[0, 1] - endwerte[0, 0]) / 2.0 / Convert.ToDouble(koor[0]) * Convert.ToDouble(koor[1]);
                }

                anzahl_einteilung[1] = Convert.ToInt32((endwerte[1, 1] - endwerte[1, 0]) * spt[1]);
            }

            for (int i = 0; i < 2; i++)
            {
                if (dazwischen(endwerte[i, 0], endwerte[i, 1], endwerte[i, 0] - endwerte[i, 0] % spt[i]) && dazwischen(endwerte[i, 0], endwerte[i, 1], endwerte[i, 1] - endwerte[i, 1] % spt[i]))
                    anzahl_einteilung[i] = Convert.ToInt32(Math.Abs(((endwerte[i, 0] - endwerte[i, 0] % spt[i]) - (endwerte[i, 1] - endwerte[i, 1] % spt[i])) / spt[i])) + 1;
                else
                    anzahl_einteilung[i] = Convert.ToInt32(Math.Abs(((endwerte[i, 0] - endwerte[i, 0] % spt[i]) - (endwerte[i, 1] - endwerte[i, 1] % spt[i])) / spt[i]));
            }

            int[] vari = new int[2]; ur_wo[0] = ur_wo[1] = -2;

            for (int i = 0; i < vari.Length; i++)
            {
                if (dazwischen(endwerte[i, 0], endwerte[i, 1], 0))
                {
                    ur_wo[i] = -1;
                    vari[i] = Convert.ToInt32(koor[i] / 2 + mitte_wert[i] * koor[i] / (endwerte[i, 0] - endwerte[i, 1]));
                }
                else if (dazwischen(endwerte[i, 0], Math.Sign(endwerte[i, 0] - endwerte[i, 1]) * Double.MaxValue, 0))
                    vari[i] = 0;
                else
                    vari[i] = koor[i];
            }

            achsen_punkte[0, 0] = new Point(links, koor[1] - vari[1] + oben);
            achsen_punkte[0, 1] = new Point(koor[0] + links, koor[1] - vari[1] + oben);

            achsen_punkte[1, 0] = new Point(vari[0] + links, oben);
            achsen_punkte[1, 1] = new Point(vari[0] + links, koor[1] + oben);

            einteilungen_machen();
            bearbeiten = false;

            if (!(endwerte[0, 0] == ba_end[0, 0] && endwerte[0, 1] == ba_end[0, 1] && koor[0] == ba_koor[0]))
            {
                ch_x = true;
                geb_be = new bool[geb_be.Length];

                ba_end[0, 0] = endwerte[0, 0];
                ba_end[0, 1] = endwerte[0, 1];
                ba_koor[0] = koor[0];
                ba_koor[1] = koor[1];
            }

            if (!(endwerte[1, 0] == ba_end[1, 0] && endwerte[1, 1] == ba_end[1, 1] && koor[1] == ba_koor[1]) || ch_x)
            {
                ch_y = true;
                gra_be = gra_be2 = new bool[gra_be.Length];

                ba_end[1, 0] = endwerte[1, 0];
                ba_end[1, 1] = endwerte[1, 1];
                ba_koor[1] = koor[1];
            }

            if (ch_x)
            {
                for (int i = 0; i < ergebnisse.Length && ch_x; i++)
                    ergebnisse[i] = new double[Convert.ToInt32(koor[0] * genau)];

                rechnen_lassen();
            }

            sct_graph_angab.Panel1.Invalidate();
        }

        private void einteilungen_machen()
        {
            bool[] richtigrum = new bool[2];
            int[,] endteilungen = new int[2, 2];
            double[] teilungen = new double[2] { koor[0] / (endwerte[0, 1] - endwerte[0, 0]), koor[1] / (endwerte[1, 1] - endwerte[1, 0]) };
            double[] drauf = new double[2];
            anzeigen_einteilungen[0] = anzeigen_einteilungen[1] = 0;

            einteilungen_punkte = new Point[2, 2, anzahl_einteilung.Max()];

            for (int i = 0; i < 2; i++)
            {
                if (dazwischen(endwerte[i, 0], endwerte[i, 1], 0))
                    drauf[i] = Math.Abs(endwerte[i, 0] % spt[i]);
                else
                    drauf[i] = spt[i] - Math.Abs(endwerte[i, 0] % spt[i]);
            }

            for (int i = 0, j = -1; true; i++)
            {
                if (dazwischen(10, koor[0] - 10, (drauf[0] + (i - 1) * Math.Abs(spt[0])) * Math.Abs(teilungen[0])))
                {
                    einteilungen_punkte[0, 0, anzeigen_einteilungen[0]] = new Point(links + Convert.ToInt32((drauf[0] + (i - 1) * Math.Abs(spt[0])) * Math.Abs(teilungen[0])), achsen_punkte[0, 0].Y - 10);
                    einteilungen_punkte[0, 1, anzeigen_einteilungen[0]] = new Point(einteilungen_punkte[0, 0, anzeigen_einteilungen[0]].X, einteilungen_punkte[0, 0, anzeigen_einteilungen[0]].Y + 20);

                    endteilungen[0, 0] = Convert.ToInt32((endwerte[0, 0] + Math.Sign(spt[0]) * (drauf[0] + (i - 1) * Math.Abs(spt[0]))) / spt[0]) * Convert.ToInt32(anzeigen_einteilungen[0] == 0) + endteilungen[0, 0] * Convert.ToInt32(anzeigen_einteilungen[0] != 0);
                    endteilungen[0, 1] = Convert.ToInt32((endwerte[0, 0] + Math.Sign(spt[0]) * (drauf[0] + (i - 1) * Math.Abs(spt[0]))) / spt[0]);

                    if (ur_wo[0] == -1 && drauf[0] + (i - 1) * Math.Abs(spt[0]) == Math.Abs(endwerte[0, 0]))
                        ur_wo[0] = anzeigen_einteilungen[0];

                    j = 2;

                    if (anzeigen_einteilungen[0] == 0 || (anzeigen_einteilungen[0] > 0 && einteilungen_punkte[0, 0, anzeigen_einteilungen[0]] != einteilungen_punkte[0, 0, anzeigen_einteilungen[0] - 1]))
                        anzeigen_einteilungen[0]++;
                }
                else if (j == 2)
                {
                    break;
                }
                else if ((drauf[0] + (i - 1) * Math.Abs(spt[0])) * Math.Abs(teilungen[0]) < 10)
                {
                    j = 2 * Convert.ToInt32(j == 1);
                }
                else if ((drauf[0] + (i - 1) * Math.Abs(spt[0])) * Math.Abs(teilungen[0]) > koor[0] - 10)
                {
                    j = 1 + Convert.ToInt32(j == 0);
                }
            }

            for (int i = 0, j = -1; true; i++)
            {
                if (dazwischen(10, koor[1] - 10, (drauf[1] + (i - 1) * spt[1]) * teilungen[1]))
                {
                    einteilungen_punkte[1, 0, anzeigen_einteilungen[1]] = new Point(achsen_punkte[1, 0].X + 10, oben + koor[1] - Convert.ToInt32((drauf[1] + (i - 1) * spt[1]) * teilungen[1]));
                    einteilungen_punkte[1, 1, anzeigen_einteilungen[1]] = new Point(einteilungen_punkte[1, 0, anzeigen_einteilungen[1]].X - 20, einteilungen_punkte[1, 0, anzeigen_einteilungen[1]].Y);

                    endteilungen[1, 0] = Convert.ToInt32((endwerte[1, 0] + Math.Sign(spt[1]) * (drauf[1] + (i - 1) * Math.Abs(spt[1]))) / spt[1]) * Convert.ToInt32(anzeigen_einteilungen[1] == 0) + endteilungen[1, 0] * Convert.ToInt32(anzeigen_einteilungen[1] != 0);
                    endteilungen[1, 1] = Convert.ToInt32((endwerte[1, 0] + Math.Sign(spt[1]) * (drauf[1] + (i - 1) * Math.Abs(spt[1]))) / spt[1]);

                    if (ur_wo[1] == -1 && drauf[1] + (i - 1) * Math.Abs(spt[1]) == Math.Abs(endwerte[1, 0]))
                        ur_wo[1] = anzeigen_einteilungen[1];

                    j = 2;

                    if (anzeigen_einteilungen[1] == 0 || (anzeigen_einteilungen[1] > 0 && einteilungen_punkte[1, 0, anzeigen_einteilungen[1]] != einteilungen_punkte[1, 0, anzeigen_einteilungen[1] - 1]))
                        anzeigen_einteilungen[1]++;
                }
                else if (j == 2)
                {
                    break;
                }
                else if ((drauf[1] + (i - 1) * Math.Abs(spt[1])) * Math.Abs(teilungen[1]) < 10)
                {
                    j = 2 * Convert.ToInt32(j == 1);
                }
                else if ((drauf[1] + (i - 1) * Math.Abs(spt[1])) * Math.Abs(teilungen[1]) > koor[1] - 10)
                {
                    j = 1 + Convert.ToInt32(j == 0);
                }
            }

            for (int i = 0; i < 2; i++)
            {
                if ((endwerte[i, 0] < endwerte[i, 1] && endteilungen[i, 0] <= endteilungen[i, 1]) || (endwerte[i, 0] > endwerte[i, 1] && endteilungen[i, 0] >= endteilungen[i, 1]))
                    richtigrum[i] = true;
            }

            bemasung(teilungen, endteilungen, richtigrum);
        }

        private void bemasung(double[] teilung, int[,] endteilungen, bool[] richtigrum)
        {
            text_anzahl[0] = Convert.ToInt32(Math.Abs(auf_ab_runden(endteilungen[0, 0] / 5.0, false) - auf_ab_runden(endteilungen[0, 1] / 5.0, false)) + Convert.ToInt32(!dazwischen(endteilungen[0, 0], endteilungen[0, 1], 0)));
            text_anzahl[1] = Convert.ToInt32(Math.Abs(auf_ab_runden(endteilungen[1, 0] / 5.0, false) - auf_ab_runden(endteilungen[1, 1] / 5.0, false)) + Convert.ToInt32(!dazwischen(endteilungen[1, 0], endteilungen[1, 1], 0)));

            text_einteilung = new string[2, text_anzahl.Max()];
            lenght = new int[2, text_einteilung.Length];
            einteil_text = new Rectangle[2, text_einteilung.GetLength(1)];

            for (int i = 0; i < 2; i++)
            {
                bool ende_auf = endwerte[i, 0] < endwerte[i, 1];

                for (int j = 0, k = endteilungen[i, 0] / 5; true; k += Math.Sign(endwerte[i, 1] - endwerte[i, 0]), j++)
                {
                    k += Convert.ToInt32(k == 0) * Math.Sign(endwerte[i, 1] - endwerte[i, 0]);

                    if ((k * 5 > endteilungen[i, 1] && ende_auf) || (k * 5 * spt[i] < endteilungen[i, 1] && !ende_auf))
                        break;

                    text_einteilung[i, j] = zahl_anpassen(spt[i], k * 5);
                    char[] cache1 = text_einteilung[i, j].ToCharArray();

                    lenght[i, j] = 7;

                    for (int l = 0; l < cache1.Length; l++)
                        lenght[i, j] += 6 - 3 * Convert.ToInt32(cache1[l] == ',' || cache1[l] == '-') + Convert.ToInt32(cache1[l] == 'E');
                }
            }

            for (int j = endteilungen[1, 0] / 5, k = 0, l = 0; j <= endteilungen[1, 1] / 5; j++, k++, l++)
            {
                l += Convert.ToInt32(j == 0 || (j > 0 && k == 0));
                j += Convert.ToInt32(j == 0 || (j > 0 && k == 0));

                if (j > endteilungen[1, 1] / 5)
                    break;

                einteil_text[1, k] = ubereinander(1, k, achsen_punkte[1, 0].X - lenght[1, k] + verschiebung[1, 0], einteilungen_punkte[1, 0, (Convert.ToInt32(richtigrum[1]) * 2 - 1) * (endteilungen[1, 0] / 5 * 5 - endteilungen[1, 0]) + l * 5].Y - 6, lenght[1, k] + 2, 11);
            }

            for (int j = endteilungen[0, 0] / 5, k = 0, l = 0; j <= endteilungen[0, 1] / 5; j++, k++, l++)
            {
                l += Convert.ToInt32(j == 0);
                j += Convert.ToInt32(j == 0);

                if (j > endteilungen[0, 1] / 5)
                    break;

                einteil_text[0, k] = ubereinander(0, k, einteilungen_punkte[0, 0, (Convert.ToInt32(richtigrum[0]) * 2 - 1) * (endteilungen[0, 0] / 5 * 5 - endteilungen[0, 0]) + l * 5].X - lenght[0, k] / 2, achsen_punkte[0, 0].Y + verschiebung[0, 0], lenght[0, k] + 2, 11);
            }
        }

        private Rectangle ubereinander(int ein, int zwei, int x, int y, int width, int height)
        {
            int fehler = 0, x1 = x, x2 = x + width, y1 = y, y2 = y + height,
                xplus = Convert.ToInt32(ein == 1) * (-1 * verschiebung[1, 0] + verschiebung[1, 1] + lenght[ein, zwei]),
                yplus = Convert.ToInt32(ein == 0) * (-1 * verschiebung[0, 0] + verschiebung[0, 1]);

            Rectangle ausgabe = new Rectangle(0, 0, width, height);

            if ((ein == 1 && dazwischen(y1, y2, achsen_punkte[0, 0].Y)) || ((ein == 0 && dazwischen(x1, x2, achsen_punkte[1, 0].X))))
                fehler = 2;

            for (int i = 0; i < anzeigen_einteilungen[1 - ein] && fehler < 2; i++)
            {
                if ((ein == 1 && (dazwischen(einteilungen_punkte[0, 0, i].Y, einteilungen_punkte[0, 1, i].Y, y1) || dazwischen(einteilungen_punkte[0, 0, i].Y, einteilungen_punkte[0, 1, i].Y, y1)) && dazwischen(x1, x2, einteilungen_punkte[0, 0, i].X)) ||
                    (ein == 0 && (dazwischen(x1, x2, einteilungen_punkte[1, 0, i].X) || dazwischen(x1, x2, einteilungen_punkte[1, 1, i].X) || dazwischen(einteilungen_punkte[1, 0, i].X, einteilungen_punkte[1, 1, i].X, x1)) && dazwischen(y1, y2, einteilungen_punkte[1, 0, i].Y)))
                {
                    fehler = 2;
                }
            }

            for (int i = 0, f = 0; i < 2 && fehler < 2; i++, x1 += xplus, x2 += xplus, y1 += yplus, y2 += yplus, f = fehler)
            {
                if (!(dazwischen(links, links + koor[0], x1) && dazwischen(links, links + koor[0], x2) && dazwischen(oben, oben + koor[1], y1) && dazwischen(oben, oben + koor[1], y2)))
                    fehler++;

                for (int j = ein; j < 2 && fehler == f; j++)
                {
                    for (int k = 0; k < zwei && fehler == f; k++)
                    {
                        if ((dazwischen(x1, x2, einteil_text[j, k].X) || dazwischen(x1, x2, einteil_text[j, k].X + einteil_text[j, k].Width) || dazwischen(einteil_text[j, k].X, einteil_text[j, k].X + einteil_text[j, k].Width, x1))
                            && (dazwischen(y, y2, einteil_text[j, k].Y) || dazwischen(y, y2, einteil_text[j, k].Y + einteil_text[j, k].Height) || dazwischen(einteil_text[j, k].Y, einteil_text[j, k].Y + einteil_text[j, k].Height, y)))
                        {
                            fehler++;
                        }
                    }
                }

                if (fehler == f)
                    break;
            }

            if (fehler < 2)
            {
                ausgabe.X = x1;
                ausgabe.Y = y1;
            }

            return ausgabe;
        }

        private bool dazwischen(double erste, double zweite, double zahl)
        {
            bool passt;

            return passt = (erste >= zweite && erste >= zahl && zahl >= zweite) || (erste <= zweite && erste <= zahl && zahl <= zweite);
        }

        private double auf_ab_runden(double zahl, bool auf)
        {
            return zahl = Math.Round(zahl, 0) + Math.Sign(zahl) * (-1 * Convert.ToInt32(!auf && Math.Round(Math.Abs(zahl), 0) > Math.Abs(zahl)) + Convert.ToInt32(auf && Math.Round(Math.Abs(zahl), 0) < Math.Abs(zahl)));
        }

        private double zahl_lesen(string text, double wenn, double wann)
        {
            bool fehler = false; double wert = 0;

            try
            {
                wert = Convert.ToDouble(text);
            }
            catch
            {
                char[] einzelne = text.ToCharArray();
                int stelle;
                double vorne, hinten;
                fehler = true;

                for (int i = 1; i < einzelne.Length - 1 && fehler; i++)
                {
                    if (einzelne[i] == 'E')
                    {
                        fehler = false;
                        stelle = i;

                        vorne = Convert.ToDouble(text.Remove(i, einzelne.Length - i));
                        hinten = Convert.ToDouble(text.Remove(0, i + 1));

                        wert = vorne * Math.Pow(10, hinten);

                        break;
                    }
                }
            }

            if (fehler || wann == wert)
                wert = wenn;

            return wert;
        }

        private string zahl_anpassen(double zahl, int multi)
        {
            string text = "0";

            if (zahl != 0)
            {
                bool fehler_hier = false;
                int vorzeichen = Math.Sign(zahl * multi);
                double betrag = Math.Abs(zahl * multi);
                double fac = 10;

                if (betrag < 1)
                {
                    fac = 0.1;

                    if (betrag == 0)
                        betrag = Double.Epsilon;
                }
                else if (Double.IsInfinity(betrag))
                {
                    betrag = Double.MaxValue;
                }
                else if (Double.IsNaN(betrag))
                {
                    text = "0";
                    fehler_hier = true;
                }

                for (int m = 0; !fehler_hier; betrag /= fac, m++)
                {
                    if (betrag < 10 && 1 <= betrag)
                    {
                        if (fac == 10 && m > 6)
                        {
                            text = Convert.ToString(Math.Round(betrag, 3) * Convert.ToDouble(vorzeichen)) + "E" + Convert.ToString(m);
                        }
                        else if (fac == 0.1 && m > 3)
                        {
                            text = Convert.ToString(Math.Round(betrag, 3) * Convert.ToDouble(vorzeichen)) + "E-" + Convert.ToString(m);
                        }
                        else if (m > 3)
                        {
                            if (betrag * Math.Pow(fac, m) == Math.Round(betrag, m - 3) * Math.Pow(fac, m))
                            {
                                text = Convert.ToString(Math.Round(betrag, 3) * Convert.ToDouble(vorzeichen)) + "E" + Convert.ToString(m);
                            }
                            else
                            {
                                text = Convert.ToString(Math.Round(betrag * Math.Pow(fac, m), 0) * Convert.ToDouble(vorzeichen));
                            }
                        }
                        else
                        {
                            text = Convert.ToString(Math.Round(betrag * Math.Pow(fac, m), 3 - m) * Convert.ToDouble(vorzeichen));
                        }

                        break;
                    }
                }
            }

            return text;
        }

        private void vorberechnen()
        {
            rechenzeichen = new int[0];
            zahlenwerte = (double[])backup_zahlenwerte.Clone();
            vorhanden_wert = (bool[])backup_vorhanden_wert.Clone();
            schritte = (string[])backup_schritte.Clone();
            was_schritte = (char[])backup_was_schritte.Clone();

            Array.Resize(ref var_wo, var_wo.Length + hinzu);

            var_wo[lastselcted] = new int[4][];
            var_wo[lastselcted][0] = new int[0];
            var_wo[lastselcted][1] = new int[0];
            var_wo[lastselcted][2] = new int[0];
            var_wo[lastselcted][3] = new int[0];

            bool[] vorhanden_fertig = new bool[0];
            string[] schritte_fertig = new string[0];
            char[] was_schritte_fertig = new char[0];
            double akt_wert = endwerte[0, 0];
            bool var_ja = false;

            for (int i = 0; i < was_schritte.Length; i++, var_ja = false)
            {
                if (was_schritte[i] == 'p')
                {
                    switch (schritte[i])
                    {
                        case "p":
                            zahlenwerte[i] = Math.PI;
                            break;

                        case "j":
                            Array.Resize(ref var_wo[lastselcted][0], var_wo[lastselcted][0].Length + 1);
                            var_ja = true;
                            break;

                        case "k":
                            Array.Resize(ref var_wo[lastselcted][1], var_wo[lastselcted][1].Length + 1);
                            var_ja = true;
                            break;

                        case "l":
                            Array.Resize(ref var_wo[lastselcted][2], var_wo[lastselcted][2].Length + 1);
                            var_ja = true;
                            break;

                        case "i":
                            zahlenwerte[i] = -1;
                            break;

                        case "e":
                            zahlenwerte[i] = Math.E;
                            break;

                        case "x":
                            Array.Resize(ref var_wo[lastselcted][3], var_wo[lastselcted][3].Length + 1);
                            var_ja = true;
                            break;
                    }

                    if (!var_ja)
                    {
                        vorhanden_wert[i] = true;
                        schritte[i] = "z";
                        was_schritte[i] = 'z';
                    }
                }
            }

            for (int a = 0; a < 2; a++)
            {
                schritte_bestimmen(false,true);
                string[] gleichung_davor = new string[8] { "", "", "", "", "", "", "", "" };

                while (gleichung != gleichung_davor[0])
                {
                    gleichung_davor[0] = gleichung;

                    while (gleichung != gleichung_davor[1])
                    {
                        gleichung_davor[1] = gleichung;

                        for (int i = 0; i < schritte.Length - 3; i++)
                        {
                            if (was_schritte[i] == 't' && was_schritte[i + 1] == '(' && was_schritte[i + 2] == 'z' && was_schritte[i + 3] == ')' && schritte[i] != "g")
                            {
                                rechzeich(i, a == 1);
                                schritte_bestimmen(false, true);
                            }
                        }
                    }

                    while (gleichung != gleichung_davor[2])
                    {
                        gleichung_davor[2] = gleichung;

                        for (int i = 0; i < schritte.Length - 6; i++)
                        {
                            if (schritte[i] == "g" && was_schritte[i + 1] == '(' && was_schritte[i + 2] == 'z' && was_schritte[i + 3] == ')' && was_schritte[i + 4] == '(' && was_schritte[i + 5] == 'z' && was_schritte[i + 6] == ')')
                            {
                                rechzeich(i, a == 1);
                                schritte[i + 1] = schritte[i + 3] = schritte[i + 4] = schritte[i + 5] = schritte[i + 6] = "";
                                vorhanden_wert[i + 5] = false;
                                schritte_bestimmen(false, true);
                            }
                        }
                    }

                    while (gleichung != gleichung_davor[3])
                    {
                        gleichung_davor[3] = gleichung;

                        for (int i = 4; i < schritte.Length - 4; i++)
                        {
                            if (was_schritte[i - 4] == '(' && was_schritte[i - 3] == '(' && was_schritte[i - 2] == 'z' && was_schritte[i - 1] == ')' && was_schritte[i] == 'h' && was_schritte[i + 1] == '(' && was_schritte[i + 2] == 'z' && was_schritte[i + 3] == ')' && was_schritte[i + 4] == ')')
                            {
                                rechzeich(i, a == 1);
                                schritte[i - 3] = schritte[i - 2] = schritte[i - 1] = schritte[i + 0] = schritte[i + 1] = schritte[i + 3] = "";
                                schritte_bestimmen(false, true);
                            }
                        }
                    }

                    while (gleichung != gleichung_davor[4])
                    {
                        gleichung_davor[4] = gleichung;

                        for (int i = 1; i < schritte.Length - 1; i++)
                        {
                            if (was_schritte[i - 1] == 'z' && was_schritte[i] == 'm' && was_schritte[i + 1] == 'z')
                            {
                                rechzeich(i, a == 1);
                                schritte_bestimmen(false,true);
                            }
                        }
                    }

                    while (gleichung != gleichung_davor[5])
                    {
                        gleichung_davor[5] = gleichung;

                        for (int i = 1; i < schritte.Length - 1; i++)
                        {
                            if ((i - 1 == 0 || was_schritte[i - 2] == '(' || was_schritte[i - 2] == 'a' || was_schritte[i - 2] == '|') && was_schritte[i - 1] == 'z' && was_schritte[i] == 'a' && was_schritte[i + 1] == 'z' && (i + 2 == was_schritte.Length || was_schritte[i + 2] == ')' || was_schritte[i + 2] == 'a' || was_schritte[i + 2] == '|'))
                            {
                                rechzeich(i, a == 1);
                                schritte_bestimmen(false,true);
                            }
                        }
                    }

                    while (gleichung != gleichung_davor[6])
                    {
                        gleichung_davor[6] = gleichung;

                        for (int i = 1; i < schritte.Length - 1; i++)
                        {
                            if ((i - 1 == 0 || (was_schritte[i - 2] != 't' && was_schritte[i - 2] != 'h' && was_schritte[i - 2] != 'g' && was_schritte[i - 2] != ')')) && was_schritte[i - 1] == '(' && was_schritte[i] == 'z' && was_schritte[i + 1] == ')' && (i + 2 == was_schritte.Length || (was_schritte[i + 2] != 't' && was_schritte[i + 2] != 'h')))
                            {
                                schritte[i - 1] = schritte[i + 1] = "";
                                schritte_bestimmen(false,true);
                            }
                        }
                    }

                    while (gleichung != gleichung_davor[7])
                    {
                        gleichung_davor[7] = gleichung;

                        for (int i = 0; i + 2 < schritte.Length; i++)
                        {
                            if (was_schritte[i] == '|' && was_schritte[i + 1] == 'z' && was_schritte[i + 2] == '|')
                            {
                                rechzeich(i, a == 1);
                                schritte[i + 2] = "";
                                schritte_bestimmen(false,true);
                            }
                        }
                    }
                }

                if (a == 1)
                    break;

                schritte_fertig = (string[])schritte.Clone();
                was_schritte_fertig = (char[])was_schritte.Clone();
                vorhanden_fertig = (bool[])vorhanden_wert.Clone();
                zahlenwerte_fertig = (double[])zahlenwerte.Clone();

                for (int i = 0, j = 0, k = 0, l = 0, x = 0; i < was_schritte.Length; i++)
                {
                    if (was_schritte[i] == 'p')
                    {
                        switch (schritte[i])
                        {
                            case "j":
                                var_wo[lastselcted][0][j] = i;
                                zahlenwerte[i] = werte_scb[0, 0];
                                j++;
                                break;

                            case "k":
                                var_wo[lastselcted][1][k] = i;
                                zahlenwerte[i] = werte_scb[1, 0];
                                k++;
                                break;

                            case "l":
                                var_wo[lastselcted][2][l] = i;
                                zahlenwerte[i] = werte_scb[2, 0];
                                l++;
                                break;

                            case "x":
                                var_wo[lastselcted][3][x] = i;
                                zahlenwerte[i] = akt_wert;
                                x++;
                                break;
                        }

                        vorhanden_wert[i] = true;
                        schritte[i] = "z";
                        was_schritte[i] = 'z';
                    }
                }
            }

            if (rechenzeichen.Length != 0)
            {
                vorhanden_wert = (bool[])vorhanden_fertig.Clone();
                zahlenwerte = (double[])zahlenwerte_fertig.Clone();
                schritte = (string[])schritte_fertig.Clone();
                was_schritte = (char[])was_schritte_fertig.Clone();
                akt_wert = endwerte[0, 0] + (endwerte[0, 1] - endwerte[0, 0]) / genau / koor[0];

                for (int i = 0; i < var_wo[lastselcted].Length; i++)
                {
                    for (int j = 0; j < var_wo[lastselcted][i].Length; j++)
                    {
                        was_schritte[var_wo[lastselcted][i][j]] = 'z';
                        schritte[var_wo[lastselcted][i][j]] = "z";
                        vorhanden_wert[var_wo[lastselcted][i][j]] = true;

                        if (i == 3)
                            zahlenwerte[var_wo[lastselcted][i][j]] = akt_wert;
                        else
                            zahlenwerte[var_wo[lastselcted][i][j]] = werte_scb[i, 0];
                    }
                }

                wo_zahlenwerte = new int[2, rechenzeichen.Length];
                wo_rechenzeichen = new int[rechenzeichen.Length];

                for (int i = 0; i < rechenzeichen.Length; i++)
                {
                    int k = 0;

                    for (int l = 0; l < rechenzeichen[i]; k++)
                    {
                        if (was_schritte[k] == 'g' || was_schritte[k] == 't' || was_schritte[k] == 'm' || was_schritte[k] == 'a' || was_schritte[k] == 'h' || was_schritte[k] == '|')
                            l++;
                    }

                    wo_rechenzeichen[i] = k - 1;

                    for (k = wo_rechenzeichen[i] + 1; true; k++)
                    {
                        if (was_schritte[k] == 'z')
                        {
                            wo_zahlenwerte[1, i] = k;
                            break;
                        }
                    }

                    for (k = wo_rechenzeichen[i] - 1; was_schritte[wo_rechenzeichen[i]] != 't' && schritte[wo_rechenzeichen[i]] != "g" && was_schritte[wo_rechenzeichen[i]] != '|'; k--)
                    {
                        if (was_schritte[k] == 'z')
                        {
                            wo_zahlenwerte[0, i] = k;
                            break;
                        }
                    }

                    for (k = wo_zahlenwerte[1, i] + 1; schritte[wo_rechenzeichen[i]] == "g"; k++)
                    {
                        if (was_schritte[k] == 'z')
                        {
                            wo_zahlenwerte[0, i] = k;
                            break;
                        }
                    }

                    berechen(wo_rechenzeichen[i], i);

                    if (was_schritte[wo_rechenzeichen[i]] != 't' && was_schritte[wo_rechenzeichen[i]] != '|')
                    {
                        schritte[wo_zahlenwerte[0, i]] = "Q";
                        was_schritte[wo_zahlenwerte[0, i]] = 'Q';
                    }
                    else if (was_schritte[wo_rechenzeichen[i]] == '|')
                    {
                        for (int j = wo_rechenzeichen[i] + 1; true; j++)
                        {
                            if (was_schritte[j] == '|')
                            {
                                schritte[j] = "Q";
                                was_schritte[j] = 'Q';
                                break;
                            }
                        }
                    }

                    schritte[wo_rechenzeichen[i]] = "Q";
                    was_schritte[wo_rechenzeichen[i]] = 'Q';
                }

                vorhanden_wert = (bool[])vorhanden_fertig.Clone();
                schritte = (string[])schritte_fertig.Clone();
                was_schritte = (char[])was_schritte_fertig.Clone();
            }

            Array.Resize(ref graphen, graphen.Length + hinzu);
            Array.Resize(ref graphen2, graphen2.Length + hinzu);
            Array.Resize(ref geb_be, geb_be.Length + hinzu);
            Array.Resize(ref gra_be, gra_be.Length + hinzu);
            Array.Resize(ref ergebnisse, ergebnisse.Length + hinzu);
            Array.Resize(ref zahlenwerte_tabelle, zahlenwerte_tabelle.Length + hinzu);
            Array.Resize(ref rechenzeichen_tabelle, rechenzeichen_tabelle.Length + hinzu);
            Array.Resize(ref wo_rechenzeichen_tabelle, wo_rechenzeichen_tabelle.Length + hinzu);
            Array.Resize(ref wo_zahlenwerte_tabelle, wo_zahlenwerte_tabelle.Length + hinzu);
            Array.Resize(ref schritte_tabelle, schritte_tabelle.Length + hinzu);

            geb_be = new bool[geb_be.Length];
            gra_be = new bool[gra_be.Length];
            ergebnisse[lastselcted] = new double[Convert.ToInt32(koor[0] * genau)];
            zahlenwerte_tabelle[lastselcted] = (double[])zahlenwerte_fertig.Clone();
            rechenzeichen_tabelle[lastselcted] = (int[])rechenzeichen.Clone();
            wo_rechenzeichen_tabelle[lastselcted] = (int[])wo_rechenzeichen.Clone();
            wo_zahlenwerte_tabelle[lastselcted] = (int[,])wo_zahlenwerte.Clone();
            schritte_tabelle[lastselcted] = (string[])schritte.Clone();

            rechnen_lassen();
        }

        private double ausrechnen(string formel)
        {
            gleich_berechnen(formel, false);

            for (int i = 0; i < was_schritte.Length; i++)
            {
                if (was_schritte[i] == 'p')
                {
                    switch (schritte[i])
                    {
                        case "p":
                            zahlenwerte[i] = Math.PI;
                            break;

                        case "j":
                            zahlenwerte[i] = werte_scb[0, 0];
                            break;

                        case "k":
                            zahlenwerte[i] = werte_scb[1, 0];
                            break;

                        case "l":
                            zahlenwerte[i] = werte_scb[2, 0];
                            break;

                        case "i":
                            zahlenwerte[i] = -1;
                            break;

                        case "e":
                            zahlenwerte[i] = Math.E;
                            break;
                    }
                }
            }

            schritte_bestimmen(false, true);
            string[] gleichung_davor = new string[8] { "", "", "", "", "", "", "", "" };

            while (gleichung != gleichung_davor[0])
            {
                gleichung_davor[0] = gleichung;

                while (gleichung != gleichung_davor[1])
                {
                    gleichung_davor[1] = gleichung;

                    for (int i = 0; i < schritte.Length - 3; i++)
                    {
                        if (was_schritte[i] == 't' && was_schritte[i + 1] == '(' && was_schritte[i + 2] == 'z' && was_schritte[i + 3] == ')' && schritte[i] != "g")
                        {
                            berechen(i);
                            schritte_bestimmen(false, false);
                        }
                    }
                }

                while (gleichung != gleichung_davor[2])
                {
                    gleichung_davor[2] = gleichung;

                    for (int i = 0; i < schritte.Length - 6; i++)
                    {
                        if (schritte[i] == "g" && was_schritte[i + 1] == '(' && was_schritte[i + 2] == 'z' && was_schritte[i + 3] == ')' && was_schritte[i + 4] == '(' && was_schritte[i + 5] == 'z' && was_schritte[i + 6] == ')')
                        {
                            berechen(i);
                            schritte[i + 1] = schritte[i + 3] = schritte[i + 4] = schritte[i + 5] = schritte[i + 6] = "";
                            vorhanden_wert[i + 5] = false;
                            schritte_bestimmen(false, false);
                        }
                    }
                }

                while (gleichung != gleichung_davor[3])
                {
                    gleichung_davor[3] = gleichung;

                    for (int i = 4; i < schritte.Length - 4; i++)
                    {
                        if (was_schritte[i - 4] == '(' && was_schritte[i - 3] == '(' && was_schritte[i - 2] == 'z' && was_schritte[i - 1] == ')' && was_schritte[i] == 'h' && was_schritte[i + 1] == '(' && was_schritte[i + 2] == 'z' && was_schritte[i + 3] == ')' && was_schritte[i + 4] == ')')
                        {
                            berechen(i);
                            schritte[i - 3] = schritte[i - 2] = schritte[i - 1] = schritte[i + 0] = schritte[i + 1] = schritte[i + 3] = "";
                            schritte_bestimmen(false, false);
                        }
                    }
                }

                while (gleichung != gleichung_davor[4])
                {
                    gleichung_davor[4] = gleichung;

                    for (int i = 1; i < schritte.Length - 1; i++)
                    {
                        if (was_schritte[i - 1] == 'z' && was_schritte[i] == 'm' && was_schritte[i + 1] == 'z')
                        {
                            berechen(i);
                            schritte_bestimmen(false, false);
                        }
                    }
                }

                while (gleichung != gleichung_davor[5])
                {
                    gleichung_davor[5] = gleichung;

                    for (int i = 1; i < schritte.Length - 1; i++)
                    {
                        if ((i - 1 == 0 || was_schritte[i - 2] == '(' || was_schritte[i - 2] == 'a' || was_schritte[i - 2] == '|') && was_schritte[i - 1] == 'z' && was_schritte[i] == 'a' && was_schritte[i + 1] == 'z' && (i + 2 == was_schritte.Length || was_schritte[i + 2] == ')' || was_schritte[i + 2] == 'a' || was_schritte[i + 2] == '|'))
                        {
                            berechen(i);
                            schritte_bestimmen(false, false);
                        }
                    }
                }

                while (gleichung != gleichung_davor[6])
                {
                    gleichung_davor[6] = gleichung;

                    for (int i = 1; i < schritte.Length - 1; i++)
                    {
                        if ((i - 1 == 0 || (was_schritte[i - 2] != 't' && was_schritte[i - 2] != 'h' && was_schritte[i - 2] != 'g' && was_schritte[i - 2] != ')')) && was_schritte[i - 1] == '(' && was_schritte[i] == 'z' && was_schritte[i + 1] == ')' && (i + 2 == was_schritte.Length || (was_schritte[i + 2] != 't' && was_schritte[i + 2] != 'h')))
                        {
                            schritte[i - 1] = schritte[i + 1] = "";
                            schritte_bestimmen(false, false);
                        }
                    }
                }

                while (gleichung != gleichung_davor[7])
                {
                    gleichung_davor[7] = gleichung;

                    for (int i = 0; i + 2 < schritte.Length; i++)
                    {
                        if (was_schritte[i] == '|' && was_schritte[i + 1] == 'z' && was_schritte[i + 2] == '|')
                        {
                            berechen(i);
                            schritte[i + 2] = "";
                            schritte_bestimmen(false, false);
                        }
                    }
                }
            }

            if (fehler)
                return Double.NaN;

            return zahlenwerte[0];
        }

        private void berechen(int welcher, int nr)
        {
            switch (schritte[welcher])
            {
                case "s":
                    zahlenwerte[wo_zahlenwerte[1, nr]] = Math.Sin(zahlenwerte[wo_zahlenwerte[1, nr]]);
                    break;

                case "n":
                    zahlenwerte[wo_zahlenwerte[1, nr]] = Math.Asin(zahlenwerte[wo_zahlenwerte[1, nr]]);
                    break;

                case "c":
                    zahlenwerte[wo_zahlenwerte[1, nr]] = Math.Cos(zahlenwerte[wo_zahlenwerte[1, nr]]);
                    break;

                case "o":
                    zahlenwerte[wo_zahlenwerte[1, nr]] = Math.Acos(zahlenwerte[wo_zahlenwerte[1, nr]]);
                    break;

                case "t":
                    zahlenwerte[wo_zahlenwerte[1, nr]] = Math.Tan(zahlenwerte[wo_zahlenwerte[1, nr]]);
                    break;

                case "u":
                    zahlenwerte[wo_zahlenwerte[1, nr]] = Math.Atan(zahlenwerte[wo_zahlenwerte[1, nr]]);
                    break;

                case "q":
                    zahlenwerte[wo_zahlenwerte[1, nr]] = Math.Log(zahlenwerte[wo_zahlenwerte[1, nr]]);
                    break;

                case "r":
                    zahlenwerte[wo_zahlenwerte[1, nr]] = Math.Log10(zahlenwerte[wo_zahlenwerte[1, nr]]);
                    break;

                case "g":
                    zahlenwerte[wo_zahlenwerte[1, nr]] = Math.Log(zahlenwerte[wo_zahlenwerte[0, nr]], zahlenwerte[wo_zahlenwerte[1, nr]]);
                    break;

                case "|":
                    zahlenwerte[wo_zahlenwerte[1, nr]] = Math.Abs(zahlenwerte[wo_zahlenwerte[1, nr]]);
                    break;

                case "+":
                    zahlenwerte[wo_zahlenwerte[1, nr]] = zahlenwerte[wo_zahlenwerte[0, nr]] + zahlenwerte[wo_zahlenwerte[1, nr]];
                    break;

                case "-":
                    zahlenwerte[wo_zahlenwerte[1, nr]] = zahlenwerte[wo_zahlenwerte[0, nr]] - zahlenwerte[wo_zahlenwerte[1, nr]];
                    break;

                case "*":
                    zahlenwerte[wo_zahlenwerte[1, nr]] = zahlenwerte[wo_zahlenwerte[0, nr]] * zahlenwerte[wo_zahlenwerte[1, nr]];
                    break;

                case "/":
                    zahlenwerte[wo_zahlenwerte[1, nr]] = zahlenwerte[wo_zahlenwerte[0, nr]] / zahlenwerte[wo_zahlenwerte[1, nr]];
                    break;

                case "^":
                    zahlenwerte[wo_zahlenwerte[1, nr]] = Math.Pow(zahlenwerte[wo_zahlenwerte[0, nr]], zahlenwerte[wo_zahlenwerte[1, nr]]);
                    break;

                case "w":
                    zahlenwerte[wo_zahlenwerte[1, nr]] = Math.Pow(zahlenwerte[wo_zahlenwerte[1, nr]], 1 / zahlenwerte[wo_zahlenwerte[0, nr]]);
                    break;
            }
        }

        private double berechen(int w, int wo, double eins, double zwei)
        {
            switch (schritte_tabelle2[w][wo])
            {
                case "s":
                    zwei = Math.Sin(zwei);
                    break;

                case "n":
                    zwei = Math.Asin(zwei);
                    break;

                case "c":
                    zwei = Math.Cos(zwei);
                    break;

                case "o":
                    zwei = Math.Acos(zwei);
                    break;

                case "t":
                    zwei = Math.Tan(zwei);
                    break;

                case "u":
                    zwei = Math.Atan(zwei);
                    break;

                case "q":
                    zwei = Math.Log(zwei);
                    break;

                case "r":
                    zwei = Math.Log10(zwei);
                    break;

                case "g":
                    zwei = Math.Log(eins, zwei);
                    break;

                case "|":
                    zwei = Math.Abs(zwei);
                    break;

                case "+":
                    zwei = eins + zwei;
                    break;

                case "-":
                    zwei = eins - zwei;
                    break;

                case "*":
                    zwei = eins * zwei;
                    break;

                case "/":
                    zwei = eins / zwei;
                    break;

                case "^":
                    zwei = Math.Pow(eins, zwei);
                    break;

                case "w":
                    zwei = Math.Pow(zwei, 1 / eins);
                    break;
            }

            return zwei;
        }

        private void rechzeich(int i, bool mit)
        {
            if (mit)
            {
                Array.Resize(ref rechenzeichen, rechenzeichen.Length + 1);

                for (int k = 0; k <= i; k++)
                {
                    if (was_schritte[i] == 'g' || was_schritte[k] == 't' || was_schritte[k] == 'm' || was_schritte[k] == 'a' || was_schritte[k] == 'h' || was_schritte[k] == '|')
                        rechenzeichen[rechenzeichen.Length - 1]++;
                }
            }

            berechen(i);
        }

        private void berechen(int l)
        {
            switch (schritte[l])
            {
                case "s":
                    zahlenwerte[l + 2] = Math.Sin(zahlenwerte[l + 2]);
                    break;

                case "n":
                    zahlenwerte[l + 2] = Math.Asin(zahlenwerte[l + 2]);
                    break;

                case "c":
                    zahlenwerte[l + 2] = Math.Cos(zahlenwerte[l + 2]);
                    break;

                case "o":
                    zahlenwerte[l + 2] = Math.Acos(zahlenwerte[l + 2]);
                    break;

                case "t":
                    zahlenwerte[l + 2] = Math.Tan(zahlenwerte[l + 2]);
                    break;

                case "u":
                    zahlenwerte[l + 2] = Math.Atan(zahlenwerte[l + 2]);
                    break;

                case "q":
                    zahlenwerte[l + 2] = Math.Log(zahlenwerte[l + 2]);
                    break;

                case "r":
                    zahlenwerte[l + 2] = Math.Log10(zahlenwerte[l + 2]);
                    break;

                case "g":
                    zahlenwerte[l + 2] = Math.Log(zahlenwerte[l + 5], zahlenwerte[l + 2]);
                    break;

                case "|":
                    zahlenwerte[l + 1] = Math.Abs(zahlenwerte[l + 1]);
                    break;

                case "^":
                    zahlenwerte[l + 2] = Math.Pow(zahlenwerte[l - 2], zahlenwerte[l + 2]);
                    break;

                case "w":
                    zahlenwerte[l + 2] = Math.Pow(zahlenwerte[l + 2], 1 / zahlenwerte[l - 2]);
                    break;

                case "+":
                    zahlenwerte[l + 1] = zahlenwerte[l - 1] + zahlenwerte[l + 1];
                    break;

                case "-":
                    zahlenwerte[l + 1] = zahlenwerte[l - 1] - zahlenwerte[l + 1];
                    break;

                case "*":
                    zahlenwerte[l + 1] = zahlenwerte[l - 1] * zahlenwerte[l + 1];
                    break;

                case "/":
                    zahlenwerte[l + 1] = zahlenwerte[l - 1] / zahlenwerte[l + 1];
                    break;
            }

            if (was_schritte[l] == 'h' || was_schritte[l] == 'a' || was_schritte[l] == 'm')
            {
                schritte[l] = schritte[l - 1] = "";
                zahlenwerte[l - 1] = 0;
                vorhanden_wert[l - 1] = false;
            }
            else
            {
                schritte[l] = "";
            }
        }

        public void gleich_berechnen(string formel, bool x_ein)
        {
            int[] betrage = new int[1];
            schritte = new string[0];
            was_schritte = new char[0];
            zahlenwerte = new double[0];
            vorhanden_wert = new bool[0];
            klammern = 0;
            fehler = false;
            string gleich_vor = "";
            gleichung = "";
            gleich_zeichen = formel.ToCharArray();
            
            for (int i = 0; i < gleich_zeichen.Length && !fehler; i++)
            {
                if (gleich_zeichen[i] == ' ') ;
                else if (Convert.ToInt32(gleich_zeichen[i]) > 64 && Convert.ToInt32(gleich_zeichen[i]) < 91 && gleich_zeichen[i] != 'E')
                {
                    gleich_zeichen[i] = Convert.ToChar(32 + Convert.ToInt32(gleich_zeichen[i]));
                    gleichung += Convert.ToString(gleich_zeichen[i]);

                    if (gleich_zeichen[i] == 'i')
                        gleichung = gleichung.TrimEnd('i');
                }
                else
                    gleichung += Convert.ToString(gleich_zeichen[i]);
            }

            for (int i = 0; i < gleich_zeichen.Length && !fehler; i++)
            {
                if (gleich_zeichen[i] == '(')
                {
                    Array.Resize(ref betrage, betrage.Length + 1);
                    betrage[betrage.Length - 1] = 0;

                    klammern++;
                }
                else if (gleich_zeichen[i] == ')')
                {
                    if (betrage[betrage.Length - 1] % 2 == 1)
                    {
                        gleichung = gleichung.Remove(i, gleichung.Length - i) + "|" + gleichung.Remove(0, i);
                    }

                    Array.Resize(ref betrage, betrage.Length - 1);
                    klammern--;
                }
                else if (gleich_zeichen[i] == '|')
                {
                    betrage[betrage.Length - 1]++;
                }

                if (klammern < 0)
                {
                    gleichung = "(" + gleichung;

                    gleich_zeichen = gleichung.ToCharArray();
                    klammern = 0;
                    i = -1;
                }
            }

            for (int i = 0; i < klammern && !fehler; i++)
            {
                if (betrage[betrage.Length - 1] % 2 == 1)
                    gleichung += "|";

                Array.Resize(ref betrage, betrage.Length - 1);
                gleichung += ")";
            }

            gleich_zeichen = gleichung.ToCharArray();
            string old_gleichung = gleichung;
            gleichung = "";
            zahlenwerte = new double[gleich_zeichen.Length];
            vorhanden_wert = new bool[gleich_zeichen.Length];

            for (int i = 0, j = 0, k = 0; i < gleich_zeichen.Length && !fehler; j++, k = i)
            {
                bool za = false, ko = false, ex = false, ex2 = false;

                while (i < gleich_zeichen.Length && (Convert.ToInt32(gleich_zeichen[i]) == 44 || gleich_zeichen[i] == 'E' || (Convert.ToInt32(gleich_zeichen[i]) >= 48 && Convert.ToInt32(gleich_zeichen[i]) <= 57)))
                {
                    if (Convert.ToInt32(gleich_zeichen[i]) == 44)
                    {
                        if (ko)
                            break;

                        ko = true;
                    }
                    else if (Convert.ToInt32(gleich_zeichen[i]) >= 48 && Convert.ToInt32(gleich_zeichen[i]) <= 57)
                    {
                        za = true;
                        ex2 = ex;
                    }
                    else
                    {
                        if (ex || !za)
                            break;

                        ex = true;
                    }

                    i++;
                }

                if (za)
                {
                    string cache = old_gleichung;

                    if (ex != ex2)
                        i--;

                    if (i != gleich_zeichen.Length)
                        cache = old_gleichung.Remove(i);

                    zahlenwerte[j] = Convert.ToDouble(cache.Remove(0, k));
                    vorhanden_wert[j] = true;
                    gleichung += "z";
                }
                else
                {
                    i++;
                    string cache = old_gleichung;

                    if (i != gleich_zeichen.Length)
                        cache = old_gleichung.Remove(i);

                    gleichung += cache.Remove(0, k);
                }
            }

            gleich_zeichen = gleichung.ToCharArray();
            gleichung = "";

            for (int i = 0; i < gleich_zeichen.Length; i++)
            {
                try
                {
                    if (gleich_zeichen[i] == 's' && gleich_zeichen[i + 1] == 'i' && gleich_zeichen[i + 2] == 'n')
                    {
                        gleichung += "s";
                        i += 2;
                    }
                    else if (gleich_zeichen[i] == 'c' && gleich_zeichen[i + 1] == 'o' && gleich_zeichen[i + 2] == 's')
                    {
                        gleichung += "c";
                        i += 2;
                    }
                    else if (gleich_zeichen[i] == 't' && gleich_zeichen[i + 1] == 'a' && gleich_zeichen[i + 2] == 'n')
                    {
                        gleichung += "t";
                        i += 2;
                    }
                    else if (gleich_zeichen[i] == 'a' && gleich_zeichen[i + 1] == 's' && gleich_zeichen[i + 2] == 'i' && gleich_zeichen[i + 3] == 'n')
                    {
                        gleichung += "n";
                        i += 3;
                    }
                    else if (gleich_zeichen[i] == 'a' && gleich_zeichen[i + 1] == 'c' && gleich_zeichen[i + 2] == 'o' && gleich_zeichen[i + 3] == 's')
                    {
                        gleichung += "o";
                        i += 3;
                    }
                    else if (gleich_zeichen[i] == 'a' && gleich_zeichen[i + 1] == 't' && gleich_zeichen[i + 2] == 'a' && gleich_zeichen[i + 3] == 'n')
                    {
                        gleichung += "u";
                        i += 3;
                    }
                    else if (gleich_zeichen[i] == 'p' && gleich_zeichen[i + 1] == 'i')
                    {
                        gleichung += "p";
                        i++;
                    }
                    else if (gleich_zeichen[i] == 'l' && gleich_zeichen[i + 1] == 'n')
                    {
                        gleichung += "q";
                        i++;
                    }
                    else if (gleich_zeichen[i] == 'l' && gleich_zeichen[i + 1] == 'g')
                    {
                        gleichung += "r";
                        i++;
                    }
                    else if (gleich_zeichen[i] == 'l' && gleich_zeichen[i + 1] == 'o' && gleich_zeichen[i + 2] == 'g' && gleich_zeichen[i + 3] == '(')
                    {
                        for (int j = i + 5, k = 1, l = 0; j < gleich_zeichen.Length && k > 0; j++)
                        {
                            if (gleich_zeichen[j] == ')' && l == 0)
                            {
                                if (gleich_zeichen[j + 1] != '(' && k == 1)
                                    fehler = true;

                                l++;
                                j++;
                            }
                            else if (gleich_zeichen[j] == ')')
                            {
                                k--;
                            }
                            else if (gleich_zeichen[j] == '(')
                            {
                                k++;
                            }
                        }

                        gleichung += "g";
                        i += 2;
                    }
                    else
                    {
                        gleichung += Convert.ToString(gleich_zeichen[i]);
                    }
                }
                catch
                {
                    gleichung += Convert.ToString(gleich_zeichen[i]);
                }
            }

            while (!fehler && gleich_vor != gleichung)
            {
                schritte_bestimmen(true, x_ein);
                gleich_vor = gleichung;

                if ((was_schritte[0] == 'g' || was_schritte[0] == 't' || was_schritte[0] == '(' || was_schritte[0] == 'a' || was_schritte[0] == 'z' || was_schritte[0] == 'p' || was_schritte[0] == '|') && !fehler)
                {
                    if (schritte[0] == "+")
                    {
                        schritte[0] = "";

                        schritte_bestimmen(false, x_ein);
                        gleich_vor = gleichung;
                    }
                    else if (schritte[0] == "-")
                    {
                        schritte[0] = "i";

                        schritte_bestimmen(false, x_ein);
                        gleich_vor = gleichung;
                    }

                    for (int i = schritte.Length - 1; 0 < i && !fehler; i--)
                    {
                        bool andern = false;

                        if (schritte[i - 1] == "g")
                        {
                            int j = i + 1;

                            for (int k = 1, l = 0; l < 2; j++)
                            {
                                if (was_schritte[j] == '(')
                                {
                                    k++;
                                }
                                else if (was_schritte[j] == ')')
                                {
                                    k--;
                                }

                                if (k == 0)
                                    l++;
                            }

                            if (i > 1 && j < was_schritte.Length)
                            {
                                if (was_schritte[i - 2] != '(' || was_schritte[j] != ')')
                                {
                                    schritte[i - 1] = "(" + schritte[i - 1];
                                    schritte[j - 1] += ")";
                                    andern = true;
                                }
                            }
                            else
                            {
                                schritte[i - 1] = "(" + schritte[i - 1];
                                schritte[j - 1] += ")";
                                andern = true;
                            }
                        }
                        else if (was_schritte[i - 1] == '|' && was_schritte[i] != 'h') ;
                        else if (was_schritte[i - 1] == 't' && (was_schritte[i] == 'p' || was_schritte[i] == '(' || was_schritte[i] == 'z' || was_schritte[i] == 't'))
                        {
                            if (was_schritte[i] != '(' && was_schritte[i] != '|')
                            {
                                andern = klammern_machen(i);
                            }
                        }
                        else if (was_schritte[i - 1] == 'p' && (was_schritte[i] == 't' || was_schritte[i] == 'p' || was_schritte[i] == '(' || was_schritte[i] == ')' || was_schritte[i] == 'm' || was_schritte[i] == 'a' || was_schritte[i] == 'h' || was_schritte[i] == 'z' || was_schritte[i] == '|'))
                        {
                            if (was_schritte[i] == 't' || was_schritte[i] == 'p' || was_schritte[i] == 'z' || was_schritte[i] == '(')
                            {
                                schritte[i - 1] += "*";
                                andern = true;
                            }
                            else if (was_schritte[i] == 'h')
                            {
                                int j = 0;

                                try
                                {
                                    while (was_schritte[i - 2 - j] == 't')
                                        j++;

                                    if (Convert.ToInt32("Q") == 10) ;
                                }
                                catch
                                {
                                    schritte[i - 1 - j] = "(" + schritte[i - 1 - j];
                                    schritte[i - 1] += ")";
                                    andern = true;
                                }

                                andern = true;
                            }
                        }
                        else if (was_schritte[i - 1] == '(' && (was_schritte[i] == 't' || was_schritte[i] == 'p' || was_schritte[i] == '(' || was_schritte[i] == 'a' || was_schritte[i] == 'z' || was_schritte[i] == '|'))
                        {
                            if (schritte[i] == "+")
                            {
                                schritte[i] = "";
                                andern = true;
                            }
                            else if (schritte[i] == "-")
                            {
                                schritte[i] = "i";
                                andern = true;
                            }
                        }
                        else if (was_schritte[i - 1] == ')' && (was_schritte[i] == 't' || was_schritte[i] == 'p' || was_schritte[i] == '(' || was_schritte[i] == ')' || was_schritte[i] == 'm' || was_schritte[i] == 'a' || was_schritte[i] == 'h' || was_schritte[i] == 'z' || was_schritte[i] == '|'))
                        {
                            if (was_schritte[i] != 'm' && was_schritte[i] != 'a' && was_schritte[i] != 'h' && was_schritte[i] != ')' && was_schritte[i] != '|')
                            {
                                bool log = false;

                                for (int j = i - 2, k = 1; j >= 0; j--)
                                {
                                    if (was_schritte[j] == ')')
                                    {
                                        k++;
                                    }
                                    else if (was_schritte[j] == '(')
                                    {
                                        k--;
                                    }

                                    if (k == 0)
                                    {
                                        if (j > 0)
                                            log = schritte[j - 1] == "g";

                                        break;
                                    }
                                }

                                if (!log)
                                {
                                    schritte[i - 1] += "*";
                                    andern = true;
                                }
                            }
                            else if (was_schritte[i] == 'h')
                            {
                                int j = 2, k = 2;
                                bool fehlt = false;
                                klammern = 1;

                                for (j = 2; klammern != 0; j++)
                                {
                                    if (was_schritte[i - j] == ')')
                                    {
                                        klammern++;
                                    }
                                    else if (was_schritte[i - j] == '(')
                                    {
                                        klammern--;
                                    }
                                }

                                try
                                {
                                    if (was_schritte[i - j] == '(')
                                        j++;
                                    else
                                        fehlt = true;

                                    try
                                    {
                                        while (was_schritte[i - j] == 't')
                                            j++;
                                    }
                                    catch { }
                                }
                                catch
                                {
                                    fehlt = true;
                                }

                                if (was_schritte[i + 1] != '(')
                                {
                                    try
                                    {
                                        schritte[i + 1] = "(" + schritte[i + 1] + ")";
                                        andern = true;

                                        if (was_schritte[i + 2] != ')' || fehlt)
                                            Convert.ToInt32("Q");
                                    }
                                    catch
                                    {
                                        schritte[i + 1 - j] = "(" + schritte[i + 1 - j];
                                        schritte[i + 1] += ")";
                                        andern = true;
                                    }
                                }
                                else
                                {
                                    for (klammern = 1; klammern != 0; k++)
                                    {
                                        if (was_schritte[i + k] == '(')
                                        {
                                            klammern++;
                                        }
                                        else if (was_schritte[i + k] == ')')
                                        {
                                            klammern--;
                                        }
                                    }

                                    try
                                    {
                                        if (was_schritte[i + k] != ')' || fehlt)
                                            Convert.ToInt32("Q");
                                    }
                                    catch
                                    {
                                        schritte[i + 1 - j] = "(" + schritte[i + 1 - j];
                                        schritte[i + k - 1] += ")";
                                        andern = true;
                                    }
                                }
                            }
                        }
                        else if (was_schritte[i - 1] == 'a' && (was_schritte[i] == 't' || was_schritte[i] == 'p' || was_schritte[i] == '(' || was_schritte[i] == 'z' || was_schritte[i] == '|')) ;
                        else if (was_schritte[i - 1] == 'm' && (was_schritte[i] == 't' || was_schritte[i] == 'p' || was_schritte[i] == '(' || was_schritte[i] == 'a' || was_schritte[i] == 'z' || was_schritte[i] == '|'))
                        {
                            if (was_schritte[i] == 'a')
                            {
                                schritte[i] = "i*";
                                andern = true;
                            }
                        }
                        else if (was_schritte[i - 1] == 'h' && (was_schritte[i] == 't' || was_schritte[i] == 'p' || was_schritte[i] == '(' || was_schritte[i] == 'a' || was_schritte[i] == 'z'))
                        {
                            if (was_schritte[i] != '(' && was_schritte[i] != '|')
                                andern = klammern_machen(i);
                        }
                        else if (was_schritte[i - 1] == 'z' && (was_schritte[i] == 't' || was_schritte[i] == 'p' || was_schritte[i] == '(' || was_schritte[i] == ')' || was_schritte[i] == 'm' || was_schritte[i] == 'a' || was_schritte[i] == 'h' || was_schritte[i] == '|'))
                        {
                            if (was_schritte[i] != ')' && was_schritte[i] != 'm' && was_schritte[i] != 'a' && was_schritte[i] != 'h' && was_schritte[i] != '|')
                            {
                                schritte[i - 1] += "*";
                                andern = true;
                            }
                            else if (was_schritte[i] == 'h')
                            {
                                int j = 0;

                                try
                                {
                                    while (was_schritte[i - 2 - j] == 't')
                                        j++;

                                    if (Convert.ToInt32("Q") == 10) ;
                                }
                                catch
                                {
                                    schritte[i - 1 - j] = "(" + schritte[i - 1 - j];
                                    schritte[i - 1] += ")";
                                    andern = true;
                                }

                                andern = true;
                            }
                        }
                        else
                        {
                            fehler = true;
                        }

                        if (andern)
                            break;
                    }

                    if (!fehler)
                    {
                        if (was_schritte[was_schritte.Length - 1] != 'z' && was_schritte[was_schritte.Length - 1] != ')' && was_schritte[was_schritte.Length - 1] != 'p' && was_schritte[was_schritte.Length - 1] != '|')
                            fehler = true;
                    }

                    gleichung = "";

                    for (int i = 0; i < schritte.Length; i++)
                        gleichung += schritte[i];

                    gleich_zeichen = gleichung.ToCharArray();
                }
                else if ((was_schritte[0] == 'a' || was_schritte[0] == '(' || was_schritte[0] == 'z' || was_schritte[0] == 't' || was_schritte[0] == 'p') && !fehler) ;
                else
                {
                    fehler = true;
                }
            }

            if (!fehler)
            {
                int auf_zu = 0, b = 0;

                if (was_schritte[0] == '|')
                {
                    auf_zu = 1;
                    b++;
                }

                for (int i = 1; i < was_schritte.Length; i++)
                {
                    if (was_schritte[i] == '|')
                    {
                        if (auf_zu == -1)
                        {
                            b--;
                        }
                        else if (auf_zu == 0)
                        {
                            if (was_schritte[i - 1] == 'm' || was_schritte[i - 1] == 'a' || was_schritte[i - 1] == '(')
                            {
                                auf_zu = 1;
                                b++;
                            }
                            else
                            {
                                auf_zu = -1;
                                b--;
                            }
                        }
                        else
                        {
                            b++;
                        }
                    }
                    else
                    {
                        auf_zu = 0;
                    }

                    if (b < 0)
                    {
                        fehler = true;
                        break;
                    }
                }
            }

            if (!fehler)
            {
                backup_zahlenwerte = (double[])zahlenwerte.Clone();
                backup_vorhanden_wert = (bool[])vorhanden_wert.Clone();
                backup_schritte = (string[])schritte.Clone();
                backup_was_schritte = (char[])was_schritte.Clone();
            }
            else
            {
                MessageBox.Show("Diese Formel ist nicht möglich!", "Fehler");
            }
        }

        private void schritte_bestimmen(bool gleich, bool x_ein)
        {
            if (!gleich)
            {
                gleichung = "";

                for (int i = 0; i < schritte.Length; i++)
                    gleichung += schritte[i];
            }

            gleich_zeichen = gleichung.ToCharArray();

            schritte = new string[0];
            was_schritte = new char[0];
            double[] zahlenwerte_old = zahlenwerte;
            bool[] vorhanden_old = vorhanden_wert;
            zahlenwerte = new double[0];
            vorhanden_wert = new bool[0];

            int zahl_h = 0;

            for (int i = 0; i < gleich_zeichen.Length && !fehler; i++)
            {
                try
                {
                    Array.Resize(ref schritte, schritte.Length + 1);
                    Array.Resize(ref was_schritte, was_schritte.Length + 1);
                    Array.Resize(ref zahlenwerte, zahlenwerte.Length + 1);
                    Array.Resize(ref vorhanden_wert, vorhanden_wert.Length + 1);

                    switch (gleich_zeichen[i])
                    {

                        case 's':
                            schritte[schritte.Length - 1] = "s";
                            was_schritte[was_schritte.Length - 1] = 't';
                            break;

                        case 'c':
                            schritte[schritte.Length - 1] = "c";
                            was_schritte[was_schritte.Length - 1] = 't';
                            break;

                        case 't':
                            schritte[schritte.Length - 1] = "t";
                            was_schritte[was_schritte.Length - 1] = 't';
                            break;

                        case 'n':
                            schritte[schritte.Length - 1] = "n";
                            was_schritte[was_schritte.Length - 1] = 't';
                            break;

                        case 'o':
                            schritte[schritte.Length - 1] = "o";
                            was_schritte[was_schritte.Length - 1] = 't';
                            break;

                        case 'u':
                            schritte[schritte.Length - 1] = "u";
                            was_schritte[was_schritte.Length - 1] = 't';
                            break;

                        case 'q':
                            schritte[schritte.Length - 1] = "q";
                            was_schritte[was_schritte.Length - 1] = 't';
                            break;

                        case 'r':
                            schritte[schritte.Length - 1] = "r";
                            was_schritte[was_schritte.Length - 1] = 't';
                            break;

                        case 'g':
                            schritte[schritte.Length - 1] = "g";
                            was_schritte[was_schritte.Length - 1] = 't';
                            break;

                        case ')':
                            schritte[schritte.Length - 1] = ")";
                            was_schritte[was_schritte.Length - 1] = ')';
                            break;

                        case '(':
                            schritte[schritte.Length - 1] = "(";
                            was_schritte[was_schritte.Length - 1] = '(';
                            break;

                        case 'p':
                            schritte[schritte.Length - 1] = "p";
                            was_schritte[was_schritte.Length - 1] = 'p';
                            break;

                        case 'i':
                            schritte[schritte.Length - 1] = "i";
                            was_schritte[was_schritte.Length - 1] = 'p';
                            break;

                        case 'j':
                            schritte[schritte.Length - 1] = "j";
                            was_schritte[was_schritte.Length - 1] = 'p';
                            break;

                        case 'k':
                            schritte[schritte.Length - 1] = "k";
                            was_schritte[was_schritte.Length - 1] = 'p';
                            break;

                        case 'l':
                            schritte[schritte.Length - 1] = "l";
                            was_schritte[was_schritte.Length - 1] = 'p';
                            break;

                        case 'x':
                            if (!x_ein)
                                fehler = true;

                            schritte[schritte.Length - 1] = "x";
                            was_schritte[was_schritte.Length - 1] = 'p';
                            break;

                        case 'e':
                            schritte[schritte.Length - 1] = "e";
                            was_schritte[was_schritte.Length - 1] = 'p';
                            break;

                        case '|':
                            schritte[schritte.Length - 1] = "|";
                            was_schritte[was_schritte.Length - 1] = '|';
                            break;

                        case '/':
                            schritte[schritte.Length - 1] = "/";
                            was_schritte[was_schritte.Length - 1] = 'm';
                            break;

                        case '*':
                            schritte[schritte.Length - 1] = "*";
                            was_schritte[was_schritte.Length - 1] = 'm';
                            break;

                        case '+':
                            schritte[schritte.Length - 1] = "+";
                            was_schritte[was_schritte.Length - 1] = 'a';
                            break;

                        case '-':
                            schritte[schritte.Length - 1] = "-";
                            was_schritte[was_schritte.Length - 1] = 'a';
                            break;

                        case 'w':
                            schritte[schritte.Length - 1] = "w";
                            was_schritte[was_schritte.Length - 1] = 'h';
                            break;

                        case '^':
                            schritte[schritte.Length - 1] = "^";
                            was_schritte[was_schritte.Length - 1] = 'h';
                            break;

                        case 'z':
                            schritte[schritte.Length - 1] = "z";
                            was_schritte[was_schritte.Length - 1] = 'z';
                            zahl_h++;

                            for (int j = 0, zahl_r = zahl_h; zahl_r > 0; j++)
                            {
                                if (vorhanden_old[j])
                                {
                                    if (zahl_r == 1)
                                    {
                                        zahlenwerte[zahlenwerte.Length - 1] = zahlenwerte_old[j];
                                        vorhanden_wert[vorhanden_wert.Length - 1] = true;
                                    }

                                    zahl_r--;
                                }
                            }
                            break;

                        default:
                            fehler = true;
                            break;
                    }
                }
                catch
                {
                    fehler = true;
                }
            }
        }

        private bool klammern_machen(int i)
        {
            bool andern = false;
            int zahl = 0, j, k, l;

            for (j = i, k = 0, l = 0; j < was_schritte.Length && zahl == 0 && ((k > 0 && l > 0) || (k == 0 && l == 0)); j++)
            {
                if (was_schritte[j] == 'z' || was_schritte[j] == 'p')
                {
                    zahl = j;
                }
                else if (was_schritte[j] == '(')
                {
                    l = 1;
                    k++;
                }
                else if (was_schritte[j] == ')')
                {
                    k--;
                }
            }

            if (zahl != 0)
            {
                schritte[i - 1] += "(";
                schritte[j - 1] += ")";
                andern = true;
            }
            else
            {
                fehler = true;
            }

            return andern;
        }

        private void backgroundworker_erstellen()
        {
            worker = new BackgroundWorker[geb_be.Length,2];

            for (int i = 0; i < worker.GetLength(0); i++)
            {
                worker[i, 0] = new BackgroundWorker();
                worker[i, 0].WorkerSupportsCancellation = true;
                worker[i, 0].WorkerReportsProgress = true;
                worker[i, 0].DoWork += new DoWorkEventHandler(worker_DoWork);
                worker[i, 0].RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
                worker[i, 0].ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);
            }

            for (int i = 0; i < worker.GetLength(0); i++)
            {
                worker[i, 1] = new BackgroundWorker();
                worker[i, 1].WorkerSupportsCancellation = true;
                worker[i, 1].WorkerReportsProgress = true;
                worker[i, 1].DoWork += new DoWorkEventHandler(worker2_DoWork);
                worker[i, 1].RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker2_RunWorkerCompleted);
                worker[i, 1].ProgressChanged += new ProgressChangedEventHandler(worker2_ProgressChanged);
            }
        }

        private void rechnen_lassen()
        {
            if (!warter.IsBusy && !resize)
                warter.RunWorkerAsync();
        }

        private void graph_rechnen()
        {
            bool aus = false, gra = true;

            if (!(endwerte[0, 0] != endwerte3[0, 0] || endwerte[0, 1] != endwerte3[0, 1] || endwerte[1, 0] != endwerte3[1, 0] || endwerte[1, 1] != endwerte3[1, 1]))
            {
                for (int i = 0; i < geb_be.Length; i++)
                {
                    if (worker[i, 1].IsBusy)
                        aus = true;

                    if (!gra_be[i])
                        gra = false;
                }
            }
            else
            {
                for (int i = 0; i < geb_be.Length; i++)
                {
                    if (worker[i, 1].IsBusy)
                        worker[i, 1].CancelAsync();
                }

                gra_be = new bool[gra_be.Length];
                gra = aus = false;
            }

            if (!aus && !gra)
            {
                gra_be2 = (bool[])gra_be.Clone();
                endwerte3 = (double[,])endwerte.Clone();
                w_work2 = 0;

                if (!worker[w_work2, 1].IsBusy && !gra_be[w_work2] && geb_be[w_work2])
                    worker[w_work2, 1].RunWorkerAsync();
                else if (gra_be[w_work2] || !geb_be[w_work2])
                    w_work2++;
            }
        }

        private void warter_DoWork(object sender, DoWorkEventArgs e)        //7warter
        {
            while (bearbeiten)
            { }

            kopieren = true;

            var_wo2 = (int[][][])var_wo.Clone();
            geb_be2 = (bool[])geb_be.Clone();
            zahlenwerte_tabelle2 = (double[][])zahlenwerte_tabelle.Clone();
            ergebnisse2 = (double[][])ergebnisse.Clone();
            endwerte2 = (double[,])endwerte.Clone();
            rechenzeichen_tabelle2 = (int[][])rechenzeichen_tabelle.Clone();
            wo_rechenzeichen_tabelle2 = (int[][])wo_rechenzeichen_tabelle.Clone();
            wo_zahlenwerte_tabelle2 = (int[][,])wo_zahlenwerte_tabelle.Clone();
            schritte_tabelle2 = (string[][])schritte_tabelle.Clone();
            koor2 = (int[])koor.Clone();

            for (int i = 0; i < var_w.Length; i++)
                var_w[i] = werte_scb[i, 0];

            bug = var_w[1];

            kopieren = false;
            w_work = 0;

            while (w_work < worker.GetLength(0))
            {
                if (w_work < worker.GetLength(0) && !worker[w_work, 0].IsBusy && !geb_be[w_work])
                {
                    worker[w_work, 0].RunWorkerAsync();
                    break;
                }
                else
                    w_work++;
            }
        }

        private void warter_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
        
        }

        void warter_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)        //7ausrechnen
        {
            int w = w_work++;

            while (geb_be.Length < w_work)
            {
                if (!worker[w_work, 0].IsBusy && !geb_be[w_work])
                {
                    worker[w_work, 0].RunWorkerAsync();
                    break;
                }
                else
                    w_work++;
            }

            double[] zahlenwerte2, zahlenwerte_fertig2 = (double[])zahlenwerte_tabelle2[w].Clone(), var = (double[])var_w.Clone();

            for (int j = 0; j < var.Length; j++)
                for (int k = 0; k < var_wo2[w][j].Length; k++)
                    zahlenwerte_fertig2[var_wo2[w][j][k]] = var[j];

            if (!geb_be[w] && !geb_be2[w])
            {
                geb_be2[w] = true;
                ergebnisse2[w] = new double[Convert.ToInt32(koor[0] * genau)];
                double akt;

                for (int i = 0; i < koor2[0] * genau; i++)
                {
                    if (zahlenwerte_fertig2[0] != bug)
                    { }
                    
                    zahlenwerte2 = (double[])zahlenwerte_fertig2.Clone();
                    akt = endwerte2[0, 0] + (endwerte2[0, 1] - endwerte2[0, 0]) * i / genau / koor2[0];

                        for (int k = 0; k < var_wo2[w][3].Length; k++)
                            zahlenwerte2[var_wo2[w][3][k]] = akt;

                    if (rechenzeichen_tabelle2[w].Length != 0)
                    {
                        for (int j = 0; j < rechenzeichen_tabelle2[w].Length; j++)
                            zahlenwerte2[wo_zahlenwerte_tabelle2[w][1, j]] = berechen(w, wo_rechenzeichen_tabelle2[w][j], zahlenwerte2[wo_zahlenwerte_tabelle2[w][0, j]], zahlenwerte2[wo_zahlenwerte_tabelle2[w][1, j]]);

                        ergebnisse2[w][i] = zahlenwerte2[wo_zahlenwerte_tabelle2[w][1, rechenzeichen_tabelle2[w].Length - 1]];
                    }
                    else
                        ergebnisse2[w][i] = zahlenwerte2[0];

                    if (i > 0 && ergebnisse2[w][i] != ergebnisse2[w][i - 1])
                    { }
                }

                ergebnisse[w] = (double[])ergebnisse2[w].Clone();
                geb_be[w] = true;
            }
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            y_achse_anpassen(!ckb_e_y_manuell.Checked && !ckb_x_y.Checked && Convert.ToInt32(ckb_b_y_von.Checked) + Convert.ToInt32(ckb_b_y_bis.Checked) + Convert.ToInt32(tbx_null_y.Enabled) < 2);

            sct_graph_angab.Panel1.Invalidate();
        }

        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void worker2_DoWork(object sender, DoWorkEventArgs e)       //7graph
        {
            int w = w_work2++;

            while (geb_be.Length < w_work2)
            {
                if (!worker[w_work2, 1].IsBusy && !gra_be[w_work2] && geb_be[w_work2])
                {
                    worker[w_work2, 1].RunWorkerAsync();
                    break;
                }
                else
                    w_work2++;
            }

            if (!gra_be[w] && !gra_be2[w] && geb_be[w])
            {
                if (Convert.ToBoolean(dgv[0, w].Value))
                {
                    do
                    {
                        gra_be2[w] = true;

                        graphen[w] = new Point[1][];
                        graphen[w][0] = new Point[ergebnisse[w].Length];
                        int oft = 0;

                        for (int i = 0, l = 1, akt = 0, last = 0, vorlast; i < ergebnisse[w].Length && gra_be2[w]; i++)
                        {
                            if (dazwischen(endwerte3[1, 0], endwerte3[1, 1], ergebnisse[w][i]))
                            {
                                vorlast = last;
                                last = akt;
                                akt = oben + Convert.ToInt32((endwerte3[1, 1] - ergebnisse[w][i]) / (endwerte3[1, 1] - endwerte3[1, 0]) * koor[1]);

                                oft += Convert.ToInt32(last != akt || akt != vorlast);
                                graphen[w][graphen[w].Length - 1][oft - 1] = new Point(links + Convert.ToInt32(i / genau), akt);

                                l = 0;
                            }
                            else if (l == 0)
                            {
                                Array.Resize(ref graphen[w][graphen[w].Length - 1], oft);
                                Array.Resize(ref graphen[w], graphen[w].Length + 1);
                                graphen[w][graphen[w].Length - 1] = new Point[ergebnisse[w].Length - i];

                                l = 1;
                                oft = 0;
                            }
                        }

                        if (oft == 0)
                            Array.Resize(ref graphen[w], graphen[w].Length - 1);
                        else if (graphen[w][graphen[w].Length - 1][0].Y != graphen[w][graphen[w].Length - 1][oft].Y)
                            Array.Resize(ref graphen[w][graphen[w].Length - 1], oft);
                        else if (graphen[w][graphen[w].Length - 1][0].Y == graphen[w][graphen[w].Length - 1][oft].Y)
                            Array.Resize(ref graphen[w][graphen[w].Length - 1], oft + 1);

                        graphen2[w] = (Point[][])graphen[w].Clone();

                        for (int i = 0; i < graphen2[w].Length && gra_be2[w]; i++)
                        {
                            for (int j = 0; j < graphen2[w][i].Length; j++)
                            {
                                graphen2[w][i][j].X -= 1;
                                graphen2[w][i][j].Y -= 1;
                            }
                        }

                    } while (!gra_be2[w]);

                    gra_be[w] = true;
                }
            }
        }

        private void worker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled || endwerte[0, 0] != endwerte3[0, 0] || endwerte[0, 1] != endwerte3[0, 1] || endwerte[1, 0] != endwerte3[1, 0] || endwerte[1, 1] != endwerte3[1, 1])
                graph_rechnen();
            else
                sct_graph_angab.Panel1.Invalidate();
        }

        void worker2_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void y_achse_anpassen(bool anpassen)
        {
            if (anpassen)
            {
                double[] grenz = new double[2] { Double.MaxValue, Double.MinValue };
                bool keiner = true;

                for (int i = 0; i < geb_be.Length; i++)
                {
                    if (geb_be[i] && Convert.ToBoolean(dgv[0, i].Value))
                    {
                        keiner = false;

                        for (int j = 0; j < ergebnisse[i].Length; j++)
                        {
                            if (ergebnisse[i][j] < grenz[0] && ergebnisse[i][j] != Double.NaN && !Double.IsInfinity(ergebnisse[i][j]))
                                grenz[0] = ergebnisse[i][j];

                            if (ergebnisse[i][j] > grenz[1] && !Double.IsInfinity(ergebnisse[i][j]))
                                grenz[1] = ergebnisse[i][j];
                        }
                    }
                }

                if (keiner)
                {
                    grenz[0] = -1;
                    grenz[1] = 1;
                }

                if (tbx_y_von.Enabled)
                    endwerte[1, 0] = zahl_lesen(tbx_y_von.Text, -10, Double.NaN);
                else
                    endwerte[1, 0] = grenz[0];

                if (tbx_y_bis.Enabled)
                    endwerte[1, 1] = zahl_lesen(tbx_y_bis.Text, 10, endwerte[1, 1]);
                else
                    endwerte[1, 1] = grenz[1];

                if (tbx_null_y.Enabled)
                {
                    endwerte[1, 0] = mitte_wert[1] - Math.Abs(grenz[Convert.ToInt32(Math.Abs(grenz[0]) < Math.Abs(grenz[1]))] - mitte_wert[1]);
                    endwerte[1, 1] = mitte_wert[1] + Math.Abs(grenz[Convert.ToInt32(Math.Abs(grenz[0]) < Math.Abs(grenz[1]))] - mitte_wert[1]);
                }

                bool cache = endwerte[1, 0] == endwerte[1, 1];
                endwerte[1, 0] -= Convert.ToInt32(cache);
                endwerte[1, 1] += Convert.ToInt32(cache);

                gelesen = true;

                achsen_anpassen();
            }
        }

        private void sct_graph_angab_Panel1_Paint(object sender, PaintEventArgs e)
        {
            textBox1.Text = anzeige;

                e.Graphics.DrawLine(stift_koor, achsen_punkte[0, 0], achsen_punkte[0, 1]);
                e.Graphics.DrawLine(stift_koor, achsen_punkte[1, 0], achsen_punkte[1, 1]);


                for (int i = 0; i < 2; i++)
                    for (int j = 0; j < anzeigen_einteilungen[i] && !(j == ur_wo[i] && anzeigen_einteilungen[i] == 1); j++)
                    {
                        e.Graphics.DrawLine(stift_koor, einteilungen_punkte[i, 0, j], einteilungen_punkte[i, 1, j]);
                        j += Convert.ToInt32(j + 1 == ur_wo[i]);
                    }


                for (int i = 0; i < 2; i++)
                    for (int j = 0; j < text_anzahl[i]; j++)
                        if (einteil_text[i, j].X != 0)
                            e.Graphics.DrawString(text_einteilung[i, j], schrift, farbe, einteil_text[i, j].X + 1, einteil_text[i, j].Y + 1);
            
            if (geb_be.Length > 0)
                graph_rechnen();

            for (int i = 0; i < graphen.Length; i++)
                if (graphen[i] != null && Convert.ToBoolean(dgv[0, i].Value))
                    for (int j = 0; j < graphen[i].Length && gra_be[i]; j++)
                        if (i == lastselcted && focoused)
                        {
                            if (graphen[i][j].Length > 1)
                                e.Graphics.DrawLines(new Pen(dgv[0, i].Style.BackColor, 3), graphen2[i][j]);
                            else if (graphen2[i][j].Length == 1)
                                e.Graphics.FillEllipse(new SolidBrush(dgv[0, i].Style.BackColor), graphen2[i][j][0].X, graphen2[i][j][0].Y, 3, 3);
                        }
                        else
                            if (graphen[i][j].Length > 1)
                                e.Graphics.DrawLines(new Pen(dgv[0, i].Style.BackColor, 1), graphen[i][j]);
                            else if (graphen[i][j].Length == 1)
                                e.Graphics.FillEllipse(new SolidBrush(dgv[0, i].Style.BackColor), graphen[i][j][0].X, graphen[i][j][0].Y, 1, 1);
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                bool cache = Convert.ToBoolean(dgv[0, e.RowIndex].Value);
                cache = !cache;
                dgv[0, e.RowIndex].Value = cache;
            }

            achsen_anpassen();
        }

        private void dgv_Enter(object sender, EventArgs e)
        {
            focoused = true;
        }

        private void dgv_Leave(object sender, EventArgs e)
        {
            focoused = false;
            btns_Enabled();
            lastselcted = dgv.CurrentCell.RowIndex;
            sct_graph_angab.Panel1.Invalidate();
        }

        private void btns_Enabled()
        {
            btn_ab.Enabled = dgv.Rows.Count > 1 && dgv.CurrentCell != null;
            btn_auf.Enabled = dgv.Rows.Count > 1 && dgv.CurrentCell != null;
            btn_losch.Enabled = btn_edit.Enabled = dgv.SelectedCells.Count > 0 && dgv.CurrentCell != null;
        }

        private void btn_neu_Click(object sender, EventArgs e)
        {
            int auto_nr = 1;

            for (int i = 0; i < geb_be.Length; i++)
            {
                for (int j = 0; j < geb_be.Length; j++)
                {
                    string text = dgv[1, j].Value.ToString();

                    if (Convert.ToInt32(text.Remove(0, 7)) > 0 && text.Remove(7) == "Formel ")
                    {
                        if (Convert.ToInt32(text.Remove(0, 7)) == auto_nr)
                            auto_nr++;
                    }
                }
            }

            hinzu = 1;
            lastselcted = dgv.Rows.Count;
            Editor.tbx_formel.Text = "";
            Editor.tbx_name.Text = "Formel " + auto_nr.ToString();
            Editor.OK = false;

            Editor.ShowDialog();

            if (Editor.OK)
            {
                dgv.Rows.Add(1);

                dgv[0, lastselcted].Value = true;
                dgv[1, lastselcted].Value = Editor.tbx_name.Text;
                dgv[2, lastselcted].Value = Editor.tbx_formel.Text;
                dgv[0, lastselcted].Style.BackColor = dgv[1, dgv.Rows.Count - 1].Style.BackColor = dgv[2, dgv.Rows.Count - 1].Style.BackColor = Editor.pbx_farbe.BackColor;

                if (Editor.pbx_farbe.BackColor.B + Editor.pbx_farbe.BackColor.G * 3 + Editor.pbx_farbe.BackColor.R > 637)
                    dgv[0, lastselcted].Style.ForeColor = dgv[1, lastselcted].Style.ForeColor = dgv[2, lastselcted].Style.ForeColor = Color.Black;
                else
                    dgv[0, lastselcted].Style.ForeColor = dgv[1, lastselcted].Style.ForeColor = dgv[2, lastselcted].Style.ForeColor = Color.White;

                vorberechnen();
                dgv.Focus();
                backgroundworker_erstellen();
                rechnen_lassen();
            }

            btns_Enabled();
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            hinzu = 0;
            Editor.tbx_name.Text = dgv[1, lastselcted].Value.ToString();
            string cache_formel = Editor.tbx_formel.Text = dgv[2, lastselcted].Value.ToString();
            Editor.pbx_farbe.BackColor = dgv[0, lastselcted].Style.BackColor;
            Editor.OK = false;

            Editor.ShowDialog();

            if (Editor.OK)
            {
                dgv[1, lastselcted].Value = Editor.tbx_name.Text;
                dgv[2, lastselcted].Value = Editor.tbx_formel.Text;
                dgv[0, lastselcted].Style.BackColor = dgv[1, lastselcted].Style.BackColor = dgv[2, lastselcted].Style.BackColor = Editor.pbx_farbe.BackColor;

                if (Editor.pbx_farbe.BackColor.B + Editor.pbx_farbe.BackColor.G * 3 + Editor.pbx_farbe.BackColor.R > 637)
                    dgv[0, lastselcted].Style.ForeColor = dgv[1, lastselcted].Style.ForeColor = dgv[2, lastselcted].Style.ForeColor = Color.Black;
                else
                    dgv[0, lastselcted].Style.ForeColor = dgv[1, lastselcted].Style.ForeColor = dgv[2, lastselcted].Style.ForeColor = Color.White;

                if (cache_formel != Editor.tbx_formel.Text)
                    vorberechnen();

                dgv.Focus();
                rechnen_lassen();
            }

            btns_Enabled();
        }

        private void btn_losch_Click(object sender, EventArgs e)
        {
            dgv.Rows.RemoveAt(lastselcted);

            Array.Copy(graphen, lastselcted + 1, graphen, lastselcted, graphen.Length - lastselcted - 1);
            Array.Copy(geb_be, lastselcted + 1, geb_be, lastselcted, geb_be.Length - lastselcted - 1);
            Array.Copy(ergebnisse, lastselcted + 1, ergebnisse, lastselcted, ergebnisse.Length - lastselcted - 1);
            Array.Copy(zahlenwerte_tabelle, lastselcted + 1, zahlenwerte_tabelle, lastselcted, zahlenwerte_tabelle.Length - lastselcted - 1);
            Array.Copy(rechenzeichen_tabelle, lastselcted + 1, rechenzeichen_tabelle, lastselcted, rechenzeichen_tabelle.Length - lastselcted - 1);
            Array.Copy(wo_rechenzeichen_tabelle, lastselcted + 1, wo_rechenzeichen_tabelle, lastselcted, wo_rechenzeichen_tabelle.Length - lastselcted - 1);
            Array.Copy(wo_zahlenwerte_tabelle, lastselcted + 1, wo_zahlenwerte_tabelle, lastselcted, wo_zahlenwerte_tabelle.Length - lastselcted - 1);

            Array.Resize(ref graphen, graphen.Length - 1);
            Array.Resize(ref graphen2, graphen2.Length - 1);
            Array.Resize(ref geb_be, geb_be.Length - 1);
            Array.Resize(ref ergebnisse, ergebnisse.Length - 1);
            Array.Resize(ref zahlenwerte_tabelle, zahlenwerte_tabelle.Length - 1);
            Array.Resize(ref rechenzeichen_tabelle, rechenzeichen_tabelle.Length - 1);
            Array.Resize(ref wo_rechenzeichen_tabelle, wo_rechenzeichen_tabelle.Length - 1);
            Array.Resize(ref wo_zahlenwerte_tabelle, wo_zahlenwerte_tabelle.Length - 1);

            gra_be = new bool[gra_be.Length];

            backgroundworker_erstellen();
            btns_Enabled();
        }

        private void btn_auf_Click(object sender, EventArgs e)
        {
            reihen_verschieben(-1);
        }

        private void btn_ab_Click(object sender, EventArgs e)
        {
            reihen_verschieben(1);
        }

        private void reihen_verschieben(int auf_ab)
        {
            int row = lastselcted;
            int row2 = (row + auf_ab + dgv.Rows.Count) % dgv.Rows.Count;

            bool cache_an = Convert.ToBoolean(dgv[0, row].Value);
            string cache_name = Convert.ToString(dgv[1, row].Value);
            string cache_formel = Convert.ToString(dgv[2, row].Value);
            Color cache_farbe = dgv[0, row].Style.BackColor,
                cache_fore = dgv[0, row].Style.ForeColor;

            dgv[0, row].Value = dgv[0, row2].Value;
            dgv[1, row].Value = dgv[1, row2].Value;
            dgv[2, row].Value = dgv[2, row2].Value;
            dgv[0, row].Style.BackColor = dgv[1, row].Style.BackColor = dgv[2, row].Style.BackColor = dgv[0, row2].Style.BackColor;
            dgv[0, row].Style.ForeColor = dgv[1, row].Style.ForeColor = dgv[2, row].Style.ForeColor = dgv[0, row2].Style.ForeColor;

            dgv[0, row2].Value = cache_an;
            dgv[1, row2].Value = cache_name;
            dgv[2, row2].Value = cache_formel;
            dgv[0, row2].Style.BackColor = dgv[1, row2].Style.BackColor = dgv[2, row2].Style.BackColor = cache_farbe;
            dgv[0, row2].Style.ForeColor = dgv[1, row2].Style.ForeColor = dgv[2, row2].Style.ForeColor = cache_fore;

            bool geb_ca = geb_be[row];
            double[] erg_ca = (double[])ergebnisse[row].Clone();
            zahlenwerte = (double[])zahlenwerte_tabelle[row].Clone();
            rechenzeichen = (int[])rechenzeichen_tabelle[row].Clone();
            wo_rechenzeichen = (int[])wo_rechenzeichen_tabelle[row].Clone();
            wo_zahlenwerte = (int[,])wo_zahlenwerte_tabelle[row].Clone();

            geb_be[row] = geb_be[row2];
            ergebnisse[row] = (double[])ergebnisse[row2].Clone();
            zahlenwerte_tabelle[row] = (double[])zahlenwerte_tabelle[row2].Clone();
            rechenzeichen_tabelle[row] = (int[])rechenzeichen_tabelle[row2].Clone();
            wo_rechenzeichen_tabelle[row] = (int[])wo_rechenzeichen_tabelle[row2].Clone();
            wo_zahlenwerte_tabelle[row] = (int[,])wo_zahlenwerte_tabelle[row2].Clone();

            geb_be[row2] = geb_ca;
            ergebnisse[row2] = (double[])erg_ca.Clone();
            zahlenwerte_tabelle[row2] = (double[])zahlenwerte.Clone();
            rechenzeichen_tabelle[row2] = (int[])rechenzeichen.Clone();
            wo_rechenzeichen_tabelle[row2] = (int[])wo_rechenzeichen.Clone();
            wo_zahlenwerte_tabelle[row2] = (int[,])wo_zahlenwerte.Clone();

            dgv.CurrentCell = dgv[dgv.CurrentCell.ColumnIndex, row2];
            lastselcted = row2;
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lastselcted = dgv.CurrentRow.Index;
            dgv.Focus();
            sct_graph_angab.Panel1.Invalidate();
        }

        private void sct_graph_angab_SplitterMoved(object sender, SplitterEventArgs e)
        {
            noch_nicht = false;
            achsen_anpassen();
        }

        private void dgv_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            formel_pbx = dgv.Width - dgv.Columns[2].Width;
        }

        private void scb_Scroll(object sender, EventArgs e)
        {
            scb_wert_changen();
        }

        private void tbx_scroll_Leave(object sender, EventArgs e)
        {
            scb_wert_changen();
        }

        private void scb_wert_changen()
        {
            scroll_an_en = true;

            scb_val[0] = scb_j.Value;
            scb_val[1] = scb_k.Value;
            scb_val[2] = scb_l.Value;

            string[,] an_en = new string[3, 2];

            an_en[0, 0] = tbx_scroll_j_an.Text;
            an_en[0, 1] = tbx_scroll_j_en.Text;
            an_en[1, 0] = tbx_scroll_k_an.Text;
            an_en[1, 1] = tbx_scroll_k_en.Text;
            an_en[2, 0] = tbx_scroll_l_an.Text;
            an_en[2, 1] = tbx_scroll_l_en.Text;

            if (an_en[0, 0] == "")
                tbx_scroll_j_an.Text = an_en[0, 0] = "0";

            if (an_en[0, 1] == "")
                tbx_scroll_j_en.Text = an_en[0, 1] = "0";

            if (an_en[1, 0] == "")
                tbx_scroll_k_an.Text = an_en[1, 0] = "0";

            if (an_en[1, 1] == "")
                tbx_scroll_k_en.Text = an_en[1, 1] = "0";

            if (an_en[2, 0] == "")
                tbx_scroll_l_an.Text = an_en[2, 0] = "0";

            if (an_en[2, 1] == "")
                tbx_scroll_l_en.Text = an_en[2, 1] = "0";

            for (int i = 0; i < 3; i++)
            {
                werte_scb[i, 1] = zahl_lesen(an_en[i, 0], 0, Double.NaN);
                werte_scb[i, 2] = zahl_lesen(an_en[i, 1], 100, Double.NaN);
                werte_scb[i, 0] = (werte_scb[i, 2] - werte_scb[i, 1]) / 91 * scb_val[i] + werte_scb[i, 1];
            }

            tbx_j.Text = zahl_anpassen(werte_scb[0, 0], 1);
            tbx_k.Text = zahl_anpassen(werte_scb[1, 0], 1);
            tbx_l.Text = zahl_anpassen(werte_scb[2, 0], 1);

            tbx_scroll_j_an.Text = zahl_anpassen(werte_scb[0, 1], 1);
            tbx_scroll_j_en.Text = zahl_anpassen(werte_scb[0, 2], 1);
            tbx_scroll_k_an.Text = zahl_anpassen(werte_scb[1, 1], 1);
            tbx_scroll_k_en.Text = zahl_anpassen(werte_scb[1, 2], 1);
            tbx_scroll_l_an.Text = zahl_anpassen(werte_scb[2, 1], 1);
            tbx_scroll_l_en.Text = zahl_anpassen(werte_scb[2, 2], 1);

            scroll_an_en = false;

            for (int i = 0; i < geb_be.Length; i++)
            {
                geb_be[i] = !(var_wo[i][0].Length > 0 || var_wo[i][1].Length > 0 || var_wo[i][2].Length > 0) && geb_be[i];
                gra_be[i] = !(var_wo[i][0].Length > 0 || var_wo[i][1].Length > 0 || var_wo[i][2].Length > 0) && geb_be[i] && gra_be[i];
            }


            rechnen_lassen();
        }

        private void tbx_vari_Leave(object sender, EventArgs e)
        {
            werte_scb[0, 0] = zahl_lesen(tbx_j.Text, 1, Double.NaN);
            werte_scb[1, 0] = zahl_lesen(tbx_k.Text, 1, Double.NaN);
            werte_scb[2, 0] = zahl_lesen(tbx_l.Text, 1, Double.NaN);

            for (int i = 0; i < 3; i++)
            {
                if (dazwischen(werte_scb[i, 1], werte_scb[i, 2], werte_scb[i, 0]) && !scroll_an_en)
                {
                    werte_scb[i, 0] = (werte_scb[i, 0] - werte_scb[i, 1]) / (werte_scb[i, 2] - werte_scb[i, 1]) * 91;
                    scb_val[i] = Convert.ToInt32(werte_scb[i, 0]);
                }
            }

            scb_j.Value = scb_val[0];
            scb_k.Value = scb_val[1];
            scb_l.Value = scb_val[2];

            rechnen_lassen();
        }

        private void sct_graph_angab_Click(object sender, EventArgs e)
        {
            focoused = false;
            sct_graph_angab.Panel1.Invalidate();
        }

        private void lbl_hilfe_Click(object sender, EventArgs e)
        {
            
        }
    }
}
