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
        private int rnd = 0;
        public void Play()
        {
            int battingResult = 0;
            if (isTopInning)//おもて
            {
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
                int nowBatterTrajectory =
                    GameTeamManager.Instance.SecondTeam.FielderPlayers[secondTeamBatter].Trajectory;
                int nowBatterMeat =
                    GameTeamManager.Instance.SecondTeam.FielderPlayers[secondTeamBatter].Meat;
                int nowBatterPower =
                    GameTeamManager.Instance.SecondTeam.FielderPlayers[secondTeamBatter].Power;
                int nowBatterRunPower =
                    GameTeamManager.Instance.SecondTeam.FielderPlayers[secondTeamBatter].RunPower;
                battingResult = BattingProcess(nowBatterTrajectory, nowBatterMeat, nowBatterPower, nowBatterRunPower);
            }
            Console.WriteLine(battingResult);
            switch (battingResult)
            {
                case 0:
                    ++outCount;
                    break;
                case 1:
                    SingleHitProcess();
                    break;
                case 2:
                    TwoBaseHitProcess();
                    break;
                case 3:
                    ThirdBaseHitProcess();
                    break;
                case 4:
                    HomeRunProcess();
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
            firstTeamBatter = (isTopInning) ? ++firstTeamBatter : firstTeamBatter;
            secondTeamBatter = (!isTopInning) ? ++secondTeamBatter : secondTeamBatter;
            firstTeamBatter %= 9;
            secondTeamBatter %= 9;
        }

        //安打か否か
        private int BattingProcess(int trajectory, int meat,int power,int runPower) 
        {
            Random rand = new Random();
            int rnd=rand.Next(100);
            int ret = 0;
            if (rnd<MeatIntConvert(meat))
            {
                ret = BaseHitProcess(trajectory,power,runPower);
            }
            else
            {
                ret = 0;
            }
            return ret;
        }

        private int MeatIntConvert(int meat)
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
        private int RunpowerIntConvert(int runPower)
        {
            int ret = 0;
            switch (runPower)
            {
                case 0:
                    ret = 1;
                    break;
                case 1:
                    ret = 3;
                    break;
                case 2:
                    ret = 5;
                    break;
                case 3:
                    ret = 10;
                    break;
                case 4:
                    ret = 15;
                    break;
                case 5:
                    ret = 20;
                    break;
                case 6:
                    ret = 25;
                    break;
                case 7:
                    ret = 30;
                    break;
            }
            return ret;
        }
        //塁打処理
        private int BaseHitProcess(int trajectory,int power,int runPower)
        {
            int ret = 0;
            Random rand = new Random();
            int rnd = rand.Next(100);
            if (rnd<trajectory*power)
            {
                Console.WriteLine("さく越え");
                ret = 4;//本塁打
            }
            else
            {
                int num = 0;
                switch (OneBaseOr(runPower,num))
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
        
        //シングルか二塁打か三塁打か
        private int OneBaseOr(int runPower,int num)
        {
            if (num > 2)
                Console.WriteLine("そうほん");
            if (num > 2)
                return num;

            Random rand = new Random();
            int rnd = rand.Next(100);
            if (rnd < RunpowerIntConvert(runPower)-(num*runPower)) 
            {
                ++num;
                return OneBaseOr(runPower, num);
            }
            else
            {
                return num;
            }
        }

        //シングルヒット処理
        private void SingleHitProcess()
        {
            if (thirdRunner)
            {
                ++nowInningScore;
                thirdRunner = false;
            }
            if (secondRunner)
            {
                if (rnd<50)//5割の確立で一塁ランナーがホームイン
                {
                    ++nowInningScore;
                    secondRunner = false;
                }
                else
                {
                    thirdRunner = true;
                    secondRunner = false;
                }
            }
            if (firstRunner)
            {
                secondRunner = true;
                firstRunner = false;
            }
            firstRunner = true;
        }
        
        //二塁打処理
        private void TwoBaseHitProcess()
        {
            if (thirdRunner)
            {
                ++nowInningScore;
                thirdRunner = false;
            }
            if (secondRunner)
            {
                ++nowInningScore;
                secondRunner = false;
            }
            if (firstRunner)
            {
                if (rnd<70)//7割の確立で一塁ランナーがホームイン
                {
                    ++nowInningScore;
                    firstRunner = false;
                }
                else
                {
                    thirdRunner = true;
                    firstRunner = false;
                }
            }
            secondRunner = true;
        }

        //三塁打処理
        private void ThirdBaseHitProcess()
        {
            if (thirdRunner)
            {
                ++nowInningScore;
                thirdRunner = false;
            }
            if (secondRunner)
            {
                ++nowInningScore;
                secondRunner = false;
            }
            if (firstRunner)
            {
                ++nowInningScore;
                firstRunner = false;
            }
            thirdRunner = true;
        }

        //本塁打処理
        private void HomeRunProcess()
        {
            if (thirdRunner)
            {
                ++nowInningScore;
                thirdRunner = false;
            }
            if (secondRunner)
            {
                ++nowInningScore;
                secondRunner = false;
            }
            if (firstRunner)
            {
                ++nowInningScore;
                firstRunner = false;
            }
            ++nowInningScore;
        }

    }
}
