using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using ClassLibrary.RPC;
using BitcoinLib.Services.Coins.Bitcoin;

namespace ClassLibrary
{
    public static class Transaction
    {
        public static IBitcoinService GetBitcoinService()
        {
            //public BitcoinService(string daemonUrl, string rpcUsername, string rpcPassword, string walletPassword = null);
            //string bitcoinUrl = ConfigurationManager.AppSettings["Bitcoin_DaemonUrl"];
            //string bitcoinUserName = ConfigurationManager.AppSettings["Bitcoin_RpcUsername"];
            //string bitcoinPassword = ConfigurationManager.AppSettings["Bitcoin_RpcPassword"];

            IBitcoinService bitcoinService = new BitcoinService();  //automatically picks up theparameters from the config file
            //bitcoinService.GetDifficulty();
            //bitcoinService.GetBlock(hash);
            //bitcoinService.GetBlockHash(index);

            return bitcoinService;
        }

       

        public static TransactionProperties DecodeTransaction(string tx)
        {
            var prop = new TransactionProperties(tx);

            var url = "https://blockchain.info/tx/" + tx + "?show_adv=true";

            Trace.WriteLine(url);

            var request = WebRequest.Create(url);
            var response = request.GetResponse();
            var responseText = "";
            using (var reader = new StreamReader(response.GetResponseStream(), Encoding.ASCII))
            {
                responseText = reader.ReadToEnd();
            }
            //System.Diagnostics.Trace.WriteLine(responseText);
            bool atOutput = false;//flags whether or not there is output scripts in the transaction
            var dataOut = "";

            using (StringReader reader = new StringReader(responseText))
            {
                string line = string.Empty;
                do
                {
                    line = reader.ReadLine();
                    if (line != null)
                    {
                        line = line.Trim();//Removes the blank data from the online page
                        if (line.Contains("Output Scripts"))//Looks for output scripts from the transaction
                            atOutput = true;

                        if (line.Contains("</table>"))
                            atOutput = false;

                        if (atOutput && line.Length > 100) // checks for output scripts and long enough?
                        {
                            var chunks = line.Split(' '); //removes spaces from the line
                            foreach (var c in chunks)
                            {
                                if (c.Contains('O') == false
                                    && c.Contains('\n') == false
                                    && c.Contains('>') == false
                                    && c.Contains('<') == false)
                                {
                                    var lineData = Encoding.UTF8.GetString(Utilities.Hex2Binary2(c));//C# equivalent of Python unhexlify
                                    dataOut += lineData;


                                }
                            }
                        }
                    }

                } while (line != null);
            }

            if (dataOut.Trim().Length == 0)
            {
                return prop;
            }
            var dataOutBytes = Encoding.ASCII.GetBytes(dataOut);
            prop.Length = Utilities.StructUnpackBinaryReader<Int32>(dataOutBytes, 0);
            prop.Checksum = Utilities.StructUnpackBinaryReader<Int32>(dataOutBytes, 4);
            prop.Output = Encoding.UTF8.GetString(dataOutBytes.Skip(8).ToArray());

            prop.Status = "Success";
            return prop;
        }

        public static TransactionProperties DecodeTransactionBitcoinLib(string tx)
        {
            var prop = new TransactionProperties(tx.Trim());

            var service = GetBitcoinService();
            var rawTransaction = service.GetRawTransaction(prop.Tx);
            var decodedTransaction = service.DecodeRawTransaction(rawTransaction.Hex);
            var dataOut = "";
            var dataOutBytes = new List<byte>();

            foreach (var vout in decodedTransaction.Vout)
            {
                foreach (var op in vout.ScriptPubKey.Asm.Split(' '))
                {
                    if (op.StartsWith("OP_") == false && op.Length >= 40)
                    {
                        var bytes = Utilities.Hex2Binary2(op);
                        dataOut += Encoding.ASCII.GetString(bytes);
                        dataOutBytes.AddRange(bytes);

                    }
                }
            }

            if (dataOut.Trim().Length == 0)
            {
                return prop;
            }

            var byteArray = dataOutBytes.ToArray();
            prop.Length = Utilities.StructUnpackBinaryReader<Int32>(byteArray, 0);
            prop.Checksum = Utilities.StructUnpackBinaryReader<Int32>(byteArray, 4);
            prop.Output = Encoding.UTF7.GetString(dataOutBytes.Skip(8).ToArray());
            prop.ContentBytes = dataOutBytes.Skip(8).Take(prop.Length).ToArray();
            prop.Status = "Success";

            return prop;
        }
            

        public static void DetermineFileType(TransactionProperties prop)
        {

            //prop.ContentBytes
            // parse the output of a transaction
            // if the output is a list of transactions, retrieve the first transaction and check for  file header

            var outputFileName = prop.Tx;

            using (FileStream stream = new FileStream(outputFileName, FileMode.Create))
            {
                using (BinaryWriter writer = new BinaryWriter(stream))
                {
                    writer.Write(prop.ContentBytes.ToArray());
                }
            }
            //File.WriteAllText(outputFileName, prop.Output);


            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "trid.exe",
                    Arguments = prop.Tx,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };

            proc.Start();
            List<string> tridOutput = new List<string>();

            while (!proc.StandardOutput.EndOfStream)
            {
                string line = proc.StandardOutput.ReadLine();
                tridOutput.Add(line);
            }

            prop.FileType = "Unknown";

            try
            {
                if (tridOutput.Count > 0)
                {
                    var line = tridOutput[tridOutput.Count - 1];

                    if (line.Contains("%"))
                    {
                        var parts = line.Split('%');
                        if (parts.Length < 2)
                            throw new Exception("unable to properly parse tridOut");
                        prop.FileType = parts[1];
                    }
                    else
                        prop.FileType = line;



                }
            }
            catch (Exception ex)
            {
                prop.FileType = "Error-Couldn't Determine";
            }
            //Trace.WriteLine(sb.ToString());


        }


        /// <summary>
        /// todo: This should look at the string and determine if it's a transaction or not
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsTransaction(string str)
        {
            if (str.Trim().Length > 40 && str.Trim().Contains(" ") == false)
                return true;

            Trace.WriteLine("Not a valid TX: " + str);
            return false;
        }

        #region RPC Manual calls (Most likely obsolete)
        public static string RPCRequest(string methodName, List<string> parameters)
        {
            //todo: check to make sure these are populated
            string bitcoinUrl = ConfigurationManager.AppSettings["Bitcoin_DaemonUrl"];
            string bitcoinUserName = ConfigurationManager.AppSettings["Bitcoin_RpcUsername"];
            string bitcoinPassword = ConfigurationManager.AppSettings["Bitcoin_RpcPassword"];

            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(bitcoinUrl);
            webRequest.Credentials = new NetworkCredential(bitcoinUserName, bitcoinPassword);

            webRequest.ContentType = "application/json-rpc";
            webRequest.Method = "POST";

            string respVal = string.Empty;

            JObject joe = new JObject();
            joe.Add(new JProperty("jsonrpc", "1.0"));
            joe.Add(new JProperty("id", "1"));
            joe.Add(new JProperty("method", methodName));

            JArray props = new JArray();
            foreach (var parameter in parameters)
            {
                props.Add(parameter);
            }

            joe.Add(new JProperty("params", props));

            // serialize json for the request
            string s = JsonConvert.SerializeObject(joe);
            byte[] byteArray = Encoding.UTF8.GetBytes(s);
            webRequest.ContentLength = byteArray.Length;
            Stream dataStream = webRequest.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            StreamReader streamReader = null;
            try
            {
                WebResponse webResponse = webRequest.GetResponse();

                streamReader = new StreamReader(webResponse.GetResponseStream(), true);

                respVal = streamReader.ReadToEnd();
                return respVal;
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                if (streamReader != null)
                {
                    streamReader.Close();
                }

            }
        }

        public static TransactionProperties DecodeTransactionRPC(string tx)
        {
            var prop = new TransactionProperties(tx);

            var rawtxdata = Transaction.RPCRequest("getrawtransaction", new List<string>() { tx });
            Trace.WriteLine(rawtxdata);
            var jsonTransaction = Utilities.Deserialize<Jsongetrawtransaction>(rawtxdata);
            var data = Transaction.RPCRequest("decoderawtransaction", new List<string>() { jsonTransaction.result });

            var dataOut = "";

            var decodedTransactionJson = Utilities.Deserialize<Jsondecoderawtransaction>(data);
            foreach (var txout in decodedTransactionJson.result.vout)
            {
                foreach (var op in txout.scriptPubKey.asm.Split(' '))
                {
                    if (op.StartsWith("OP_") == false && op.Length >= 40)
                    {
                        dataOut += Encoding.UTF8.GetString(Utilities.Hex2Binary2(op)); ;
                    }
                }
            }

            if (dataOut.Trim().Length == 0)
            {
                return prop;
            }
            var dataOutBytes = Encoding.ASCII.GetBytes(dataOut);
            prop.Length = Utilities.StructUnpackBinaryReader<Int32>(dataOutBytes, 0);
            prop.Checksum = Utilities.StructUnpackBinaryReader<Int32>(dataOutBytes, 4);
            prop.Output = Encoding.UTF8.GetString(dataOutBytes.Skip(8).ToArray());

            prop.Status = "Success";
            return prop;
        }
        #endregion 

        public static void SearchWallet(string WalletID)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var bitcoinService = Transaction.GetBitcoinService();
            uint totalBlockCount = bitcoinService.GetBlockCount();
            for (uint i = totalBlockCount; i >= 0; i--)
            {
                //Console.WriteLine(i);
                //TXOutputTextBox.Text = i.ToString();
                var blockhash = bitcoinService.GetBlockHash(i);
                foreach (var Tx in bitcoinService.GetBlock(blockhash).Tx)
                {
                    try
                    {
                        var Transaction = bitcoinService.GetRawTransaction(Tx);
                        var DecodeTx = bitcoinService.DecodeRawTransaction(Transaction.Hex);
                        //Console.WriteLine(Tx.ToString());
                        foreach (var vout in DecodeTx.Vout)
                        {
                            if (vout.ScriptPubKey == null)
                            {
                                var errorMessage = "SearchWallet; WalletId:" + WalletID + "; blockHash: " + blockhash + "; Tx: " + Tx + "; Tx.Hex: " + Transaction.Hex + "; vox.ScriptPubKey null";
                                Console.WriteLine(errorMessage);
                                Trace.WriteLine(errorMessage);
                                continue;
                            }
                            else if (vout.ScriptPubKey.Addresses == null)
                            {
                                var errorMessage = "SearchWallet; WalletId:" + WalletID + "; blockHash: " + blockhash + "; Tx: " + Tx + "; Tx.Hex: " + Transaction.Hex + "; vox.ScriptPubKey.Addressses null";
                                Console.WriteLine(errorMessage);
                                Trace.WriteLine(errorMessage);
                                continue;
                            }

                            foreach (var addresses in vout.ScriptPubKey.Addresses)
                            {

                                //Console.WriteLine(addresses);
                                if (addresses == WalletID)
                                {
                                    //Console.WriteLine(addresses);
                                    Trace.WriteLine("found");
                                    //TXOutputTextBox.Text += blockhash;
                                    break;
                                }
                            }

                        }
                    }
                    catch (BitcoinLib.ExceptionHandling.Rpc.RpcInternalServerErrorException ex)
                    {
                        if (ex.RpcErrorCode == BitcoinLib.RPC.Specifications.RpcErrorCode.RPC_INVALID_ADDRESS_OR_KEY)
                        {
                            // ignore this for now
                        }
                        else
                            throw ex;

                    }
                    catch (Exception ex)
                    {
                        throw ex;

                        //Console.WriteLine(e);

                    }


                }
            }
            sw.Stop();
            Trace.WriteLine(sw.Elapsed);
        }
        
    }
}
