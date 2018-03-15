using System;
using Shapes;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Exercies02
{
    class Program
    {
        static void Main(string[] args)
        {

            Figur[] figurs = {
                new Kreis(2),
                new Rechteck(10, 20)
            };

            //SeralizeToXml(figurs);
            SerializeToJson(figurs);
            List<Figur> figurs2 = ReadJson();
            foreach(var item in figurs2){
                Console.WriteLine($"{item.FigurName}, {item.Flache}");
            }
        }

        static void SeralizeToXml(Figur[] figurs){
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Shapes.xml");
            using(FileStream stream = File.Create(path)){
                XmlSerializer xml = new XmlSerializer(typeof(Figur[]));
                xml.Serialize(stream, figurs);
            }
        }

        static void SerializeToJson(Figur[] figurs){
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Shapes.json");
            using(StreamWriter stream = File.CreateText(path)){
                var jss = new JsonSerializer();
                jss.Serialize(stream, figurs);
            }
        }

        static List<Figur> ReadJson(){
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Shapes.json");
            string text = File.ReadAllText(path);
            Console.WriteLine(text);
            JArray a = JArray.Parse(text);
            List<Figur> figurs = new List<Figur>();
            
            foreach(var item in a){
                if(item["FigurName"].ToString() == "Kreis"){
                    figurs.Add(JsonConvert.DeserializeObject<Kreis>(item.ToString()));
                }else{
                    figurs.Add(JsonConvert.DeserializeObject<Rechteck>(item.ToString()));
                }
            }
            return figurs;
        }
    }
}
