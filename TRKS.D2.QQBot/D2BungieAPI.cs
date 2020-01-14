using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TRKS.D2.QQBot
{
    public class D2BungieAPI
    {
        private D2Translator translator = new D2Translator();
        public D2Objects.PlayerInfo GetPlayerInfo(string id)
        {
            var header = new WebHeaderCollection();
            header.Add("X-API-Key", Config.Instance.apikey);
            var info = WebHelper.DownloadJson<D2Objects.PlayerInfo>(
                $"https://www.bungie.net/Platform/Destiny2/3/Profile/{id}/?components=100, 101, 102, 103, 200", header);
            translator.TranslatePlayerInfo(info);
            return info;
        }
        public D2Objects.PlayerInfo GetPlayerInfoAsync(string id)
        {
            var header = new WebHeaderCollection();
            header.Add("X-API-Key", Config.Instance.apikey);
            var info = WebHelper.DownloadJsonAsync<D2Objects.PlayerInfo>(
                $"https://www.bungie.net/Platform/Destiny2/3/Profile/{id}/?components=100, 101, 102, 103, 200", header);
            translator.TranslatePlayerInfo(info.Result);
            return info.Result;
        }
    }
}
