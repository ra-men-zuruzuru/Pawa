using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PawaModoki
{
    public partial class test : Form
    {
        TeamManager teamManager = new TeamManager();
        public test()
        {
            InitializeComponent();
            Team team = TeamManager.Instance.Teams[0];
            Console.WriteLine($"{team.TeamName} {team.Id}");
            foreach (var t in team.FielderPlayers)
            {
                Console.WriteLine($"{t.Name} {t.BattingOrder} {t.Position} {t.Meat}");
                string a=t.Name;
                label1.Text=a.Replace("System.Windows.Forms.TextBox, Text:", "");
            }
        }
    }
}
