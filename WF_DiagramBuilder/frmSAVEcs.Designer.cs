namespace WF_DiagramBuilder
{
    partial class frmSAVE
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSAVE));
            this.btnSaveToImage = new System.Windows.Forms.Button();
            this.btnSaveToXML = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSaveToImage
            // 
            this.btnSaveToImage.Location = new System.Drawing.Point(111, 15);
            this.btnSaveToImage.Margin = new System.Windows.Forms.Padding(4);
            this.btnSaveToImage.Name = "btnSaveToImage";
            this.btnSaveToImage.Size = new System.Drawing.Size(340, 28);
            this.btnSaveToImage.TabIndex = 0;
            this.btnSaveToImage.Text = "Save diagram image";
            this.btnSaveToImage.UseVisualStyleBackColor = true;
            this.btnSaveToImage.Click += new System.EventHandler(this.btnSaveToImage_Click);
            // 
            // btnSaveToXML
            // 
            this.btnSaveToXML.Location = new System.Drawing.Point(111, 65);
            this.btnSaveToXML.Margin = new System.Windows.Forms.Padding(4);
            this.btnSaveToXML.Name = "btnSaveToXML";
            this.btnSaveToXML.Size = new System.Drawing.Size(340, 28);
            this.btnSaveToXML.TabIndex = 0;
            this.btnSaveToXML.Text = "Save to XML";
            this.btnSaveToXML.UseVisualStyleBackColor = true;
            this.btnSaveToXML.Click += new System.EventHandler(this.btnSaveToXML_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(19, 15);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(84, 78);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // frmSAVE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 106);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnSaveToXML);
            this.Controls.Add(this.btnSaveToImage);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSAVE";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Save dialog";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSaveToImage;
        private System.Windows.Forms.Button btnSaveToXML;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}