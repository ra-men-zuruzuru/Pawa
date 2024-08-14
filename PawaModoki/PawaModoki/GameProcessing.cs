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
            int battingResult = 0;
            if (isTopInning)//おもて
            {
                Console.WriteLine(firstTeamBatter);
                int nowBatterTrajectory =
                    GameTeamManager.Instance.FirstTeam.FielderPlayers[firstTeamBatter].Trajectory;
                int nowBatterMeat =
                    GameTeamManager.Instance.FirstTeam.FielderPlayers[firstTeamBatter].Meat;
                int nowBatterPower =
                    GameTeamManager.Instance.FirstTeam.FielderPlayers[firstTeamBatter].Power;
                int nowBatterRunPower =
                    GameTeamManager.Instance.FirstTeam.FielderPlayers[firstTeamBatter].RunPower;
                battingResult = BattingProcess(nowBatterTrajectory,nowBatterMeat,nowBatterPower,nowBatterRunPower);

            }
            else//うら
            {

            }
            switch (battingResult)
            {
                case 0:

                    ++outCount;
                    break;
                case 1:

                    break;
                case 2:

                    break;
                case 3:

                    break;
            }
            //チェンジ処理
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
                firstRunner = false;
                secondRunner = false;
                thirdRunner = false;
                return;
            }
            
            //firstTeamBatter = (isTopInning) ? ++firstTeamBatter : firstTeamBatter; 三項式というやつ
            //secondTeamBatter = (!isTopInning) ? ++secondTeamBatter : secondTeamBatter;
            firstTeamBatter %= 9;
            secondTeamBatter %= 9;
        }
        private int BattingProcess(int trajectory, int meat,int power,int runPower) 
        {
            int ret = 0;
            Random random = new Random();
            int rnd = random.Next(100);
            if (rnd<BatRnd(meat))
            {
                ret = BaseHitProcess(trajectory,power,runPower,rnd);
            }
            else
            {
                ret = 0;
            }
            return ret;
        }

        private int BatRnd(int meat)
        {
            int ret = 0;
            switch (meat) 
            {
                case 0:
                    ret = 10;
                    break;
                case 1:
                    ret = 15;
                    break;
                case 2:
                    ret = 20;
                    break;
                case 3:
                    ret = 25;
                    break;
                case 4:
                    ret = 27;
                    break;
                case 5:
                    ret = 30;
                    break;
                case 6:
                    ret = 32;
                    break;
                case 7:
                    ret = 35;
                    break;
            }
            return ret;
        }

        private int BaseHitProcess(int trajectory,int power,int runPower,int rnd)
        {
            int ret = 0;
            if (rnd<trajectory*power)
            {
                ret = 4;//本塁打
            }
            else
            {
                int num = 0;
                switch (OneBaseOr(runPower,rnd,num))
                {
                    case 0:
                        ret = 1;//安打
                        break;
                    case 1:
                        ret = 2;//二塁打
                        break;
                    case 2:
                        ret= 3;//三塁打
                        break;
                    case 3:
                        ret = 4;//走本
                        break;
                }

            }
            return ret;
        }
        private int OneBaseOr(int runPower,int rnd,int num)//シングルか二塁打か三塁打か
        {
            if (num > 2)
                return num;

            if (rnd < BatRnd(runPower)) 
            {
                ++num;
                return OneBaseOr(runPower, rnd, num);
            }
            else
            {
                return num;
            }
        }
    }
}
