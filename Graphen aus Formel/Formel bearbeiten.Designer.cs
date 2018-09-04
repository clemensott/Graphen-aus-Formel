namespace Graphen_aus_Formel
{
    partial class Formel_bearbeiten
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl_y = new System.Windows.Forms.Label();
            this.tbx_formel = new System.Windows.Forms.TextBox();
            this.lbl_formel = new System.Windows.Forms.Label();
            this.lbl_name = new System.Windows.Forms.Label();
            this.tbx_name = new System.Windows.Forms.TextBox();
            this.lbl_farbe = new System.Windows.Forms.Label();
            this.pbx_farbe = new System.Windows.Forms.PictureBox();
            this.btn_ok = new System.Windows.Forms.Button();
            this.btn_abb = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_farbe)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_y
            // 
            this.lbl_y.AutoSize = true;
            this.lbl_y.Location = new System.Drawing.Point(14, 79);
            this.lbl_y.Name = "lbl_y";
            this.lbl_y.Size = new System.Drawing.Size(21, 13);
            this.lbl_y.TabIndex = 115;
            this.lbl_y.Text = "y =";
            // 
            // tbx_formel
            // 
            this.tbx_formel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_formel.Location = new System.Drawing.Point(34, 76);
            this.tbx_formel.Name = "tbx_formel";
            this.tbx_formel.Size = new System.Drawing.Size(438, 20);
            this.tbx_formel.TabIndex = 1;
            // 
            // lbl_formel
            // 
            this.lbl_formel.AutoSize = true;
            this.lbl_formel.Location = new System.Drawing.Point(12, 60);
            this.lbl_formel.Name = "lbl_formel";
            this.lbl_formel.Size = new System.Drawing.Size(41, 13);
            this.lbl_formel.TabIndex = 116;
            this.lbl_formel.Text = "Formel:";
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Location = new System.Drawing.Point(12, 9);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(38, 13);
            this.lbl_name.TabIndex = 116;
            this.lbl_name.Text = "Name:";
            // 
            // tbx_name
            // 
            this.tbx_name.Location = new System.Drawing.Point(13, 26);
            this.tbx_name.Name = "tbx_name";
            this.tbx_name.Size = new System.Drawing.Size(155, 20);
            this.tbx_name.TabIndex = 0;
            // 
            // lbl_farbe
            // 
            this.lbl_farbe.AutoSize = true;
            this.lbl_farbe.Location = new System.Drawing.Point(12, 108);
            this.lbl_farbe.Name = "lbl_farbe";
            this.lbl_farbe.Size = new System.Drawing.Size(37, 13);
            this.lbl_farbe.TabIndex = 118;
            this.lbl_farbe.Text = "Farbe:";
            // 
            // pbx_farbe
            // 
            this.pbx_farbe.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pbx_farbe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbx_farbe.Location = new System.Drawing.Point(13, 125);
            this.pbx_farbe.Name = "pbx_farbe";
            this.pbx_farbe.Size = new System.Drawing.Size(74, 30);
            this.pbx_farbe.TabIndex = 120;
            this.pbx_farbe.TabStop = false;
            this.pbx_farbe.Click += new System.EventHandler(this.pbx_farbe_Click);
            // 
            // btn_ok
            // 
            this.btn_ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_ok.Location = new System.Drawing.Point(12, 177);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 3;
            this.btn_ok.Text = "OK";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // btn_abb
            // 
            this.btn_abb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_abb.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_abb.Location = new System.Drawing.Point(93, 177);
            this.btn_abb.Name = "btn_abb";
            this.btn_abb.Size = new System.Drawing.Size(75, 23);
            this.btn_abb.TabIndex = 4;
            this.btn_abb.Text = "Abbrechen";
            this.btn_abb.UseVisualStyleBackColor = true;
            this.btn_abb.Click += new System.EventHandler(this.btn_abb_Click);
            // 
            // Formel_bearbeiten
            // 
            this.AcceptButton = this.btn_ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_abb;
            this.ClientSize = new System.Drawing.Size(484, 212);
            this.Controls.Add(this.btn_abb);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.pbx_farbe);
            this.Controls.Add(this.lbl_farbe);
            this.Controls.Add(this.tbx_name);
            this.Controls.Add(this.lbl_name);
            this.Controls.Add(this.lbl_formel);
            this.Controls.Add(this.lbl_y);
            this.Controls.Add(this.tbx_formel);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(100000, 250);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(100, 250);
            this.Name = "Formel_bearbeiten";
            this.Text = "Formel bearbeiten";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Formel_bearbeiten_FormClosing);
            this.Load += new System.EventHandler(this.Formel_bearbeiten_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbx_farbe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_y;
        private System.Windows.Forms.Label lbl_formel;
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.Label lbl_farbe;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Button btn_abb;
        public System.Windows.Forms.PictureBox pbx_farbe;
        public System.Windows.Forms.TextBox tbx_formel;
        public System.Windows.Forms.TextBox tbx_name;
    }
}