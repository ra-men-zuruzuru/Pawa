using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PawaModoki.Team;

namespace PawaModoki
{
    internal class NowEditTeamNum//シングルトンインスタンス
    {
        private static NowEditTeamNum instance;
        public int Num { get; set; }
        private NowEditTeamNum() { }

        public static NowEditTeamNum Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new NowEditTeamNum();
                }
                return instance;
            }
        }
    }

    public class Team
    {
        public int Id { get; set; }
        public string TeamName { get; set; }

        //野手
        public class FielderPlayer
        {
            public string Name { get; set; }
            public int BattingOrder { get; set; }//打順
            public int Position { get; set; }//ポジション
            public int Trajectory { get; set; }//弾道
            public int Meat { get; set; }
            public int Power { get; set; }
            public int RunPower { get; set; }
            public int Defence { get; set; }
            public int CatchPower { get; set; }
        }
        //投手
        public class PitcherPlayer
        {
            public string Name { get; set; }
            public int BallSpeed { get; set; }
            public int Stamina { get; set; }
            public int Controll { get; set; }
            public int Slider { get; set; }
            public int Curve { get; set; }
            public int Fork { get; set; }
            public int Sinker { get; set; }
            public int Shut { get; set; }
        }
        public List<FielderPlayer> FielderPlayers { get; set; } = new List<FielderPlayer>();
        public List<PitcherPlayer> PitcherPlayers { get; set; } = new List<PitcherPlayer>();
    }


    public class TeamManager
    {
        public static TeamManager instance;

        public static TeamManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TeamManager();
                }
                return instance;
            }
        }

        public TeamManager() { }

        public List<Team> Teams { get; set; } = new List<Team>();

        public Team GetId(int id)
        {
            return Teams.Find(team=>team.Id==id);
        }
        public static void SetInstance(TeamManager newInstance)
        {
            instance = newInstance;
        }
    }
}
