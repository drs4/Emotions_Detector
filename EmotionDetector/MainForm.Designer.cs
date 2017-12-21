namespace EmotionDetector
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pieChart1 = new LiveCharts.WinForms.PieChart();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnTry = new System.Windows.Forms.Button();
            this.tmrStopAnimation = new System.Windows.Forms.Timer(this.components);
            this.pctFeedback = new System.Windows.Forms.PictureBox();
            this.pctLoading = new System.Windows.Forms.PictureBox();
            this.pctMain = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pctFeedback)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctLoading)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctMain)).BeginInit();
            this.SuspendLayout();
            // 
            // pieChart1
            // 
            this.pieChart1.Location = new System.Drawing.Point(348, 12);
            this.pieChart1.Name = "pieChart1";
            this.pieChart1.Size = new System.Drawing.Size(330, 280);
            this.pieChart1.TabIndex = 0;
            this.pieChart1.Text = "pieChart1";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(12, 314);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(127, 64);
            this.btnBrowse.TabIndex = 3;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Image Files(*.BMP;*.JPG;*.PNG)|*.BMP;*.JPG;*.PNG|All files (*.*)|*.*";
            this.openFileDialog1.Title = "Select Image";
            // 
            // btnTry
            // 
            this.btnTry.Location = new System.Drawing.Point(568, 314);
            this.btnTry.Name = "btnTry";
            this.btnTry.Size = new System.Drawing.Size(109, 64);
            this.btnTry.TabIndex = 5;
            this.btnTry.Text = "Try Reading Me!";
            this.btnTry.UseVisualStyleBackColor = true;
            this.btnTry.Click += new System.EventHandler(this.btnTry_Click);
            // 
            // tmrStopAnimation
            // 
            this.tmrStopAnimation.Enabled = true;
            this.tmrStopAnimation.Interval = 3000;
            this.tmrStopAnimation.Tick += new System.EventHandler(this.tmrStopAnimation_Tick);
            // 
            // pctFeedback
            // 
            this.pctFeedback.Image = global::EmotionDetector.Properties.Resources.ic_too_sad;
            this.pctFeedback.Location = new System.Drawing.Point(145, 314);
            this.pctFeedback.Name = "pctFeedback";
            this.pctFeedback.Size = new System.Drawing.Size(64, 64);
            this.pctFeedback.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctFeedback.TabIndex = 7;
            this.pctFeedback.TabStop = false;
            // 
            // pctLoading
            // 
            this.pctLoading.Image = ((System.Drawing.Image)(resources.GetObject("pctLoading.Image")));
            this.pctLoading.Location = new System.Drawing.Point(498, 314);
            this.pctLoading.Name = "pctLoading";
            this.pctLoading.Size = new System.Drawing.Size(64, 64);
            this.pctLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pctLoading.TabIndex = 6;
            this.pctLoading.TabStop = false;
            // 
            // pctMain
            // 
            this.pctMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pctMain.Image = global::EmotionDetector.Properties.Resources.happiness;
            this.pctMain.Location = new System.Drawing.Point(12, 12);
            this.pctMain.Name = "pctMain";
            this.pctMain.Size = new System.Drawing.Size(330, 280);
            this.pctMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctMain.TabIndex = 4;
            this.pctMain.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 390);
            this.Controls.Add(this.pctFeedback);
            this.Controls.Add(this.pctLoading);
            this.Controls.Add(this.btnTry);
            this.Controls.Add(this.pctMain);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.pieChart1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Emotions Detector!";
            ((System.ComponentModel.ISupportInitialize)(this.pctFeedback)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctLoading)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LiveCharts.WinForms.PieChart pieChart1;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.PictureBox pctMain;
        private System.Windows.Forms.Button btnTry;
        private System.Windows.Forms.PictureBox pctLoading;
        private System.Windows.Forms.Timer tmrStopAnimation;
        private System.Windows.Forms.PictureBox pctFeedback;
    }
}

