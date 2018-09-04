namespace Graphen_aus_Formel
{
    partial class Zahl_Einlesen
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
            this.btn_ok = new System.Windows.Forms.Button();
            this.btn_abb = new System.Windows.Forms.Button();
            this.tbx_formel = new System.Windows.Forms.TextBox();
            this.lbl_name = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(12, 55);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 0;
            this.btn_ok.Text = "OK";
            this.btn_ok.UseVisualStyleBackColor = true;
            // 
            // btn_abb
            // 
            this.btn_abb.Location = new System.Drawing.Point(93, 55);
            this.btn_abb.Name = "btn_abb";
            this.btn_abb.Size = new System.Drawing.Size(75, 23);
            this.btn_abb.TabIndex = 1;
            this.btn_abb.Text = "Abbrechen";
            this.btn_abb.UseVisualStyleBackColor = true;
            // 
            // tbx_formel
            // 
            this.tbx_formel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_formel.Location = new System.Drawing.Point(12, 29);
            this.tbx_formel.Name = "tbx_formel";
            this.tbx_formel.Size = new System.Drawing.Size(345, 20);
            this.tbx_formel.TabIndex = 2;
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Location = new System.Drawing.Point(13, 13);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(38, 13);
            this.lbl_name.TabIndex = 3;
            this.lbl_name.Text = "Formel";
            // 
            // Zahl_Einlesen
            // 
            this.AcceptButton = this.btn_ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_abb;
            this.ClientSize = new System.Drawing.Size(369, 90);
            this.Controls.Add(this.lbl_name);
            this.Controls.Add(this.tbx_formel);
            this.Controls.Add(this.btn_abb);
            this.Controls.Add(this.btn_ok);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(10000, 128);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(197, 128);
            this.Name = "Zahl_Einlesen";
            this.Text = "Einlesen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Button btn_abb;
        private System.Windows.Forms.TextBox tbx_formel;
        private System.Windows.Forms.Label lbl_name;
    }
}