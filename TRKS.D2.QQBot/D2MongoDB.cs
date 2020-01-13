using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GammaLibrary.Extensions;
using MongoDB.Bson;
using MongoDB.Driver;


namespace TRKS.D2.QQBot
{
    public class D2MongoDB
    {
        private static MongoClient client;
        private IMongoDatabase d2Database;
        private IMongoCollection<BsonDocument> inventoryitem;
        private IMongoCollection<BsonDocument> charactercustomization;
        private IMongoCollection<BsonDocument> destinyclass;
        public D2MongoDB()
        {
            client = new MongoClient("mongodb://localhost:27017/?readPreference=primary&appname=MongoDB%20Compass%20Community&ssl=false");
            d2Database = client.GetDatabase("destiny2");
            inventoryitem = 
                d2Database.GetCollection<BsonDocument>("chs_DestinyInventoryItemDefinition");
            charactercustomization =
                d2Database.GetCollection<BsonDocument>("chs_DestinyCharacterCustomizationOptionDefinition");
            destinyclass = 
                d2Database.GetCollection<BsonDocument>("chs_DestinyClassDefinition");
        }

        public string GetItemNameFromId(string id)
        {
            var item = inventoryitem.Find(new BsonDocument
            {
                {"_id", id}
            }).ToList().First();
            return item.GetValue("displayProperties").ToBsonDocument().GetValue("name").ToString();
        }

        public string GetCharacterType(long genderid, int raceid, long classid)
        {
            var type = inventoryitem.Find(new BsonDocument
            {
                {"genderHash", genderid },
                {"raceHash", raceid }
            }).ToList().First();
            var classtype = destinyclass.Find(new BsonDocument
            {
                {"hash", classid}
            }).ToList().First();
            return type.GetValue("displayProperties").ToBsonDocument().GetValue("name").ToString() + classtype.GetValue("displayProperties").ToBsonDocument().GetValue("name");
        }
        // 妈的 数据库操作真鬼畜

    }
}
