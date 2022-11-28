using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ColorReduction
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();

            inputPicture.Image = new Bitmap(inputPicture.Size.Width, inputPicture.Size.Height);
            outputPicture.Image = new Bitmap(outputPicture.Size.Width, outputPicture.Size.Height);
        }

        private void chooseFileButton_Click(object sender, EventArgs e)
        {
            var result = openFileDialog.ShowDialog();
            if (result != DialogResult.OK) return;

            chooseFileLabel.Text = Path.GetFileName(openFileDialog.FileName);
            inputPicture.Image = new Bitmap(openFileDialog.FileName);
            inputPicture.Refresh();
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
        }
    }
}