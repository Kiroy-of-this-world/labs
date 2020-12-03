using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using System.Xml.Linq;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml.Serialization;
using System.Text.Json;

namespace Laba_14
{
    [Serializable]
    public class Tennis
    {
        public Tennis() { }
    }
    [Serializable]
    public class TennisBall : Tennis
    {
        public int numberOfBall = 1;
        public int price = 20;
        public string name;
        public TennisBall() { }
        public void Output()
        {
            Console.WriteLine($"Номер мяча: {numberOfBall}");
            Console.WriteLine($"Цена мяча: {price}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            TennisBall ball1 = new TennisBall();

            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fileStream = new FileStream("data.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fileStream, ball1);
                Console.WriteLine("Объект сериализован (Bin)");
            }
            using (FileStream fileStream = new FileStream("data.dat", FileMode.OpenOrCreate))
            {
                TennisBall ball11 = (TennisBall)formatter.Deserialize(fileStream);
                Console.WriteLine("Номер мяча: " + ball11.numberOfBall);
                Console.WriteLine("Цена мяча: " + ball11.price);
                Console.WriteLine("Объект десериализован");
            }
            Console.WriteLine();

            SoapFormatter sformatter = new SoapFormatter();
            using (FileStream fileStream = new FileStream("data.soap", FileMode.OpenOrCreate))
            {
                sformatter.Serialize(fileStream, ball1);
                Console.WriteLine("Объект сериализован (Saop)");
            }
            using (FileStream fileStream = new FileStream("data.soap", FileMode.OpenOrCreate))
            {
                TennisBall ball12 = (TennisBall)sformatter.Deserialize(fileStream);
                Console.WriteLine("Номер мяча: " + ball12.numberOfBall);
                Console.WriteLine("Цена мяча: " + ball12.price);
                Console.WriteLine("Объект десериализован");
            }
            Console.WriteLine();

            string json = JsonSerializer.Serialize(ball1);
            Console.WriteLine("Объект сериализован (Json)");
            TennisBall ball13 = JsonSerializer.Deserialize<TennisBall>(json);
            Console.WriteLine("Номер мяча: " + ball13.numberOfBall);
            Console.WriteLine("Цена мяча: " + ball13.price);
            Console.WriteLine("Объект десериализован");
            Console.WriteLine();

            XmlSerializer xformatter = new XmlSerializer(typeof(TennisBall));
            using (FileStream fileStream = new FileStream("data.xml", FileMode.OpenOrCreate))
            {
                xformatter.Serialize(fileStream, ball1);
                Console.WriteLine("Объект сериализован (Xml)");
            }
            using (FileStream fileStream = new FileStream("data.xml", FileMode.OpenOrCreate))
            {
                TennisBall ball14 = (TennisBall)xformatter.Deserialize(fileStream);
                Console.WriteLine("Номер мяча: " + ball14.numberOfBall);
                Console.WriteLine("Цена мяча: " + ball14.price);
                Console.WriteLine("Объект десериализован");
            }
            Console.WriteLine();

            List<TennisBall> balls = new List<TennisBall>();
            balls.Add(ball1);
            balls.Add(ball1);
            balls.Add(ball1);
            XmlSerializer xSer = new XmlSerializer(typeof(List<TennisBall>));
            using (FileStream fileStream = new FileStream("data1.xml", FileMode.OpenOrCreate))
            {
                xSer.Serialize(fileStream, balls);
                Console.WriteLine("Коллекция сериализована (Xml)");
            }
            using (FileStream fileStream = new FileStream("data1.xml", FileMode.OpenOrCreate))
            {
                List<TennisBall> ball15 = (List<TennisBall>)xSer.Deserialize(fileStream);
                int j = 1;
                foreach (TennisBall g in ball15)
                {
                    Console.WriteLine("Цена " + j + " мяча: " + g.price);
                    j++;
                }
                Console.WriteLine("Объект десериализован");
            }
            Console.WriteLine();

            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("data1.xml");
            XmlElement xRoot = xDoc.DocumentElement;
            XmlNodeList childnodes = xRoot.SelectNodes("*");
            foreach (XmlNode n in childnodes)
                Console.WriteLine(n.OuterXml);
            Console.WriteLine();

            XmlNodeList nodes = xRoot.SelectNodes("TennisBall");
            foreach (XmlNode n in nodes)
            {
                XmlNodeList nnn = n.SelectNodes("numberOfBall");
                foreach (XmlNode c in nnn)
                {
                    Console.WriteLine("Номер мяча: " + c.InnerText);
                }
                XmlNodeList nn = n.SelectNodes("price");
                foreach (XmlNode c in nn)
                {
                    Console.WriteLine("Цена мяча: " + c.InnerText);
                }
            }
            Console.WriteLine();


            XDocument doc = new XDocument();
            XElement user = new XElement("Player");
            XElement user2 = new XElement("Player");
            XAttribute userName = new XAttribute("Name", "Кирилл");
            XAttribute userName2 = new XAttribute("Name", "Дима");
            XElement userPass = new XElement("Wins", "3");
            XElement userPass2 = new XElement("Wins", "null");
            user.Add(userName);
            user.Add(userPass);
            user2.Add(userName2);
            user2.Add(userPass2);
            XElement users = new XElement("Tennis");
            users.Add(user);
            users.Add(user2);
            doc.Add(users);
            doc.Save("linq.xml");
            XDocument xdoc = XDocument.Load("linq.xml");
            var res = from xe in xdoc.Element("Tennis").Elements("Player")
                      select new TennisBall
                      {
                          name = xe.Attribute("Name").Value
                      };
            foreach (TennisBall comp in res)
                Console.WriteLine(comp.name);
            Console.WriteLine();
        }
    }
}
