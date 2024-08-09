using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawaModoki
{
    internal class ClassGameTeamData
    {
        
    }
    internal class GameTeamId//シングルトンインスタンス
    {
        private static GameTeamId instance;
        public int FirstTeamId { get; set; }
        public int SecondTeamId { get; set; }
        private GameTeamId() { }

        public static GameTeamId Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameTeamId();
                }
                return instance;
            }
        }
    }
    public class GameTeam
    {
        public int Id { get; set; }
        public string TeamName { get; set; }
        public string TeamStrength { get; set; }

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


    public class GameTeamManager
    {
        private static GameTeamManager instance;
        public Team FirstTeam { get; set; }
        public Team SecondTeam { get; set; }

        private GameTeamManager() { }

        public static GameTeamManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameTeamManager();
                }
                return instance;
            }
        }
    }

}
