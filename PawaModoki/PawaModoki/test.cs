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
    public partial class test : Form
    {
        TeamManager teamManager = new TeamManager();
        public test()
        {
            InitializeComponent();
            //label1.Text = TeamManager.instance.Teams[0];//参照可能！！！
        }
    }
}
