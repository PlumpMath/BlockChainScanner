using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public static class Utilities
    {
        public static T StructUnpackBinaryReader<T>(byte[] data, int startIndex)
        {
            using (var stream = new MemoryStream(data))
            {
                using (var reader = new BinaryReader(stream))
                {
                    stream.Seek(startIndex, SeekOrigin.Begin);

                    var val = reader.ReadInt32();
                    return (T)Convert.ChangeType(val, typeof(T));
                }
            }
        }

        public static string Hex2Char(string hexvalue)
        {
            StringBuilder charVal = new StringBuilder();
            for (int i = 0; i < hexvalue.Length; i++)
            {
                charVal.Append(Convert.ToChar(hexvalue.Substring(i, 1)));
            }
            return charVal.ToString();
        }
        public static byte[] Hex2Binary2(string hex)
        {
            var chars = hex.ToCharArray();
            var bytes = new List<byte>();
            for (int index = 0; index < chars.Length; index += 2)
            {
                var chunk = new string(chars, index, 2);
                bytes.Add(byte.Parse(chunk, NumberStyles.AllowHexSpecifier));
            }
            return bytes.ToArray();
        }
        public static string Hex2Binary(string hexvalue)
        {
            StringBuilder binaryval = new StringBuilder();
            for (int i = 0; i < hexvalue.Length; i++)
            {
                string byteString = hexvalue.Substring(i, 1);
                byte b = Convert.ToByte(byteString, 16);
                binaryval.Append(Convert.ToString(b, 2).PadLeft(4, '0'));
            }
            return binaryval.ToString();
        }
        public static string Hex2Base64(string hexvalue)
        {
            if (hexvalue.Length % 2 != 0)
                hexvalue = "0" + hexvalue;
            int len = hexvalue.Length / 2;
            byte[] bytes = new byte[len];
            for (int i = 0; i < len; i++)
            {
                string byteString = hexvalue.Substring(2 * i, 2);
                bytes[i] = Convert.ToByte(byteString, 16);
            }
            return Convert.ToBase64String(bytes);
        }

        public static Encoding GetEncoding(string filename)
        {
            // Read the BOM
            var bom = new byte[4];
            using (var file = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                file.Read(bom, 0, 4);
            }

            // Analyze the BOM
            if (bom[0] == 0x2b && bom[1] == 0x2f && bom[2] == 0x76) return Encoding.UTF7;
            if (bom[0] == 0xef && bom[1] == 0xbb && bom[2] == 0xbf) return Encoding.UTF8;
            if (bom[0] == 0xff && bom[1] == 0xfe) return Encoding.Unicode; //UTF-16LE
            if (bom[0] == 0xfe && bom[1] == 0xff) return Encoding.BigEndianUnicode; //UTF-16BE
            if (bom[0] == 0 && bom[1] == 0 && bom[2] == 0xfe && bom[3] == 0xff) return Encoding.UTF32;
            return Encoding.ASCII;
        }


        public static string Serialize<T>(T obj)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
            MemoryStream ms = new MemoryStream();
            serializer.WriteObject(ms, obj);
            string retVal = Encoding.UTF8.GetString(ms.ToArray());
            return retVal;
        }

        public static T Deserialize<T>(string json)
        {
            T obj = Activator.CreateInstance<T>();
            MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(json));
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
            obj = (T)serializer.ReadObject(ms);
            ms.Close();
            return obj;
        }
    }
}
