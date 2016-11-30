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
        public SingleTransactionForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
      
        private void DecodeTXButton_Click(object sender, EventArgs e)
        {
            try
            {

                var txProp = DecodeTransaction();
                if (txProp == null)
                    return;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error Occured:" + ex.Message);
            }
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
            try
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
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured:" + ex.Message);
            }
           
        }
    }




}

