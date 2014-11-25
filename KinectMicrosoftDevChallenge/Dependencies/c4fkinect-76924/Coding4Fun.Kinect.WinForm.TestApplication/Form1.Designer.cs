namespace Coding4Fun.Kinect.WinForm.TestApplication
{
    partial class Form1
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
            this.DepthImage = new System.Windows.Forms.PictureBox();
            this.DepthImageWithMinDistance = new System.Windows.Forms.PictureBox();
            this.ColorImage = new System.Windows.Forms.PictureBox();
            this.DistanceSlider = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.DistanceText = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.MidPointDistanceViaGetDistanceText = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DepthImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepthImageWithMinDistance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ColorImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DistanceSlider)).BeginInit();
            this.SuspendLayout();
            // 
            // DepthImage
            // 
            this.DepthImage.Location = new System.Drawing.Point(12, 12);
            this.DepthImage.Name = "DepthImage";
            this.DepthImage.Size = new System.Drawing.Size(320, 240);
            this.DepthImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.DepthImage.TabIndex = 0;
            this.DepthImage.TabStop = false;
            // 
            // DepthImageWithMinDistance
            // 
            this.DepthImageWithMinDistance.Location = new System.Drawing.Point(342, 12);
            this.DepthImageWithMinDistance.Name = "DepthImageWithMinDistance";
            this.DepthImageWithMinDistance.Size = new System.Drawing.Size(320, 240);
            this.DepthImageWithMinDistance.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.DepthImageWithMinDistance.TabIndex = 1;
            this.DepthImageWithMinDistance.TabStop = false;
            // 
            // ColorImage
            // 
            this.ColorImage.Location = new System.Drawing.Point(12, 258);
            this.ColorImage.Name = "ColorImage";
            this.ColorImage.Size = new System.Drawing.Size(320, 240);
            this.ColorImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ColorImage.TabIndex = 2;
            this.ColorImage.TabStop = false;
            // 
            // DistanceSlider
            // 
            this.DistanceSlider.Location = new System.Drawing.Point(342, 362);
            this.DistanceSlider.Maximum = 4000;
            this.DistanceSlider.Minimum = 800;
            this.DistanceSlider.Name = "DistanceSlider";
            this.DistanceSlider.Size = new System.Drawing.Size(320, 45);
            this.DistanceSlider.TabIndex = 6;
            this.DistanceSlider.TickFrequency = 250;
            this.DistanceSlider.Value = 1000;
            this.DistanceSlider.Scroll += new System.EventHandler(this.DistanceSlider_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(373, 346);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Minimum Distance: ";
            // 
            // DistanceText
            // 
            this.DistanceText.AutoSize = true;
            this.DistanceText.Location = new System.Drawing.Point(478, 346);
            this.DistanceText.Name = "DistanceText";
            this.DistanceText.Size = new System.Drawing.Size(35, 13);
            this.DistanceText.TabIndex = 8;
            this.DistanceText.Text = "####";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(447, 463);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(112, 23);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save Images";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // MidPointDistanceViaGetDistanceText
            // 
            this.MidPointDistanceViaGetDistanceText.AutoSize = true;
            this.MidPointDistanceViaGetDistanceText.Location = new System.Drawing.Point(478, 437);
            this.MidPointDistanceViaGetDistanceText.Name = "MidPointDistanceViaGetDistanceText";
            this.MidPointDistanceViaGetDistanceText.Size = new System.Drawing.Size(35, 13);
            this.MidPointDistanceViaGetDistanceText.TabIndex = 14;
            this.MidPointDistanceViaGetDistanceText.Text = "####";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(353, 437);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Get MidPoint Distance: ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 508);
            this.Controls.Add(this.MidPointDistanceViaGetDistanceText);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.DistanceText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DistanceSlider);
            this.Controls.Add(this.ColorImage);
            this.Controls.Add(this.DepthImageWithMinDistance);
            this.Controls.Add(this.DepthImage);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.DepthImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepthImageWithMinDistance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ColorImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DistanceSlider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox DepthImage;
        private System.Windows.Forms.PictureBox DepthImageWithMinDistance;
        private System.Windows.Forms.PictureBox ColorImage;
        private System.Windows.Forms.TrackBar DistanceSlider;
		private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label DistanceText;
        private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Label MidPointDistanceViaGetDistanceText;
        private System.Windows.Forms.Label label4;
    }
}

