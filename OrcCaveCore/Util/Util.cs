using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Globalization;
using System.Threading;
using System.Linq;
using System.Security.Cryptography;
using ICSharpCode.SharpZipLib.GZip;
using ICSharpCode.SharpZipLib.Core;

namespace Util
{
    public class Util
    {
        public static string Serialize<T>(T dataToSerialize)
        {
            try
            {
                CultureInfo n = new CultureInfo("pt-br");
                Thread.CurrentThread.CurrentCulture = n;
                Thread.CurrentThread.CurrentUICulture = n;

                var serializer = new XmlSerializer(typeof(T));
                var stringwriter = new System.IO.StringWriter();

                var ns = new XmlSerializerNamespaces();
                ns.Add("", "");

                var xmlWriter = XmlWriter.Create(stringwriter, new XmlWriterSettings() { OmitXmlDeclaration = true });

                serializer.Serialize(xmlWriter, dataToSerialize, ns);

                return stringwriter.ToString();
            }
            catch
            {
                throw;
            }
        }

        //public static void Main()
        //{
        //    var str = "<verticalTab>\v</verticalTab>";
        //    Console.WriteLine(RemoveInvalidXmlChars(str));
        //    Console.WriteLine(CheckValidXmlChars(str));
        //}

        public static string RemoveInvalidXmlChars(string content)
        {
            return new string(content.Where(ch => System.Xml.XmlConvert.IsXmlChar(ch)).ToArray());
        }

        public static bool CheckValidXmlChars(string content)
        {
            return content.All(ch => System.Xml.XmlConvert.IsXmlChar(ch));
        }

        public static T Deserialize<T>(string xmlText)
        {
            try
            {
                CultureInfo n = new CultureInfo("pt-br");
                Thread.CurrentThread.CurrentCulture = n;
                Thread.CurrentThread.CurrentUICulture = n;

                var stringReader = new System.IO.StringReader(xmlText);
                var serializer = new XmlSerializer(typeof(T));
                return (T)serializer.Deserialize(stringReader);
            }
            catch
            {
                throw;
            }
        }

        public static string FormatNumberWithoutSymbols(string original)
        {
            return string.Join("", original.Where(char.IsDigit));
        }

        public static string GetDateTimeToString()
        {
            return DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss"); 
        }

        public static string CalculateMD5(string filename)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filename))
                {
                    var hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
        }

        public static void UnzipGZIPFile(string file, string folder)
        {
            byte[] dataBuffer = new byte[4096];

            using (System.IO.Stream fs = new FileStream(file, FileMode.Open, FileAccess.Read))
            {
                using (GZipInputStream gzipStream = new GZipInputStream(fs))
                {
                    // Change this to your needs
                    string fnOut = Path.Combine(folder, Path.GetFileNameWithoutExtension(file)) + ".html";

                    using (FileStream fsOut = File.Create(fnOut))
                    {
                        StreamUtils.Copy(gzipStream, fsOut, dataBuffer);
                    }
                }
            }
        }


    }
}

