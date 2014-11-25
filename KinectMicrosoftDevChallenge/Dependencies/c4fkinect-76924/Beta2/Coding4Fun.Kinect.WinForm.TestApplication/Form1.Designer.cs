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
			this.TrackSkeleton = new System.Windows.Forms.CheckBox();
			this.TrackDepth = new System.Windows.Forms.CheckBox();
			this.TrackColor = new System.Windows.Forms.CheckBox();
			this.DistanceSlider = new System.Windows.Forms.TrackBar();
			this.label1 = new System.Windows.Forms.Label();
			this.DistanceText = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.MidPointDistanceText = new System.Windows.Forms.Label();
			this.TrackDepthAndPlayerIndex = new System.Windows.Forms.CheckBox();
			this.btnSave = new System.Windows.Forms.Button();
			this.MidPointDistanceViaGetDistanceText = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
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
			// TrackSkeleton
			// 
			this.TrackSkeleton.AutoSize = true;
			this.TrackSkeleton.Checked = true;
			this.TrackSkeleton.CheckState = System.Windows.Forms.CheckState.Checked;
			this.TrackSkeleton.Location = new System.Drawing.Point(342, 258);
			this.TrackSkeleton.Name = "TrackSkeleton";
			this.TrackSkeleton.Size = new System.Drawing.Size(99, 17);
			this.TrackSkeleton.TabIndex = 3;
			this.TrackSkeleton.Text = "Track Skeleton";
			this.TrackSkeleton.UseVisualStyleBackColor = true;
			this.TrackSkeleton.Click += new System.EventHandler(this.ReinitRuntime_Click);
			// 
			// TrackDepth
			// 
			this.TrackDepth.AutoSize = true;
			this.TrackDepth.Location = new System.Drawing.Point(342, 281);
			this.TrackDepth.Name = "TrackDepth";
			this.TrackDepth.Size = new System.Drawing.Size(86, 17);
			this.TrackDepth.TabIndex = 4;
			this.TrackDepth.Text = "Track Depth";
			this.TrackDepth.UseVisualStyleBackColor = true;
			this.TrackDepth.Click += new System.EventHandler(this.ReinitRuntime_Click);
			// 
			// TrackColor
			// 
			this.TrackColor.AutoSize = true;
			this.TrackColor.Checked = true;
			this.TrackColor.CheckState = System.Windows.Forms.CheckState.Checked;
			this.TrackColor.Location = new System.Drawing.Point(342, 326);
			this.TrackColor.Name = "TrackColor";
			this.TrackColor.Size = new System.Drawing.Size(81, 17);
			this.TrackColor.TabIndex = 5;
			this.TrackColor.Text = "Track Color";
			this.TrackColor.UseVisualStyleBackColor = true;
			this.TrackColor.Click += new System.EventHandler(this.ReinitRuntime_Click);
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
			this.label1.Location = new System.Drawing.Point(339, 346);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(99, 13);
			this.label1.TabIndex = 7;
			this.label1.Text = "Minimum Distance: ";
			// 
			// DistanceText
			// 
			this.DistanceText.AutoSize = true;
			this.DistanceText.Location = new System.Drawing.Point(444, 346);
			this.DistanceText.Name = "DistanceText";
			this.DistanceText.Size = new System.Drawing.Size(35, 13);
			this.DistanceText.TabIndex = 8;
			this.DistanceText.Text = "####";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(339, 394);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(116, 13);
			this.label2.TabIndex = 9;
			this.label2.Text = "Middle Point Distance: ";
			// 
			// MidPointDistanceText
			// 
			this.MidPointDistanceText.AutoSize = true;
			this.MidPointDistanceText.Location = new System.Drawing.Point(444, 421);
			this.MidPointDistanceText.Name = "MidPointDistanceText";
			this.MidPointDistanceText.Size = new System.Drawing.Size(35, 13);
			this.MidPointDistanceText.TabIndex = 10;
			this.MidPointDistanceText.Text = "####";
			// 
			// TrackDepthAndPlayerIndex
			// 
			this.TrackDepthAndPlayerIndex.AutoSize = true;
			this.TrackDepthAndPlayerIndex.Checked = true;
			this.TrackDepthAndPlayerIndex.CheckState = System.Windows.Forms.CheckState.Checked;
			this.TrackDepthAndPlayerIndex.Location = new System.Drawing.Point(342, 304);
			this.TrackDepthAndPlayerIndex.Name = "TrackDepthAndPlayerIndex";
			this.TrackDepthAndPlayerIndex.Size = new System.Drawing.Size(168, 17);
			this.TrackDepthAndPlayerIndex.TabIndex = 11;
			this.TrackDepthAndPlayerIndex.Text = "Track Depth and Player Index";
			this.TrackDepthAndPlayerIndex.UseVisualStyleBackColor = true;
			this.TrackDepthAndPlayerIndex.Click += new System.EventHandler(this.ReinitRuntime_Click);
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(447, 452);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(75, 23);
			this.btnSave.TabIndex = 12;
			this.btnSave.Text = "Save Images";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// MidPointDistanceViaGetDistanceText
			// 
			this.MidPointDistanceViaGetDistanceText.AutoSize = true;
			this.MidPointDistanceViaGetDistanceText.Location = new System.Drawing.Point(444, 437);
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
			this.label4.Size = new System.Drawing.Size(90, 13);
			this.label4.TabIndex = 13;
			this.label4.Text = "Via Get Distance: ";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(353, 421);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(43, 13);
			this.label5.TabIndex = 15;
			this.label5.Text = "Via [][]: ";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(674, 508);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.MidPointDistanceViaGetDistanceText);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.TrackDepthAndPlayerIndex);
			this.Controls.Add(this.MidPointDistanceText);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.DistanceText);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.DistanceSlider);
			this.Controls.Add(this.TrackColor);
			this.Controls.Add(this.TrackDepth);
			this.Controls.Add(this.TrackSkeleton);
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
        private System.Windows.Forms.CheckBox TrackSkeleton;
        private System.Windows.Forms.CheckBox TrackDepth;
        private System.Windows.Forms.CheckBox TrackColor;
        private System.Windows.Forms.TrackBar DistanceSlider;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label DistanceText;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label MidPointDistanceText;
		private System.Windows.Forms.CheckBox TrackDepthAndPlayerIndex;
        private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Label MidPointDistanceViaGetDistanceText;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
    }
}

