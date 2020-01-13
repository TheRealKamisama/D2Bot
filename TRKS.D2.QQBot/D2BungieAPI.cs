using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRKS.D2.QQBot
{
    public class D2BungieAPI
    {
        private D2Translator translator = new D2Translator();
        public D2Objects.PlayerInfo GetPlayerInfo(string id)
        {
            var info = WebHelper.DownloadJson<D2Objects.PlayerInfo>(
                $"https://www.bungie.net/Platform/Destiny2/3/Profile/{id}/?components=100, 101, 102, 103, 200");
            translator.TranslatePlayerInfo(info);
            return info;
        }
    }
}
