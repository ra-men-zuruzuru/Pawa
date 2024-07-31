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
        public TeamSelection()
        {
            InitializeComponent();
            PutButton();
        }
        private void PutButton()
        {
            for (int i=0;i<5;i++)
            {
                bool isfind = false;
                Button button = new Button();
                button.Name = "ButtonPut" + (i + 1);
                button.Size = new Size(100, 100);
                button.Location = new Point(20 + (i * 160), 250);
                button.Click += new EventHandler(Team_Click);
                if (TeamManager.instance != null && TeamManager.instance.Teams != null)
                {
                    foreach (var t in TeamManager.instance.Teams)
                    {
                        if (t.Id == i + 1)
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
            Console.WriteLine("わんこ");
        }
    }
}
