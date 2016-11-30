using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BitcoinLib.Services.Coins.Bitcoin;
using ClassLibrary;

namespace WinForm
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }


        private void ReadmeButton_Click(object sender, EventArgs e)
        {
            Process.Start("readme.txt");
        }

        private void MultiTransactionButton_Click(object sender, EventArgs e)
        {
            var form = new MultiTransactionForm();
            form.Show();
        }

        private void SingleTransactionButton_Click(object sender, EventArgs e)
        {
            var form = new SingleTransactionForm();
            form.Show();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            TestStub();

        }

        private void TestStub()
        {
            //var walletId = "1C3WStWpfCmsoG5WmDeaYSwAeEY1ncWQoh";
            //Transaction.SearchWallet(walletId);

            //var txProp = Transaction.DecodeTransactionBitcoinLib("54e48e5f5c656b26c3bca14a8c95aa583d07ebe84dde3b7dd4a78f4e4186e713 ");
            //Transaction.DetermineFileType(txProp);
            //var bitcoinService = Transaction.GetBitcoinService();

            //todo: testing
            //Transaction.SearchWallet("1HB5XMLmzFVj8ALj6mfBsbifRoD4miY36v");

            //var op = "204e00005cfccf40377abcaf271c0003c5f219041462270000000000260000000000000069469d0400239244d42fe726b29b083ec863bb48f5c1765c23e5cf23f5";

            //var bytes = Utilities.Hex2Binary2(op);
            //var dataOut = Encoding.UTF8.GetString(bytes);
            //var byteArray = dataOutBytes.ToArray();

            //prop.Length = Utilities.StructUnpackBinaryReader<Int32>(byteArray, 0);
            //prop.Checksum = Utilities.StructUnpackBinaryReader<Int32>(byteArray, 4);
            //var final = Encoding.UTF7.GetString(bytes.Skip(8).ToArray());

            //var outputFileName = "cablegate.7z";

            //////File.WriteAllBytes(outputFileName, dataOutBytes.Skip(8).ToArray());
            ////using (StreamWriter writer = new StreamWriter(outputFileName, false, Encoding.UTF8))
            ////{
            ////    writer.WriteLine(final);
            ////}

            //using (FileStream stream = new FileStream(outputFileName, FileMode.Create))
            //{
            //    using (BinaryWriter writer = new BinaryWriter(stream))
            //    {
            //        writer.Write(bytes.Skip(8).ToArray());
            //    }
            //}
        }
    }
}
