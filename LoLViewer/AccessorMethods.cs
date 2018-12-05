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
 

        private static string baseUrl = "https://na1.api.riotgames.com";

        //finds and populates a summoner object with data from the API.
        //returns null and prints the exception if something goes wrong.
        public static async Task<Summoner> FillSummoner(string apiKey, string summonerName, HttpClient client)
        {
            //always clear headers first so you can call consecutively..
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("X-Riot-Token", apiKey);
            try{

            
            var result = await client.GetStreamAsync(baseUrl + "/lol/summoner/v3/summoners/by-name/" + summonerName);
            var serializer = new DataContractJsonSerializer(typeof(Summoner));
            Summoner summoner = serializer.ReadObject(result) as Summoner;
            Console.WriteLine("Summoner: " + summoner.name + "\n Level: " + summoner.summonerLevel);
            return summoner;
            
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }

        
        //get ranked info. because there are multiple queues, has to be a list of positions.
         public static async Task<List<Positions>> FindRank(string apiKey, string summonerId, HttpClient client)
        {
             //always clear headers first so you can call consecutively..
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("X-Riot-Token", apiKey);
            try{

            var result = await client.GetStreamAsync(baseUrl + "/lol/league/v3/positions/by-summoner/" + summonerId);
            var serializer = new DataContractJsonSerializer(typeof(List<Positions>));
            List<Positions> positions = serializer.ReadObject(result) as List<Positions>;
            return positions;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }





    }
}