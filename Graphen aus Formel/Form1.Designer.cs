namespace Graphen_aus_Formel
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.scb_j = new System.Windows.Forms.HScrollBar();
            this.scb_k = new System.Windows.Forms.HScrollBar();
            this.scb_l = new System.Windows.Forms.HScrollBar();
            this.tbx_j = new System.Windows.Forms.TextBox();
            this.tbx_k = new System.Windows.Forms.TextBox();
            this.tbx_l = new System.Windows.Forms.TextBox();
            this.tbx_scroll_j_an = new System.Windows.Forms.TextBox();
            this.tbx_scroll_k_an = new System.Windows.Forms.TextBox();
            this.tbx_scroll_l_an = new System.Windows.Forms.TextBox();
            this.tbx_scroll_l_en = new System.Windows.Forms.TextBox();
            this.tbx_scroll_k_en = new System.Windows.Forms.TextBox();
            this.tbx_scroll_j_en = new System.Windows.Forms.TextBox();
            this.tbx_x_achse = new System.Windows.Forms.TextBox();
            this.gbx_e_x = new System.Windows.Forms.GroupBox();
            this.ckb_e_x_manuell = new System.Windows.Forms.CheckBox();
            this.gbx_e_y = new System.Windows.Forms.GroupBox();
            this.ckb_e_y_manuell = new System.Windows.Forms.CheckBox();
            this.tbx_y_achse = new System.Windows.Forms.TextBox();
            this.gbx_einteilung = new System.Windows.Forms.GroupBox();
            this.gbx_bereich = new System.Windows.Forms.GroupBox();
            this.gbx_b_y = new System.Windows.Forms.GroupBox();
            this.ckb_b_y_bis = new System.Windows.Forms.CheckBox();
            this.ckb_b_y_von = new System.Windows.Forms.CheckBox();
            this.tbx_y_bis = new System.Windows.Forms.TextBox();
            this.tbx_y_von = new System.Windows.Forms.TextBox();
            this.gbx_b_x = new System.Windows.Forms.GroupBox();
            this.ckb_b_x_bis = new System.Windows.Forms.CheckBox();
            this.ckb_b_x_von = new System.Windows.Forms.CheckBox();
            this.tbx_x_bis = new System.Windows.Forms.TextBox();
            this.tbx_x_von = new System.Windows.Forms.TextBox();
            this.gbx_null = new System.Windows.Forms.GroupBox();
            this.gbx_m_x = new System.Windows.Forms.GroupBox();
            this.ckb_n_x_manuell = new System.Windows.Forms.CheckBox();
            this.tbx_null_x = new System.Windows.Forms.TextBox();
            this.gbx_m_y = new System.Windows.Forms.GroupBox();
            this.ckb_n_y_manuell = new System.Windows.Forms.CheckBox();
            this.tbx_null_y = new System.Windows.Forms.TextBox();
            this.ckb_x_y = new System.Windows.Forms.CheckBox();
            this.tbx_verhaltnis = new System.Windows.Forms.TextBox();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.sct_graph_angab = new System.Windows.Forms.SplitContainer();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lbl_hilfe = new System.Windows.Forms.Label();
            this.gbx_variablen = new System.Windows.Forms.GroupBox();
            this.gbx_j = new System.Windows.Forms.GroupBox();
            this.gbx_l = new System.Windows.Forms.GroupBox();
            this.gbx_k = new System.Windows.Forms.GroupBox();
            this.gbx_koor = new System.Windows.Forms.GroupBox();
            this.btn_losch = new System.Windows.Forms.Button();
            this.btn_ab = new System.Windows.Forms.Button();
            this.btn_auf = new System.Windows.Forms.Button();
            this.btn_neu = new System.Windows.Forms.Button();
            this.btn_edit = new System.Windows.Forms.Button();
            this.Anzeigen = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Name_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Formel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbx_e_x.SuspendLayout();
            this.gbx_e_y.SuspendLayout();
            this.gbx_einteilung.SuspendLayout();
            this.gbx_bereich.SuspendLayout();
            this.gbx_b_y.SuspendLayout();
            this.gbx_b_x.SuspendLayout();
            this.gbx_null.SuspendLayout();
            this.gbx_m_x.SuspendLayout();
            this.gbx_m_y.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sct_graph_angab)).BeginInit();
            this.sct_graph_angab.Panel1.SuspendLayout();
            this.sct_graph_angab.Panel2.SuspendLayout();
            this.sct_graph_angab.SuspendLayout();
            this.gbx_variablen.SuspendLayout();
            this.gbx_j.SuspendLayout();
            this.gbx_l.SuspendLayout();
            this.gbx_k.SuspendLayout();
            this.gbx_koor.SuspendLayout();
            this.SuspendLayout();
            // 
            // scb_j
            // 
            this.scb_j.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.scb_j.Location = new System.Drawing.Point(6, 39);
            this.scb_j.Name = "scb_j";
            this.scb_j.Size = new System.Drawing.Size(149, 20);
            this.scb_j.TabIndex = 8;
            this.scb_j.ValueChanged += new System.EventHandler(this.scb_Scroll);
            // 
            // scb_k
            // 
            this.scb_k.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.scb_k.Location = new System.Drawing.Point(6, 38);
            this.scb_k.Name = "scb_k";
            this.scb_k.Size = new System.Drawing.Size(149, 22);
            this.scb_k.TabIndex = 9;
            this.scb_k.ValueChanged += new System.EventHandler(this.scb_Scroll);
            // 
            // scb_l
            // 
            this.scb_l.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.scb_l.Location = new System.Drawing.Point(6, 38);
            this.scb_l.Name = "scb_l";
            this.scb_l.Size = new System.Drawing.Size(149, 20);
            this.scb_l.TabIndex = 10;
            this.scb_l.ValueChanged += new System.EventHandler(this.scb_Scroll);
            // 
            // tbx_j
            // 
            this.tbx_j.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbx_j.Location = new System.Drawing.Point(56, 16);
            this.tbx_j.Name = "tbx_j";
            this.tbx_j.Size = new System.Drawing.Size(49, 20);
            this.tbx_j.TabIndex = 2;
            this.tbx_j.Leave += new System.EventHandler(this.tbx_vari_Leave);
            // 
            // tbx_k
            // 
            this.tbx_k.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbx_k.Location = new System.Drawing.Point(56, 15);
            this.tbx_k.Name = "tbx_k";
            this.tbx_k.Size = new System.Drawing.Size(49, 20);
            this.tbx_k.TabIndex = 3;
            this.tbx_k.Leave += new System.EventHandler(this.tbx_vari_Leave);
            // 
            // tbx_l
            // 
            this.tbx_l.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbx_l.Location = new System.Drawing.Point(56, 15);
            this.tbx_l.Name = "tbx_l";
            this.tbx_l.Size = new System.Drawing.Size(49, 20);
            this.tbx_l.TabIndex = 4;
            this.tbx_l.Leave += new System.EventHandler(this.tbx_vari_Leave);
            // 
            // tbx_scroll_j_an
            // 
            this.tbx_scroll_j_an.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbx_scroll_j_an.Location = new System.Drawing.Point(6, 16);
            this.tbx_scroll_j_an.Name = "tbx_scroll_j_an";
            this.tbx_scroll_j_an.Size = new System.Drawing.Size(44, 20);
            this.tbx_scroll_j_an.TabIndex = 5;
            this.tbx_scroll_j_an.Text = "0";
            this.tbx_scroll_j_an.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbx_scroll_j_an.Leave += new System.EventHandler(this.tbx_scroll_Leave);
            // 
            // tbx_scroll_k_an
            // 
            this.tbx_scroll_k_an.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbx_scroll_k_an.Location = new System.Drawing.Point(6, 15);
            this.tbx_scroll_k_an.Name = "tbx_scroll_k_an";
            this.tbx_scroll_k_an.Size = new System.Drawing.Size(44, 20);
            this.tbx_scroll_k_an.TabIndex = 6;
            this.tbx_scroll_k_an.Text = "0";
            this.tbx_scroll_k_an.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbx_scroll_k_an.Leave += new System.EventHandler(this.tbx_scroll_Leave);
            // 
            // tbx_scroll_l_an
            // 
            this.tbx_scroll_l_an.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbx_scroll_l_an.Location = new System.Drawing.Point(6, 15);
            this.tbx_scroll_l_an.Name = "tbx_scroll_l_an";
            this.tbx_scroll_l_an.Size = new System.Drawing.Size(44, 20);
            this.tbx_scroll_l_an.TabIndex = 7;
            this.tbx_scroll_l_an.Text = "0";
            this.tbx_scroll_l_an.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbx_scroll_l_an.Leave += new System.EventHandler(this.tbx_scroll_Leave);
            // 
            // tbx_scroll_l_en
            // 
            this.tbx_scroll_l_en.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbx_scroll_l_en.Location = new System.Drawing.Point(111, 15);
            this.tbx_scroll_l_en.Name = "tbx_scroll_l_en";
            this.tbx_scroll_l_en.Size = new System.Drawing.Size(44, 20);
            this.tbx_scroll_l_en.TabIndex = 13;
            this.tbx_scroll_l_en.Text = "100";
            this.tbx_scroll_l_en.Leave += new System.EventHandler(this.tbx_scroll_Leave);
            // 
            // tbx_scroll_k_en
            // 
            this.tbx_scroll_k_en.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbx_scroll_k_en.Location = new System.Drawing.Point(111, 15);
            this.tbx_scroll_k_en.Name = "tbx_scroll_k_en";
            this.tbx_scroll_k_en.Size = new System.Drawing.Size(44, 20);
            this.tbx_scroll_k_en.TabIndex = 12;
            this.tbx_scroll_k_en.Text = "100";
            this.tbx_scroll_k_en.Leave += new System.EventHandler(this.tbx_scroll_Leave);
            // 
            // tbx_scroll_j_en
            // 
            this.tbx_scroll_j_en.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbx_scroll_j_en.Location = new System.Drawing.Point(111, 16);
            this.tbx_scroll_j_en.Name = "tbx_scroll_j_en";
            this.tbx_scroll_j_en.Size = new System.Drawing.Size(44, 20);
            this.tbx_scroll_j_en.TabIndex = 11;
            this.tbx_scroll_j_en.Text = "100";
            this.tbx_scroll_j_en.Leave += new System.EventHandler(this.tbx_scroll_Leave);
            // 
            // tbx_x_achse
            // 
            this.tbx_x_achse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbx_x_achse.Location = new System.Drawing.Point(6, 40);
            this.tbx_x_achse.Name = "tbx_x_achse";
            this.tbx_x_achse.Size = new System.Drawing.Size(63, 20);
            this.tbx_x_achse.TabIndex = 16;
            this.tbx_x_achse.Leave += new System.EventHandler(this.tbx_Steuerung_Leave);
            // 
            // gbx_e_x
            // 
            this.gbx_e_x.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbx_e_x.Controls.Add(this.ckb_e_x_manuell);
            this.gbx_e_x.Controls.Add(this.tbx_x_achse);
            this.gbx_e_x.Location = new System.Drawing.Point(6, 19);
            this.gbx_e_x.Name = "gbx_e_x";
            this.gbx_e_x.Size = new System.Drawing.Size(75, 67);
            this.gbx_e_x.TabIndex = 122;
            this.gbx_e_x.TabStop = false;
            this.gbx_e_x.Text = "X-Achse";
            // 
            // ckb_e_x_manuell
            // 
            this.ckb_e_x_manuell.AutoSize = true;
            this.ckb_e_x_manuell.Checked = true;
            this.ckb_e_x_manuell.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckb_e_x_manuell.Enabled = false;
            this.ckb_e_x_manuell.Location = new System.Drawing.Point(6, 17);
            this.ckb_e_x_manuell.Name = "ckb_e_x_manuell";
            this.ckb_e_x_manuell.Size = new System.Drawing.Size(63, 17);
            this.ckb_e_x_manuell.TabIndex = 15;
            this.ckb_e_x_manuell.Text = "Manuell";
            this.ckb_e_x_manuell.UseVisualStyleBackColor = true;
            this.ckb_e_x_manuell.CheckedChanged += new System.EventHandler(this.Sterung_CheckedChanged);
            // 
            // gbx_e_y
            // 
            this.gbx_e_y.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbx_e_y.Controls.Add(this.ckb_e_y_manuell);
            this.gbx_e_y.Controls.Add(this.tbx_y_achse);
            this.gbx_e_y.Location = new System.Drawing.Point(87, 19);
            this.gbx_e_y.Name = "gbx_e_y";
            this.gbx_e_y.Size = new System.Drawing.Size(75, 67);
            this.gbx_e_y.TabIndex = 122;
            this.gbx_e_y.TabStop = false;
            this.gbx_e_y.Text = "Y-Achse";
            // 
            // ckb_e_y_manuell
            // 
            this.ckb_e_y_manuell.AutoSize = true;
            this.ckb_e_y_manuell.Checked = true;
            this.ckb_e_y_manuell.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckb_e_y_manuell.Location = new System.Drawing.Point(6, 17);
            this.ckb_e_y_manuell.Name = "ckb_e_y_manuell";
            this.ckb_e_y_manuell.Size = new System.Drawing.Size(63, 17);
            this.ckb_e_y_manuell.TabIndex = 17;
            this.ckb_e_y_manuell.Text = "Manuell";
            this.ckb_e_y_manuell.UseVisualStyleBackColor = true;
            this.ckb_e_y_manuell.CheckedChanged += new System.EventHandler(this.Sterung_CheckedChanged);
            // 
            // tbx_y_achse
            // 
            this.tbx_y_achse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbx_y_achse.Location = new System.Drawing.Point(6, 40);
            this.tbx_y_achse.Name = "tbx_y_achse";
            this.tbx_y_achse.Size = new System.Drawing.Size(63, 20);
            this.tbx_y_achse.TabIndex = 18;
            this.tbx_y_achse.Leave += new System.EventHandler(this.tbx_Steuerung_Leave);
            // 
            // gbx_einteilung
            // 
            this.gbx_einteilung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbx_einteilung.Controls.Add(this.gbx_e_x);
            this.gbx_einteilung.Controls.Add(this.gbx_e_y);
            this.gbx_einteilung.Location = new System.Drawing.Point(6, 19);
            this.gbx_einteilung.Name = "gbx_einteilung";
            this.gbx_einteilung.Size = new System.Drawing.Size(168, 92);
            this.gbx_einteilung.TabIndex = 127;
            this.gbx_einteilung.TabStop = false;
            this.gbx_einteilung.Text = "Einteilungen";
            // 
            // gbx_bereich
            // 
            this.gbx_bereich.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbx_bereich.Controls.Add(this.gbx_b_y);
            this.gbx_bereich.Controls.Add(this.gbx_b_x);
            this.gbx_bereich.Location = new System.Drawing.Point(182, 19);
            this.gbx_bereich.Name = "gbx_bereich";
            this.gbx_bereich.Size = new System.Drawing.Size(122, 165);
            this.gbx_bereich.TabIndex = 127;
            this.gbx_bereich.TabStop = false;
            this.gbx_bereich.Text = "Bereich";
            // 
            // gbx_b_y
            // 
            this.gbx_b_y.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbx_b_y.Controls.Add(this.ckb_b_y_bis);
            this.gbx_b_y.Controls.Add(this.ckb_b_y_von);
            this.gbx_b_y.Controls.Add(this.tbx_y_bis);
            this.gbx_b_y.Controls.Add(this.tbx_y_von);
            this.gbx_b_y.Location = new System.Drawing.Point(6, 92);
            this.gbx_b_y.Name = "gbx_b_y";
            this.gbx_b_y.Size = new System.Drawing.Size(110, 67);
            this.gbx_b_y.TabIndex = 122;
            this.gbx_b_y.TabStop = false;
            this.gbx_b_y.Text = "Y-Achse";
            // 
            // ckb_b_y_bis
            // 
            this.ckb_b_y_bis.AutoSize = true;
            this.ckb_b_y_bis.Location = new System.Drawing.Point(6, 43);
            this.ckb_b_y_bis.Name = "ckb_b_y_bis";
            this.ckb_b_y_bis.Size = new System.Drawing.Size(39, 17);
            this.ckb_b_y_bis.TabIndex = 29;
            this.ckb_b_y_bis.Text = "bis";
            this.ckb_b_y_bis.UseVisualStyleBackColor = true;
            this.ckb_b_y_bis.CheckedChanged += new System.EventHandler(this.Sterung_CheckedChanged);
            // 
            // ckb_b_y_von
            // 
            this.ckb_b_y_von.AutoSize = true;
            this.ckb_b_y_von.Location = new System.Drawing.Point(6, 17);
            this.ckb_b_y_von.Name = "ckb_b_y_von";
            this.ckb_b_y_von.Size = new System.Drawing.Size(44, 17);
            this.ckb_b_y_von.TabIndex = 27;
            this.ckb_b_y_von.Text = "von";
            this.ckb_b_y_von.UseVisualStyleBackColor = true;
            this.ckb_b_y_von.CheckedChanged += new System.EventHandler(this.Sterung_CheckedChanged);
            // 
            // tbx_y_bis
            // 
            this.tbx_y_bis.Enabled = false;
            this.tbx_y_bis.Location = new System.Drawing.Point(50, 41);
            this.tbx_y_bis.Name = "tbx_y_bis";
            this.tbx_y_bis.Size = new System.Drawing.Size(54, 20);
            this.tbx_y_bis.TabIndex = 30;
            this.tbx_y_bis.Text = "10";
            this.tbx_y_bis.Leave += new System.EventHandler(this.tbx_Steuerung_Leave);
            // 
            // tbx_y_von
            // 
            this.tbx_y_von.Enabled = false;
            this.tbx_y_von.Location = new System.Drawing.Point(50, 15);
            this.tbx_y_von.Name = "tbx_y_von";
            this.tbx_y_von.Size = new System.Drawing.Size(54, 20);
            this.tbx_y_von.TabIndex = 28;
            this.tbx_y_von.Text = "-10";
            this.tbx_y_von.Leave += new System.EventHandler(this.tbx_Steuerung_Leave);
            // 
            // gbx_b_x
            // 
            this.gbx_b_x.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbx_b_x.Controls.Add(this.ckb_b_x_bis);
            this.gbx_b_x.Controls.Add(this.ckb_b_x_von);
            this.gbx_b_x.Controls.Add(this.tbx_x_bis);
            this.gbx_b_x.Controls.Add(this.tbx_x_von);
            this.gbx_b_x.Location = new System.Drawing.Point(6, 19);
            this.gbx_b_x.Name = "gbx_b_x";
            this.gbx_b_x.Size = new System.Drawing.Size(110, 67);
            this.gbx_b_x.TabIndex = 122;
            this.gbx_b_x.TabStop = false;
            this.gbx_b_x.Text = "X-Achse";
            // 
            // ckb_b_x_bis
            // 
            this.ckb_b_x_bis.AutoSize = true;
            this.ckb_b_x_bis.Location = new System.Drawing.Point(6, 43);
            this.ckb_b_x_bis.Name = "ckb_b_x_bis";
            this.ckb_b_x_bis.Size = new System.Drawing.Size(39, 17);
            this.ckb_b_x_bis.TabIndex = 25;
            this.ckb_b_x_bis.Text = "bis";
            this.ckb_b_x_bis.UseVisualStyleBackColor = true;
            this.ckb_b_x_bis.CheckedChanged += new System.EventHandler(this.Sterung_CheckedChanged);
            // 
            // ckb_b_x_von
            // 
            this.ckb_b_x_von.AutoSize = true;
            this.ckb_b_x_von.Location = new System.Drawing.Point(6, 17);
            this.ckb_b_x_von.Name = "ckb_b_x_von";
            this.ckb_b_x_von.Size = new System.Drawing.Size(44, 17);
            this.ckb_b_x_von.TabIndex = 23;
            this.ckb_b_x_von.Text = "von";
            this.ckb_b_x_von.UseVisualStyleBackColor = true;
            this.ckb_b_x_von.CheckedChanged += new System.EventHandler(this.Sterung_CheckedChanged);
            // 
            // tbx_x_bis
            // 
            this.tbx_x_bis.Enabled = false;
            this.tbx_x_bis.Location = new System.Drawing.Point(50, 41);
            this.tbx_x_bis.Name = "tbx_x_bis";
            this.tbx_x_bis.Size = new System.Drawing.Size(54, 20);
            this.tbx_x_bis.TabIndex = 26;
            this.tbx_x_bis.Text = "10";
            this.tbx_x_bis.Leave += new System.EventHandler(this.tbx_Steuerung_Leave);
            // 
            // tbx_x_von
            // 
            this.tbx_x_von.Enabled = false;
            this.tbx_x_von.Location = new System.Drawing.Point(50, 15);
            this.tbx_x_von.Name = "tbx_x_von";
            this.tbx_x_von.Size = new System.Drawing.Size(54, 20);
            this.tbx_x_von.TabIndex = 24;
            this.tbx_x_von.Text = "-10";
            this.tbx_x_von.Leave += new System.EventHandler(this.tbx_Steuerung_Leave);
            // 
            // gbx_null
            // 
            this.gbx_null.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbx_null.Controls.Add(this.gbx_m_x);
            this.gbx_null.Controls.Add(this.gbx_m_y);
            this.gbx_null.Location = new System.Drawing.Point(6, 117);
            this.gbx_null.Name = "gbx_null";
            this.gbx_null.Size = new System.Drawing.Size(168, 92);
            this.gbx_null.TabIndex = 127;
            this.gbx_null.TabStop = false;
            this.gbx_null.Text = "Mittelpunkt";
            // 
            // gbx_m_x
            // 
            this.gbx_m_x.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbx_m_x.Controls.Add(this.ckb_n_x_manuell);
            this.gbx_m_x.Controls.Add(this.tbx_null_x);
            this.gbx_m_x.Location = new System.Drawing.Point(6, 19);
            this.gbx_m_x.Name = "gbx_m_x";
            this.gbx_m_x.Size = new System.Drawing.Size(75, 67);
            this.gbx_m_x.TabIndex = 122;
            this.gbx_m_x.TabStop = false;
            this.gbx_m_x.Text = "X-Achse";
            // 
            // ckb_n_x_manuell
            // 
            this.ckb_n_x_manuell.AutoSize = true;
            this.ckb_n_x_manuell.Location = new System.Drawing.Point(6, 18);
            this.ckb_n_x_manuell.Name = "ckb_n_x_manuell";
            this.ckb_n_x_manuell.Size = new System.Drawing.Size(63, 17);
            this.ckb_n_x_manuell.TabIndex = 19;
            this.ckb_n_x_manuell.Text = "Manuell";
            this.ckb_n_x_manuell.UseVisualStyleBackColor = true;
            this.ckb_n_x_manuell.CheckedChanged += new System.EventHandler(this.Sterung_CheckedChanged);
            // 
            // tbx_null_x
            // 
            this.tbx_null_x.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbx_null_x.Enabled = false;
            this.tbx_null_x.Location = new System.Drawing.Point(6, 41);
            this.tbx_null_x.Name = "tbx_null_x";
            this.tbx_null_x.Size = new System.Drawing.Size(63, 20);
            this.tbx_null_x.TabIndex = 20;
            this.tbx_null_x.Text = "0";
            this.tbx_null_x.Leave += new System.EventHandler(this.tbx_Steuerung_Leave);
            // 
            // gbx_m_y
            // 
            this.gbx_m_y.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbx_m_y.Controls.Add(this.ckb_n_y_manuell);
            this.gbx_m_y.Controls.Add(this.tbx_null_y);
            this.gbx_m_y.Location = new System.Drawing.Point(87, 19);
            this.gbx_m_y.Name = "gbx_m_y";
            this.gbx_m_y.Size = new System.Drawing.Size(75, 67);
            this.gbx_m_y.TabIndex = 122;
            this.gbx_m_y.TabStop = false;
            this.gbx_m_y.Text = "Y-Achse";
            // 
            // ckb_n_y_manuell
            // 
            this.ckb_n_y_manuell.AutoSize = true;
            this.ckb_n_y_manuell.Location = new System.Drawing.Point(6, 18);
            this.ckb_n_y_manuell.Name = "ckb_n_y_manuell";
            this.ckb_n_y_manuell.Size = new System.Drawing.Size(63, 17);
            this.ckb_n_y_manuell.TabIndex = 21;
            this.ckb_n_y_manuell.Text = "Manuell";
            this.ckb_n_y_manuell.UseVisualStyleBackColor = true;
            this.ckb_n_y_manuell.CheckedChanged += new System.EventHandler(this.Sterung_CheckedChanged);
            // 
            // tbx_null_y
            // 
            this.tbx_null_y.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbx_null_y.Enabled = false;
            this.tbx_null_y.Location = new System.Drawing.Point(6, 41);
            this.tbx_null_y.Name = "tbx_null_y";
            this.tbx_null_y.Size = new System.Drawing.Size(63, 20);
            this.tbx_null_y.TabIndex = 22;
            this.tbx_null_y.Text = "0";
            this.tbx_null_y.Leave += new System.EventHandler(this.tbx_Steuerung_Leave);
            // 
            // ckb_x_y
            // 
            this.ckb_x_y.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ckb_x_y.AutoSize = true;
            this.ckb_x_y.Location = new System.Drawing.Point(194, 190);
            this.ckb_x_y.Name = "ckb_x_y";
            this.ckb_x_y.Size = new System.Drawing.Size(58, 17);
            this.ckb_x_y.TabIndex = 31;
            this.ckb_x_y.Text = "y = x * ";
            this.ckb_x_y.UseVisualStyleBackColor = true;
            this.ckb_x_y.CheckedChanged += new System.EventHandler(this.Sterung_CheckedChanged);
            // 
            // tbx_verhaltnis
            // 
            this.tbx_verhaltnis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbx_verhaltnis.Enabled = false;
            this.tbx_verhaltnis.Location = new System.Drawing.Point(246, 190);
            this.tbx_verhaltnis.Name = "tbx_verhaltnis";
            this.tbx_verhaltnis.Size = new System.Drawing.Size(46, 20);
            this.tbx_verhaltnis.TabIndex = 32;
            this.tbx_verhaltnis.Text = "1";
            this.tbx_verhaltnis.Leave += new System.EventHandler(this.tbx_Steuerung_Leave);
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Anzeigen,
            this.Name_col,
            this.Formel});
            this.dgv.Location = new System.Drawing.Point(12, 3);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.Size = new System.Drawing.Size(325, 186);
            this.dgv.TabIndex = 128;
            this.dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellClick);
            this.dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellContentClick);
            this.dgv.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dgv_ColumnWidthChanged);
            this.dgv.Enter += new System.EventHandler(this.dgv_Enter);
            this.dgv.Leave += new System.EventHandler(this.dgv_Leave);
            // 
            // sct_graph_angab
            // 
            this.sct_graph_angab.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.sct_graph_angab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sct_graph_angab.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.sct_graph_angab.Location = new System.Drawing.Point(0, 0);
            this.sct_graph_angab.Name = "sct_graph_angab";
            this.sct_graph_angab.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // sct_graph_angab.Panel1
            // 
            this.sct_graph_angab.Panel1.Controls.Add(this.textBox1);
            this.sct_graph_angab.Panel1.Controls.Add(this.lbl_hilfe);
            this.sct_graph_angab.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.sct_graph_angab_Panel1_Paint);
            this.sct_graph_angab.Panel1MinSize = 100;
            // 
            // sct_graph_angab.Panel2
            // 
            this.sct_graph_angab.Panel2.AutoScroll = true;
            this.sct_graph_angab.Panel2.AutoScrollMinSize = new System.Drawing.Size(100, 230);
            this.sct_graph_angab.Panel2.Controls.Add(this.gbx_variablen);
            this.sct_graph_angab.Panel2.Controls.Add(this.gbx_koor);
            this.sct_graph_angab.Panel2.Controls.Add(this.btn_losch);
            this.sct_graph_angab.Panel2.Controls.Add(this.btn_ab);
            this.sct_graph_angab.Panel2.Controls.Add(this.dgv);
            this.sct_graph_angab.Panel2.Controls.Add(this.btn_auf);
            this.sct_graph_angab.Panel2.Controls.Add(this.btn_neu);
            this.sct_graph_angab.Panel2.Controls.Add(this.btn_edit);
            this.sct_graph_angab.Panel2MinSize = 100;
            this.sct_graph_angab.Size = new System.Drawing.Size(848, 436);
            this.sct_graph_angab.SplitterDistance = 198;
            this.sct_graph_angab.TabIndex = 130;
            this.sct_graph_angab.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.sct_graph_angab_SplitterMoved);
            this.sct_graph_angab.Click += new System.EventHandler(this.sct_graph_angab_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(45, 11);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "0";
            // 
            // lbl_hilfe
            // 
            this.lbl_hilfe.AutoSize = true;
            this.lbl_hilfe.Location = new System.Drawing.Point(10, 7);
            this.lbl_hilfe.Name = "lbl_hilfe";
            this.lbl_hilfe.Size = new System.Drawing.Size(28, 13);
            this.lbl_hilfe.TabIndex = 0;
            this.lbl_hilfe.Text = "Hilfe";
            this.lbl_hilfe.Click += new System.EventHandler(this.lbl_hilfe_Click);
            // 
            // gbx_variablen
            // 
            this.gbx_variablen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.gbx_variablen.Controls.Add(this.gbx_j);
            this.gbx_variablen.Controls.Add(this.gbx_l);
            this.gbx_variablen.Controls.Add(this.gbx_k);
            this.gbx_variablen.Location = new System.Drawing.Point(345, 3);
            this.gbx_variablen.Name = "gbx_variablen";
            this.gbx_variablen.Size = new System.Drawing.Size(173, 215);
            this.gbx_variablen.TabIndex = 133;
            this.gbx_variablen.TabStop = false;
            this.gbx_variablen.Text = "Variabeln";
            // 
            // gbx_j
            // 
            this.gbx_j.Controls.Add(this.scb_j);
            this.gbx_j.Controls.Add(this.tbx_scroll_j_an);
            this.gbx_j.Controls.Add(this.tbx_scroll_j_en);
            this.gbx_j.Controls.Add(this.tbx_j);
            this.gbx_j.Location = new System.Drawing.Point(6, 19);
            this.gbx_j.Name = "gbx_j";
            this.gbx_j.Size = new System.Drawing.Size(161, 64);
            this.gbx_j.TabIndex = 132;
            this.gbx_j.TabStop = false;
            this.gbx_j.Text = "j =";
            // 
            // gbx_l
            // 
            this.gbx_l.Controls.Add(this.tbx_scroll_l_an);
            this.gbx_l.Controls.Add(this.scb_l);
            this.gbx_l.Controls.Add(this.tbx_l);
            this.gbx_l.Controls.Add(this.tbx_scroll_l_en);
            this.gbx_l.Location = new System.Drawing.Point(6, 145);
            this.gbx_l.Name = "gbx_l";
            this.gbx_l.Size = new System.Drawing.Size(161, 64);
            this.gbx_l.TabIndex = 132;
            this.gbx_l.TabStop = false;
            this.gbx_l.Text = "l =";
            // 
            // gbx_k
            // 
            this.gbx_k.Controls.Add(this.tbx_scroll_k_an);
            this.gbx_k.Controls.Add(this.tbx_scroll_k_en);
            this.gbx_k.Controls.Add(this.scb_k);
            this.gbx_k.Controls.Add(this.tbx_k);
            this.gbx_k.Location = new System.Drawing.Point(6, 81);
            this.gbx_k.Name = "gbx_k";
            this.gbx_k.Size = new System.Drawing.Size(161, 64);
            this.gbx_k.TabIndex = 132;
            this.gbx_k.TabStop = false;
            this.gbx_k.Text = "k =";
            // 
            // gbx_koor
            // 
            this.gbx_koor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.gbx_koor.Controls.Add(this.gbx_null);
            this.gbx_koor.Controls.Add(this.gbx_einteilung);
            this.gbx_koor.Controls.Add(this.gbx_bereich);
            this.gbx_koor.Controls.Add(this.tbx_verhaltnis);
            this.gbx_koor.Controls.Add(this.ckb_x_y);
            this.gbx_koor.Location = new System.Drawing.Point(524, 5);
            this.gbx_koor.Name = "gbx_koor";
            this.gbx_koor.Size = new System.Drawing.Size(310, 215);
            this.gbx_koor.TabIndex = 131;
            this.gbx_koor.TabStop = false;
            this.gbx_koor.Text = "Koordinatensystem";
            // 
            // btn_losch
            // 
            this.btn_losch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_losch.Location = new System.Drawing.Point(163, 195);
            this.btn_losch.Name = "btn_losch";
            this.btn_losch.Size = new System.Drawing.Size(75, 23);
            this.btn_losch.TabIndex = 136;
            this.btn_losch.Text = "Löschen";
            this.btn_losch.UseVisualStyleBackColor = true;
            this.btn_losch.Click += new System.EventHandler(this.btn_losch_Click);
            // 
            // btn_ab
            // 
            this.btn_ab.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_ab.Location = new System.Drawing.Point(292, 195);
            this.btn_ab.Name = "btn_ab";
            this.btn_ab.Size = new System.Drawing.Size(45, 23);
            this.btn_ab.TabIndex = 136;
            this.btn_ab.Text = "Ab";
            this.btn_ab.UseVisualStyleBackColor = true;
            this.btn_ab.Click += new System.EventHandler(this.btn_ab_Click);
            // 
            // btn_auf
            // 
            this.btn_auf.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_auf.Location = new System.Drawing.Point(244, 195);
            this.btn_auf.Name = "btn_auf";
            this.btn_auf.Size = new System.Drawing.Size(45, 23);
            this.btn_auf.TabIndex = 136;
            this.btn_auf.Text = "Auf";
            this.btn_auf.UseVisualStyleBackColor = true;
            this.btn_auf.Click += new System.EventHandler(this.btn_auf_Click);
            // 
            // btn_neu
            // 
            this.btn_neu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_neu.Location = new System.Drawing.Point(10, 195);
            this.btn_neu.Name = "btn_neu";
            this.btn_neu.Size = new System.Drawing.Size(66, 23);
            this.btn_neu.TabIndex = 136;
            this.btn_neu.Text = "Neu";
            this.btn_neu.UseVisualStyleBackColor = true;
            this.btn_neu.Click += new System.EventHandler(this.btn_neu_Click);
            // 
            // btn_edit
            // 
            this.btn_edit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_edit.Location = new System.Drawing.Point(82, 195);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(75, 23);
            this.btn_edit.TabIndex = 136;
            this.btn_edit.Text = "Bearbeiten";
            this.btn_edit.UseVisualStyleBackColor = true;
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
            // 
            // Anzeigen
            // 
            this.Anzeigen.FillWeight = 30.45685F;
            this.Anzeigen.HeaderText = "";
            this.Anzeigen.Name = "Anzeigen";
            this.Anzeigen.ReadOnly = true;
            this.Anzeigen.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Anzeigen.Width = 20;
            // 
            // Name_col
            // 
            this.Name_col.HeaderText = "Name";
            this.Name_col.Name = "Name_col";
            this.Name_col.ReadOnly = true;
            // 
            // Formel
            // 
            this.Formel.FillWeight = 134.7716F;
            this.Formel.HeaderText = "Formel";
            this.Formel.Name = "Formel";
            this.Formel.ReadOnly = true;
            this.Formel.Width = 202;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 436);
            this.Controls.Add(this.sct_graph_angab);
            this.MinimumSize = new System.Drawing.Size(862, 420);
            this.Name = "Form1";
            this.Text = "Graphomat";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResizeBegin += new System.EventHandler(this.Form1_ResizeBegin);
            this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.gbx_e_x.ResumeLayout(false);
            this.gbx_e_x.PerformLayout();
            this.gbx_e_y.ResumeLayout(false);
            this.gbx_e_y.PerformLayout();
            this.gbx_einteilung.ResumeLayout(false);
            this.gbx_bereich.ResumeLayout(false);
            this.gbx_b_y.ResumeLayout(false);
            this.gbx_b_y.PerformLayout();
            this.gbx_b_x.ResumeLayout(false);
            this.gbx_b_x.PerformLayout();
            this.gbx_null.ResumeLayout(false);
            this.gbx_m_x.ResumeLayout(false);
            this.gbx_m_x.PerformLayout();
            this.gbx_m_y.ResumeLayout(false);
            this.gbx_m_y.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.sct_graph_angab.Panel1.ResumeLayout(false);
            this.sct_graph_angab.Panel1.PerformLayout();
            this.sct_graph_angab.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sct_graph_angab)).EndInit();
            this.sct_graph_angab.ResumeLayout(false);
            this.gbx_variablen.ResumeLayout(false);
            this.gbx_j.ResumeLayout(false);
            this.gbx_j.PerformLayout();
            this.gbx_l.ResumeLayout(false);
            this.gbx_l.PerformLayout();
            this.gbx_k.ResumeLayout(false);
            this.gbx_k.PerformLayout();
            this.gbx_koor.ResumeLayout(false);
            this.gbx_koor.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.HScrollBar scb_j;
        private System.Windows.Forms.HScrollBar scb_k;
        private System.Windows.Forms.HScrollBar scb_l;
        private System.Windows.Forms.TextBox tbx_j;
        private System.Windows.Forms.TextBox tbx_k;
        private System.Windows.Forms.TextBox tbx_l;
        private System.Windows.Forms.TextBox tbx_scroll_j_an;
        private System.Windows.Forms.TextBox tbx_scroll_k_an;
        private System.Windows.Forms.TextBox tbx_scroll_l_an;
        private System.Windows.Forms.TextBox tbx_scroll_l_en;
        private System.Windows.Forms.TextBox tbx_scroll_k_en;
        private System.Windows.Forms.TextBox tbx_scroll_j_en;
        private System.Windows.Forms.TextBox tbx_x_achse;
        private System.Windows.Forms.GroupBox gbx_e_x;
        private System.Windows.Forms.GroupBox gbx_e_y;
        private System.Windows.Forms.TextBox tbx_y_achse;
        private System.Windows.Forms.CheckBox ckb_e_y_manuell;
        private System.Windows.Forms.GroupBox gbx_einteilung;
        private System.Windows.Forms.GroupBox gbx_bereich;
        private System.Windows.Forms.GroupBox gbx_b_y;
        private System.Windows.Forms.TextBox tbx_y_bis;
        private System.Windows.Forms.TextBox tbx_y_von;
        private System.Windows.Forms.GroupBox gbx_b_x;
        private System.Windows.Forms.TextBox tbx_x_bis;
        private System.Windows.Forms.TextBox tbx_x_von;
        private System.Windows.Forms.GroupBox gbx_null;
        private System.Windows.Forms.GroupBox gbx_m_x;
        private System.Windows.Forms.CheckBox ckb_n_x_manuell;
        private System.Windows.Forms.TextBox tbx_null_x;
        private System.Windows.Forms.GroupBox gbx_m_y;
        private System.Windows.Forms.CheckBox ckb_n_y_manuell;
        private System.Windows.Forms.TextBox tbx_null_y;
        private System.Windows.Forms.CheckBox ckb_e_x_manuell;
        private System.Windows.Forms.CheckBox ckb_x_y;
        private System.Windows.Forms.CheckBox ckb_b_y_bis;
        private System.Windows.Forms.CheckBox ckb_b_y_von;
        private System.Windows.Forms.CheckBox ckb_b_x_bis;
        private System.Windows.Forms.CheckBox ckb_b_x_von;
        private System.Windows.Forms.TextBox tbx_verhaltnis;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.SplitContainer sct_graph_angab;
        private System.Windows.Forms.GroupBox gbx_koor;
        private System.Windows.Forms.GroupBox gbx_l;
        private System.Windows.Forms.GroupBox gbx_j;
        private System.Windows.Forms.GroupBox gbx_k;
        private System.Windows.Forms.GroupBox gbx_variablen;
        private System.Windows.Forms.Button btn_neu;
        private System.Windows.Forms.Button btn_edit;
        private System.Windows.Forms.Button btn_losch;
        private System.Windows.Forms.Button btn_auf;
        private System.Windows.Forms.Button btn_ab;
        private System.Windows.Forms.Label lbl_hilfe;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Anzeigen;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name_col;
        private System.Windows.Forms.DataGridViewTextBoxColumn Formel;
    }
}

