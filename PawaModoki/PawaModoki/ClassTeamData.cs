using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawaModoki
{
    internal class NowEditTeamNum//シングルトンインスタンス
    {
        private static NowEditTeamNum instance;
        public int Num {  get; set; }
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
        public class Player
        {
            public string Name { get; set; }
            public int Number { get; set; }
            public int Position {  get; set; }
            public int Trajectory {  get; set; }
            public int Meat {  get; set; }
            public int Power {  get; set; }
            public int RunPower {  get; set; }
            public int Defence {  get; set; }
            public int CatchPower {  get; set; }
        }
        public List<Player> Players { get; set; } = new List<Player>();
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
    }


}
