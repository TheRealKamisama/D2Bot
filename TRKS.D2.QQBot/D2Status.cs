﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRKS.D2.QQBot
{
    public class D2Status
    {
        private D2BungieAPI _bungieApi = new D2BungieAPI();
        private D2TrackerAPI  _trackerApi = new D2TrackerAPI();
        public void SendPlayerinfos(GroupNumber group, string name)
        {
            var sb = new StringBuilder();
            sb.AppendLine("为您找到以下噶点:");
            var players = _trackerApi.GetPlayers(name);
            foreach (var player in players)
            {
                var info = _bungieApi.GetPlayerInfo(player.platformUserIdentifier);
                sb.AppendLine($"    {D2Formatter.ToString(info)}");
            }
            Messenger.SendGroup(group, sb.ToString().Trim());
        }
    }
}
