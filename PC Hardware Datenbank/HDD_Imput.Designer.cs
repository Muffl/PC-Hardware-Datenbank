﻿namespace PC_Hardware_Datenbank
{
    partial class HDD_Imput
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HDD_Imput));
            this.wtxtStromversorgung = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.wtxtStromverbrauch = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.wtxtAnschluss = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.wtxtHersteller = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.wtxtTyp = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cmdQR = new System.Windows.Forms.Button();
            this.cmdBildEinfugen = new System.Windows.Forms.Button();
            this.cmdClear = new System.Windows.Forms.Button();
            this.cmdSpeichern = new System.Windows.Forms.Button();
            this.cmdBeenden = new System.Windows.Forms.Button();
            this.pcmdMainbord = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtGrosse = new System.Windows.Forms.TextBox();
            this.cbtxSSD = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.wtxtBaugrose = new System.Windows.Forms.ComboBox();
            this.cbtSSHD = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcmdMainbord)).BeginInit();
            this.SuspendLayout();
            // 
            // wtxtStromversorgung
            // 
            this.wtxtStromversorgung.FormattingEnabled = true;
            this.wtxtStromversorgung.Items.AddRange(new object[] {
            "Molex-8981",
            "SATA"});
            this.wtxtStromversorgung.Location = new System.Drawing.Point(249, 209);
            this.wtxtStromversorgung.Name = "wtxtStromversorgung";
            this.wtxtStromversorgung.Size = new System.Drawing.Size(146, 28);
            this.wtxtStromversorgung.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(245, 186);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(135, 20);
            this.label9.TabIndex = 130;
            this.label9.Text = "Stromversorgung:";
            // 
            // wtxtStromverbrauch
            // 
            this.wtxtStromverbrauch.Location = new System.Drawing.Point(34, 211);
            this.wtxtStromverbrauch.Name = "wtxtStromverbrauch";
            this.wtxtStromverbrauch.Size = new System.Drawing.Size(146, 26);
            this.wtxtStromverbrauch.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(30, 188);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(126, 20);
            this.label8.TabIndex = 129;
            this.label8.Text = "Stromverbrauch:";
            // 
            // wtxtAnschluss
            // 
            this.wtxtAnschluss.FormattingEnabled = true;
            this.wtxtAnschluss.Items.AddRange(new object[] {
            "IDE",
            "SATA",
            "SCSI",
            "PCIe"});
            this.wtxtAnschluss.Location = new System.Drawing.Point(249, 135);
            this.wtxtAnschluss.Name = "wtxtAnschluss";
            this.wtxtAnschluss.Size = new System.Drawing.Size(146, 28);
            this.wtxtAnschluss.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(245, 112);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 20);
            this.label7.TabIndex = 128;
            this.label7.Text = "Anschlüsse:";
            // 
            // wtxtHersteller
            // 
            this.wtxtHersteller.FormattingEnabled = true;
            this.wtxtHersteller.Location = new System.Drawing.Point(34, 61);
            this.wtxtHersteller.Name = "wtxtHersteller";
            this.wtxtHersteller.Size = new System.Drawing.Size(146, 28);
            this.wtxtHersteller.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(30, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 20);
            this.label1.TabIndex = 121;
            this.label1.Text = "Hersteller:";
            // 
            // wtxtTyp
            // 
            this.wtxtTyp.FormattingEnabled = true;
            this.wtxtTyp.Location = new System.Drawing.Point(249, 61);
            this.wtxtTyp.Name = "wtxtTyp";
            this.wtxtTyp.Size = new System.Drawing.Size(146, 28);
            this.wtxtTyp.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1053, 494);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(60, 60);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 126;
            this.pictureBox1.TabStop = false;
            // 
            // cmdQR
            // 
            this.cmdQR.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdQR.Location = new System.Drawing.Point(329, 571);
            this.cmdQR.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmdQR.Name = "cmdQR";
            this.cmdQR.Size = new System.Drawing.Size(171, 35);
            this.cmdQR.TabIndex = 12;
            this.cmdQR.Text = "QR-Code Drucken";
            this.cmdQR.UseVisualStyleBackColor = false;
            // 
            // cmdBildEinfugen
            // 
            this.cmdBildEinfugen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmdBildEinfugen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdBildEinfugen.Location = new System.Drawing.Point(827, 474);
            this.cmdBildEinfugen.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmdBildEinfugen.Name = "cmdBildEinfugen";
            this.cmdBildEinfugen.Size = new System.Drawing.Size(150, 35);
            this.cmdBildEinfugen.TabIndex = 9;
            this.cmdBildEinfugen.Text = "Bild einfügen";
            this.cmdBildEinfugen.UseVisualStyleBackColor = false;
            // 
            // cmdClear
            // 
            this.cmdClear.BackColor = System.Drawing.Color.Yellow;
            this.cmdClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdClear.Location = new System.Drawing.Point(171, 571);
            this.cmdClear.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmdClear.Name = "cmdClear";
            this.cmdClear.Size = new System.Drawing.Size(150, 35);
            this.cmdClear.TabIndex = 11;
            this.cmdClear.Text = "Zurücksetzen";
            this.cmdClear.UseVisualStyleBackColor = false;
            this.cmdClear.Click += new System.EventHandler(this.cmdClear_Click);
            // 
            // cmdSpeichern
            // 
            this.cmdSpeichern.BackColor = System.Drawing.Color.Lime;
            this.cmdSpeichern.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSpeichern.Location = new System.Drawing.Point(13, 571);
            this.cmdSpeichern.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmdSpeichern.Name = "cmdSpeichern";
            this.cmdSpeichern.Size = new System.Drawing.Size(150, 35);
            this.cmdSpeichern.TabIndex = 10;
            this.cmdSpeichern.Text = "Speichern";
            this.cmdSpeichern.UseVisualStyleBackColor = false;
            this.cmdSpeichern.Click += new System.EventHandler(this.cmdSpeichern_Click);
            // 
            // cmdBeenden
            // 
            this.cmdBeenden.BackColor = System.Drawing.Color.OrangeRed;
            this.cmdBeenden.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdBeenden.Location = new System.Drawing.Point(963, 571);
            this.cmdBeenden.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmdBeenden.Name = "cmdBeenden";
            this.cmdBeenden.Size = new System.Drawing.Size(150, 35);
            this.cmdBeenden.TabIndex = 13;
            this.cmdBeenden.Text = "Schließen";
            this.cmdBeenden.UseVisualStyleBackColor = false;
            this.cmdBeenden.Click += new System.EventHandler(this.cmdBeenden_Click);
            // 
            // pcmdMainbord
            // 
            this.pcmdMainbord.Image = ((System.Drawing.Image)(resources.GetObject("pcmdMainbord.Image")));
            this.pcmdMainbord.Location = new System.Drawing.Point(663, 14);
            this.pcmdMainbord.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pcmdMainbord.Name = "pcmdMainbord";
            this.pcmdMainbord.Size = new System.Drawing.Size(450, 450);
            this.pcmdMainbord.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcmdMainbord.TabIndex = 125;
            this.pcmdMainbord.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(245, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 20);
            this.label5.TabIndex = 124;
            this.label5.Text = "Typ:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 20);
            this.label2.TabIndex = 122;
            this.label2.Text = "Speichergröße (GB):";
            // 
            // txtGrosse
            // 
            this.txtGrosse.Location = new System.Drawing.Point(34, 135);
            this.txtGrosse.Name = "txtGrosse";
            this.txtGrosse.Size = new System.Drawing.Size(146, 26);
            this.txtGrosse.TabIndex = 2;
            // 
            // cbtxSSD
            // 
            this.cbtxSSD.AutoSize = true;
            this.cbtxSSD.Location = new System.Drawing.Point(34, 335);
            this.cbtxSSD.Name = "cbtxSSD";
            this.cbtxSSD.Size = new System.Drawing.Size(213, 24);
            this.cbtxSSD.TabIndex = 7;
            this.cbtxSSD.Text = "es ist eine SSD Festplatte";
            this.cbtxSSD.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 260);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 20);
            this.label3.TabIndex = 134;
            this.label3.Text = "Baugröße:";
            // 
            // wtxtBaugrose
            // 
            this.wtxtBaugrose.FormattingEnabled = true;
            this.wtxtBaugrose.Items.AddRange(new object[] {
            "3,5",
            "2,5"});
            this.wtxtBaugrose.Location = new System.Drawing.Point(34, 283);
            this.wtxtBaugrose.Name = "wtxtBaugrose";
            this.wtxtBaugrose.Size = new System.Drawing.Size(146, 28);
            this.wtxtBaugrose.TabIndex = 6;
            // 
            // cbtSSHD
            // 
            this.cbtSSHD.AutoSize = true;
            this.cbtSSHD.Location = new System.Drawing.Point(34, 365);
            this.cbtSSHD.Name = "cbtSSHD";
            this.cbtSSHD.Size = new System.Drawing.Size(225, 24);
            this.cbtSSHD.TabIndex = 8;
            this.cbtSSHD.Text = "es ist eine SSHD Festplatte";
            this.cbtSSHD.UseVisualStyleBackColor = true;
            // 
            // HDD_Imput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1126, 620);
            this.Controls.Add(this.cbtSSHD);
            this.Controls.Add(this.wtxtBaugrose);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbtxSSD);
            this.Controls.Add(this.txtGrosse);
            this.Controls.Add(this.wtxtStromversorgung);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.wtxtStromverbrauch);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.wtxtAnschluss);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.wtxtHersteller);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.wtxtTyp);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cmdQR);
            this.Controls.Add(this.cmdBildEinfugen);
            this.Controls.Add(this.cmdClear);
            this.Controls.Add(this.cmdSpeichern);
            this.Controls.Add(this.cmdBeenden);
            this.Controls.Add(this.pcmdMainbord);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "HDD_Imput";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HDD_Imput";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcmdMainbord)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox wtxtStromversorgung;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox wtxtStromverbrauch;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox wtxtAnschluss;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox wtxtHersteller;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox wtxtTyp;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button cmdQR;
        private System.Windows.Forms.Button cmdBildEinfugen;
        private System.Windows.Forms.Button cmdClear;
        private System.Windows.Forms.Button cmdSpeichern;
        private System.Windows.Forms.Button cmdBeenden;
        private System.Windows.Forms.PictureBox pcmdMainbord;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtGrosse;
        private System.Windows.Forms.CheckBox cbtxSSD;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox wtxtBaugrose;
        private System.Windows.Forms.CheckBox cbtSSHD;
    }
}