using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_DiagramBuilder
{
    public partial class frmOpenCreate : Form
    {
        public frmOpenCreate()
        {
            InitializeComponent();
        }

        private void brnCreateNew_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
        }
    }
}
