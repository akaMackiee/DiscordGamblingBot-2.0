using System;
using System.Threading.Tasks;

namespace DiscordGamblingBot
{
    class CoinFlip
    {
        public static int FlipCoin(string side)
        {
            Random r = new Random();
            int score = 0;
            int BotSide = r.Next(1,3);
            switch(BotSide)
            {
                case 1:
                if (string.Equals(side, "heads", StringComparison.CurrentCultureIgnoreCase))
                {
                    score = 1;
                }
                else
                {
                    score = 2;
                }
                break;
                
                case 2:
                if(string.Equals(side, "tails", StringComparison.CurrentCultureIgnoreCase))
                {
                    score = 1;
                }

                else
                {
                    score = 2;
                }
                break;
            }
            return score;
        }
    }
}