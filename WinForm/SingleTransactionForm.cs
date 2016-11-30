using System;
using System.Collections.Generic;
using System.Configuration;

using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiscUtil.Conversion;
using BitcoinLib.Auxiliary;
using BitcoinLib.ExceptionHandling.Rpc;
using BitcoinLib.Responses;
using BitcoinLib.Services.Coins.Base;
using BitcoinLib.Services.Coins.Bitcoin;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using ClassLibrary;

namespace WinForm
{
    public partial class SingleTransactionForm : Form
    {
        //public string bitcoinSource;

        public SingleTransactionForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //decode single transaction
            //var txProp = DecodeTransaction("691dd277dc0e90a462a3d652a1171686de49cf19067cd33c7df0392833fb986a");
            //DetermineFileType(txProp);

            //DecodeTransaction("6c53cd987119ef797d5adccd76241247988a0a5ef783572a9972e7371c5fb0cc");
            //TxTextBox.Text = "08654f9dc9d673b3527b48ad06ab1b199ad47b61fd54033af30c2ee975c588bd";//Cablegate.7z start file
            //                                                                                    //TxTextBox.Text = "5c593b7b71063a01f4128c98e36fb407b00a87454e67b39ad5f8820ebc1b2ad5";//First transaction for cablegate.7z
            //// determine connection method
            //if (ConfigurationManager.AppSettings["BitCoin_Source"] == null)
            //{
            //    throw new Exception("Configuration file must have BitCoin_Source - Set to web or rpc");
            //}

            //bitcoinSource = ConfigurationManager.AppSettings["BitCoin_Source"];



        }
      
        private void DecodeTXButton_Click(object sender, EventArgs e)
        {
            var txProp = DecodeTransaction();
            if (txProp == null)
                return;

        }


        private TransactionProperties DecodeTransaction()
        {
            TXOutputTextBox.Text = "";

            if (TxTextBox.Text.Trim().Length == 0)
            {
                MessageBox.Show("TX is required to decode");
                return null;
            }

            var prop = Transaction.DecodeTransactionBitcoinLib(TxTextBox.Text.Trim());
            Transaction.DetermineFileType(prop);

            if (prop.Status == "Success")
            {
                TXOutputTextBox.Text = prop.Output.Replace("\n", System.Environment.NewLine);
                TxPropTextBox.Text = PropToText(prop).Replace("\n", System.Environment.NewLine);
            }
            return prop;
        }

 

        private string PropToText(TransactionProperties prop)
        {
            int padding = 20;

            var debug = "";
            debug += "Id".PadRight(padding, ' ') + ":" + prop.Tx + "\n";
            debug += "Status".PadRight(padding, ' ') + ":" + prop.Status + "\n";
            debug += "Length".PadRight(padding, ' ') + ":" + prop.Length + "\n";
            debug += "Linked Tx's".PadRight(padding, ' ') + ":" + prop.LinkedTransactions.Count + "\n";
            debug += "File Type: " + prop.FileType;

            return debug;
        }



        #region RPC Related


        #endregion

        private void DecodeGetFileButton_Click(object sender, EventArgs e)
        {

            var txProp = DecodeTransaction();
            if (txProp == null)
                return;

            var result = saveFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                var outputFileName = saveFileDialog1.FileName;
                using (FileStream stream = new FileStream(outputFileName, FileMode.Create))
                {
                    using (BinaryWriter writer = new BinaryWriter(stream))
                    {
                        writer.Write(txProp.ContentBytes);
                    }
                }
            }
        }
    }




}

