using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_DiagramBuilder
{
    public partial class frmData : Form
    {
        public List<string> tmpClrs;
        //public string DiagramName;
        public frmData()
        {
            InitializeComponent();
            modelData.getInstance().data.diagramName = "";
            tmpClrs = new List<string>();
            loadColorsInDGVComboBox();
            rbBarGraph.Checked = true;
            
        }

        public void clearDGView()
        {
            this.DataGV.Rows.Clear();
        }

        private void loadColorsInDGVComboBox()
        {
            ArrayList ColorList = new ArrayList();
            Type colorType = typeof(System.Drawing.Color);
            PropertyInfo[] propInfoList = colorType.GetProperties(BindingFlags.Static |
                                          BindingFlags.DeclaredOnly | BindingFlags.Public);
            foreach (PropertyInfo c in propInfoList)
            {
                this.pColor.Items.Add(c.Name);
                tmpClrs.Add(c.Name);
            }
        }

        public string getColor(int index)
        {
            return DataGV.Rows[index].Cells[2].Value.ToString();
        }

        private void buttonADD_Click(object sender, EventArgs e)
        {
            modelData.getInstance().data.diagramName = TBDiagramName.Text.ToString();
            modelData.getInstance().data.data.Clear();
            Color tempColor;
            Random random = new Random();
            for (int i = 0; i < DataGV.Rows.Count - 1; i++)
            {
                tempColor = DataGV.Rows[i].Cells[2].Value == null ? 
                    Color.FromName(pColor.Items[random.Next(1, (pColor.Items.Count - 1))].ToString()) :
                    Color.FromName(getColor(i));

                modelData.getInstance().data.data.Add(new Node(
                    DataGV.Rows[i].Cells[0].Value.ToString(),
                    Convert.ToInt32(DataGV.Rows[i].Cells[1].Value),
                    tempColor)
                    );
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Form1.isPieChart = rbPieChart.Checked ? true : false;
        }
    }
}
