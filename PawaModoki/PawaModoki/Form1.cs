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
    public partial class FormStartMenu : Form
    {
        public FormStartMenu()
        {
            InitializeComponent();
        }

        private void buttonEnd_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            EditMenu editMenu = new EditMenu();
            editMenu.Show(this);
        }

        private void buttonNewGame_Click(object sender, EventArgs e)
        {
            TeamSelection teamSelection = new TeamSelection();
            teamSelection.Show(this);
            /*
            if (TeamManager.Instance!=null&&TeamManager.instance.Teams.Count>=1)
            {
                SelectionOpen();
            }
            else
            {
                MessageBox.Show("保存されているチーム数が2未満です。チームエディットでチームを作成してください。", "エラー"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            */
        }
        private void SelectionOpen()
        {
            TeamSelection teamSelection = new TeamSelection();
            teamSelection.Show(this);
        }
    }
}
