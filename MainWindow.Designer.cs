
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
            this.chooseFileButton = new System.Windows.Forms.Button();
            this.chooseFileLabel = new System.Windows.Forms.Label();
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
            this.inputPicture = new System.Windows.Forms.PictureBox();
            this.outputPicture = new System.Windows.Forms.PictureBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.controls.SuspendLayout();
            this.parameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inputPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.outputPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // controls
            // 
            this.controls.Controls.Add(this.chooseFileButton);
            this.controls.Controls.Add(this.chooseFileLabel);
            this.controls.Controls.Add(this.applyButton);
            this.controls.Controls.Add(this.parameters);
            this.controls.Controls.Add(this.algorithmSwitchlabel);
            this.controls.Controls.Add(this.algorithmSwitch);
            this.controls.Location = new System.Drawing.Point(18, 18);
            this.controls.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.controls.Name = "controls";
            this.controls.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.controls.Size = new System.Drawing.Size(236, 980);
            this.controls.TabIndex = 0;
            this.controls.TabStop = false;
            this.controls.Text = "Options";
            // 
            // chooseFileButton
            // 
            this.chooseFileButton.Location = new System.Drawing.Point(9, 55);
            this.chooseFileButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chooseFileButton.Name = "chooseFileButton";
            this.chooseFileButton.Size = new System.Drawing.Size(218, 35);
            this.chooseFileButton.TabIndex = 6;
            this.chooseFileButton.Text = "Choose file";
            this.chooseFileButton.UseVisualStyleBackColor = true;
            this.chooseFileButton.Click += new System.EventHandler(this.chooseFileButton_Click);
            // 
            // chooseFileLabel
            // 
            this.chooseFileLabel.Location = new System.Drawing.Point(9, 25);
            this.chooseFileLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.chooseFileLabel.Name = "chooseFileLabel";
            this.chooseFileLabel.Size = new System.Drawing.Size(218, 26);
            this.chooseFileLabel.TabIndex = 5;
            this.chooseFileLabel.Text = "Choose image";
            this.chooseFileLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(9, 168);
            this.applyButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(218, 35);
            this.applyButton.TabIndex = 4;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
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
            this.parameters.Location = new System.Drawing.Point(10, 212);
            this.parameters.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.parameters.Name = "parameters";
            this.parameters.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.parameters.Size = new System.Drawing.Size(216, 188);
            this.parameters.TabIndex = 2;
            this.parameters.TabStop = false;
            this.parameters.Text = "Algorithm parameters";
            // 
            // kAllBox
            // 
            this.kAllBox.Location = new System.Drawing.Point(102, 145);
            this.kAllBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.kAllBox.Name = "kAllBox";
            this.kAllBox.Size = new System.Drawing.Size(103, 26);
            this.kAllBox.TabIndex = 7;
            this.kAllBox.Text = "128";
            this.kAllBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // kAllLabel
            // 
            this.kAllLabel.Location = new System.Drawing.Point(9, 145);
            this.kAllLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.kAllLabel.Name = "kAllLabel";
            this.kAllLabel.Size = new System.Drawing.Size(84, 31);
            this.kAllLabel.TabIndex = 6;
            this.kAllLabel.Text = "K (all)";
            this.kAllLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // kBlueBox
            // 
            this.kBlueBox.Location = new System.Drawing.Point(102, 105);
            this.kBlueBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.kBlueBox.Name = "kBlueBox";
            this.kBlueBox.Size = new System.Drawing.Size(103, 26);
            this.kBlueBox.TabIndex = 5;
            this.kBlueBox.Text = "16";
            this.kBlueBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // kBlueLabel
            // 
            this.kBlueLabel.Location = new System.Drawing.Point(9, 105);
            this.kBlueLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.kBlueLabel.Name = "kBlueLabel";
            this.kBlueLabel.Size = new System.Drawing.Size(84, 31);
            this.kBlueLabel.TabIndex = 4;
            this.kBlueLabel.Text = "K (blue)";
            this.kBlueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // kGreenBox
            // 
            this.kGreenBox.Location = new System.Drawing.Point(102, 65);
            this.kGreenBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.kGreenBox.Name = "kGreenBox";
            this.kGreenBox.Size = new System.Drawing.Size(103, 26);
            this.kGreenBox.TabIndex = 3;
            this.kGreenBox.Text = "16";
            this.kGreenBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // kGreenLabel
            // 
            this.kGreenLabel.Location = new System.Drawing.Point(9, 65);
            this.kGreenLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.kGreenLabel.Name = "kGreenLabel";
            this.kGreenLabel.Size = new System.Drawing.Size(84, 31);
            this.kGreenLabel.TabIndex = 2;
            this.kGreenLabel.Text = "K (green)";
            this.kGreenLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // kRedBox
            // 
            this.kRedBox.Location = new System.Drawing.Point(102, 25);
            this.kRedBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.kRedBox.Name = "kRedBox";
            this.kRedBox.Size = new System.Drawing.Size(103, 26);
            this.kRedBox.TabIndex = 1;
            this.kRedBox.Text = "16";
            this.kRedBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // kRedLabel
            // 
            this.kRedLabel.Location = new System.Drawing.Point(9, 25);
            this.kRedLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.kRedLabel.Name = "kRedLabel";
            this.kRedLabel.Size = new System.Drawing.Size(84, 31);
            this.kRedLabel.TabIndex = 0;
            this.kRedLabel.Text = "K (red)";
            this.kRedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // algorithmSwitchlabel
            // 
            this.algorithmSwitchlabel.Location = new System.Drawing.Point(9, 95);
            this.algorithmSwitchlabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.algorithmSwitchlabel.Name = "algorithmSwitchlabel";
            this.algorithmSwitchlabel.Size = new System.Drawing.Size(218, 26);
            this.algorithmSwitchlabel.TabIndex = 1;
            this.algorithmSwitchlabel.Text = "Choose algorithm";
            this.algorithmSwitchlabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // algorithmSwitch
            // 
            this.algorithmSwitch.FormattingEnabled = true;
            this.algorithmSwitch.Items.AddRange(new object[] { "Average dithering", "Ordered dithering (random position in pattern)", "Ordered dithering (consecutive position in pattern)", "Error propagation", "Popularity algorithm" });
            this.algorithmSwitch.Location = new System.Drawing.Point(9, 126);
            this.algorithmSwitch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.algorithmSwitch.Name = "algorithmSwitch";
            this.algorithmSwitch.Size = new System.Drawing.Size(216, 28);
            this.algorithmSwitch.TabIndex = 0;
            // 
            // inputPicture
            // 
            this.inputPicture.Location = new System.Drawing.Point(262, 18);
            this.inputPicture.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.inputPicture.Name = "inputPicture";
            this.inputPicture.Size = new System.Drawing.Size(668, 903);
            this.inputPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.inputPicture.TabIndex = 1;
            this.inputPicture.TabStop = false;
            // 
            // outputPicture
            // 
            this.outputPicture.Location = new System.Drawing.Point(939, 18);
            this.outputPicture.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.outputPicture.Name = "outputPicture";
            this.outputPicture.Size = new System.Drawing.Size(668, 903);
            this.outputPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.outputPicture.TabIndex = 2;
            this.outputPicture.TabStop = false;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1626, 940);
            this.Controls.Add(this.outputPicture);
            this.Controls.Add(this.inputPicture);
            this.Controls.Add(this.controls);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1642, 979);
            this.MinimumSize = new System.Drawing.Size(1642, 979);
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            this.controls.ResumeLayout(false);
            this.parameters.ResumeLayout(false);
            this.parameters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inputPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.outputPicture)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.PictureBox inputPicture;

        private System.Windows.Forms.OpenFileDialog openFileDialog;

        private System.Windows.Forms.PictureBox outputPicture;

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

        private System.Windows.Forms.Button chooseFileButton;
        private System.Windows.Forms.Label chooseFileLabel;
    }
}

