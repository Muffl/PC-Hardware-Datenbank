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
    public partial class Gehause_Imput : Form
    {
        private string Datensatz = "";//Datensatz der dan in die Datenbank geschoben wird
        private char LF = (char)10;
        private string QR = "";//QR Code

        public Gehause_Imput()
        {
            InitializeComponent();
        }

        private void cmdBeenden_Click(object sender, EventArgs e)//Fenster schlissen
        {
            Close();
        }

        private void LoschFuncktion()//Lösch Funktion
        {
            mtxtBreiteHocheTiefe.Text = wtxtHersteller.Text = wtxtTyp.Text = wtxtNetzteilPosition.Text = wtxtFormfaktor.Text = null;
            nudEinschub5.Value = nudEinschub3.Value = nudHDD3.Value = nudHDD2.Value = nudFrontUSB.Value = nudFrontKlinke.Value = 0;
            cbtKabelsystem.Checked = cbtBelechtung.Checked = cbtFenster.Checked = false;
        }

        private void cmdClear_Click(object sender, EventArgs e)//Löschen Button
        {
            LoschFuncktion();
        }

        private void cmdSpeichern_Click(object sender, EventArgs e)//Speichern Button
        {
            if (File.Exists(@"./Gehause_Datenbank.csv") == true)//Prüffen ob eine .csv Datei bereits erstellt wurde
            {
                if (mtxtBreiteHocheTiefe.Text != "" && wtxtHersteller.Text != "")//Prüfft die Pflichtangaben
                {
                    Datensatz = File.ReadAllText(@"./Gehause_Datenbank.csv");//Datenbanck lessen und in Datensatz speichern

                    #region Check Box auswerten
                    string Kabelsystem = "NEIN", Beleuchtung = "NEIN", PlexiglassFenster = "NEIN";
                    if (cbtKabelsystem.Checked == true)
                    {
                        Kabelsystem = "JA";
                    }
                    if (cbtBelechtung.Checked == true)
                    {
                        Beleuchtung = "JA";
                    }
                    if (cbtFenster.Checked == true)
                    {
                        PlexiglassFenster = "JA";
                    }
                    #endregion

                    #region Datensatz bilden
                    Datensatz += LF + mtxtBreiteHocheTiefe.Text + ";" + wtxtHersteller.Text + ";" + wtxtTyp.Text + ";" + wtxtNetzteilPosition.Text;

                    Datensatz += ";" + nudEinschub5.Value + ";" + nudEinschub3.Value + ";" + nudHDD3.Value + ";";
                    Datensatz += nudHDD2.Value + ";" + nudFrontUSB.Value + ";" + nudFrontKlinke.Value + ";";

                    Datensatz += Kabelsystem + ";" + Beleuchtung + ";" + PlexiglassFenster + ";" + wtxtFormfaktor.Text;
                    #endregion

                    #region QR Code
                    QR = "Breite-Höhe-Tiefe:" + mtxtBreiteHocheTiefe.Text + LF + "Hersteller:" + wtxtHersteller.Text + LF + "Typ:" + wtxtTyp.Text + LF + "Netzteil Position:" + wtxtNetzteilPosition.Text + LF + "Einschub 5,25 Zoll:" + nudEinschub5.Value + LF + "Einschub 3,5 Zoll:" + nudEinschub3.Value + LF + "Einschub 3,5 HDD:" + nudHDD3.Value + LF + "Einschub 2,5 HDD:" + nudHDD2.Value + LF + "Front USB:" + nudFrontUSB.Value + LF + "Front Klinke:" + nudFrontKlinke.Value + LF + "Formfaktor:" + wtxtFormfaktor.Text + LF + "Kabelsystem:" + Kabelsystem + LF + "Beleuchtung:" + Beleuchtung + LF + "Plexiglas Fenster:" + PlexiglassFenster;
                    #endregion

                    File.WriteAllText(@"./Gehause_Datenbank.csv", Datensatz);//Datensatz in Mainbord_Datenbank.csv schreiben
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
