using System;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Post
{
    class ConsoleMessage
    {
        public int Id { get; set; }
        public string ConsoleMsg { get; set; }
        public DateTime Date { get; set; }
    }

    class Program
    {
        static void Main()
        {
            RunAsync().Wait();
        }

        static async Task RunAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:52991/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                Console.WriteLine("Skriv något:");
                Console.WriteLine();
                var consoleMessage = Console.ReadLine();

                var msg = new ConsoleMessage() { ConsoleMsg = consoleMessage, Date = DateTime.Now };
                var response = await client.PostAsJsonAsync("api/ConsoleMessage", msg);
                if (response.IsSuccessStatusCode)
                {
                    Uri msgUrl = response.Headers.Location;
                }
            }
        }
    }
}
