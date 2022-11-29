using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ColorReduction.Reducers;

namespace ColorReduction
{
    public partial class MainWindow : Form
    {
        private Bitmap? _inputBitmap;
        private TimeSpan? _processingTime;

        public MainWindow()
        {
            InitializeComponent();

            inputPicture.Image = new Bitmap(inputPicture.Size.Width, inputPicture.Size.Height);
            outputPicture.Image = new Bitmap(outputPicture.Size.Width, outputPicture.Size.Height);
        }

        private void ImportImage(string filename)
        {
            chooseFileLabel.Text = Path.GetFileName(filename);
            outputPicture.Image = new Bitmap(outputPicture.Size.Width, outputPicture.Size.Height);
            inputPicture.Image = new Bitmap(filename);
            _inputBitmap = new Bitmap(filename);
            inputPicture.Refresh();

            _processingTime = null;
            RefreshProcessingTimeLabel();
        }

        private void ProcessImage(Bitmap input, ColorReducer reducer)
        {
            processingLabel.Visible = true;
            processingLabel.Refresh();
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var result = reducer.Reduce(input);

            stopwatch.Stop();
            processingLabel.Visible = false;
            processingLabel.Refresh();
            _processingTime = stopwatch.Elapsed;
            RefreshProcessingTimeLabel();

            outputPicture.Image = result;
            outputPicture.Refresh();
        }

        private ReducerOptions? GetCurrentOptions()
        {
            if (!int.TryParse(kRedBox.Text, out var kRed) || !int.TryParse(kGreenBox.Text, out var kGreen) ||
                !int.TryParse(kBlueBox.Text, out var kBlue) || !int.TryParse(kAllBox.Text, out var kAll))
                return null;

            return new ReducerOptions(kRed, kGreen, kBlue, kAll);
        }

        private void RefreshProcessingTimeLabel()
        {
            if (_processingTime is { } time)
            {
                processingTimeLabel.Visible = true;
                processingTimeLabel.Text = @$"Processing time: {time.TotalSeconds:0.000}s";
                return;
            }

            processingTimeLabel.Visible = false;
        }

        private void chooseFileButton_Click(object sender, EventArgs e)
        {
            var result = openFileDialog.ShowDialog();
            if (result != DialogResult.OK) return;

            ImportImage(openFileDialog.FileName);
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            if (_inputBitmap is null) return;

            var options = GetCurrentOptions();
            if (!(options?.Validate() ?? false)) return;

            _processingTime = null;
            RefreshProcessingTimeLabel();

            var algorithmName = algorithmSwitch.SelectedItem as string ?? throw new InvalidOperationException();
            var reducer = ColorReducerFactory.Create(algorithmName, options);
            ProcessImage(_inputBitmap, reducer);
        }
    }
}