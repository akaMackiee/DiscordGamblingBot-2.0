using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace DiscordGamblingBot
{
    class Config
    {
        private const string configFolder = "Resources";
        private const string configFile = "config.json";

        public static BotConfig bot;


        static Config()
        {
            if(!Directory.Exists("bin/Debug/" + configFolder))
            {
                Directory.CreateDirectory("bin/Debug/" + configFolder);
            }
            if(!File.Exists("bin/Debug/" + configFolder + "/" + configFile))
            {
                bot = new BotConfig();
                string json = JsonConvert.SerializeObject(bot, Formatting.Indented);
                File.WriteAllText("bin/Debug/" + configFolder + "/" + configFile, json);
            }
            else
            {
                string json = File.ReadAllText("bin/Debug/" + configFolder + "/" + configFile);
                bot = JsonConvert.DeserializeObject<BotConfig>(json);
            }
        }
    }

    public struct BotConfig
    {
        public string token;
        public string cmdPrefix;
    }
}