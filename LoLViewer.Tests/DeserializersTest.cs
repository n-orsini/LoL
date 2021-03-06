using System;
using Xunit;

namespace LoLViewer.Tests
{
    public class DeserializersTest
    {
        private readonly Summoner _summoner;
        private readonly Positions _positions;

        public DeserializersTest()
        {
            _summoner = new Summoner();
            _positions = new Positions();
        }

        [Fact]
        public void TestSummoner()
        {
            
            _summoner.name = "Aclyptic";
            _summoner.accountId = 12345;
            _summoner.summonerLevel = 103;
            _summoner.profileIconId = 3;
            _summoner.id = 453463456;
            _summoner.revisionDate = 12432536746457474;

            Assert.Equal("Aclyptic",_summoner.name);
            Assert.Equal(12345,_summoner.accountId);
            Assert.Equal(103,_summoner.summonerLevel);
            Assert.Equal(3,_summoner.profileIconId);
            Assert.Equal(453463456,_summoner.id);
            Assert.Equal(12432536746457474,_summoner.revisionDate);
        }

        [Fact]
        public void TestPosition()
        {
            
            _positions.queueType = "Solo/Duo";
            _positions.wins = 100;
            _positions.losses = 90;
            _positions.playerOrTeamName = "Aclyptic";
            _positions.rank = "Platinum";
            _positions.leagueId = "12345a";
            _positions.tier = "IV";
            _positions.leaguePoints = 93;



            Assert.Equal("Solo/Duo", _positions.queueType);
            Assert.Equal(100, _positions.wins);
            Assert.Equal(90, _positions.losses);
            Assert.Equal("Aclyptic", _positions.playerOrTeamName);
            Assert.Equal("Platinum", _positions.rank);
            Assert.Equal("12345a", _positions.leagueId);
            Assert.Equal("IV", _positions.tier);
            Assert.Equal(93, _positions.leaguePoints);

        }
    }
}
