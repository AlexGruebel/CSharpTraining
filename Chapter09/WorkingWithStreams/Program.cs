using System;
using System.IO;
using System.Text;
using System.Xml;
using System.IO.Compression;

namespace WorkingWithStreams{
    
    class Program{
        
        static string[] callsigns = new string[] {"Husker", "Starbuck", "Apollo",
                                                  "Boomer"};
        
        static void Main(string[] args){
            //WorkWithText();
            //WorkWithXml();
            WorkWithCompression();
        }

        static void WorkWithText()
        {
            string textFile = Path.Combine(Directory.GetCurrentDirectory(), "streams.txt");
            Console.WriteLine(textFile);
            StreamWriter text = File.CreateText(textFile);

            foreach (var item in callsigns)
            {
                text.WriteLine(item);
            }

            text.Close();
            //Console.WriteLine(File.ReadAllText(textFile));

            //String aufteilen
            string[] txt = File.ReadAllText(textFile).Split("\n");
            foreach (var item in txt)
            {
                Console.WriteLine(item);
            }
        }

        static void WorkWithXml()
        {
            string xmlFile = Path.Combine(Directory.GetCurrentDirectory(), "streams.xml");

            using(FileStream xmlFileStream = File.Create(xmlFile)){
                using(XmlWriter xml = XmlWriter.Create(xmlFileStream, new XmlWriterSettings {Indent = true})){
                    xml.WriteStartDocument();
                    xml.WriteStartElement("callsigns");

                    foreach (var item in callsigns){
                        xml.WriteElementString("callsign", item);
                    }

                    xml.WriteEndElement();
                }
            }    
        }

        static void WorkWithCompression()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "streams.gzip");
            FileStream f = File.Create(path);
            using(GZipStream compressor = new GZipStream(f, CompressionMode.Compress)){
               using(XmlWriter xml = XmlWriter.Create(compressor)){
                   xml.WriteStartDocument();
                   xml.WriteStartElement("callsigngs");
                   foreach (var item in callsigns)
                   {
                       xml.WriteElementString("callsing", item);
                   }
               }
            }

        }   
    }
}
