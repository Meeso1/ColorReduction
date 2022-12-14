
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
            this.Ycbcr = new System.Windows.Forms.GroupBox();
            this.decodeButton = new System.Windows.Forms.Button();
            this.crInputButton = new System.Windows.Forms.Button();
            this.cbInputButton = new System.Windows.Forms.Button();
            this.yInputButton = new System.Windows.Forms.Button();
            this.inputImagesLabel = new System.Windows.Forms.Label();
            this.decodeCheckBox = new System.Windows.Forms.CheckBox();
            this.processingTimeLabel = new System.Windows.Forms.Label();
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
            this.processingLabel = new System.Windows.Forms.Label();
            this.outputCr = new System.Windows.Forms.PictureBox();
            this.outputCb = new System.Windows.Forms.PictureBox();
            this.outputY = new System.Windows.Forms.PictureBox();
            this.controls.SuspendLayout();
            this.Ycbcr.SuspendLayout();
            this.parameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inputPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.outputPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.outputCr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.outputCb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.outputY)).BeginInit();
            this.SuspendLayout();
            // 
            // controls
            // 
            this.controls.Controls.Add(this.Ycbcr);
            this.controls.Controls.Add(this.processingTimeLabel);
            this.controls.Controls.Add(this.chooseFileButton);
            this.controls.Controls.Add(this.chooseFileLabel);
            this.controls.Controls.Add(this.applyButton);
            this.controls.Controls.Add(this.parameters);
            this.controls.Controls.Add(this.algorithmSwitchlabel);
            this.controls.Controls.Add(this.algorithmSwitch);
            this.controls.Location = new System.Drawing.Point(12, 12);
            this.controls.Name = "controls";
            this.controls.Size = new System.Drawing.Size(157, 587);
            this.controls.TabIndex = 0;
            this.controls.TabStop = false;
            this.controls.Text = "Options";
            // 
            // Ycbcr
            // 
            this.Ycbcr.Controls.Add(this.decodeButton);
            this.Ycbcr.Controls.Add(this.crInputButton);
            this.Ycbcr.Controls.Add(this.cbInputButton);
            this.Ycbcr.Controls.Add(this.yInputButton);
            this.Ycbcr.Controls.Add(this.inputImagesLabel);
            this.Ycbcr.Controls.Add(this.decodeCheckBox);
            this.Ycbcr.Location = new System.Drawing.Point(7, 268);
            this.Ycbcr.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Ycbcr.Name = "Ycbcr";
            this.Ycbcr.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Ycbcr.Size = new System.Drawing.Size(144, 176);
            this.Ycbcr.TabIndex = 8;
            this.Ycbcr.TabStop = false;
            this.Ycbcr.Text = "Y Cb Cr";
            // 
            // decodeButton
            // 
            this.decodeButton.Location = new System.Drawing.Point(6, 145);
            this.decodeButton.Name = "decodeButton";
            this.decodeButton.Size = new System.Drawing.Size(133, 23);
            this.decodeButton.TabIndex = 11;
            this.decodeButton.Text = "Apply";
            this.decodeButton.UseVisualStyleBackColor = true;
            this.decodeButton.Click += new System.EventHandler(this.decodeButton_Click);
            // 
            // crInputButton
            // 
            this.crInputButton.Enabled = false;
            this.crInputButton.Location = new System.Drawing.Point(6, 116);
            this.crInputButton.Name = "crInputButton";
            this.crInputButton.Size = new System.Drawing.Size(133, 23);
            this.crInputButton.TabIndex = 10;
            this.crInputButton.Text = "Choose Cr file";
            this.crInputButton.UseVisualStyleBackColor = true;
            this.crInputButton.Click += new System.EventHandler(this.crInputButton_Click);
            // 
            // cbInputButton
            // 
            this.cbInputButton.Enabled = false;
            this.cbInputButton.Location = new System.Drawing.Point(6, 86);
            this.cbInputButton.Name = "cbInputButton";
            this.cbInputButton.Size = new System.Drawing.Size(133, 23);
            this.cbInputButton.TabIndex = 9;
            this.cbInputButton.Text = "Choose Cb file";
            this.cbInputButton.UseVisualStyleBackColor = true;
            this.cbInputButton.Click += new System.EventHandler(this.cbInputButton_Click);
            // 
            // yInputButton
            // 
            this.yInputButton.Enabled = false;
            this.yInputButton.Location = new System.Drawing.Point(6, 57);
            this.yInputButton.Name = "yInputButton";
            this.yInputButton.Size = new System.Drawing.Size(133, 23);
            this.yInputButton.TabIndex = 8;
            this.yInputButton.Text = "Choose Y file";
            this.yInputButton.UseVisualStyleBackColor = true;
            this.yInputButton.Click += new System.EventHandler(this.yInputButton_Click);
            // 
            // inputImagesLabel
            // 
            this.inputImagesLabel.Location = new System.Drawing.Point(6, 38);
            this.inputImagesLabel.Name = "inputImagesLabel";
            this.inputImagesLabel.Size = new System.Drawing.Size(133, 17);
            this.inputImagesLabel.TabIndex = 7;
            this.inputImagesLabel.Text = "Input images";
            this.inputImagesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // decodeCheckBox
            // 
            this.decodeCheckBox.Location = new System.Drawing.Point(6, 18);
            this.decodeCheckBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.decodeCheckBox.Name = "decodeCheckBox";
            this.decodeCheckBox.Size = new System.Drawing.Size(130, 17);
            this.decodeCheckBox.TabIndex = 0;
            this.decodeCheckBox.Text = "Decode";
            this.decodeCheckBox.UseVisualStyleBackColor = true;
            this.decodeCheckBox.CheckedChanged += new System.EventHandler(this.encodeCheckBox_CheckedChanged);
            // 
            // processingTimeLabel
            // 
            this.processingTimeLabel.Location = new System.Drawing.Point(6, 554);
            this.processingTimeLabel.Name = "processingTimeLabel";
            this.processingTimeLabel.Size = new System.Drawing.Size(144, 22);
            this.processingTimeLabel.TabIndex = 7;
            this.processingTimeLabel.Text = "Processing time: 00.000s";
            this.processingTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chooseFileButton
            // 
            this.chooseFileButton.Location = new System.Drawing.Point(6, 36);
            this.chooseFileButton.Name = "chooseFileButton";
            this.chooseFileButton.Size = new System.Drawing.Size(145, 23);
            this.chooseFileButton.TabIndex = 6;
            this.chooseFileButton.Text = "Choose file";
            this.chooseFileButton.UseVisualStyleBackColor = true;
            this.chooseFileButton.Click += new System.EventHandler(this.chooseFileButton_Click);
            // 
            // chooseFileLabel
            // 
            this.chooseFileLabel.Location = new System.Drawing.Point(6, 16);
            this.chooseFileLabel.Name = "chooseFileLabel";
            this.chooseFileLabel.Size = new System.Drawing.Size(145, 17);
            this.chooseFileLabel.TabIndex = 5;
            this.chooseFileLabel.Text = "Choose image";
            this.chooseFileLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(6, 109);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(145, 23);
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
            this.parameters.Location = new System.Drawing.Point(7, 138);
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
            this.algorithmSwitchlabel.Location = new System.Drawing.Point(6, 62);
            this.algorithmSwitchlabel.Name = "algorithmSwitchlabel";
            this.algorithmSwitchlabel.Size = new System.Drawing.Size(145, 17);
            this.algorithmSwitchlabel.TabIndex = 1;
            this.algorithmSwitchlabel.Text = "Choose algorithm";
            this.algorithmSwitchlabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // algorithmSwitch
            // 
            this.algorithmSwitch.FormattingEnabled = true;
            this.algorithmSwitch.Items.AddRange(new object[] { "None", "Average dithering", "Ordered dithering (random)", "Ordered dithering (consecutive)", "Error propagation", "Popularity algorithm" });
            this.algorithmSwitch.Location = new System.Drawing.Point(6, 82);
            this.algorithmSwitch.Name = "algorithmSwitch";
            this.algorithmSwitch.Size = new System.Drawing.Size(145, 21);
            this.algorithmSwitch.TabIndex = 0;
            // 
            // inputPicture
            // 
            this.inputPicture.Location = new System.Drawing.Point(175, 12);
            this.inputPicture.Name = "inputPicture";
            this.inputPicture.Size = new System.Drawing.Size(445, 587);
            this.inputPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.inputPicture.TabIndex = 1;
            this.inputPicture.TabStop = false;
            // 
            // outputPicture
            // 
            this.outputPicture.Location = new System.Drawing.Point(626, 12);
            this.outputPicture.Name = "outputPicture";
            this.outputPicture.Size = new System.Drawing.Size(445, 587);
            this.outputPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.outputPicture.TabIndex = 2;
            this.outputPicture.TabStop = false;
            // 
            // processingLabel
            // 
            this.processingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.processingLabel.Location = new System.Drawing.Point(799, 284);
            this.processingLabel.Name = "processingLabel";
            this.processingLabel.Size = new System.Drawing.Size(100, 20);
            this.processingLabel.TabIndex = 3;
            this.processingLabel.Text = "Processing...";
            this.processingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.processingLabel.Visible = false;
            // 
            // outputCr
            // 
            this.outputCr.Location = new System.Drawing.Point(737, 305);
            this.outputCr.Name = "outputCr";
            this.outputCr.Size = new System.Drawing.Size(223, 293);
            this.outputCr.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.outputCr.TabIndex = 4;
            this.outputCr.TabStop = false;
            this.outputCr.Visible = false;
            // 
            // outputCb
            // 
            this.outputCb.Location = new System.Drawing.Point(849, 12);
            this.outputCb.Name = "outputCb";
            this.outputCb.Size = new System.Drawing.Size(223, 293);
            this.outputCb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.outputCb.TabIndex = 5;
            this.outputCb.TabStop = false;
            this.outputCb.Visible = false;
            // 
            // outputY
            // 
            this.outputY.Location = new System.Drawing.Point(626, 12);
            this.outputY.Name = "outputY";
            this.outputY.Size = new System.Drawing.Size(223, 293);
            this.outputY.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.outputY.TabIndex = 6;
            this.outputY.TabStop = false;
            this.outputY.Visible = false;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 605);
            this.Controls.Add(this.outputY);
            this.Controls.Add(this.outputCb);
            this.Controls.Add(this.outputCr);
            this.Controls.Add(this.processingLabel);
            this.Controls.Add(this.outputPicture);
            this.Controls.Add(this.inputPicture);
            this.Controls.Add(this.controls);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1098, 644);
            this.MinimumSize = new System.Drawing.Size(1098, 644);
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            this.controls.ResumeLayout(false);
            this.Ycbcr.ResumeLayout(false);
            this.parameters.ResumeLayout(false);
            this.parameters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inputPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.outputPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.outputCr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.outputCb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.outputY)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.PictureBox outputCr;
        private System.Windows.Forms.PictureBox outputCb;
        private System.Windows.Forms.PictureBox outputY;

        private System.Windows.Forms.Button decodeButton;

        private System.Windows.Forms.Button yInputButton;
        private System.Windows.Forms.Button crInputButton;

        private System.Windows.Forms.GroupBox Ycbcr;
        private System.Windows.Forms.CheckBox decodeCheckBox;
        private System.Windows.Forms.Button cbInputButton;
        private System.Windows.Forms.Label inputImagesLabel;

        private System.Windows.Forms.Label processingLabel;

        private System.Windows.Forms.Label processingTimeLabel;

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

