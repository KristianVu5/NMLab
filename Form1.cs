using System.Reflection.Metadata.Ecma335;

namespace NMLab
{
    public partial class Form1 : Form
    {
        private Bitmap originalImage;

        public Form1()
        {
            InitializeComponent();

            this.Load += Form1_Load;


        }

        private void Form1_Load(Object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;


        }

        public static List<double> process(double x, double min, double max, double newMin, double newMax, int rangeSize)
        {
            if (min >= max || rangeSize <= 0)
                throw new ArgumentException("Invalid range.");
            if (x < min || x >= max)
                    throw new ArgumentOutOfRangeException(nameof(x));
            double rangeStart = min + Math.Floor((x - min) / rangeSize) * rangeSize;
            double rangeEnd = Math.Min(rangeStart + rangeSize, max);
            List<double> values = new List<double>();
            for (double i = rangeStart; i < rangeEnd; i++)
            {
                double scaled = newMin + ((i - min) / (max - min)) * (newMax - newMin);
                values.Add(scaled);
            }
            return values;
        }

        private void btnChooseImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Title = "Choose image";
                dialog.Filter = "Image Files |*.jpg;*.jpeg;*.png;*.bmp;";

                if (dialog.ShowDialog() == DialogResult.OK)
                {

                    originalImage?.Dispose();
                    originalImage = new Bitmap(dialog.FileName);

                    pictureBox1.Image = originalImage;
                }
            }
        }

        private void btnGrayscale_Click(object sender, EventArgs e)
        {
            if (originalImage == null)
            {
                MessageBox.Show("Please choose an image first.");
                return;
            }

            Bitmap grayImage = new Bitmap(originalImage.Width, originalImage.Height);

            for (int x = 0; x < originalImage.Width; x++)
            {
                for (int y = 0; y < originalImage.Height; y++)
                {
                    Color pixel = originalImage.GetPixel(x, y);

                    // Средноаритметичната стойност на цветовете дава сивия нюанс.
                    int gray = (pixel.R + pixel.G + pixel.B) / 3;

                    grayImage.SetPixel(x, y, Color.FromArgb(
                        pixel.A, gray, gray, gray));
                }
            }
            pictureBox2.Image?.Dispose();
            pictureBox2.Image = grayImage;

            double[] vector = ExtractRgbVector(grayImage, 3);

            txtVectors.Text = 
                "Average RGB values for range: " + Environment.NewLine + 
                $"Up: [{vector[0]:F2}, {vector[1]:F2}, {vector[2]:F2}]" + Environment.NewLine +
                $"Mid: [{vector[3]:F2}, {vector[4]:F2}, {vector[5]:F2}]" +Environment.NewLine +
                $"Down: [{vector[6]:F2}, {vector[7]:F2}, {vector[8]:F2}]";

        }

        private double[] ExtractRgbVector(Bitmap image, int numberOfRegions)
        {
            double[] vector = new double[numberOfRegions * 3];

            for (int region = 0; region < numberOfRegions; region++)
            {
                int startY = region * image.Height / numberOfRegions;
                int endY = (region + 1) * image.Height / numberOfRegions;

                long sumR = 0;
                long sumG = 0;
                long sumB = 0;
                long count = 0;

                for (int y = startY; y < endY; y++)
                {
                    for (int x = 0; x < image.Width; x++)
                    {
                        Color pixel = image.GetPixel(x, y);

                        sumR += pixel.R;
                        sumG += pixel.G;
                        sumB += pixel.B;
                        count++;
                    }
                }

                int i = region * 3;

                double averageR = (double)sumR / count;
                double averageG = (double)sumG / count;
                double averageB = (double)sumB / count;


                vector[i] = ConvertToNewRange(averageR);
                vector[i + 1] = ConvertToNewRange(averageG);
                vector[i + 2] = ConvertToNewRange(averageB);
            }

            return vector;
        }

        private double ConvertToNewRange(double value)
        {

            List<double> values = process(value, 0, 256, -1, 1, 1);
            return values[0];
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            originalImage?.Dispose();
            base.OnFormClosed(e);
        }

        
    }
}
