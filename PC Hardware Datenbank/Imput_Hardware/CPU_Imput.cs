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
    public partial class CPU_Imput : Form
    {
        private string Datensatz = "";//Datensatz, der dann in die Datenbank geschoben wird
        private char LF = (char)10;
        private string Sockel = "leer";
        private string QR = "";//QR Code
        public string DateiPfad;

        public CPU_Imput()
        {
            InitializeComponent();
        }

        private void cmdBeenden_Click(object sender, EventArgs e)//Fenster schliessen
        {
            Close();
        }

        private void LoschenFunktion()//Löschfunktion
        {
            wtxtHersteller.Text = wtxtTyp.Text = wtxtSockelAMD.Text = wtxtSockelINTEL.Text = mtxtTaktrate.Text = wtxtSockel.Text = nudCach1.Text = nudCach2.Text = nudCach3.Text = nudCach4.Text = wtxtZustand.Text = null;
            nudKerne.Value = 1;
            wtxtHersteller.Focus();
        }

        private void cmdClear_Click(object sender, EventArgs e)//Löschen Button
        {
            LoschenFunktion();
        }

        private void cmdSpeichern_Click(object sender, EventArgs e)//Speichern Button
        {
            if (File.Exists(DateiPfad + @"/CPU_Datenbank.csv") == true)//Prüffen ob eine .csv Datei bereits erstellt wurde
            {
                if (wtxtHersteller.Text != "" && wtxtTyp.Text != "" && wtxtZustand.Text != "")//Prüfft die Pflichtangaben
                {
                    Datensatz = File.ReadAllText(DateiPfad + @"/CPU_Datenbank.csv");//Datenbanck lessen und in Datensatz speichern

                    #region Datensatz erstellen
                    Datensatz += LF +
                        wtxtHersteller.Text + ";" +
                        wtxtTyp.Text + ";" +
                        wtxtZustand.Text + ";" +
                        Sockel + ";" +
                        mtxtTaktrate.Text + ";" +
                        nudKerne.Value + ";" +
                        nudCach1.Text + ";" +
                        nudCach2.Text + ";" +
                        nudCach3.Text + ";" +
                        nudCach4.Text + ";";
                    #endregion

                    #region QR Code
                    QR +=
                        "Hersteller: " + wtxtHersteller.Text + LF +
                        "Typ: " + wtxtTyp.Text + LF +
                        "Zustand: " + wtxtZustand.Text + LF +
                        "Sockel: " + Sockel + LF +
                        "Taktrate: " + mtxtTaktrate.Text + LF +
                        "Anzahl Kerne: " + nudKerne.Value + LF +
                        "Level1 Cache: " + nudCach1.Value + LF +
                        "Level2 Cache: " + nudCach2.Value + LF +
                        "Level3 Cache: " + nudCach3.Value + LF +
                        "Level4 Cache: " + nudCach3.Value + LF;
                    #endregion

                    //Datensatz in Datenbank schreiben
                    File.WriteAllText(DateiPfad + @"/CPU_Datenbank.csv", Datensatz);//Datensatz in RAM_Datenbank.csv schreiben
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
        #region CPU Sockel auswerten
        private void wtxtHersteller_SelectedIndexChanged(object sender, EventArgs e)//Giebt die Sokel für den Hersteller frei
        {
            if (wtxtHersteller.Text == "")
            {
                wtxtSockelAMD.Visible = false;
                wtxtSockelINTEL.Visible = false;
                wtxtSockel.Visible = true;
                Sockel = wtxtSockel.Text;
            }
            if (wtxtHersteller.Text == "AMD")
            {
                wtxtSockelINTEL.Visible = false;
                wtxtSockel.Visible = false;
                wtxtSockelAMD.Visible = true;
                Sockel = wtxtSockelAMD.Text;
            }
            if (wtxtHersteller.Text == "Intel")
            {
                wtxtSockelAMD.Visible = false;
                wtxtSockel.Visible = false;
                wtxtSockelINTEL.Visible = true;
                Sockel = wtxtSockelINTEL.Text;
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

        private void CPU_Imput_Load(object sender, EventArgs e)//lesen des gespeicherten DateiPfad
        {
            DateiPfad = File.ReadAllText(@"./settings");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/JHGjdwdwu");
        }
    }
}