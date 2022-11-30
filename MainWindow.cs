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
        }

        private static Bitmap ResizeImage(Image image, Size size)
        {
            var inputRatio = image.Size.Height / (double)image.Size.Width;
            var outputRatio = size.Height / (double)size.Width;

            if (inputRatio > outputRatio)
            {
                // Match height
                var width = image.Size.Width * (size.Height / (double)image.Size.Height);
                return new Bitmap(image, new Size((int)width, size.Height));
            }

            // Match width
            var height = image.Size.Height * (size.Width / (double)image.Size.Width);
            return new Bitmap(image, new Size(size.Width, (int)height));
        }

        private void ImportImage(string filename)
        {
            chooseFileLabel.Text = Path.GetFileName(filename);
            outputPicture.Image = new Bitmap(outputPicture.Size.Width, outputPicture.Size.Height);
            outputPicture.Refresh();

            inputPicture.Image = new Bitmap(filename);
            inputPicture.Refresh();

            _inputBitmap = ResizeImage(new Bitmap(filename), outputPicture.Size);
            _processingTime = null;
            RefreshProcessingTimeLabel();
        }

        private void ProcessImage(Bitmap input, IColorReducer reducer)
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

            var algorithmName = algorithmSwitch.SelectedItem as string ??
                                throw new InvalidOperationException(
                                    $"Selected object is not a string but {algorithmSwitch.SelectedItem.GetType().Name}");
            var reducer = ColorReducerFactory.Create(algorithmName, options);
            ProcessImage(_inputBitmap, reducer);
        }
    }
}