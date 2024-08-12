using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PawaModoki
{
    
    internal class GameProcessing
    {
        Game game;
        public int inning = 1;
        public bool isTopInning = true;
        public int firstTeamBatter = 0;
        public int secondTeamBatter = 0;
        public int  outCount= 0;
        public int nowInningScore = 0;
        public bool firstRunner = false;
        public bool secondRunner = false;
        public bool thirdRunner = false;
        public void Play()
        {
            ++outCount;
            ++nowInningScore;
            if (outCount>=3)
            {
                if (isTopInning)
                {
                    ++firstTeamBatter;

                    nowInningScore = 0;
                }
                else
                {
                    ++secondTeamBatter;
                    ++inning;
                    nowInningScore = 0;
                }
                isTopInning = !isTopInning;
                outCount = 0;
                return;
            }
            firstRunner = true;
            secondRunner = true;
            thirdRunner = true;
            firstTeamBatter = (isTopInning) ? ++firstTeamBatter : firstTeamBatter;
            secondTeamBatter = (!isTopInning) ? ++secondTeamBatter : secondTeamBatter;
            firstTeamBatter %= 9;
            secondTeamBatter %= 9;
        }

    }
}
