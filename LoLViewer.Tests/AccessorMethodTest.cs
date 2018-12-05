using System;
using System.Collections.Generic;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace LoLViewer.Tests
{
    public class AccessorMethodTest
    {
        private Summoner _summoner;
        private List<Positions> _positions;
        private readonly Summoner _controlSummoner;
        private readonly Positions _controlPositions;
        private static HttpClient client = new HttpClient();
        private static string key;

        public AccessorMethodTest()
        {
            _summoner = new Summoner();
            _positions = new List<Positions>();
            _controlSummoner = new Summoner();
            _controlPositions = new Positions();
            IConfiguration config = new ConfigurationBuilder()
.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
.Build();

            key = config["apiKey"];


        }

        //summoner test. Tests a control summoner with manually entered data vs the deserialized object returned by the api.
        [Fact]
        public async void TestSummoner()
        {
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("X-Riot-Token", key);
            _summoner = await LoLViewer.LoLViewerMain.FillSummoner(key, "Aclyptic", client);

            _controlSummoner.profileIconId = 938;
            _controlSummoner.name = "Aclyptic";
            _controlSummoner.summonerLevel = 108;
            _controlSummoner.accountId = 33911210;
            _controlSummoner.id = 21044320;
            _controlSummoner.revisionDate = 1543455263000;


            Assert.Equal(_controlSummoner.profileIconId, _summoner.profileIconId);
            Assert.Equal(_controlSummoner.name, _summoner.name);
            Assert.Equal(_controlSummoner.summonerLevel, _summoner.summonerLevel);
            Assert.Equal(_controlSummoner.accountId, _summoner.accountId);
            Assert.Equal(_controlSummoner.id, _summoner.id);
            Assert.Equal(_controlSummoner.revisionDate, _summoner.revisionDate);


        }

        //position test. Tests a control position with manually entered data vs the deserialized object returned by the api.
        [Fact]
        public async void TestPosition()
        {

            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("X-Riot-Token", key);
            _positions = await LoLViewer.LoLViewerMain.FindRank(key, "21044320", client);

            Positions p = _positions[0];

            Assert.True(_positions.Count > 0);
            Assert.True(_positions.Count > 1);

            _controlPositions.queueType = "RANKED_SOLO_5x5";
            _controlPositions.wins = 64;
            _controlPositions.losses = 75;
            _controlPositions.leagueName = "Jarvan IV's Scions";
            _controlPositions.playerOrTeamName = "Aclyptic";
            _controlPositions.rank = "IV";
            _controlPositions.leagueId = "0da53b80-15b0-11e8-a61f-c81f66cf2333";
            _controlPositions.tier = "GOLD";
            _controlPositions.leaguePoints = 0;


            Assert.Equal(_controlPositions.queueType, p.queueType);
            Assert.Equal(_controlPositions.wins, p.wins);
            Assert.Equal(_controlPositions.losses, p.losses);
            Assert.Equal(_controlPositions.leagueName, p.leagueName);
            Assert.Equal(_controlPositions.playerOrTeamName, p.playerOrTeamName);
            Assert.Equal(_controlPositions.rank, p.rank);
            Assert.Equal(_controlPositions.leagueId, p.leagueId);
            Assert.Equal(_controlPositions.tier, p.tier);
            Assert.Equal(_controlPositions.leaguePoints, p.leaguePoints);


        }
    }
}
