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
    public partial class Kabel_Imput : Form
    {
        private string Datensatz = "";//Datensatz der dan in die Datenbank geschoben wird
        private char LF = (char)10;
        private string QR = "";//QR Code
        public string DateiPfad;

        public Kabel_Imput()
        {
            InitializeComponent();
        }

        private void cmdBeenden_Click(object sender, EventArgs e)//Fenster Schlissen
        {
            Close();
        }

        private void LoschFunktion()//Löschen Funktion
        {
            wtxtZustand.Text = wtxtKabelendeA.Text = wtxtKabelendeB.Text = null;
            nudLange.Value = 0;
            cbtSchaltbar.Checked = false;
            wtxtKabelendeA.Focus();
        }

        private void cmdClear_Click(object sender, EventArgs e)//Löschen Button
        {
            LoschFunktion();
        }

        private void cmdSpeichern_Click(object sender, EventArgs e)//Speichern Button
        {
            if (File.Exists(DateiPfad + @"/Kabel_Datenbank.csv") == true)//Prüffen ob eine .csv Datei bereits erstellt wurde
            {
                if (wtxtKabelendeA.Text != "" && wtxtKabelendeB.Text != "" && wtxtZustand.Text != "" && nudLange.Value != 0)//Prüfft die Pflichtangaben
                {
                    Datensatz = File.ReadAllText(DateiPfad + @"/Kabel_Datenbank.csv");//Datenbanck lessen und in Datensatz speichern

                    #region Chak Boxen auswerten und Daten zuweisen
                    string Schaltbar = "NEIN";
                    if (cbtSchaltbar.Checked == true)
                    {
                        Schaltbar = "JA";
                    }
                    #endregion

                    #region Datensatz bilden
                    Datensatz += LF +
                        wtxtZustand.Text + ";" +
                        wtxtKabelendeA.Text + ";" +
                        nudLange.Value + ";" +
                        wtxtKabelendeB.Text + ";" +
                        Schaltbar;
                    #endregion

                    #region QR Code
                    QR =
                        "Zustand: " + wtxtZustand.Text + LF +
                        "Kabelende: " + wtxtKabelendeA.Text + LF +
                        "Länge (m): " + nudLange.Value + LF +
                        "Kabelende: " + wtxtKabelendeB.Text + LF +
                        "Schaltbar: " + Schaltbar;
                    #endregion

                    File.WriteAllText(DateiPfad + @"/Kabel_Datenbank.csv", Datensatz);//Datensatz in GPU_Datenbank.csv schreiben
                    MessageBox.Show("Datensatz geschrieben!");//Bestätigung das der Datensatz geschrieben wurd
                }
                else
                {
                    MessageBox.Show("Bitte alle roten Pflichtfelder ausfüllen!");
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

        private void Kabel_Imput_Load(object sender, EventArgs e)//lesen des gespeicherten DateiPfad
        {
            DateiPfad = File.ReadAllText(@"./settings");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/JHGjdwdwu");
        }
    }
}