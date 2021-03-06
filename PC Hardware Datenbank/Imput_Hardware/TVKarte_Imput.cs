﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;//Zusäzlich für Daten
using System.Drawing.Printing;//Zusäzlich für Drucken
using QRCoder;//Zusäzlich für den QR-Code Generator

namespace PC_Hardware_Datenbank
{
    public partial class TVKarte_Imput : Form
    {
        public TVKarte_Imput()
        {
            InitializeComponent();
        }

        Methoden methoden = new Methoden();
        private char LF = (char)10;
        private string QR = "";//QR Code

        private void cmdBeenden_Click(object sender, EventArgs e)//Fenster Schlissen
        {
            Close();
        }

        private void LoschFunktion()//Löschen Funktion
        {
            TVKarte_Imput NewForm = new TVKarte_Imput();
            NewForm.Show();
            this.Dispose(false);
            wtxtHersteller.Focus();
        }

        private void cmdClear_Click(object sender, EventArgs e)//Löschen Button
        {
            LoschFunktion();
        }

        private void cmdSpeichern_Click(object sender, EventArgs e)//Speichern Button
        {
            if (wtxtHersteller.Text != "" && wtxtID.Text != "" && wtxtZustand.Text != "" && wtxtAnschluss.Text != "")
            {
                try
                {
                    string mysqlconnectionstring = methoden.MySqlConnectionString();//Angaben um sich an der Datenbank anzumelden
                    methoden.MySQL_ping_check(mysqlconnectionstring);//Testabfrage bei der Datenkan
                    string Datensatz = methoden.ObjekteTextToString(",", this);//Erzeugt ein String aus den Daten auf der Form
                    string sqldatensatz = Datensatz.Substring(0, Datensatz.Length - 1);//Entfert ein überflüssiges Zeichen (Grund Schleife)
                    string mysqlcommandtext = "INSERT INTO `tv-karte` VALUES (''," + sqldatensatz + ");";//SQL Befehl Abfrage aller User
                    methoden.MySqlCommand(mysqlconnectionstring, mysqlcommandtext);//Daten in die Datenbank schreiben
                    LoschFunktion();
                    wtxtZustand.Focus();
                    MessageBox.Show("Daten wurden erfolgreich gespeichert!");

                    #region QR Code
                    QR =
                        "Kartenhersteller: " + wtxtHersteller.Text + LF +
                        "Modell: " + wtxtID.Text + LF +
                        "Zustand: " + wtxtZustand.Text + LF +
                        "Anschlussart: " + wtxtAnschluss.Text + LF +
                        "Analog: " + nudAnalog.Value + LF +
                        "DVB-C: " + nudDVB_C.Value + LF +
                        "DVB-C2: " + nudDVB_C2.Value + LF +
                        "DVB-T: " + nudDVB_T.Value + LF +
                        "DVB-T2: " + nudDVB_T2.Value + LF +
                        "DVB-S: " + nudDVB_S.Value + LF +
                        "DVB-S2: " + nudDVB_S2.Value + LF +
                        "Klinke: " + nudKlinke.Value + LF +
                        "ODT: " + nudODT.Value + LF +
                        "HDMI: " + nudHDMI.Value + LF +
                        "Scart: " + nudScart.Value + LF +
                        "S-Video: " + nudSVideo.Value + LF +
                        "Cinch: " + nudCinch.Value;
                    #endregion

                    DialogResult dialogresult = MessageBox.Show("Möchten Sie einen QR-Code Drucken?", "QR-Code Drucken?", MessageBoxButtons.YesNo);
                    if (dialogresult == DialogResult.Yes)
                    {
                        cmdQR_Click(cmdQR, e);
                    }
                    else if (dialogresult == DialogResult.No)
                    {

                    }
                }
                catch
                {
                    MessageBox.Show("Fehler: Daten konnten nicht gespeichert speichern werden!");
                }
            }
            else
            {
                MessageBox.Show("Bitte füllen sie alle rot markierten Felder aus!");
            }
        }

        #region Prüfen ob Check-Box aktiv ist dan Nummern Block auf 1
        private void cbtAnalog_CheckedChanged(object sender, EventArgs e)
        {
            if (cbtAnalog.Checked == true)
            {
                nudAnalog.Value = 1;
            }
            if (cbtAnalog.Checked == false)
            {
                nudAnalog.Value = 0;
            }
        }
        private void cbtDVB_C_CheckedChanged(object sender, EventArgs e)
        {
            if (cbtDVB_C.Checked == true)
            {
                nudDVB_C.Value = 1;
            }
            if (cbtDVB_C.Checked == false)
            {
                nudDVB_C.Value = 0;
            }
        }
        private void cbtDVB_C2_CheckedChanged(object sender, EventArgs e)
        {
            if (cbtDVB_C2.Checked == true)
            {
                nudDVB_C2.Value = 1;
            }
            if (cbtDVB_C2.Checked == false)
            {
                nudDVB_C2.Value = 0;
            }
        }
        private void cbtCVB_T_CheckedChanged(object sender, EventArgs e)
        {
            if (cbtDVB_T.Checked == true)
            {
                nudDVB_T.Value = 1;
            }
            if (cbtDVB_T.Checked == false)
            {
                nudDVB_T.Value = 0;
            }
        }
        private void cbtDVB_T2_CheckedChanged(object sender, EventArgs e)
        {
            if (cbtDVB_T2.Checked == true)
            {
                nudDVB_T2.Value = 1;
            }
            if (cbtDVB_T2.Checked == false)
            {
                nudDVB_T2.Value = 0;
            }
        }
        private void cbtDVB_S_CheckedChanged(object sender, EventArgs e)
        {
            if (cbtDVB_S.Checked == true)
            {
                nudDVB_S.Value = 1;
            }
            if (cbtDVB_S.Checked == false)
            {
                nudDVB_S.Value = 0;
            }
        }
        private void cbtDVB_S2_CheckedChanged(object sender, EventArgs e)
        {
            if (cbtDVB_S2.Checked == true)
            {
                nudDVB_S2.Value = 1;
            }
            if (cbtDVB_S2.Checked == false)
            {
                nudDVB_S2.Value = 0;
            }
        }
        private void cbtKlinke_CheckedChanged(object sender, EventArgs e)
        {
            if (cbtKlinke.Checked == true)
            {
                nudKlinke.Value = 1;
            }
            if (cbtKlinke.Checked == false)
            {
                nudKlinke.Value = 0;
            }
        }
        private void cbtODT_CheckedChanged(object sender, EventArgs e)
        {
            if (cbtODT.Checked == true)
            {
                nudODT.Value = 1;
            }
            if (cbtODT.Checked == false)
            {
                nudODT.Value = 0;
            }
        }
        private void cbtHDMI_CheckedChanged(object sender, EventArgs e)
        {
            if (cbtHDMI.Checked == true)
            {
                nudHDMI.Value = 1;
            }
            if (cbtHDMI.Checked == false)
            {
                nudHDMI.Value = 0;
            }
        }
        private void cbtScart_CheckedChanged(object sender, EventArgs e)
        {
            if (cbtScart.Checked == true)
            {
                nudScart.Value = 1;
            }
            if (cbtScart.Checked == false)
            {
                nudScart.Value = 0;
            }
        }
        private void cbtSVideo_CheckedChanged(object sender, EventArgs e)
        {
            if (cbtSVideo.Checked == true)
            {
                nudSVideo.Value = 1;
            }
            if (cbtSVideo.Checked == false)
            {
                nudSVideo.Value = 0;
            }
        }
        private void cbtCinch_CheckedChanged(object sender, EventArgs e)
        {
            if (cbtCinch.Checked == true)
            {
                nudCinch.Value = 1;
            }
            if (cbtCinch.Checked == false)
            {
                nudCinch.Value = 0;
            }
        }
        #endregion
        #region Prüfen das Nummern Felder
        private void nudAnalog_ValueChanged(object sender, EventArgs e)
        {
            if (nudAnalog.Value > 0)
            {
                cbtAnalog.Checked = true;
            }
            if (nudAnalog.Value == 0)
            {
                cbtAnalog.Checked = false;
            }
        }
        private void nudDVB_C_ValueChanged(object sender, EventArgs e)
        {
            if (nudDVB_C.Value > 0)
            {
                cbtDVB_C.Checked = true;
            }
            if (nudDVB_C.Value == 0)
            {
                cbtDVB_C.Checked = false;
            }
        }
        private void nudDVB_C2_ValueChanged(object sender, EventArgs e)
        {
            if (nudDVB_C2.Value > 0)
            {
                cbtDVB_C2.Checked = true;
            }
            if (nudDVB_C2.Value == 0)
            {
                cbtDVB_C2.Checked = false;
            }
        }
        private void nudCVB_T_ValueChanged(object sender, EventArgs e)
        {
            if (nudDVB_T.Value > 0)
            {
                cbtDVB_T.Checked = true;
            }
            if (nudDVB_T.Value == 0)
            {
                cbtDVB_T.Checked = false;
            }
        }
        private void nudDVB_T2_ValueChanged(object sender, EventArgs e)
        {
            if (nudDVB_T2.Value > 0)
            {
                cbtDVB_T2.Checked = true;
            }
            if (nudDVB_T2.Value == 0)
            {
                cbtDVB_T2.Checked = false;
            }
        }
        private void nudDVB_S_ValueChanged(object sender, EventArgs e)
        {
            if (nudDVB_S.Value > 0)
            {
                cbtDVB_S.Checked = true;
            }
            if (nudDVB_S.Value == 0)
            {
                cbtDVB_S.Checked = false;
            }
        }
        private void nudDVB_S2_ValueChanged(object sender, EventArgs e)
        {
            if (nudDVB_S2.Value > 0)
            {
                cbtDVB_S2.Checked = true;
            }
            if (nudDVB_S2.Value == 0)
            {
                cbtDVB_S2.Checked = false;
            }
        }
        private void nudKlinke_ValueChanged(object sender, EventArgs e)
        {
            if (nudKlinke.Value > 0)
            {
                cbtKlinke.Checked = true;
            }
            if (nudKlinke.Value == 0)
            {
                cbtKlinke.Checked = false;
            }
        }
        private void nudODT_ValueChanged(object sender, EventArgs e)
        {
            if (nudODT.Value > 0)
            {
                cbtODT.Checked = true;
            }
            if (nudODT.Value == 0)
            {
                cbtODT.Checked = false;
            }
        }
        private void nudHDMI_ValueChanged(object sender, EventArgs e)
        {
            if (nudHDMI.Value > 0)
            {
                cbtHDMI.Checked = true;
            }
            if (nudHDMI.Value == 0)
            {
                cbtHDMI.Checked = false;
            }
        }
        private void nudScart_ValueChanged(object sender, EventArgs e)
        {
            if (nudScart.Value > 0)
            {
                cbtScart.Checked = true;
            }
            if (nudScart.Value == 0)
            {
                cbtScart.Checked = false;
            }
        }
        private void nudSVideo_ValueChanged(object sender, EventArgs e)
        {
            if (nudSVideo.Value > 0)
            {
                cbtSVideo.Checked = true;
            }
            if (nudSVideo.Value == 0)
            {
                cbtSVideo.Checked = false;
            }
        }
        private void nudCinch_ValueChanged(object sender, EventArgs e)
        {
            if (nudCinch.Value > 0)
            {
                cbtCinch.Checked = true;
            }
            if (nudCinch.Value == 0)
            {
                cbtCinch.Checked = false;
            }
        }
        #endregion

        #region Drucken von einem QR-Code
        private void cmdQR_Click(object sender, EventArgs e)
        {
            if (QR != "")
            {
                PrintDialog pd = new PrintDialog();
                PrintDocument doc = new PrintDocument();
                doc.PrintPage += printDocument1_PrintPage;
                pd.Document = doc;
                if (pd.ShowDialog() == DialogResult.OK)
                {
                    doc.Print();
                }
            }
            else
            {
                MessageBox.Show("Zuerst muss ein Datensatz gespeichert werden!");
            }
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData Daten = qrGenerator.CreateQrCode(QR, QRCodeGenerator.ECCLevel.L);

            QRCode qrCode = new QRCode(Daten);
            Bitmap qrCodeImage = qrCode.GetGraphic(2);
            e.Graphics.DrawImage(qrCodeImage, 10, 10);
            qrCodeImage.Dispose();
        }
        #endregion

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/JHGjdwdwu");
        }
    }
}
