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
    public partial class EditMenu : Form
    {
        EditTeam editTeam;
        TeamManager teamManager = TeamManager.Instance;
        public EditMenu()
        {
            InitializeComponent();
        }

        private void OpenEditTeam()
        {
            editTeam = new EditTeam();
            editTeam.Show();
        }

        private void buttonInEditMenuReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NowEditTeamNum.Instance.Num = 1;
            OpenEditTeam();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NowEditTeamNum.Instance.Num = 2;
            OpenEditTeam();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            NowEditTeamNum.Instance.Num = 3;
            OpenEditTeam();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            NowEditTeamNum.Instance.Num = 4;
            OpenEditTeam();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            NowEditTeamNum.Instance.Num = 5;
            OpenEditTeam();
        }
    }
}
