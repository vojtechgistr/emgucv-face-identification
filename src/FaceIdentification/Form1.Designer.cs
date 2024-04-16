namespace FaceIdentification
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
            this.components = new System.ComponentModel.Container();
            this.RegisterFaceButton = new System.Windows.Forms.Button();
            this.FaceNameTxtBox = new System.Windows.Forms.TextBox();
            this.detectedFacePictureBox = new System.Windows.Forms.PictureBox();
            this.imageBox = new Emgu.CV.UI.ImageBox();
            this.registeredFacePictureBox = new System.Windows.Forms.PictureBox();
            this.enterFaceNameLabel = new System.Windows.Forms.Label();
            this.ReTrainModelButton = new System.Windows.Forms.Button();
            this.ChangeEigenThreshold = new System.Windows.Forms.NumericUpDown();
            this.eigenThresholdLabel = new System.Windows.Forms.Label();
            this.ThresholdDistance = new System.Windows.Forms.Label();
            this.detectedObjectLabel = new System.Windows.Forms.Label();
            this.registeredObjectLabel = new System.Windows.Forms.Label();
            this.registeringNotificationLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.detectedFacePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.registeredFacePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChangeEigenThreshold)).BeginInit();
            this.SuspendLayout();
            // 
            // RegisterFaceButton
            // 
            this.RegisterFaceButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.8F);
            this.RegisterFaceButton.Location = new System.Drawing.Point(1017, 517);
            this.RegisterFaceButton.Margin = new System.Windows.Forms.Padding(2);
            this.RegisterFaceButton.Name = "RegisterFaceButton";
            this.RegisterFaceButton.Size = new System.Drawing.Size(105, 34);
            this.RegisterFaceButton.TabIndex = 3;
            this.RegisterFaceButton.Text = "Register Face";
            this.RegisterFaceButton.UseVisualStyleBackColor = true;
            this.RegisterFaceButton.Click += new System.EventHandler(this.RegisterFaceButton_Click);
            // 
            // FaceNameTxtBox
            // 
            this.FaceNameTxtBox.Location = new System.Drawing.Point(1017, 493);
            this.FaceNameTxtBox.Margin = new System.Windows.Forms.Padding(2);
            this.FaceNameTxtBox.Name = "FaceNameTxtBox";
            this.FaceNameTxtBox.Size = new System.Drawing.Size(87, 20);
            this.FaceNameTxtBox.TabIndex = 4;
            // 
            // detectedFacePictureBox
            // 
            this.detectedFacePictureBox.Location = new System.Drawing.Point(1020, 13);
            this.detectedFacePictureBox.Margin = new System.Windows.Forms.Padding(2);
            this.detectedFacePictureBox.Name = "detectedFacePictureBox";
            this.detectedFacePictureBox.Size = new System.Drawing.Size(200, 200);
            this.detectedFacePictureBox.TabIndex = 7;
            this.detectedFacePictureBox.TabStop = false;
            // 
            // imageBox
            // 
            this.imageBox.Location = new System.Drawing.Point(11, 11);
            this.imageBox.Margin = new System.Windows.Forms.Padding(2);
            this.imageBox.Name = "imageBox";
            this.imageBox.Size = new System.Drawing.Size(960, 540);
            this.imageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageBox.TabIndex = 2;
            this.imageBox.TabStop = false;
            // 
            // registeredFacePictureBox
            // 
            this.registeredFacePictureBox.Location = new System.Drawing.Point(1017, 255);
            this.registeredFacePictureBox.Margin = new System.Windows.Forms.Padding(2);
            this.registeredFacePictureBox.Name = "registeredFacePictureBox";
            this.registeredFacePictureBox.Size = new System.Drawing.Size(200, 200);
            this.registeredFacePictureBox.TabIndex = 8;
            this.registeredFacePictureBox.TabStop = false;
            // 
            // enterFaceNameLabel
            // 
            this.enterFaceNameLabel.AutoSize = true;
            this.enterFaceNameLabel.Location = new System.Drawing.Point(1017, 475);
            this.enterFaceNameLabel.Name = "enterFaceNameLabel";
            this.enterFaceNameLabel.Size = new System.Drawing.Size(93, 13);
            this.enterFaceNameLabel.TabIndex = 9;
            this.enterFaceNameLabel.Text = "Enter Face Name:";
            // 
            // ReTrainModelButton
            // 
            this.ReTrainModelButton.Location = new System.Drawing.Point(12, 583);
            this.ReTrainModelButton.Name = "ReTrainModelButton";
            this.ReTrainModelButton.Size = new System.Drawing.Size(105, 23);
            this.ReTrainModelButton.TabIndex = 10;
            this.ReTrainModelButton.Text = "Re-Train Model";
            this.ReTrainModelButton.UseVisualStyleBackColor = true;
            this.ReTrainModelButton.Click += new System.EventHandler(this.ReTrainModelButton_Click);
            // 
            // ChangeEigenThreshold
            // 
            this.ChangeEigenThreshold.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.ChangeEigenThreshold.Location = new System.Drawing.Point(160, 583);
            this.ChangeEigenThreshold.Maximum = new decimal(new int[] {
            1569325055,
            23283064,
            0,
            0});
            this.ChangeEigenThreshold.Minimum = new decimal(new int[] {
            1569325055,
            23283064,
            0,
            -2147483648});
            this.ChangeEigenThreshold.Name = "ChangeEigenThreshold";
            this.ChangeEigenThreshold.Size = new System.Drawing.Size(120, 20);
            this.ChangeEigenThreshold.TabIndex = 11;
            this.ChangeEigenThreshold.ValueChanged += new System.EventHandler(this.ChangeEigenThreshold_ValueChanged);
            // 
            // eigenThresholdLabel
            // 
            this.eigenThresholdLabel.AutoSize = true;
            this.eigenThresholdLabel.Location = new System.Drawing.Point(157, 567);
            this.eigenThresholdLabel.Name = "eigenThresholdLabel";
            this.eigenThresholdLabel.Size = new System.Drawing.Size(87, 13);
            this.eigenThresholdLabel.TabIndex = 12;
            this.eigenThresholdLabel.Text = "Eigen Threshold:";
            // 
            // ThresholdDistance
            // 
            this.ThresholdDistance.AutoSize = true;
            this.ThresholdDistance.Location = new System.Drawing.Point(456, 583);
            this.ThresholdDistance.Name = "ThresholdDistance";
            this.ThresholdDistance.Size = new System.Drawing.Size(102, 13);
            this.ThresholdDistance.TabIndex = 13;
            this.ThresholdDistance.Text = "Threshold Distance:";
            // 
            // detectedObjectLabel
            // 
            this.detectedObjectLabel.AutoSize = true;
            this.detectedObjectLabel.Location = new System.Drawing.Point(980, 13);
            this.detectedObjectLabel.Name = "detectedObjectLabel";
            this.detectedObjectLabel.Size = new System.Drawing.Size(88, 13);
            this.detectedObjectLabel.TabIndex = 14;
            this.detectedObjectLabel.Text = "Detected Object:";
            // 
            // registeredObjectLabel
            // 
            this.registeredObjectLabel.AutoSize = true;
            this.registeredObjectLabel.Location = new System.Drawing.Point(980, 255);
            this.registeredObjectLabel.Name = "registeredObjectLabel";
            this.registeredObjectLabel.Size = new System.Drawing.Size(95, 13);
            this.registeredObjectLabel.TabIndex = 15;
            this.registeredObjectLabel.Text = "Registered Object:";
            // 
            // registeringNotificationLabel
            // 
            this.registeringNotificationLabel.AutoSize = true;
            this.registeringNotificationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.registeringNotificationLabel.Location = new System.Drawing.Point(189, 1);
            this.registeringNotificationLabel.Name = "registeringNotificationLabel";
            this.registeringNotificationLabel.Size = new System.Drawing.Size(617, 29);
            this.registeringNotificationLabel.TabIndex = 16;
            this.registeringNotificationLabel.Text = "Please move with your face to sides... REGISTERING";
            this.registeringNotificationLabel.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1253, 628);
            this.Controls.Add(this.registeringNotificationLabel);
            this.Controls.Add(this.registeredObjectLabel);
            this.Controls.Add(this.detectedObjectLabel);
            this.Controls.Add(this.ThresholdDistance);
            this.Controls.Add(this.eigenThresholdLabel);
            this.Controls.Add(this.ChangeEigenThreshold);
            this.Controls.Add(this.ReTrainModelButton);
            this.Controls.Add(this.enterFaceNameLabel);
            this.Controls.Add(this.registeredFacePictureBox);
            this.Controls.Add(this.imageBox);
            this.Controls.Add(this.detectedFacePictureBox);
            this.Controls.Add(this.FaceNameTxtBox);
            this.Controls.Add(this.RegisterFaceButton);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.detectedFacePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.registeredFacePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChangeEigenThreshold)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button RegisterFaceButton;
        private System.Windows.Forms.TextBox FaceNameTxtBox;
        private System.Windows.Forms.PictureBox detectedFacePictureBox;
        private Emgu.CV.UI.ImageBox imageBox;
        private System.Windows.Forms.PictureBox registeredFacePictureBox;
        private System.Windows.Forms.Label enterFaceNameLabel;
        private System.Windows.Forms.Button ReTrainModelButton;
        private System.Windows.Forms.NumericUpDown ChangeEigenThreshold;
        private System.Windows.Forms.Label eigenThresholdLabel;
        private System.Windows.Forms.Label ThresholdDistance;
        private System.Windows.Forms.Label detectedObjectLabel;
        private System.Windows.Forms.Label registeredObjectLabel;
        private System.Windows.Forms.Label registeringNotificationLabel;
    }
}

