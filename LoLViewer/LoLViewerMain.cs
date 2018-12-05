using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace LoLViewer
{
    public partial class LoLViewerMain
    {
        private static HttpClient client = new HttpClient();
        public static async Task Main(string[] args)
        {
            IConfiguration config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional:true, reloadOnChange:true)
            .Build();
            string key = config["apiKey"];
            Console.WriteLine(key);
            Console.WriteLine("Enter a number corresponding to the action youd like:");
            string userInput = "";
            string summonerName = "";
            while (!userInput.Equals("Exit") && !userInput.Equals("exit"))
            {
                Console.WriteLine("1. Find Summoner by Name");
                userInput = Console.ReadLine();

                if(userInput.Equals("1"))
                {
                    Console.WriteLine("Enter Summoner Name: ");
                     summonerName = Console.ReadLine();
                     Console.WriteLine(await FillSummoner(key, summonerName, client));
                }


            }

        }
    }
}
