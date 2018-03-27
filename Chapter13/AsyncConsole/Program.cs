using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AsyncConsole
{
    class Program
    {
        
         
        static async Task Main(string[] args)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://www.apple.com/");
            Console.WriteLine($"Apple's home page has {response.Content.Headers.ContentLength} bytes");
        }
    }
}
