using System;
namespace LoLViewer
{
    //Deserializer class for getting a summoners ladder information on different match types. 
    //eg Ranked Solo/Duo, Ranked Flex, Ranked 3's
    public class Positions
    {

        public string queueType { get; set; }
        public Boolean hotStreak { get; set; }
        public int wins { get; set; }
        public Boolean veteran { get; set; }
        public int losses { get; set; }
        public string playerOrTeamId { get; set; }
        public string playerOrTeamName { get; set; }

        public Boolean inactive { get; set; }
        public string rank { get; set; }
        public Boolean freshBlood { get; set; }
        public string leagueId { get; set; }
        public string tier { get; set; }
        public int leaguePoints { get; set; }

    }

    //Deserializer class for getting the summoner by name api. Only return name and summoner level. Probably cant hurt
    //but I dont know why anyone would want accountid etc. Store id for further calls. Overwrite ID on new getsummoner call.
    public class Summoner
    {
        public int profileIconId { get; set; }
        public string name { get; set; }
        public int summonerLevel { get; set; }
        public int accountId { get; set; }
        public int id { get; set; }
        public long revisionDate { get; set; }
    }
}