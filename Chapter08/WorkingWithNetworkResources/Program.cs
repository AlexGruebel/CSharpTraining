using System;
using System.Net;
using System.Net.NetworkInformation;

namespace WorkingWithNetworkResources
{
    class Program
    {
        static void Main(string[] args){
            Console.Write("Enter a valid web address: ");
            string url = Console.ReadLine();

            var uri = new Uri(url);

            Console.WriteLine($"Scheme: {uri.Scheme}");
            Console.WriteLine($"Port: {uri.Port}");
            Console.WriteLine($"Host: {uri.Host}");
            Console.WriteLine($"Querry: {uri.Query}");

            IPHostEntry entry = Dns.GetHostEntry(uri.Host);
            Console.Write($"{entry.HostName} hast the following IP addresse:");

            foreach (var item in entry.AddressList){
                Console.Write($" {item} ");
            }

            var ping = new Ping();
            PingReply reply = ping.Send(uri.Host);
            Console.WriteLine($"\n{uri.Host} was pinged, and replied {reply.Status}.");
            if(reply.Status == IPStatus.Success){
                Console.WriteLine($"Reply from {reply.Address} took {reply.RoundtripTime}ms");
            }

        }
    }
}
