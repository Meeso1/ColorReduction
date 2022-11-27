
namespace ColorReduction
{
    partial class MainWindow
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
            this.controls = new System.Windows.Forms.GroupBox();
            this.applyButton = new System.Windows.Forms.Button();
            this.parameters = new System.Windows.Forms.GroupBox();
            this.kAllBox = new System.Windows.Forms.TextBox();
            this.kAllLabel = new System.Windows.Forms.Label();
            this.kBlueBox = new System.Windows.Forms.TextBox();
            this.kBlueLabel = new System.Windows.Forms.Label();
            this.kGreenBox = new System.Windows.Forms.TextBox();
            this.kGreenLabel = new System.Windows.Forms.Label();
            this.kRedBox = new System.Windows.Forms.TextBox();
            this.kRedLabel = new System.Windows.Forms.Label();
            this.algorithmSwitchlabel = new System.Windows.Forms.Label();
            this.algorithmSwitch = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.controls.SuspendLayout();
            this.parameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // controls
            // 
            this.controls.Controls.Add(this.applyButton);
            this.controls.Controls.Add(this.parameters);
            this.controls.Controls.Add(this.algorithmSwitchlabel);
            this.controls.Controls.Add(this.algorithmSwitch);
            this.controls.Location = new System.Drawing.Point(12, 12);
            this.controls.Name = "controls";
            this.controls.Size = new System.Drawing.Size(157, 637);
            this.controls.TabIndex = 0;
            this.controls.TabStop = false;
            this.controls.Text = "Options";
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(6, 63);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(145, 23);
            this.applyButton.TabIndex = 4;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            // 
            // parameters
            // 
            this.parameters.Controls.Add(this.kAllBox);
            this.parameters.Controls.Add(this.kAllLabel);
            this.parameters.Controls.Add(this.kBlueBox);
            this.parameters.Controls.Add(this.kBlueLabel);
            this.parameters.Controls.Add(this.kGreenBox);
            this.parameters.Controls.Add(this.kGreenLabel);
            this.parameters.Controls.Add(this.kRedBox);
            this.parameters.Controls.Add(this.kRedLabel);
            this.parameters.Location = new System.Drawing.Point(7, 92);
            this.parameters.Name = "parameters";
            this.parameters.Size = new System.Drawing.Size(144, 122);
            this.parameters.TabIndex = 2;
            this.parameters.TabStop = false;
            this.parameters.Text = "Algorithm parameters";
            // 
            // kAllBox
            // 
            this.kAllBox.Location = new System.Drawing.Point(68, 94);
            this.kAllBox.Name = "kAllBox";
            this.kAllBox.Size = new System.Drawing.Size(70, 20);
            this.kAllBox.TabIndex = 7;
            this.kAllBox.Text = "128";
            this.kAllBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // kAllLabel
            // 
            this.kAllLabel.Location = new System.Drawing.Point(6, 94);
            this.kAllLabel.Name = "kAllLabel";
            this.kAllLabel.Size = new System.Drawing.Size(56, 20);
            this.kAllLabel.TabIndex = 6;
            this.kAllLabel.Text = "K (all)";
            this.kAllLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // kBlueBox
            // 
            this.kBlueBox.Location = new System.Drawing.Point(68, 68);
            this.kBlueBox.Name = "kBlueBox";
            this.kBlueBox.Size = new System.Drawing.Size(70, 20);
            this.kBlueBox.TabIndex = 5;
            this.kBlueBox.Text = "16";
            this.kBlueBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // kBlueLabel
            // 
            this.kBlueLabel.Location = new System.Drawing.Point(6, 68);
            this.kBlueLabel.Name = "kBlueLabel";
            this.kBlueLabel.Size = new System.Drawing.Size(56, 20);
            this.kBlueLabel.TabIndex = 4;
            this.kBlueLabel.Text = "K (blue)";
            this.kBlueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // kGreenBox
            // 
            this.kGreenBox.Location = new System.Drawing.Point(68, 42);
            this.kGreenBox.Name = "kGreenBox";
            this.kGreenBox.Size = new System.Drawing.Size(70, 20);
            this.kGreenBox.TabIndex = 3;
            this.kGreenBox.Text = "16";
            this.kGreenBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // kGreenLabel
            // 
            this.kGreenLabel.Location = new System.Drawing.Point(6, 42);
            this.kGreenLabel.Name = "kGreenLabel";
            this.kGreenLabel.Size = new System.Drawing.Size(56, 20);
            this.kGreenLabel.TabIndex = 2;
            this.kGreenLabel.Text = "K (green)";
            this.kGreenLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // kRedBox
            // 
            this.kRedBox.Location = new System.Drawing.Point(68, 16);
            this.kRedBox.Name = "kRedBox";
            this.kRedBox.Size = new System.Drawing.Size(70, 20);
            this.kRedBox.TabIndex = 1;
            this.kRedBox.Text = "16";
            this.kRedBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // kRedLabel
            // 
            this.kRedLabel.Location = new System.Drawing.Point(6, 16);
            this.kRedLabel.Name = "kRedLabel";
            this.kRedLabel.Size = new System.Drawing.Size(56, 20);
            this.kRedLabel.TabIndex = 0;
            this.kRedLabel.Text = "K (red)";
            this.kRedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // algorithmSwitchlabel
            // 
            this.algorithmSwitchlabel.Location = new System.Drawing.Point(6, 16);
            this.algorithmSwitchlabel.Name = "algorithmSwitchlabel";
            this.algorithmSwitchlabel.Size = new System.Drawing.Size(145, 17);
            this.algorithmSwitchlabel.TabIndex = 1;
            this.algorithmSwitchlabel.Text = "Choose algorithm";
            this.algorithmSwitchlabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // algorithmSwitch
            // 
            this.algorithmSwitch.FormattingEnabled = true;
            this.algorithmSwitch.Items.AddRange(new object[] { "Average dithering", "Ordered dithering (random position in pattern)", "Ordered dithering (consecutive position in pattern)", "Error propagation", "Popularity algorithm" });
            this.algorithmSwitch.Location = new System.Drawing.Point(6, 36);
            this.algorithmSwitch.Name = "algorithmSwitch";
            this.algorithmSwitch.Size = new System.Drawing.Size(145, 21);
            this.algorithmSwitch.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(175, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(445, 636);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(626, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(445, 636);
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 661);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.controls);
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            this.controls.ResumeLayout(false);
            this.parameters.ResumeLayout(false);
            this.parameters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.PictureBox pictureBox2;

        private System.Windows.Forms.PictureBox pictureBox1;

        private System.Windows.Forms.TextBox kRedBox;
        private System.Windows.Forms.Label kRedLabel;
        private System.Windows.Forms.TextBox kBlueBox;
        private System.Windows.Forms.Label kBlueLabel;
        private System.Windows.Forms.TextBox kAllBox;
        private System.Windows.Forms.Label kAllLabel;

        private System.Windows.Forms.GroupBox parameters;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.Label kGreenLabel;
        private System.Windows.Forms.TextBox kGreenBox;

        private System.Windows.Forms.GroupBox controls;
        private System.Windows.Forms.ComboBox algorithmSwitch;
        private System.Windows.Forms.Label algorithmSwitchlabel;

        #endregion
    }
}

