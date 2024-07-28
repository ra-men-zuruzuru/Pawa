using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace PawaModoki
{
    public partial class EditTeam : Form
    {
        TeamManager teamManager = TeamManager.Instance;
        Team team = new Team();
        //野手のリスト
        List<TextBox> listTextboxFielderPlayerName = new List<TextBox>();
        List<Button> listButtonTrajectory= new List<Button>();
        List<Button> listButtonMeat=new List<Button>();
        List<Button> listButtonPower=new List<Button>();
        List<Button> listButtonRunpower=new List<Button>();
        List<Button> listButtonDefence=new List<Button>();
        List<Button> listButtonCatchpower=new List<Button>();
        List<ComboBox> listComboboxPosition=new List<ComboBox>();
        //投手のリスト
        List<TextBox> listTextboxPitcherPlayerName = new List<TextBox>();
        List<Button>listButtonBoc=new List<Button>();
        List<Button>listButtonStamina=new List<Button>();
        List<Button>listButtonControl=new List<Button>();
        List<Button> listButtonSlider=new List<Button>();
        List<Button>listButtonCurve=new List<Button>();
        List<Button>listButtonFork=new List<Button>();
        List<Button> listButtonSinker=new List<Button>();
        List<Button>listBuittonShut=new List<Button>();
        //ボタンに入れる要素
        private string[] trajectory = {"1","2","3","4"};
        private string[] mprdcsc = {"G","F","E","D","C","B","A","S"};
        private string[] Position = { "指","捕","一","二","三","遊","左","中","右" };
        private string[] boc = {"N","1","2","3","4","5","6","7","8" };
        public EditTeam()
        {
            InitializeComponent();
            Create();
            OrInitial();
            //teamManeger.Team[任意の番号].ID とかで参照できる
            
            Team team = new Team { TeamName = "オリジナル",Id=NowEditTeamNum.Instance.Num };//teamnameとチームIDを代入
            //TeamManager.Instance.Teams.Add(team);//チームマネージャーにteamを追加
            
            labelTeamNum.Text = $"現在編集中のチームidは{team.Id}です。チーム名は{team.TeamName}です。";
        }
        private void Create()
        {
            //各種部品設置(野手)
            for (int i = 0; i < 9; i++)
            {
                TextBox textBoxFilderName = new TextBox();
                textBoxFilderName.Name = "textBoxFielderPlayerName" + (i+1);
                textBoxFilderName.Size = new Size(70, 25);
                textBoxFilderName.Location = new Point(20, 45 + i * 35);
                textBoxFilderName.Text = "パワプロ";
                this.Controls.Add(textBoxFilderName);
                listTextboxFielderPlayerName.Add(textBoxFilderName); // リストに追加

                Button traButton = new Button();
                traButton.Name = "ButtonTrajectory" +(i+1);
                traButton.Size = new Size(30, 30);
                traButton.Location = new Point(95, 42 + i * 35);
                traButton.Text = trajectory[2];
                traButton.Tag = 2;
                traButton.Click += new EventHandler(ButtonTra_Click);
                traButton.MouseUp += new MouseEventHandler(ButtonTra_RightClick);
                this.Controls.Add(traButton);
                listButtonTrajectory.Add(traButton);

                Button meatButton= new Button();
                meatButton.Name="ButtonMeat"+(i+1);
                meatButton.Size = new Size(30,30);
                meatButton.Location = new Point(125, 42 + i * 35);
                meatButton.Text = mprdcsc[3];
                meatButton.Click += new EventHandler(ButtonMPRDC_Click);
                meatButton.MouseUp += new MouseEventHandler(ButtonMPRDC_RightClick);
                meatButton.Tag = 3;
                this.Controls.Add(meatButton);
                listButtonMeat.Add(meatButton);

                Button powerButton= new Button();
                powerButton.Name="ButtonPower"+(i+1);
                powerButton.Size = new Size(30,30);
                powerButton.Location = new Point(155, 42 + i * 35);
                powerButton.Text = mprdcsc[3];
                powerButton.Click += new EventHandler(ButtonMPRDC_Click);
                powerButton.MouseUp += new MouseEventHandler(ButtonMPRDC_RightClick);
                powerButton.Tag = 3;
                this.Controls.Add(powerButton);
                listButtonPower.Add(powerButton);

                Button runpowerButton= new Button();
                runpowerButton.Name = "ButtonRunpower"+(i+1);
                runpowerButton.Size = new Size(30, 30);
                runpowerButton.Location = new Point(185, 42 + i * 35);
                runpowerButton.Text = mprdcsc[3];
                runpowerButton.Click += new EventHandler(ButtonMPRDC_Click);
                runpowerButton.MouseUp += new MouseEventHandler(ButtonMPRDC_RightClick);
                runpowerButton.Tag = 3;
                this.Controls.Add(runpowerButton);
                listButtonRunpower.Add(runpowerButton);

                Button defenceButton= new Button();
                defenceButton.Name = "ButtonDefence"+(i+1);
                defenceButton.Size = new Size(30, 30);
                defenceButton.Location = new Point(215, 42 + i * 35);
                defenceButton.Text = mprdcsc[3];
                defenceButton.Click += new EventHandler(ButtonMPRDC_Click);
                defenceButton.MouseUp += new MouseEventHandler(ButtonMPRDC_RightClick);
                defenceButton.Tag = 3;
                this.Controls.Add(defenceButton);
                listButtonDefence.Add(defenceButton);

                Button catchButton= new Button();
                catchButton.Name = "ButtonCatch" + (i+1);
                catchButton.Size = new Size(30, 30);
                catchButton.Location = new Point(245, 42 + i * 35);
                catchButton.Text = mprdcsc[3];
                catchButton.Click += new EventHandler(ButtonMPRDC_Click);
                catchButton.MouseUp += new MouseEventHandler(ButtonMPRDC_RightClick);
                catchButton.Tag = 3;
                this.Controls.Add(catchButton);
                listButtonCatchpower.Add(catchButton);

                ComboBox positionCombobox = new ComboBox();
                positionCombobox.Name = "position"+(i+1);
                positionCombobox.Size = new Size(70, 40);
                positionCombobox.Location = new Point(275, 45 + i * 35);
                positionCombobox.DropDownHeight = 106;
                positionCombobox.DropDownWidth = 77;
                positionCombobox.DropDownStyle = ComboBoxStyle.DropDownList;
                positionCombobox.Items.AddRange(Position);
                positionCombobox.SelectedIndex = i;
                this.Controls.Add(positionCombobox);
                listComboboxPosition.Add(positionCombobox);
            }
            //投手
            for (int i=0;i<6;i++)
            {
                TextBox textBoxPitcherPlayerName = new TextBox();
                textBoxPitcherPlayerName.Name = "textBoxPitcherPlayerName" + (i + 1);
                textBoxPitcherPlayerName.Size = new Size(70, 25);
                textBoxPitcherPlayerName.Location = new Point(425, 45 + i * 35);
                textBoxPitcherPlayerName.Text = "パワプロ";
                this.Controls.Add(textBoxPitcherPlayerName);
                listTextboxPitcherPlayerName.Add(textBoxPitcherPlayerName);

                Button bosButton= new Button();
                bosButton.Name = "ButtonBallOfSpeed"+(i+1);
                bosButton.Size = new Size(30,30);
                bosButton.Location = new Point(500,42+i*35);
                bosButton.Text = mprdcsc[3];
                bosButton.Click += new EventHandler(ButtonMPRDC_Click);
                bosButton.MouseUp += new MouseEventHandler(ButtonMPRDC_RightClick);
                bosButton.Tag = 3;
                this.Controls.Add(bosButton);
                listButtonBoc.Add(bosButton);

                Button staminaButton = new Button();
                staminaButton.Name = "ButtonStamina"+(i+1);
                staminaButton.Size = new Size(30, 30);
                staminaButton.Location = new Point(530,42+i*35);
                staminaButton.Text = mprdcsc[3];
                staminaButton.Click += new EventHandler(ButtonMPRDC_Click);
                staminaButton.MouseUp += new MouseEventHandler(ButtonMPRDC_RightClick);
                staminaButton.Tag = 3;
                this.Controls.Add(staminaButton);
                listButtonStamina.Add(staminaButton);

                Button controlButton= new Button();
                controlButton.Name = "ButtonControl"+(i+1);
                controlButton.Size = new Size(30, 30);
                controlButton.Location = new Point(560, 42 + i * 35);
                controlButton.Text = mprdcsc[3];
                controlButton.Click += new EventHandler(ButtonMPRDC_Click);
                controlButton.MouseUp += new MouseEventHandler(ButtonMPRDC_RightClick);
                controlButton.Tag = 3;
                this.Controls.Add(controlButton);
                listButtonControl.Add(controlButton);

                Button sliderButton= new Button();
                sliderButton.Name = "ButtonSlider" + (i+1);
                sliderButton.Size = new Size(30, 30);
                sliderButton.Location = new Point(590, 42 + i * 35);
                sliderButton.Text = boc[3];
                sliderButton.Click += new EventHandler(ButtonBoc_Click);
                sliderButton.MouseUp += new MouseEventHandler(ButtonBoc_RightClick);
                sliderButton.Tag = 3;
                this.Controls.Add(sliderButton);
                listButtonSlider.Add(sliderButton);

                Button curveButton= new Button();
                curveButton.Name = "ButtonCurve" + (i + 1);
                curveButton.Size = new Size(30, 30);
                curveButton.Location = new Point(620, 42 + i * 35);
                curveButton.Text = boc[3];
                curveButton.Click += new EventHandler(ButtonBoc_Click);
                curveButton.MouseUp += new MouseEventHandler(ButtonBoc_RightClick);
                curveButton.Tag = 3;
                this.Controls.Add(curveButton);
                listButtonSlider.Add(curveButton);

                Button forkButton= new Button();
                forkButton.Name = "ButtonFork" + (i + 1);
                forkButton.Size = new Size(30, 30);
                forkButton.Location = new Point(650, 42 + i * 35);
                forkButton.Text = boc[3];
                forkButton.Click += new EventHandler(ButtonBoc_Click);
                forkButton.MouseUp += new MouseEventHandler(ButtonBoc_RightClick);
                forkButton.Tag = 3;
                this.Controls.Add(forkButton);
                listButtonSlider.Add(forkButton);

                Button sinkerButton= new Button();
                sinkerButton.Name = "ButtonSinker" + (i + 1);
                sinkerButton.Size = new Size(30, 30);
                sinkerButton.Location = new Point(680, 42 + i * 35);
                sinkerButton.Text = boc[0];
                sinkerButton.Click += new EventHandler(ButtonBoc_Click);
                sinkerButton.MouseUp += new MouseEventHandler(ButtonBoc_RightClick);
                sinkerButton.Tag = 0;
                this.Controls.Add(sinkerButton);
                listButtonSlider.Add(sinkerButton);

                Button shutButton= new Button();
                shutButton.Name = "ButtonShut" + (i + 1);
                shutButton.Size = new Size(30, 30);
                shutButton.Location = new Point(710, 42 + i * 35);
                shutButton.Text = boc[0];
                shutButton.Click += new EventHandler(ButtonBoc_Click);
                shutButton.MouseUp += new MouseEventHandler(ButtonBoc_RightClick);
                shutButton.Tag = 0;
                this.Controls.Add(shutButton);
                listButtonSlider.Add(shutButton);
            }

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

            }
            
        }
        private void ButtonTra_Click(object sender, EventArgs e)
        {
            Button button=sender as Button;
            int index=(int)button.Tag;
            index = (index + 1) % trajectory.Length;
            button.Tag = index;
            button.Text=trajectory[index];
        }
        private void ButtonTra_RightClick(object sender,MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Button button = sender as Button;
                int index = (int)button.Tag;
                index -= 1;
                if (index < 0)
                    index = trajectory.Length - 1;
                button.Tag = index;
                button.Text = trajectory[index];
            }
        }
        private void ButtonMPRDC_Click(object sender,EventArgs e)
        {
            Button button = sender as Button;
            int index = (int)button.Tag;
            index = (index + 1) % mprdcsc.Length;
            button.Tag = index;
            button.Text = mprdcsc[index];
        }
        private void ButtonMPRDC_RightClick(object sender,MouseEventArgs e)
        {
            if (e.Button==MouseButtons.Right)
            {
                Button button = sender as Button;
                int index = (int)button.Tag;
                index -= 1;
                if (index < 0)
                    index=mprdcsc.Length-1;
                button.Tag = index;
                button.Text = mprdcsc[index];
            }
        }
        private void ButtonBoc_Click(object sender,EventArgs e)
        {
            Button button = sender as Button;
            int index = (int)button.Tag;
            index = (index + 1) % boc.Length;
            button.Tag = index;
            button.Text = boc[index];
        }
        private void ButtonBoc_RightClick(object sender,MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Button button = sender as Button;
                int index = (int)button.Tag;
                index -= 1;
                if (index < 0)
                    index = boc.Length - 1;
                button.Tag = index;
                button.Text = boc[index];
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            test test = new test();
            test.Show();
        }
    }
}
