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
                        if (t.Id==i)
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
                        button.Click += new EventHandler(Button1_Click);
                        break;
                    case 1:
                        button.Click += new EventHandler(Button2_Click);
                        break;
                    case 2:
                        button.Click += new EventHandler(Button3_Click);
                        break;
                    case 3:
                        button.Click += new EventHandler(Button4_Click);
                        break;
                    case 4:
                        button.Click += new EventHandler(Button5_Click);
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
            this.Close();
        }

        private void ButtonInEditMenuReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            NowEditTeamNum.Instance.Num = 0;
            OpenEditTeam();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            NowEditTeamNum.Instance.Num = 1;
            OpenEditTeam();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            NowEditTeamNum.Instance.Num = 2;
            OpenEditTeam();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            NowEditTeamNum.Instance.Num = 3;
            OpenEditTeam();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            NowEditTeamNum.Instance.Num = 4;
            OpenEditTeam() ;
        }
    }
}
