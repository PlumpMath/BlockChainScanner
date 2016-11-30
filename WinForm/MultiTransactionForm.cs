using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary;

namespace WinForm
{
    public partial class MultiTransactionForm : Form
    {
        public MultiTransactionForm()
        {
            InitializeComponent();
        }

        private void GetTxListFromFileButton_Click(object sender, EventArgs e)
        {
            TxListTextBox.Text = "";

            openFileDialog1.Multiselect = false;
            var result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                var fileContents = File.ReadAllText(openFileDialog1.FileName);
                TxListTextBox.Text = fileContents;

            }

        }

        private void BuildFileFromMultiButton_Click(object sender, EventArgs e)
        {
            if (TxListTextBox.Text.Trim().Length == 0)
            {
                MessageBox.Show("No Transactions listed");
                return;
            }

            var result = saveFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                var fileBytes = new List<byte>();

                foreach (var tx in TxListTextBox.Text.Split('\n'))
                {
                    var cleanedTx = tx.Replace("\r", "");

                    if (cleanedTx.Trim().Length == 0)
                        continue;

                    var prop = Transaction.DecodeTransactionBitcoinLib(cleanedTx);
                    fileBytes.AddRange(prop.ContentBytes);
                }

                var outputFileName = saveFileDialog1.FileName;
                using (FileStream stream = new FileStream(outputFileName, FileMode.Create))
                {
                    using (BinaryWriter writer = new BinaryWriter(stream))
                    {
                        writer.Write(fileBytes.ToArray());
                    }
                }
            }
        }

        private void MultiTransactionForm_Load(object sender, EventArgs e)
        {
            //temp: testing
            //var path = @"E:\Development\Python\tx_list.txt";
            //var fileContents = File.ReadAllText(path);
            //TxListTextBox.Text = fileContents;
            //BuildFileFromMultiButton_Click(null, null);
        }
    }
}
