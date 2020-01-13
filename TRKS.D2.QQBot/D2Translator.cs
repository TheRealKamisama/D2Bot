using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRKS.D2.QQBot
{
    public class D2Translator
    {
        private static D2MongoDB db;

        public D2Translator()
        {
            db = new D2MongoDB();
        }

        private static DateTime GetRealTime(DateTime time)
        {
            return time + TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now);
        }

        public void TranslatePlayerInfo(D2Objects.PlayerInfo info)
        {

            foreach (var chara in info.Response.characters.data.characters)
            {
                chara.type = db.GetCharacterType(chara.genderHash, chara.raceHash, chara.classHash);
                chara.dateLastPlayed = GetRealTime(chara.dateLastPlayed);
            }

        }
    }
}
