using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace LoLViewer
{

    //This class will contain all the methods I will use to access various API's and call them from the main 
    //program class. All classes will be of return type string? for Console.WriteLine-ing the results? We shall see.
    public partial class LoLViewerMain
    {
 


        //finds and populates a summoner object with data from the API.
        //returns null and prints the exception if something goes wrong.
        public static async Task<Summoner> FillSummoner(string apiKey, string summonerName, HttpClient client)
        {
            //always clear headers first so you can call consecutively..
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("X-Riot-Token", apiKey);
            try{

            
            var result = await client.GetStreamAsync("https://na1.api.riotgames.com/lol/summoner/v3/summoners/by-name/" + summonerName);
            var serializer = new DataContractJsonSerializer(typeof(Summoner));
            Summoner summoner = serializer.ReadObject(result) as Summoner;
            return summoner;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }

        // }
        // public string getRanks()
        // {
        //            List<Positions> model = null;
        //     var result = await client.GetStreamAsync(baseUrl + "/lol/league/v3/positions/by-summoner/21044320");
        //     var serializer = new DataContractJsonSerializer(typeof(List<Positions>));
        //     List<Positions> positions = serializer.ReadObject(result) as List<Positions>;
        //     foreach (Positions p in positions)
        //     {
        //         Console.WriteLine("Summoner Name: " + p.playerOrTeamName);
        //         Console.WriteLine("Queue: " + p.queueType);
        //         Console.WriteLine("Rank: " + p.tier + " " + p.rank);
        //         Console.WriteLine("Wins: " + p.wins);
        //         Console.WriteLine("Losses: " + p.losses);
        //         Console.WriteLine("-------------------------------");

        //     }
        // }





    }
}