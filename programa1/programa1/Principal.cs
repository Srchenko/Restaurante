using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace programa1
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void Principal_Load(object sender, EventArgs e)
        {

        }

        private void mozosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MdiChildren.OfType<Mesas>().Count() == 0)
            {
                Mesas hijo = new Mesas();
                hijo.MdiParent = this.MdiParent;
                hijo.Show();
            }
        }

        private void mozosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (this.MdiChildren.OfType<Mozos>().Count() == 0)
            {
                Mozos hijo = new Mozos();
                hijo.MdiParent = this.MdiParent;
                hijo.Show();
            }
        }

        private void aBMMozosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
