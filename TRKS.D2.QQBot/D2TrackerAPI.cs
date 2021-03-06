﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace TRKS.D2.QQBot
{
    public class D2TrackerAPI
    {
        public D2Objects.SearchResult GetPlayers(string name)
        {
            return WebHelper.DownloadJson<D2Objects.SearchResult>(
                $"https://api.tracker.gg/api/v2/destiny-2/standard/search?platform=steam&query={Uri.EscapeUriString(name)}&autocomplete=true");
        }
    }
}
