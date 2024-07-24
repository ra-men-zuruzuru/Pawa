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
    public partial class EditTeam : Form
    {
        TeamManager teamManager = TeamManager.Instance;
        Team team = new Team();
        private int[] trajectory = {1,2,3,4};
        private string[] meat = {"G","F","E","D","C","B","A","S"};
        private string[] power = { "G", "F", "E", "D", "C", "B", "A", "S"};
        private string[] runPower = { "G", "F", "E", "D", "C", "B", "A", "S" };
        private string[] defence = { "G", "F", "E", "D", "C", "B", "A", "S" };
        private string[] catchPower={ "G", "F", "E", "D", "C", "B", "A", "S" };
        public EditTeam()
        {
            InitializeComponent();
            OrInitial();
            //teamManeger.Team[任意の番号].ID とかで参照できる
            /*
            Team team = new Team { TeamName = "Team A",Id=NowEditTeamNum.Instance.Num };//teamnameとチームIDを代入
            TeamManager.Instance.Teams.Add(team);//チームマネージャーにteamを追加
            */
            labelTeamNum.Text = $"現在編集中のチームidは{team.Id}です。チーム名は{team.TeamName}です。";
        }
        private void OrInitial()
        {
            int nowEditNum = NowEditTeamNum.Instance.Num;
            bool aru = false;
            foreach (var i in TeamManager.instance.Teams)
            {
                if (i.Id==nowEditNum)
                {
                    aru = true;
                }
            }

            if (aru)
            {
                //すでに格納されている値を呼び出してそれぞれ代入
            }
            else
            {
                team.Id=NowEditTeamNum.Instance.Num;
                team.TeamName ="オリジナルチーム";
                textBoxTeamName.Text = "オリジナルチーム";
                //一番バッター
                textBoxOneName.Text = "パワプロ";
                buttonOneTrajectory.Text = trajectory[2].ToString();
                buttonOneMeat.Text = meat[3];
                buttonOnePower.Text = power[3];
                buttonOneRunPower.Text = runPower[3];
                buttonOneDefence.Text = defence[3];
                buttonOneCatchPower.Text = catchPower[3];
                comboBoxOnePosition.SelectedIndex = 0;
                //二番バッター

            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            test test=new test();
            test.Show();
        }
    }
}
