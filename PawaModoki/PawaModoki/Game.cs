using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PawaModoki
{
    public partial class Game : Form
    {
        private DataTable scoreTable;
        private DataTable dataTableFirstTeam;
        private DataTable dataTableSecondTeam;
        private RadioButton radioButtonOneOut;
        private RadioButton radioButtonTwoOut;
        private RadioButton radioButtonFirstBase;
        private RadioButton radioButtonSecondBase;
        private RadioButton radioButtonThirdBase;
        public Game()
        {
            GameTeamManager.Instance.FirstTeam = TeamManager.instance.GetId(GameTeamId.Instance.FirstTeamId);
            GameTeamManager.Instance.SecondTeam = TeamManager.instance.GetId(GameTeamId.Instance.SecondTeamId);
            InitializeComponent();
            SetDataGridViewTeam();
            SetDataGridViewScore();
            SetLabelRadio();

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
            DataGridView dataGridViewScore = new DataGridView();
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
        private void SetLabelRadio()
        {
            labelScore.Text = $"{scoreTable.Rows[0][10]} - {scoreTable.Rows[1][10]}";
            // アウトカウントラジオボタン
            radioButtonOneOut=new RadioButton();
            radioButtonOneOut.Checked = false;
            radioButtonOneOut.Enabled = false;
            radioButtonOneOut.AutoSize = true;
            radioButtonOneOut.Name = "radioButtonOneOut";
            radioButtonOneOut.Location = new Point(615, 375);
            this.Controls.Add(radioButtonOneOut);

            radioButtonTwoOut=new RadioButton();
            radioButtonTwoOut.Checked = false;
            radioButtonTwoOut.Enabled = false;
            radioButtonTwoOut.AutoSize = true;
            radioButtonTwoOut.Name = "radioButtonTwoOut";
            radioButtonTwoOut.Location = new Point(635, 375);
            this.Controls.Add(radioButtonTwoOut);

            //ベースラジオボタン
            radioButtonFirstBase=new RadioButton();
            radioButtonFirstBase.Checked = false;
            radioButtonFirstBase.Enabled = false;
            radioButtonFirstBase.AutoSize = true;
            radioButtonFirstBase.Name = "radioButtonFirstBase";
            radioButtonFirstBase.Location = new Point(450,270);
            this.Controls.Add(radioButtonFirstBase);

            radioButtonSecondBase=new RadioButton();
            radioButtonSecondBase.Checked = false;
            radioButtonSecondBase.Enabled = false;
            radioButtonSecondBase.AutoSize = true;
            radioButtonSecondBase.Name = "radioButtonSecondBase";
            radioButtonSecondBase.Location = new Point(390,200);
            this.Controls.Add(radioButtonSecondBase);

            radioButtonThirdBase=new RadioButton();
            radioButtonThirdBase.Checked = false;
            radioButtonThirdBase.Enabled = false;
            radioButtonThirdBase.AutoSize = true;
            radioButtonThirdBase.Name = "radioButtonThirdBase";
            radioButtonThirdBase.Location = new Point(330,270);
            this.Controls.Add(radioButtonThirdBase);

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

    }
}
