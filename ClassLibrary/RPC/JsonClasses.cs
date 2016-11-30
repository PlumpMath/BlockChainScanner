using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.RPC
{
    public class Jsongetrawtransaction
    {
        public string result;
        public string error;
        public int id;
    }
    public class Jsondecoderawtransaction
    {
        public JsondecoderawtransactionResult result;
        public string error;
        public int id;
    }
    public class JsondecoderawtransactionResult
    {
        public string txid;
        public string hash;
        public int size;
        public int vsize;
        public int version;
        public int locktime;
        public List<JsondecoderawtransactionResultVin> vin;
        public List<JsondecoderawtransactionResultVout> vout;
    }
    public class JsondecoderawtransactionResultVin
    {
        public string txid;
        public string vout;
        public JsondecoderawtransactionResultVinScriptSig scriptSig;
        public long sequence;


    }
    public class JsondecoderawtransactionResultVinScriptSig
    {
        public string asm;
        public string hex;

    }

    public class JsondecoderawtransactionResultVout
    {
        public float value;
        public int n;
        public JsondecoderawtransactionResultVoutScriptPubKey scriptPubKey;

    }
    public class JsondecoderawtransactionResultVoutScriptPubKey
    {
        public string asm;
        public string hex;
        public int reqSigs;
        public string type;
        public string[] addresses;
    }
}
