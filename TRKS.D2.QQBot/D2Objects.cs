using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TRKS.D2.QQBot
{
    public class D2Objects
    {

        public class SearchResult
        {
            public int platformId { get; set; }
            public string platformSlug { get; set; }
            public string platformUserIdentifier { get; set; }
            public object platformUserId { get; set; }
            public string platformUserHandle { get; set; }
            public object avatarUrl { get; set; }
            public object additionalParameters { get; set; }
        }

        public class PlayerInfo
        {
            public Response Response { get; set; }
            public int ErrorCode { get; set; }
            public int ThrottleSeconds { get; set; }
            public string ErrorStatus { get; set; }
            public string Message { get; set; }
            public Messagedata MessageData { get; set; }
        }

        public class Response
        {
            public Vendorreceipts vendorReceipts { get; set; }
            public Profileinventory profileInventory { get; set; }
            public Profilecurrencies profileCurrencies { get; set; }
            public Profile profile { get; set; }
            public Characters characters { get; set; }
        }

        public class Vendorreceipts
        {
            public int privacy { get; set; }
        }

        public class Profileinventory
        {
            public int privacy { get; set; }
        }

        public class Profilecurrencies
        {
            public int privacy { get; set; }
        }

        public class Profile
        {
            public Data data { get; set; }
            public int privacy { get; set; }
        }

        public class Data
        {
            public Userinfo userInfo { get; set; }
            public DateTime dateLastPlayed { get; set; }
            public int versionsOwned { get; set; }
            public string[] characterIds { get; set; }
            public long[] seasonHashes { get; set; }
            public int currentSeasonHash { get; set; }
        }

        public class Userinfo
        {
            public int crossSaveOverride { get; set; }
            public int[] applicableMembershipTypes { get; set; }
            public bool isPublic { get; set; }
            public int membershipType { get; set; }
            public string membershipId { get; set; }
            public string displayName { get; set; }
        }

        public class Characters
        {
            public Data1 data { get; set; }
            public int privacy { get; set; }
        }

        public class Data1
        {
            public List<Character> characters { get; set; }
        }

        public class Character
        {
            [JsonIgnore]
            public string type { get; set; }

            public string membershipId { get; set; }
            public int membershipType { get; set; }
            public string characterId { get; set; }
            public DateTime dateLastPlayed { get; set; }
            public string minutesPlayedThisSession { get; set; }
            public string minutesPlayedTotal { get; set; }
            public int light { get; set; }
            public Stats stats { get; set; }
            public int raceHash { get; set; }
            public long genderHash { get; set; }
            public long classHash { get; set; }
            public int raceType { get; set; }
            public int classType { get; set; }
            public int genderType { get; set; }
            public string emblemPath { get; set; }
            public string emblemBackgroundPath { get; set; }
            public long emblemHash { get; set; }
            public Emblemcolor emblemColor { get; set; }
            public Levelprogression levelProgression { get; set; }
            public int baseCharacterLevel { get; set; }
            public int percentToNextLevel { get; set; }
        }

        public class Stats
        {
            public int _144602215 { get; set; }
            public int _392767087 { get; set; }
            public int _1735777505 { get; set; }
            public int _1935470627 { get; set; }
            public int _1943323491 { get; set; }
            public int _2996146975 { get; set; }
            public int _4244567218 { get; set; }
        }

        public class Emblemcolor
        {
            public int red { get; set; }
            public int green { get; set; }
            public int blue { get; set; }
            public int alpha { get; set; }
        }

        public class Levelprogression
        {
            public int progressionHash { get; set; }
            public int dailyProgress { get; set; }
            public int dailyLimit { get; set; }
            public int weeklyProgress { get; set; }
            public int weeklyLimit { get; set; }
            public int currentProgress { get; set; }
            public int level { get; set; }
            public int levelCap { get; set; }
            public int stepIndex { get; set; }
            public int progressToNextLevel { get; set; }
            public int nextLevelAt { get; set; }
        }

        public class Emblemcolor1
        {
            public int red { get; set; }
            public int green { get; set; }
            public int blue { get; set; }
            public int alpha { get; set; }
        }

        public class Levelprogression1
        {
            public int progressionHash { get; set; }
            public int dailyProgress { get; set; }
            public int dailyLimit { get; set; }
            public int weeklyProgress { get; set; }
            public int weeklyLimit { get; set; }
            public int currentProgress { get; set; }
            public int level { get; set; }
            public int levelCap { get; set; }
            public int stepIndex { get; set; }
            public int progressToNextLevel { get; set; }
            public int nextLevelAt { get; set; }
        }

        public class Messagedata
        {
        }


    }
}
