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
            //config for adding api key without putting it directly in code.
            IConfiguration config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();

            string key = config["apiKey"];

            Console.WriteLine("Enter a number corresponding to the action youd like:");
            string userInput = "";
            string summonerName = "";
            //loop until user exits. allows users to find multiple opponents instead of running more than one time for each opponent.
            while (!userInput.Equals("Exit") && !userInput.Equals("exit"))
            {
                Console.WriteLine("1. Find Summoner by Name");
                userInput = Console.ReadLine();

                if (userInput.Equals("1"))
                {
                    Summoner sum = new Summoner();
                    Console.WriteLine("Enter Summoner Name: ");
                    summonerName = Console.ReadLine();
                    sum = await FillSummoner(key, summonerName, client);

                    //find more details if that is the correct summoner.
                    Console.WriteLine("Find Rank? (Y/N)");

                    userInput = Console.ReadLine();
                    if (userInput.ToLower().Equals("y") || userInput.ToLower().Equals("yes"))
                    {
                        List<Positions> positionList = new List<Positions>();
                        positionList = await FindRank(key, sum.id.ToString(), client);
                        Console.WriteLine("Summoner Name: " + sum.name);
                        foreach (Positions p in positionList)
                        {

                            Console.WriteLine("Queue: " + p.queueType);
                            Console.WriteLine("Rank: " + p.tier + " " + p.rank);
                            Console.WriteLine("Wins: " + p.wins);
                            Console.WriteLine("Losses: " + p.losses);
                            Console.WriteLine("-------------------------------");
                        }
                    }
                    else
                    {

                    }
                }


            }

        }
    }
}
