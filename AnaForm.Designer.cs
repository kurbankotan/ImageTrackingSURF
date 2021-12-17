namespace SURF
{
    partial class AnaForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnaForm));
            this.Resim = new Emgu.CV.UI.ImageBox();
            this.group_KaynakSec = new System.Windows.Forms.GroupBox();
            this.radioWebKamerasi = new System.Windows.Forms.RadioButton();
            this.radioResimDosyasi = new System.Windows.Forms.RadioButton();
            this.checkBox_OznitelikHatlari = new System.Windows.Forms.CheckBox();
            this.checkBox_OznitelikNoktalari = new System.Windows.Forms.CheckBox();
            this.buton_SURF_Uygula = new System.Windows.Forms.Button();
            this.buton_AranacakResimSec = new System.Windows.Forms.Button();
            this.buton_SahneSec = new System.Windows.Forms.Button();
            this.text_AranacakResimAdresi = new System.Windows.Forms.TextBox();
            this.text_SahneAdresi = new System.Windows.Forms.TextBox();
            this.labelAranacakNesne = new System.Windows.Forms.Label();
            this.labelSahne = new System.Windows.Forms.Label();
            this.OpenFileDialog_SahneResmiSec = new System.Windows.Forms.OpenFileDialog();
            this.OpenFileDialog_AranacakResmiSec = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.Resim)).BeginInit();
            this.group_KaynakSec.SuspendLayout();
            this.SuspendLayout();
            // 
            // Resim
            // 
            this.Resim.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Resim.Cursor = System.Windows.Forms.Cursors.Cross;
            this.Resim.Location = new System.Drawing.Point(10, 78);
            this.Resim.Name = "Resim";
            this.Resim.Size = new System.Drawing.Size(1094, 523);
            this.Resim.TabIndex = 12;
            this.Resim.TabStop = false;
            // 
            // group_KaynakSec
            // 
            this.group_KaynakSec.Controls.Add(this.radioWebKamerasi);
            this.group_KaynakSec.Controls.Add(this.radioResimDosyasi);
            this.group_KaynakSec.Location = new System.Drawing.Point(10, 7);
            this.group_KaynakSec.Name = "group_KaynakSec";
            this.group_KaynakSec.Size = new System.Drawing.Size(225, 56);
            this.group_KaynakSec.TabIndex = 10;
            this.group_KaynakSec.TabStop = false;
            this.group_KaynakSec.Text = "Resmin Kaynağını Seçin";
            // 
            // radioWebKamerasi
            // 
            this.radioWebKamerasi.AutoSize = true;
            this.radioWebKamerasi.Location = new System.Drawing.Point(95, 19);
            this.radioWebKamerasi.Name = "radioWebKamerasi";
            this.radioWebKamerasi.Size = new System.Drawing.Size(94, 17);
            this.radioWebKamerasi.TabIndex = 1;
            this.radioWebKamerasi.TabStop = true;
            this.radioWebKamerasi.Text = "Web Kamerası";
            this.radioWebKamerasi.UseVisualStyleBackColor = true;
            this.radioWebKamerasi.CheckedChanged += new System.EventHandler(this.radioWebKamerasi_CheckedChanged);
            // 
            // radioResimDosyasi
            // 
            this.radioResimDosyasi.AutoSize = true;
            this.radioResimDosyasi.Checked = true;
            this.radioResimDosyasi.Location = new System.Drawing.Point(21, 20);
            this.radioResimDosyasi.Name = "radioResimDosyasi";
            this.radioResimDosyasi.Size = new System.Drawing.Size(55, 17);
            this.radioResimDosyasi.TabIndex = 0;
            this.radioResimDosyasi.TabStop = true;
            this.radioResimDosyasi.Text = "Dosya";
            this.radioResimDosyasi.UseVisualStyleBackColor = true;
            this.radioResimDosyasi.CheckedChanged += new System.EventHandler(this.radioResimDosyasi_CheckedChanged);
            // 
            // checkBox_OznitelikHatlari
            // 
            this.checkBox_OznitelikHatlari.AutoSize = true;
            this.checkBox_OznitelikHatlari.Checked = true;
            this.checkBox_OznitelikHatlari.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_OznitelikHatlari.Location = new System.Drawing.Point(675, 36);
            this.checkBox_OznitelikHatlari.Name = "checkBox_OznitelikHatlari";
            this.checkBox_OznitelikHatlari.Size = new System.Drawing.Size(204, 17);
            this.checkBox_OznitelikHatlari.TabIndex = 20;
            this.checkBox_OznitelikHatlari.Text = "Öznitelikleri Eşleştirme Hatlarını Göster";
            this.checkBox_OznitelikHatlari.UseVisualStyleBackColor = true;
            this.checkBox_OznitelikHatlari.CheckedChanged += new System.EventHandler(this.checkBox_OznitelikHatlari_CheckedChanged);
            // 
            // checkBox_OznitelikNoktalari
            // 
            this.checkBox_OznitelikNoktalari.AutoSize = true;
            this.checkBox_OznitelikNoktalari.Checked = true;
            this.checkBox_OznitelikNoktalari.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_OznitelikNoktalari.Location = new System.Drawing.Point(675, 15);
            this.checkBox_OznitelikNoktalari.Name = "checkBox_OznitelikNoktalari";
            this.checkBox_OznitelikNoktalari.Size = new System.Drawing.Size(141, 17);
            this.checkBox_OznitelikNoktalari.TabIndex = 19;
            this.checkBox_OznitelikNoktalari.Text = "Öznitelik Notlarını Göster";
            this.checkBox_OznitelikNoktalari.UseVisualStyleBackColor = true;
            this.checkBox_OznitelikNoktalari.CheckedChanged += new System.EventHandler(this.checkBox_OznitelikNoktalari_CheckedChanged);
            // 
            // buton_SURF_Uygula
            // 
            this.buton_SURF_Uygula.Location = new System.Drawing.Point(887, 7);
            this.buton_SURF_Uygula.Name = "buton_SURF_Uygula";
            this.buton_SURF_Uygula.Size = new System.Drawing.Size(197, 53);
            this.buton_SURF_Uygula.TabIndex = 18;
            this.buton_SURF_Uygula.Text = "SURF Algoritmasını Uygula";
            this.buton_SURF_Uygula.UseVisualStyleBackColor = true;
            this.buton_SURF_Uygula.Click += new System.EventHandler(this.buton_SURF_Uygula_Click);
            // 
            // buton_AranacakResimSec
            // 
            this.buton_AranacakResimSec.Location = new System.Drawing.Point(633, 36);
            this.buton_AranacakResimSec.Name = "buton_AranacakResimSec";
            this.buton_AranacakResimSec.Size = new System.Drawing.Size(22, 23);
            this.buton_AranacakResimSec.TabIndex = 17;
            this.buton_AranacakResimSec.Text = "...";
            this.buton_AranacakResimSec.UseVisualStyleBackColor = true;
            this.buton_AranacakResimSec.Click += new System.EventHandler(this.buton_AranacakResimSec_Click);
            // 
            // buton_SahneSec
            // 
            this.buton_SahneSec.Location = new System.Drawing.Point(633, 9);
            this.buton_SahneSec.Name = "buton_SahneSec";
            this.buton_SahneSec.Size = new System.Drawing.Size(22, 23);
            this.buton_SahneSec.TabIndex = 16;
            this.buton_SahneSec.Text = "...";
            this.buton_SahneSec.UseVisualStyleBackColor = true;
            this.buton_SahneSec.Click += new System.EventHandler(this.buton_SahneSec_Click);
            // 
            // text_AranacakResimAdresi
            // 
            this.text_AranacakResimAdresi.Location = new System.Drawing.Point(431, 37);
            this.text_AranacakResimAdresi.Name = "text_AranacakResimAdresi";
            this.text_AranacakResimAdresi.Size = new System.Drawing.Size(196, 20);
            this.text_AranacakResimAdresi.TabIndex = 15;
            this.text_AranacakResimAdresi.TextChanged += new System.EventHandler(this.text_AranacakResimAdresi_TextChanged);
            // 
            // text_SahneAdresi
            // 
            this.text_SahneAdresi.Location = new System.Drawing.Point(431, 11);
            this.text_SahneAdresi.Name = "text_SahneAdresi";
            this.text_SahneAdresi.Size = new System.Drawing.Size(196, 20);
            this.text_SahneAdresi.TabIndex = 14;
            this.text_SahneAdresi.TextChanged += new System.EventHandler(this.text_SahneAdresi_TextChanged);
            // 
            // labelAranacakNesne
            // 
            this.labelAranacakNesne.AutoSize = true;
            this.labelAranacakNesne.Location = new System.Drawing.Point(247, 40);
            this.labelAranacakNesne.Name = "labelAranacakNesne";
            this.labelAranacakNesne.Size = new System.Drawing.Size(184, 13);
            this.labelAranacakNesne.TabIndex = 13;
            this.labelAranacakNesne.Text = "Sahne İçinde Aranacak Resmi Seçin:";
            // 
            // labelSahne
            // 
            this.labelSahne.AutoSize = true;
            this.labelSahne.Location = new System.Drawing.Point(247, 14);
            this.labelSahne.Name = "labelSahne";
            this.labelSahne.Size = new System.Drawing.Size(106, 13);
            this.labelSahne.TabIndex = 11;
            this.labelSahne.Text = "Sahne Resmi Seçin :";
            // 
            // OpenFileDialog_SahneResmiSec
            // 
            this.OpenFileDialog_SahneResmiSec.FileName = "OpenFileDialog1";
            // 
            // OpenFileDialog_AranacakResmiSec
            // 
            this.OpenFileDialog_AranacakResmiSec.FileName = "OpenFileDialog2";
            // 
            // AnaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1118, 615);
            this.Controls.Add(this.Resim);
            this.Controls.Add(this.group_KaynakSec);
            this.Controls.Add(this.checkBox_OznitelikHatlari);
            this.Controls.Add(this.checkBox_OznitelikNoktalari);
            this.Controls.Add(this.buton_SURF_Uygula);
            this.Controls.Add(this.buton_AranacakResimSec);
            this.Controls.Add(this.buton_SahneSec);
            this.Controls.Add(this.text_AranacakResimAdresi);
            this.Controls.Add(this.text_SahneAdresi);
            this.Controls.Add(this.labelAranacakNesne);
            this.Controls.Add(this.labelSahne);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AnaForm";
            this.Text = "SURF";
            this.Resize += new System.EventHandler(this.AnaForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.Resim)).EndInit();
            this.group_KaynakSec.ResumeLayout(false);
            this.group_KaynakSec.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal Emgu.CV.UI.ImageBox Resim;
        internal System.Windows.Forms.GroupBox group_KaynakSec;
        internal System.Windows.Forms.RadioButton radioWebKamerasi;
        internal System.Windows.Forms.RadioButton radioResimDosyasi;
        internal System.Windows.Forms.CheckBox checkBox_OznitelikHatlari;
        internal System.Windows.Forms.CheckBox checkBox_OznitelikNoktalari;
        internal System.Windows.Forms.Button buton_SURF_Uygula;
        internal System.Windows.Forms.Button buton_AranacakResimSec;
        internal System.Windows.Forms.Button buton_SahneSec;
        internal System.Windows.Forms.TextBox text_AranacakResimAdresi;
        internal System.Windows.Forms.TextBox text_SahneAdresi;
        internal System.Windows.Forms.Label labelAranacakNesne;
        internal System.Windows.Forms.Label labelSahne;
        internal System.Windows.Forms.OpenFileDialog OpenFileDialog_SahneResmiSec;
        internal System.Windows.Forms.OpenFileDialog OpenFileDialog_AranacakResmiSec;
    }
}

