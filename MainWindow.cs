using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using ColorReduction.Reducers;

namespace ColorReduction
{
    public partial class MainWindow : Form
    {
        private Bitmap? _inputBitmap;
        private string? _cbPath;
        private string? _crPath;
        private string? _yPath;

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
            processingTimeLabel.Visible = false;
        }

        private void ProcessImage(Bitmap input, IColorReducer reducer)
        {
            var result = RegisterProcessingTime(() => reducer.Reduce(input));

            ResetYcbcrFunctions();
            DisplayOutputPicture(result);
        }

        private T RegisterProcessingTime<T>(Func<T> func)
        {
            processingTimeLabel.Visible = false;
            processingLabel.Visible = true;
            processingLabel.Refresh();

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var result = func();
            stopwatch.Stop();

            processingLabel.Visible = false;
            processingLabel.Refresh();
            DisplayProcessingTime(stopwatch.Elapsed);

            return result;
        }

        private void ResetYcbcrFunctions()
        {
            outputY.Visible = false;
            outputCb.Visible = false;
            outputCr.Visible = false;
            yInputButton.Text = @"Choose Y image";
            cbInputButton.Text = @"Choose Cb image";
            crInputButton.Text = @"Choose Cr image";
        }

        private ReducerOptions? GetCurrentOptions()
        {
            if (!int.TryParse(kRedBox.Text, out var kRed) || !int.TryParse(kGreenBox.Text, out var kGreen) ||
                !int.TryParse(kBlueBox.Text, out var kBlue) || !int.TryParse(kAllBox.Text, out var kAll))
                return null;

            return new ReducerOptions(kRed, kGreen, kBlue, kAll);
        }

        private void DisplayProcessingTime(TimeSpan processingTime)
        {
            processingTimeLabel.Visible = true;
            processingTimeLabel.Text = @$"Processing time: {processingTime.TotalSeconds:0.000}s";
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

            processingTimeLabel.Visible = false;

            var algorithmName = algorithmSwitch.SelectedItem as string ??
                                throw new InvalidOperationException(
                                    $"Selected object is not a string but {algorithmSwitch.SelectedItem.GetType().Name}");
            var reducer = ColorReducerFactory.Create(algorithmName, options);
            ProcessImage(_inputBitmap, reducer);
        }

        private void encodeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            yInputButton.Enabled = decodeCheckBox.Checked;
            cbInputButton.Enabled = decodeCheckBox.Checked;
            crInputButton.Enabled = decodeCheckBox.Checked;
        }

        private void yInputButton_Click(object sender, EventArgs e)
        {
            var result = openFileDialog.ShowDialog();
            if (result != DialogResult.OK) return;
            _yPath = openFileDialog.FileName;
            yInputButton.Text = openFileDialog.SafeFileName;
        }

        private void cbInputButton_Click(object sender, EventArgs e)
        {
            var result = openFileDialog.ShowDialog();
            if (result != DialogResult.OK) return;
            _cbPath = openFileDialog.FileName;
            cbInputButton.Text = openFileDialog.SafeFileName;
        }

        private void crInputButton_Click(object sender, EventArgs e)
        {
            var result = openFileDialog.ShowDialog();
            if (result != DialogResult.OK) return;
            _crPath = openFileDialog.FileName;
            crInputButton.Text = openFileDialog.SafeFileName;
        }

        private void decodeButton_Click(object sender, EventArgs e)
        {
            if (!decodeCheckBox.Checked)
            {
                if (_inputBitmap is null) return;
                var encodedImages = RegisterProcessingTime(() => CreateYcbcrImages(_inputBitmap));
                DisplayEncodedImages(encodedImages);
                SaveEncodedImages(encodedImages);
                return;
            }

            if (_yPath is null || _cbPath is null || _crPath is null) return;
            var importedImages = new YcbcrImages(_yPath, _cbPath, _crPath);
            var decoded = RegisterProcessingTime(() => DecodeFromYcbcr(importedImages));
            DisplayDecodedImage(decoded);
            SaveDecodedImage(decoded);
        }

        private static Bitmap DecodeFromYcbcr(YcbcrImages images)
        {
            var yCbCrOutput = YcbcrWriter.Read(images);
            return new YcbcrEncoder(yCbCrOutput).Decode();
        }

        private void DisplayDecodedImage(Bitmap decoded)
        {
            ResetYcbcrFunctions();
            DisplayOutputPicture(decoded);
        }

        private void DisplayOutputPicture(Image image)
        {
            outputPicture.Visible = true;
            outputPicture.Image = image;
            outputPicture.Refresh();
        }

        private static void SaveDecodedImage(Bitmap decoded)
        {
            decoded.Save("output_Rgb.png", ImageFormat.Png);
        }

        private void DisplayEncodedImages(YcbcrImages images)
        {
            outputPicture.Visible = false;

            outputY.Visible = true;
            outputY.Image = images.Y;
            outputY.Refresh();

            outputCb.Visible = true;
            outputCb.Image = images.Cb;
            outputY.Refresh();

            outputCr.Visible = true;
            outputCr.Image = images.Cr;
            outputY.Refresh();
        }

        private static YcbcrImages CreateYcbcrImages(Bitmap input)
        {
            var yCbCrInput = new YcbcrEncoder(input).Encode();
            return YcbcrWriter.Write(yCbCrInput);
        }

        private static void SaveEncodedImages(YcbcrImages images)
        {
            images.Y.Save("output_Y.png", ImageFormat.Png);
            images.Cb.Save("output_Cb.png", ImageFormat.Png);
            images.Cr.Save("output_Cr.png", ImageFormat.Png);
        }
    }
}