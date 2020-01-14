using System;
using System.Collections.Generic;
using GammaLibrary;
using Newtonsoft.Json;

namespace TRKS.D2.QQBot
{
    [Configuration("D2Config")]
    internal class Config : Configuration<Config>
    {
        public string apikey = "";
    }




}