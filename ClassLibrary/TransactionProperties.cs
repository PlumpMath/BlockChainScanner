using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class TransactionProperties
    {
        public string Tx;
        public string Status;

        public int Length;
        public int Checksum;

        public string Output;
        public string FileType;
        public byte[] ContentBytes;
        public List<TransactionProperties> LinkedTransactions = new List<TransactionProperties>();

        public TransactionProperties(string tx)
        {
            this.Tx = tx.Trim();
            Status = "Incomplete";


        }
    }
}
