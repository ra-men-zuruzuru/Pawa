using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PawaModoki
{
    public partial class Game : Form
    {
        public DataGridView dataGridViewScore;
        public DataTable scoreTable;
        private DataTable dataTableFirstTeam;
        private DataTable dataTableSecondTeam;
        private RadioButton radioButtonOneOut;
        private RadioButton radioButtonTwoOut;
        private RadioButton radioButtonFirstBase;
        private RadioButton radioButtonSecondBase;
        private RadioButton radioButtonThirdBase;
        private List<RadioButton> radioButtonsFirstTeamBatter=new List<RadioButton>();
        private List<RadioButton> radioButtonsSecondTeamBatter = new List<RadioButton>();
        private Button buttonPlay;
        int firstTeamSumScore = 0;
        int firstTeamNowInningScore = 0;
        int secondTeamSumScore = 0;
        int secondTeamNowInningScore = 0;
        bool isGameEnd = false;
        GameProcessing gameProcessing=new GameProcessing();
        public Game()
        {
            GameTeamManager.Instance.FirstTeam = TeamManager.instance.GetId(GameTeamId.Instance.FirstTeamId);
            GameTeamManager.Instance.SecondTeam = TeamManager.instance.GetId(GameTeamId.Instance.SecondTeamId);
            InitializeComponent();
            SetDataGridViewTeam();
            SetDataGridViewScore();
            SetLabelRadioButton();
        }
        private void SetDataGridViewTeam()
        {
            DataGridView dataGridViewFirstTeam = new DataGridView();
            DataGridView dataGridViewSecondTeam = new DataGridView();
            //先攻チーム表
            dataTableFirstTeam = GetDataTableTeam();
            foreach (var t in GameTeamManager.Instance.FirstTeam.FielderPlayers)
            {
                string s = t.Name;
                dataTableFirstTeam.Rows.Add(t.BattingOrder + 1, s.Replace("System.Windows.Forms.TextBox, Text: ", ""), MPStringTransInt(t.Meat), MPStringTransInt(t.Power), MPStringTransInt(t.RunPower));
            }
            dataGridViewFirstTeam.DataSource = dataTableFirstTeam;
            dataGridViewFirstTeam.Location = new Point(10, 100);
            dataGridViewFirstTeam.Size = new Size(270, 220);
            dataGridViewFirstTeam.AllowDrop = false;
            dataGridViewFirstTeam.AllowUserToAddRows = false;
            dataGridViewFirstTeam.AllowUserToDeleteRows = false;
            dataGridViewFirstTeam.AllowUserToResizeRows = false;
            dataGridViewFirstTeam.AllowUserToResizeColumns = false;
            dataGridViewFirstTeam.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            this.Controls.Add(dataGridViewFirstTeam);

            //後攻チーム表
            dataTableSecondTeam = GetDataTableTeam();
            foreach (var t in GameTeamManager.Instance.SecondTeam.FielderPlayers)
            {
                string s = t.Name;
                dataTableSecondTeam.Rows.Add(t.BattingOrder + 1, s.Replace("System.Windows.Forms.TextBox, Text: ", ""), MPStringTransInt(t.Meat), MPStringTransInt(t.Power), MPStringTransInt(t.RunPower));
            }
            dataGridViewSecondTeam.DataSource = dataTableSecondTeam;
            dataGridViewSecondTeam.Location = new Point(510, 100);
            dataGridViewSecondTeam.Size = new Size(270, 220);
            dataGridViewSecondTeam.AllowDrop = false;
            dataGridViewSecondTeam.AllowUserToAddRows = false;
            dataGridViewSecondTeam.AllowUserToDeleteRows = false;
            dataGridViewSecondTeam.AllowUserToResizeRows = false;
            dataGridViewSecondTeam.AllowUserToResizeColumns = false;
            dataGridViewSecondTeam.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            this.Controls.Add(dataGridViewSecondTeam);
        }
        private string MPStringTransInt(int i)
        {
            string st = "";
            switch (i)
            {
                case 0:
                    st = "G";
                    break;
                case 1:
                    st = "F";
                    break;
                case 2:
                    st = "E";
                    break;
                case 3:
                    st = "D";
                    break;
                case 4:
                    st = "C";
                    break;
                case 5:
                    st = "B";
                    break;
                case 6:
                    st = "A";
                    break;
                case 7:
                    st = "S";
                    break;
            }
            return st;
        }


        public void SetDataGridViewScore()
        {
            dataGridViewScore = new DataGridView();
            dataGridViewScore.Size = new Size(530, 80);
            dataGridViewScore.Location = new Point(20, 380);
            scoreTable = GetScoreTable();
            scoreTable.Rows.Add($"{TeamManager.Instance.GetId(GameTeamId.Instance.FirstTeamId).TeamName}(先)", "", "", "", "", "", "", "", "", "", 0);
            scoreTable.Rows.Add($"{TeamManager.Instance.GetId(GameTeamId.Instance.SecondTeamId).TeamName}(後)", "", "", "", "", "", "", "", "", "", 0);
            dataGridViewScore.DataSource = scoreTable;
            dataGridViewScore.ReadOnly = true;
            dataGridViewScore.AllowDrop = false;
            dataGridViewScore.AllowUserToAddRows = false;
            dataGridViewScore.AllowUserToDeleteRows = false;
            dataGridViewScore.AllowUserToResizeRows = false;
            //DataGridView1の列の幅をユーザーが変更できないようにする
            dataGridViewScore.AllowUserToResizeColumns = false;

            //DataGridView1の行の高さをユーザーが変更できないようにする
            dataGridViewScore.AllowUserToResizeRows = false;
            dataGridViewScore.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            this.Controls.Add(dataGridViewScore);
        }
        private void SetLabelRadioButton()
        {
            labelScore.Text = $"{firstTeamSumScore} - {secondTeamSumScore}";
            //進めるボタン
            buttonPlay = new Button();
            buttonPlay.Name = "buttonPlay";
            buttonPlay.Text = "進める";
            buttonPlay.Location = new Point(40,340);
            buttonPlay.Click += new EventHandler(Play);
            this.Controls.Add(buttonPlay);

            // アウトカウントラジオボタン
            radioButtonOneOut=new RadioButton();
            radioButtonOneOut.Checked = false;
            radioButtonOneOut.Enabled = false;
            radioButtonOneOut.AutoSize = true;
            radioButtonOneOut.AutoCheck = false;
            radioButtonOneOut.Name = "radioButtonOneOut";
            radioButtonOneOut.Location = new Point(615, 375);
            this.Controls.Add(radioButtonOneOut);

            radioButtonTwoOut=new RadioButton();
            radioButtonTwoOut.Checked = false;
            radioButtonTwoOut.Enabled = false;
            radioButtonTwoOut.AutoSize = true;
            radioButtonTwoOut.AutoCheck = false;
            radioButtonTwoOut.Name = "radioButtonTwoOut";
            radioButtonTwoOut.Location = new Point(635, 375);
            this.Controls.Add(radioButtonTwoOut);

            //ベースラジオボタン
            radioButtonFirstBase=new RadioButton();
            radioButtonFirstBase.Checked = false;
            radioButtonFirstBase.Enabled = false;
            radioButtonFirstBase.AutoSize = true;
            radioButtonFirstBase.AutoCheck = false;
            radioButtonFirstBase.Text = "1";
            radioButtonFirstBase.Name = "radioButtonFirstBase";
            radioButtonFirstBase.Location = new Point(450,270);
            this.Controls.Add(radioButtonFirstBase);

            radioButtonSecondBase=new RadioButton();
            radioButtonSecondBase.Checked = false;
            radioButtonSecondBase.Enabled = false;
            radioButtonSecondBase.AutoSize = true;
            radioButtonSecondBase.AutoCheck= false;
            radioButtonSecondBase.Text = "2";
            radioButtonSecondBase.Name = "radioButtonSecondBase";
            radioButtonSecondBase.Location = new Point(390,200);
            this.Controls.Add(radioButtonSecondBase);

            radioButtonThirdBase=new RadioButton();
            radioButtonThirdBase.Checked = false;
            radioButtonThirdBase.Enabled = false;
            radioButtonThirdBase.AutoSize = true;
            radioButtonThirdBase.AutoCheck =false;
            radioButtonThirdBase.Text = "3";
            radioButtonThirdBase.Name = "radioButtonThirdBase";
            radioButtonThirdBase.Location = new Point(330,270);
            this.Controls.Add(radioButtonThirdBase);

            //バッターのラジオボタン(先攻チーム)
            for (int i=0;i<9;i++)
            {
                RadioButton radioButton=new RadioButton();
                radioButton.Checked=false;
                radioButton.Checked = i == 0;//一番バッターのみtrue
                radioButton.Enabled=false;
                radioButton.AutoSize=true;
                radioButton.AutoCheck=false;
                radioButton.Location = new Point(290,129+(i*21));
                radioButtonsFirstTeamBatter.Add(radioButton);
                this.Controls.Add(radioButton);
            }
            //後攻チーム
            for (int i=0;i<9;i++)
            {
                RadioButton radioButton = new RadioButton();
                radioButton.Checked = false;
                radioButton.Checked = i == 0;//一番バッターのみtrue
                radioButton.Enabled = false;
                radioButton.AutoSize = true;
                radioButton.AutoCheck = false;
                radioButton.Location = new Point(490, 129 + (i * 21));
                radioButtonsSecondTeamBatter.Add(radioButton);
                this.Controls.Add(radioButton);
            }

        }
        private void Play(object sender, EventArgs e)
        {
            firstTeamNowInningScore=gameProcessing.nowInningScore;
            secondTeamNowInningScore = gameProcessing.nowInningScore;
            gameProcessing.Play();
            //ランナー処理
            radioButtonFirstBase.Checked = gameProcessing.firstRunner;
            radioButtonSecondBase.Checked= gameProcessing.secondRunner;
            radioButtonThirdBase.Checked= gameProcessing.thirdRunner;
            //アウトカウント処理
            radioButtonOneOut.Checked = (gameProcessing.outCount==1 || gameProcessing.outCount==2);
            radioButtonTwoOut.Checked = gameProcessing.outCount == 2;
            //バッターラジオボタン処理
            if (gameProcessing.isTopInning)
            {
                radioButtonsFirstTeamBatter.ForEach(radiobutton => radiobutton.Checked = false);
                radioButtonsFirstTeamBatter[gameProcessing.firstTeamBatter].Checked = true;
            }
            else
            {
                radioButtonsSecondTeamBatter.ForEach(radiobutton => radiobutton.Checked = false);
                radioButtonsSecondTeamBatter[gameProcessing.secondTeamBatter].Checked = true;
            }
            //得点表処理
            if (gameProcessing.isTopInning) 
            {
                scoreTable.Rows[0][gameProcessing.inning] = gameProcessing.nowInningScore;
                int i = gameProcessing.nowInningScore - firstTeamNowInningScore;
                i = (i < 0) ? 0 : i;
                firstTeamSumScore += i;
                scoreTable.Rows[0][10] = firstTeamSumScore;
            }
            else
            {
                scoreTable.Rows[1][gameProcessing.inning] = gameProcessing.nowInningScore;
                int i = gameProcessing.nowInningScore - secondTeamNowInningScore;
                i = (i < 0) ? 0 : i;
                secondTeamSumScore += i;
                scoreTable.Rows[1][10] = secondTeamSumScore;
            }
            labelScore.Text = $"{firstTeamSumScore} - {secondTeamSumScore}";

            //終了処理
            if (gameProcessing.inning>9)
            {
                isGameEnd = true;
                buttonPlay.Enabled = false;
                buttonPlay.Visible = false;
                MessageBox.Show("試合が終わりました", "試合終了"
                        , MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private DataTable GetDataTableTeam()
        {
            DataTable table = new DataTable();
            table.Columns.Add("順", typeof(int));
            table.Columns.Add("名前", typeof(string));
            table.Columns.Add("ミ", typeof(string));
            table.Columns.Add("パ", typeof(string));
            table.Columns.Add("走", typeof(string));
            return table;
        }
        private DataTable GetScoreTable()
        {
            //列追加
            DataTable table = new DataTable();
            table.Columns.Add("チーム名", typeof(string));
            for (int i = 1; i <= 9; i++)
            {
                table.Columns.Add(i.ToString(), typeof(string));
            }
            table.Columns.Add("計", typeof(int));
            return table;
        }
        private void aru()
        {
            //一回裏に3を追加する
            DataRow row = scoreTable.Rows[1];
            row[1] = 3;
        }
        private void buttonReturn_Click(object sender, EventArgs e)
        {
            if (isGameEnd)
            {
                this.Close();
            }
            else
            {
                DialogResult result = MessageBox.Show("本気ですか？",
                "本気？",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button2);

                //何が選択されたか調べる
                if (result == DialogResult.Yes)
                {
                    this.Close();
                }
            }
        }
    }
}
