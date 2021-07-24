using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AcessCarBrasil
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void adicionarCarroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmaddcar add = new frmaddcar();
            add.ShowDialog();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            frmInicio init = new frmInicio();
            init.ShowDialog();
        }
    }
}
