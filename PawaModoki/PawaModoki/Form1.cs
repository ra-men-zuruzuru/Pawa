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
    }
}
