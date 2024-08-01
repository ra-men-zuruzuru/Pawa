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
    public partial class TeamSelection : Form
    {
        private LeftToRightProgressBar leftToRightProgressBar;
        private RightToLeftProgressBar rightProgressBar;
        List<ProgressBar> listLeftProgressBars = new List<ProgressBar>();
        List<ProgressBar> listRightProgressBars = new List<ProgressBar>();
        bool isFirstTeamBuried = false;
        bool isSecondTeamBuried= false;
        int  firstTeamId=0, secondTeamId=0;
        public TeamSelection()
        {
            InitializeComponent();
            buttonGameStart.Enabled = false;
            buttonGameStart.Visible = false;
            InitialLabel_ProgressBar();
            PutButton();
        }
        private void InitialLabel_ProgressBar()
        {
            labelFirst.Text = "";
            labelSecond.Text = "";
            for (int i = 0; i < 4; i++)
            {
                ProgressBar progressBar = new LeftToRightProgressBar();
                progressBar.Maximum = 100;
                progressBar.Minimum = 0;
                progressBar.Value = 0;
                progressBar.Margin = new Padding() { All = 3 };
                progressBar.Size = new Size(160, 17);
                progressBar.Location = new Point(75, 100 + (i * 30));
                this.Controls.Add(progressBar);
                listLeftProgressBars.Add(progressBar);
            }
            for (int i = 0; i < 4; i++)
            {
                ProgressBar progressBar = new RightToLeftProgressBar();
                progressBar.Maximum = 100;
                progressBar.Minimum = 0;
                progressBar.Value = 0;
                progressBar.Margin = new Padding() { All = 3 };
                progressBar.Size = new Size(160, 17);
                progressBar.Location = new Point(530, 100 + (i * 30));
                this.Controls.Add(progressBar);
                listRightProgressBars.Add(progressBar);
            }
        }
        private void PutButton()
        {
            for (int i = 0; i < 5; i++)
            {
                bool isfind = false;
                Button button = new Button();
                button.Name = "ButtonPut" + (i + 1);
                button.Size = new Size(100, 100);
                button.Location = new Point(20 + (i * 160), 220);
                button.Click += new EventHandler(Team_Click);
                button.Tag = i;
                if (TeamManager.instance != null && TeamManager.instance.Teams != null)
                {
                    foreach (var t in TeamManager.instance.Teams)
                    {
                        if (t.Id == i)
                        {
                            button.Text = t.TeamName;
                            isfind = true;
                            break;
                        }
                    }
                    if (!isfind)
                        button.Text = "あき";
                }
                else
                {
                    button.Text = "あき";
                }
                this.Controls.Add(button);
            }
        }
        private void Team_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            int index = (int)button.Tag;
            Team team = TeamManager.Instance.GetId(index);
            if (team!=null)
            {
                int[] strength = team.TeamStrength.Split().Select(int.Parse).ToArray();
                if (!isFirstTeamBuried && !isSecondTeamBuried)
                {
                    FirstTeamOverride(strength,team.TeamName);
                    isFirstTeamBuried = true;
                    firstTeamId=team.Id;
                }
                else if (isFirstTeamBuried && !isSecondTeamBuried)
                {
                    SecondTeamOverride(strength,team.TeamName);
                    isSecondTeamBuried = true;
                    secondTeamId=team.Id;
                    buttonGameStart.Enabled = true;
                    buttonGameStart.Visible = true;
                }
                else if (isFirstTeamBuried && isSecondTeamBuried)
                {
                    labelFirst.Text = "";
                    labelSecond.Text = "";
                    foreach (var t in listLeftProgressBars)
                    {
                        t.Value = 0;
                    }
                    foreach (var t in listRightProgressBars)
                    {
                        t.Value = 0;
                    }
                    isFirstTeamBuried=false;
                    isSecondTeamBuried = false;
                    buttonGameStart.Enabled = false;
                    buttonGameStart.Visible = false;
                }
            }
            else
            {

            }
        }
        private void FirstTeamOverride(int[]strength ,string teamName)
        {
            labelFirst.Text=teamName;
            int i = 0;
            int a = 0;
            foreach (var t in listLeftProgressBars)
            {
                double num =0;
                switch (i)
                {
                    case 0:
                        num=strength[i];
                        a=(int)Math.Round(num / 144 * 100);
                        t.Value = a;
                        break;
                    case 1:
                        num = strength[i];
                        a = (int)Math.Round(num / 72 * 100);
                        t.Value = a;
                        break;
                    case 2:
                        num = strength[i];
                        a = (int)Math.Round(num / 144 * 100);
                        t.Value = a;
                        break;
                    case 3:
                        num = strength[i];
                        a = (int)Math.Round(num / 414 * 100);
                        t.Value = a;
                        break;
                }
                ++i;
            }
        }
        private void SecondTeamOverride(int[]strength,string teamName) 
        {
            labelSecond.Text = teamName;
            int i = 0;
            int a = 0;
            foreach (var t in listRightProgressBars)
            {
                double num = 0;
                switch (i)
                {
                    case 0:
                        num = strength[i];
                        a = (int)Math.Round(num / 144 * 100);
                        t.Value = a;
                        break;
                    case 1:
                        num = strength[i];
                        a = (int)Math.Round(num / 72 * 100);
                        t.Value = a;
                        break;
                    case 2:
                        num = strength[i];
                        a = (int)Math.Round(num / 144 * 100);
                        t.Value = a;
                        break;
                    case 3:
                        num = strength[i];
                        a = (int)Math.Round(num / 414 * 100);
                        t.Value = a;
                        break;
                }
                ++i;
            }
        }

        private void buttonGameStart_Click(object sender, EventArgs e)
        {
            Game game = new Game ();
            GameTeamManager.instance = new GameTeamManager();
            GameTeamManager.instance.TeamFirst = TeamManager.instance.GetId(firstTeamId);
            GameTeamManager.instance.TeamSecond=TeamManager.instance.GetId(secondTeamId);
            Console.WriteLine(GameTeamManager.instance.TeamFirst.TeamName);
            game.Show ();
        }

        private void buttonreturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
