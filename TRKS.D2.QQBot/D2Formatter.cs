using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GammaLibrary.Extensions;

namespace TRKS.D2.QQBot
{
    class D2Formatter
    {
        [Pure]
        public static string ToString(D2Objects.PlayerInfo info)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"1.[{info.Response.profile.data.userInfo.displayName}] ");
            foreach (var chara in info.Response.characters.data.characters)
            {
                sb.Append($"{chara.type}-{chara.light} ");
            }
            
            return sb.ToString().Trim();
        }
    }
}
