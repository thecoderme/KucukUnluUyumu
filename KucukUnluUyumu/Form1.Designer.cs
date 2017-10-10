namespace KucukUnluUyumu
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.Txt_kelimeGir = new System.Windows.Forms.TextBox();
            this.btn_kucukUnluUyumuKontrolEt = new System.Windows.Forms.Button();
            this.Txt_Durum = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(14, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kelime Gir:";
            // 
            // Txt_kelimeGir
            // 
            this.Txt_kelimeGir.Font = new System.Drawing.Font("Calibri", 12F);
            this.Txt_kelimeGir.Location = new System.Drawing.Point(123, 32);
            this.Txt_kelimeGir.Name = "Txt_kelimeGir";
            this.Txt_kelimeGir.Size = new System.Drawing.Size(334, 32);
            this.Txt_kelimeGir.TabIndex = 1;
            this.Txt_kelimeGir.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Txt_kelimeGir_KeyDown);
            // 
            // btn_kucukUnluUyumuKontrolEt
            // 
            this.btn_kucukUnluUyumuKontrolEt.Font = new System.Drawing.Font("Calibri", 12F);
            this.btn_kucukUnluUyumuKontrolEt.Location = new System.Drawing.Point(225, 70);
            this.btn_kucukUnluUyumuKontrolEt.Name = "btn_kucukUnluUyumuKontrolEt";
            this.btn_kucukUnluUyumuKontrolEt.Size = new System.Drawing.Size(232, 68);
            this.btn_kucukUnluUyumuKontrolEt.TabIndex = 2;
            this.btn_kucukUnluUyumuKontrolEt.Text = "Küçük Ünlü Uyumu Kontrol Et";
            this.btn_kucukUnluUyumuKontrolEt.UseVisualStyleBackColor = true;
            this.btn_kucukUnluUyumuKontrolEt.Click += new System.EventHandler(this.Btn_kucukUnluUyumuKontrolEt_Click);
            // 
            // Txt_Durum
            // 
            this.Txt_Durum.BackColor = System.Drawing.Color.White;
            this.Txt_Durum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Txt_Durum.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Txt_Durum.Location = new System.Drawing.Point(123, 144);
            this.Txt_Durum.Multiline = true;
            this.Txt_Durum.Name = "Txt_Durum";
            this.Txt_Durum.ReadOnly = true;
            this.Txt_Durum.Size = new System.Drawing.Size(334, 90);
            this.Txt_Durum.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(14, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "Sonuç:";
            // 
            // Form1
            // 
            this.AcceptButton = this.btn_kucukUnluUyumuKontrolEt;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 246);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Txt_Durum);
            this.Controls.Add(this.btn_kucukUnluUyumuKontrolEt);
            this.Controls.Add(this.Txt_kelimeGir);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Küçük Ünlü Uyumu Ödevi";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Txt_kelimeGir;
        private System.Windows.Forms.Button btn_kucukUnluUyumuKontrolEt;
        private System.Windows.Forms.TextBox Txt_Durum;
        private System.Windows.Forms.Label label2;
    }
}

