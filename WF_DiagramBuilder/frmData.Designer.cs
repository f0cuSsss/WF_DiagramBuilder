namespace WF_DiagramBuilder
{
    partial class frmData
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonADD = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.DataGV = new System.Windows.Forms.DataGridView();
            this.pName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pColor = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.rbBarGraph = new System.Windows.Forms.RadioButton();
            this.rbPieChart = new System.Windows.Forms.RadioButton();
            this.TBDiagramName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DataGV)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonADD
            // 
            this.buttonADD.Location = new System.Drawing.Point(237, 260);
            this.buttonADD.Margin = new System.Windows.Forms.Padding(4);
            this.buttonADD.Name = "buttonADD";
            this.buttonADD.Size = new System.Drawing.Size(232, 28);
            this.buttonADD.TabIndex = 0;
            this.buttonADD.Text = "Add";
            this.buttonADD.UseVisualStyleBackColor = true;
            this.buttonADD.Click += new System.EventHandler(this.buttonADD_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(303, 295);
            this.buttonOK.Margin = new System.Windows.Forms.Padding(4);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(100, 28);
            this.buttonOK.TabIndex = 1;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // DataGV
            // 
            this.DataGV.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DataGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pName,
            this.pValue,
            this.pColor});
            this.DataGV.Location = new System.Drawing.Point(13, 72);
            this.DataGV.Name = "DataGV";
            this.DataGV.RowTemplate.Height = 24;
            this.DataGV.Size = new System.Drawing.Size(458, 179);
            this.DataGV.TabIndex = 6;
            // 
            // pName
            // 
            this.pName.HeaderText = "pName";
            this.pName.Name = "pName";
            this.pName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // pValue
            // 
            this.pValue.HeaderText = "pValue";
            this.pValue.Name = "pValue";
            this.pValue.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // pColor
            // 
            this.pColor.HeaderText = "pColor";
            this.pColor.Name = "pColor";
            // 
            // rbBarGraph
            // 
            this.rbBarGraph.AutoSize = true;
            this.rbBarGraph.Location = new System.Drawing.Point(13, 260);
            this.rbBarGraph.Name = "rbBarGraph";
            this.rbBarGraph.Size = new System.Drawing.Size(183, 21);
            this.rbBarGraph.TabIndex = 7;
            this.rbBarGraph.TabStop = true;
            this.rbBarGraph.Text = "Столбчатая диаграмма";
            this.rbBarGraph.UseVisualStyleBackColor = true;
            // 
            // rbPieChart
            // 
            this.rbPieChart.AutoSize = true;
            this.rbPieChart.Location = new System.Drawing.Point(13, 302);
            this.rbPieChart.Name = "rbPieChart";
            this.rbPieChart.Size = new System.Drawing.Size(164, 21);
            this.rbPieChart.TabIndex = 8;
            this.rbPieChart.TabStop = true;
            this.rbPieChart.Text = "Круговая диаграмма";
            this.rbPieChart.UseVisualStyleBackColor = true;
            // 
            // TBDiagramName
            // 
            this.TBDiagramName.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TBDiagramName.Location = new System.Drawing.Point(13, 35);
            this.TBDiagramName.Name = "TBDiagramName";
            this.TBDiagramName.Size = new System.Drawing.Size(456, 26);
            this.TBDiagramName.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(123, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 23);
            this.label1.TabIndex = 10;
            this.label1.Text = "Название диаграммы";
            // 
            // frmData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 337);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TBDiagramName);
            this.Controls.Add(this.rbPieChart);
            this.Controls.Add(this.rbBarGraph);
            this.Controls.Add(this.DataGV);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonADD);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmData";
            ((System.ComponentModel.ISupportInitialize)(this.DataGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonADD;
        private System.Windows.Forms.Button buttonOK;
        public System.Windows.Forms.DataGridView DataGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn pName;
        private System.Windows.Forms.DataGridViewTextBoxColumn pValue;
        private System.Windows.Forms.DataGridViewComboBoxColumn pColor;
        public System.Windows.Forms.RadioButton rbBarGraph;
        public System.Windows.Forms.RadioButton rbPieChart;
        private System.Windows.Forms.TextBox TBDiagramName;
        private System.Windows.Forms.Label label1;
    }
}