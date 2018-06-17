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
    public partial class USV_Imput : Form
    {
        private string Datensatz = "";//Datensatz der dan in die Datenbank geschoben wird
        private char LF = (char)10;
        private string QR = "";//QR Code

        public USV_Imput()
        {
            InitializeComponent();
        }

        private void cmdBeenden_Click(object sender, EventArgs e)//Fenster Schlissen
        {
            Close();
        }

        private void LoschFunktion()//Löschen Funktion
        {
            wtxtHersteller.Text = wtxtModell.Text = wtxtWatt.Text = wtxtVA.Text = wtxtArbeitsweise.Text = wtxtAkkutyp.Text = null;
            nudAkkanzahl.Value = nudUSB.Value = 0;
            cbtCOM.Checked = false;
            wtxtHersteller.Focus();
        }

        private void cmdClear_Click(object sender, EventArgs e)//Löschen Button
        {
            LoschFunktion();
        }

        private void cmdSpeichern_Click(object sender, EventArgs e)//Speichern Button
        {
            if (File.Exists(@"./USV_Datenbank.csv") == true)//Prüffen ob eine .csv Datei bereits erstellt wurde
            {
                if (wtxtHersteller.Text != "" && wtxtModell.Text != "")//Prüfft die Pflichtangaben
                {
                    Datensatz = File.ReadAllText(@"./USV_Datenbank.csv");//Datenbanck lessen und in Datensatz speichern

                    #region Chak Boxen auswerten und Daten zuweisen
                    string COM = "NEIN";
                    if (cbtCOM.Checked == true)
                    {
                        COM = "JA";
                    }
                    #endregion

                    #region Datensatz bilden
                    Datensatz += LF + wtxtHersteller.Text + ";" + wtxtModell.Text + ";" + wtxtWatt.Text + ";" + wtxtVA.Text + ";" + wtxtArbeitsweise.Text + ";" + wtxtAkkutyp.Text + ";" + nudAkkanzahl.Value + ";" + nudUSB.Value + ";" + COM;
                    #endregion

                    #region QR Code
                    QR = "Hersteller:" + wtxtHersteller.Text + LF + "Modell:" + wtxtModell.Text + LF + "Watt (W):" + wtxtWatt.Text + LF + "Volt-Apere (VA):" + wtxtVA.Text + LF + "Arbeitsweise:" + wtxtArbeitsweise.Text + LF + "Akkutyp:" + wtxtAkkutyp.Text + LF + "Akkanzahl:" + nudAkkanzahl.Value + LF + "USB Anschlüsse:" + nudUSB.Value + LF + "COM:" + COM;
                    #endregion

                    File.WriteAllText(@"./USV_Datenbank.csv", Datensatz);//Datensatz in GPU_Datenbank.csv schreiben
                    MessageBox.Show("Datensatz geschrieben!");//Bestätigung das der Datensatz geschrieben wurd
                }
                else
                {
                    MessageBox.Show("Bitte alle Roten Pflicht eintragungen ausfüllen!");
                }
            }
            else
            {
                MessageBox.Show("Datenbank nicht vorhanden bitte einen Administrator aufsuchen!");
                Application.Exit();
            }
        }

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
                MessageBox.Show("zuerst muss ein Datensatz gespeichert werden!");
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
    }
}