using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.IO;
using Newtonsoft.Json;
using System.Xml.Serialization;

namespace Exercies02
{
    class Program
    {
        static void Main(string[] args)
        {

            var products = GetDataProduct();
            var categories = GetDataCategory();
            SaveArrayToJson(products);
            SaveArrayToJson(categories);
            SaveArrayToXml(products);
            SaveArrayToXml(categories);
            SaveArrayToCsv(products);
            SaveArrayToCsv(categories);
        }

        static Product[] GetDataProduct(){
            using(var db = new Northwind()){
                return db.Products.ToArray();
            }
        }

        static Category[] GetDataCategory(){
            using(var db = new Northwind()){
                return db.Categories.ToArray();
            }
        }

        static void SaveArrayToJson<T>(T[] data){
            using(StreamWriter sw = File.CreateText($"./target/{data.ToString()}.json"))
            {
                JsonSerializer jss = new JsonSerializer();
                jss.Serialize(sw, data);
            }
        }

        static void SaveArrayToXml<T>(T[] data){
            using(StreamWriter sw = File.CreateText($"./target/{data.ToString()}.xml")){
                XmlSerializer xs = new XmlSerializer(typeof(T[]));
                xs.Serialize(sw, data);
            }
        }

        static void SaveArrayToCsv<T>(T[] data) where T : IToCsv
        {
            using(StreamWriter sw = File.CreateText($"./target/{data.ToString()}.csv")){
                sw.WriteLine(data[0].HeadLine);
                foreach (var item in data)
                {
                    sw.WriteLine(item.ToCsv());
                }
            }
        }
    }
}
