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
        List<Button> openEditButtons = new List<Button>();
        public EditMenu()
        {
            InitializeComponent();
            PutButtons();
        }
        private void PutButtons()
        {
            for (int i=0;i<5;i++)
            {
                bool isfind = false;
                Button button = new Button();
                button.Name = "ButtonPut" + (i+1);
                button.Size = new Size(100,100);
                button.Location = new Point(20+(i*160),30);
                if (TeamManager.instance!=null&&TeamManager.instance.Teams!=null)
                {
                    foreach (var t in TeamManager.instance.Teams)
                    {
                        if (t.Id==i+1)
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
                switch (i)
                {
                    case 0:
                        button.Click += new EventHandler(button1_Click);
                        break;
                    case 1:
                        button.Click += new EventHandler(button2_Click);
                        break;
                    case 2:
                        button.Click += new EventHandler(button3_Click);
                        break;
                    case 3:
                        button.Click += new EventHandler(button4_Click);
                        break;
                    case 4:
                        button.Click += new EventHandler(button5_Click);
                        break;
                }
                openEditButtons.Add(button);
                this.Controls.Add(button);
            }
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
            OpenEditTeam() ;
        }
    }
}
