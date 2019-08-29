using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace WF_DiagramBuilder
{
    public partial class Form1 : Form
    {
        Dictionary<string, double> dHeightNodes;
        List<Label> listLabels;
        public static bool isPieChart;
        int maxHeight;
        frmData tempD;
        public Form1()
        {
            maxHeight = 380;
            InitializeComponent();
            isPieChart = false;
            listLabels = new List<Label>();
        }

        /// <summary>
        /// Очищает все динамические Label
        /// </summary>
        private void clearListLabels()
        {
            foreach (var item in this.listLabels)
            {
                this.Controls.Remove(item);
            }
            listLabels.Clear();
        }

        /// <summary>
        /// Событие создания новой диаграммы
        /// </summary>
        private void создатьToolStripButton_Click(object sender, EventArgs e)
        {
            frmOpenCreate tempOC = new frmOpenCreate();
            DialogResult OCDialogResult = tempOC.ShowDialog();
            tempD = new frmData();
            tempD.clearDGView();
            if (OCDialogResult == DialogResult.OK)
            {
                clearListLabels();
                modelData.getInstance()
                            .data
                            .data
                            .Clear();
                if (tempD.ShowDialog() == DialogResult.OK)
                    Invalidate();
            }
            else if(OCDialogResult == DialogResult.Yes)
            {
                modelData.getInstance().LoadFromXML();

                for (int i = 0; i < modelData.getInstance().data.data.Count; i++)
                {
                    //f.listBox1.Items.Add(modelData.getInstance().data.data.ElementAt(i).ToString());
                    // Сделать добавление в Датагрид
                    //tempD.DataGV.Rows.Add(tempD.DataGV.NewRowIndex())
                    tempD.DataGV.Rows.Add();
                    tempD.DataGV[i, 0].Value = modelData.getInstance().data.data[i].name;
                    tempD.DataGV[i, 1].Value = modelData.getInstance().data.data[i].value;
                    
                    //tempD.DataGV[i, 2]. = modelData.getInstance().data.data[i].color.Name;

                    tempD.DataGV.Rows[i].Cells[3].Value =   tempD
                                                            .tmpClrs
                                                            .IndexOf(modelData.getInstance().data.data[i].color.Name);
                }
            }
        }

        /// <summary>
        /// Метод заполнения словаря высотами для ступечатой диаграммы
        /// </summary>
        private void fillHeightNodesForBarDiagram()
        {
            modelData.getInstance() // Сортировка введённых значений в списке
                .data
                .data
                .Sort(new NodeComparer());

            if (dHeightNodes == null)
                dHeightNodes = new Dictionary<string, double>();
            dHeightNodes.Clear();
            int tempPercent = 0;
            foreach (Node thisNode in modelData.getInstance().data.data)     // Нахождение высот
            {
                tempPercent = (thisNode.value * 100) / (modelData.getInstance().data.data[0].value);
                dHeightNodes.Add(thisNode.name, ((maxHeight * tempPercent) / 100));
            }
            dHeightNodes = dHeightNodes     // Сортировка словаря высот
                .OrderBy(x => x.Value)
                .ToDictionary(x => x.Key, x => x.Value);
        }

        /// <summary>
        /// Метод заполнения словаря соотношениями для круговой диаграммы
        /// </summary>
        private void fillHeightNodesForPieDiagram()
        {
            if (dHeightNodes == null)
                dHeightNodes = new Dictionary<string, double>();
            dHeightNodes.Clear();
            double sum = 0;
            foreach (var item in modelData.getInstance().data.data) // Нахождение суммы(стандарт. метод не работает)
                sum += item.value;

            foreach (Node thisNode in modelData.getInstance().data.data) // Нахождение высот
            {
                dHeightNodes.Add(thisNode.name, (thisNode.value * 360) / sum);
            }
        }

        /// <summary>
        /// Выбор типа диаграммы, вызов определенного метода
        /// </summary>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            
            if (modelData.getInstance().data.data.Count == 0)
            {
                drwWelcome(e);
                return;
            }
            
            if (tempD.rbBarGraph.Checked)
            {
                fillHeightNodesForBarDiagram();
                modelData.getInstance().data.diagramType = "Bar diagram";
                drawBarDiagram(e);
            }
            else if (tempD.rbPieChart.Checked)
            {
                fillHeightNodesForPieDiagram();
                modelData.getInstance().data.diagramType = "PieChart diagram";
                drawPieChartDiagram(e);
            }

        }

        /// <summary>
        /// Метод рисования ступенчатой диаграммы
        /// </summary>
        private void drawBarDiagram(PaintEventArgs e)
        {
            
            Bitmap bmp = new Bitmap(pictureBox.Width, pictureBox.Height);
            pictureBox.Image = bmp;
            Graphics g = Graphics.FromImage(pictureBox.Image);
            int diagramsCount = modelData.getInstance()
                                            .data
                                            .data
                                            .Count;
            if (diagramsCount == 0) return;
            
            Pen pen = new Pen(Brushes.Brown, 2);
            pen.DashStyle = DashStyle.Solid;
             
            int blockSize = ((this.Width - 30) - (diagramsCount + 2) * 10) / diagramsCount;
            g.DrawString(modelData.getInstance().data.diagramName,
                new Font(new FontFamily("Century Gothic"), 11, FontStyle.Regular), Brushes.Black, 204, 22);
            double tempHeight = 0;
            for (int i = diagramsCount - 1; i >= 0; i--)
            {
                pen.Color = Color.FromName(tempD.getColor(i).ToString());
                tempHeight = dHeightNodes.ElementAt(i).Value == 0 ? 1 : dHeightNodes.ElementAt(i).Value;

                Rectangle rect = new Rectangle(25 + (i * blockSize),
                    Convert.ToInt32(maxHeight - dHeightNodes.ElementAt(i).Value + 50),
                    blockSize, Convert.ToInt32(tempHeight));

                g.FillRectangle(new LinearGradientBrush(rect, pen.Color, pen.Color, 90.0f, true), rect);
                g.DrawRectangle(new Pen(Brushes.Chocolate), rect);
                //Label l = new Label();
                //l.Width = blockSize;
                //l.Font = new Font(new FontFamily("Century Gothic"), 9, FontStyle.Bold);
                //l.Location = new Point((i * blockSize) + 35, 435);
                g.DrawString($"{dHeightNodes.ElementAt(i).Key} ({modelData.getInstance().data.data[modelData.getInstance().data.data.Count - i - 1].value})",
                    new Font(new FontFamily("Century Gothic"), 9, FontStyle.Regular), Brushes.Black, new Point((i * blockSize) + 35, 435));
                //l.Text = $"{dHeightNodes.ElementAt(i).Key} ({modelData.getInstance().data[modelData.getInstance().data.Count - i - 1].value})";
                //this.Controls.Add(l);
                //listLabels.Add(l);
            }
            pictureBox.Invalidate();

        }

        /// <summary>
        /// Метод рисования круговой диаграммы
        /// </summary>
        private void drawPieChartDiagram(PaintEventArgs e)
        {
            //Bitmap bmp = new Bitmap(pictureBox.Width, pictureBox.Height);
            //pictureBox.Image = bmp;
            //Graphics g = Graphics.FromImage(pictureBox.Image);
            pictureBox.Visible = false;
            int diagramsCount = modelData.getInstance()
                                            .data
                                            .data
                                            .Count;
            Graphics g = CreateGraphics();
            if (diagramsCount == 0) return;
            float tempHeight = 0.0f;
            DataGridView DGview = new DataGridView();
            DGview.BackgroundColor = Color.FromName("Control");
            DGview.Columns.Add("rDGVName", "Name");
            DGview.Columns.Add("rDGVValue", "Value");
            DGview.AllowUserToResizeColumns = false;
            DGview.AllowUserToResizeRows = false;
            DGview.Width = 235;
            DGview.Columns[0].Width = 116;
            DGview.Columns[1].Width = 116;
            DGview.AllowUserToAddRows = false;
            DGview.RowHeadersVisible = false;
            DGview.RowTemplate.Resizable = DataGridViewTriState.True;
            DGview.RowTemplate.Height = 24;
            DGview.Height = ((diagramsCount+1) * DGview.RowTemplate.Height > 385 ?
                385 : (diagramsCount+1) * DGview.RowTemplate.Height) + 3;
            g.DrawString(modelData.getInstance().data.diagramName,
                new Font(new FontFamily("Century Gothic"), 11, FontStyle.Regular), Brushes.Black, 204, 22);
            
            DGview.Location = new Point(425, 72);
            this.Controls.Add(DGview);
            for (int i = 0; i < diagramsCount; i++) 
            {
                e.Graphics.FillPie(new SolidBrush(Color.FromName(tempD.getColor(i).ToString())),
                    new Rectangle(15, 60, 400, 400),
                   tempHeight,
                    Convert.ToSingle(dHeightNodes.ElementAt(i).Value));
              
                tempHeight += Convert.ToSingle(dHeightNodes.ElementAt(i).Value);
                DGview.Rows.Add(modelData.getInstance().data.data[i].name,
                    modelData.getInstance().data.data[i].value);
                DGview.Rows[i]
                    .DefaultCellStyle
                    .BackColor = Color
                    .FromName(tempD.getColor(i).ToString());
            }
            //pictureBox.Invalidate();
        }

        /// <summary>
        /// Рисование начальной формы
        /// </summary>
        /// <param name="e"></param>
        private void drwWelcome(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen pen = new Pen(Brushes.Brown, 2);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            int x = 200;
            Rectangle rect = new Rectangle(x, 190, 40, maxHeight - 190 + 50);

            Rectangle rect2 = new Rectangle(x + rect.Width + 50, maxHeight, 40, 50);
            Rectangle rect3 = new Rectangle(x + rect.Width + 50 + rect2.Width + 50, 50, 120, maxHeight);
            g.DrawRectangle(pen, rect);
            pen.Brush = Brushes.Green;
            g.DrawRectangle(pen, rect2);
            pen.Brush = Brushes.Indigo;
            g.DrawRectangle(pen, rect3);

            LinearGradientBrush gradient = new LinearGradientBrush(rect, Color.Red, Color.Orange, 40.0f, true);
            g.FillRectangle(gradient, rect);


        }

        /// <summary>
        /// Сохранение диаграммы как рисунок
        /// </summary>
        private void сохранитьToolStripButton_Click(object sender, EventArgs e)
        {
            frmSAVE frmS = new frmSAVE();
            DialogResult tempDR = frmS.ShowDialog();
            if (tempDR == DialogResult.OK)
            {
                var ctrl = this;
                Bitmap bmp = new Bitmap(ctrl.Width, ctrl.Height);
                ctrl.DrawToBitmap(bmp, new Rectangle(Point.Empty, bmp.Size));
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Bitmap Image (.bmp)|*.bmp|JPEG Image (.jpeg)|*.jpeg|PNG Image (.png)|*.png";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    bmp.Save(sfd.FileName);
                }
            }
            else if(tempDR == DialogResult.Yes)
            {
                modelData.getInstance().SaveToXML();
            }
        }

    }

}
