using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using PdfSharp.Drawing;
using PdfSharp.Pdf;

using STC.QRCodeGenerator.Tool.Helpers;
using STC.QRCodeGenerator.Tool.Models;

using ZXing;
using ZXing.Common;
using ZXing.QrCode.Internal;
using ZXing.Rendering;

namespace STC.QRCodeGenerator.Tool
{
    public partial class Form1 : Form
    {
        private Logger _logger;
        private Bitmap _backgroundImg;
        public Form1()
        {
            InitializeComponent();
            Init();
        }
        private void Init()
        {

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            _logger = new Logger(boxOutput);
            Settings.BackgroundImage = AppConfig.BackgroundImage;
            _logger.WriteLog($"Destination Directory : {Settings.BackgroundImage}");
            _logger.WriteLog($"Background Image : {Settings.BackgroundImage}");
            UpdateBackgroundImg();
            InitSettings();
            ShowPreview();
            if (string.IsNullOrEmpty(txtExcel.Text))
            {
                txtExcel.Text = @"C:\Users\shadi\Desktop\Stc_QR\files\DeskSheet.xlsx";
            }
        }

        private void UpdateBackgroundImg()
        {
            if (!string.IsNullOrEmpty(Settings.BackgroundImage) && File.Exists(Settings.BackgroundImage))
                _backgroundImg = new Bitmap(Settings.BackgroundImage);
            else _backgroundImg = new Bitmap(Resources.Resource.Stc_background);
        }

        private void InitSettings()
        {

            txtColName.Text = AppConfig.ColumnName;
            Settings.ColumnName = AppConfig.ColumnName;

            numTextX.Value = Settings.TextX;
            numTextY.Value = Settings.TextY;
            numQRX.Value = Settings.QRCodeX;
            numQRY.Value = Settings.QRCodeY;


            trkTextX.Maximum = picPreview.Width;
            numTextX.Maximum = picPreview.Width;

            trkTextY.Maximum = picPreview.Height;
            numTextY.Maximum = picPreview.Height;

            trkQRX.Maximum = picPreview.Width;
            numQRX.Maximum = picPreview.Width;

            trkQRY.Maximum = picPreview.Height;
            numQRY.Maximum = picPreview.Height;

            trkTextX.Value = Settings.TextX;
            trkTextY.Value = Settings.TextY;
            trkQRX.Value = Settings.QRCodeX;
            trkQRY.Value = Settings.QRCodeY;

        }

        #region Events
        private void trk_Scroll(object sender, EventArgs e)
        {
            Settings.TextX = trkTextX.Value;
            Settings.TextY = trkTextY.Value;
            Settings.QRCodeX = trkQRX.Value;
            Settings.QRCodeY = trkQRY.Value;
            Settings.QRSize = trQRSize.Value;


            numTextX.Value = Settings.TextX;
            numTextY.Value = Settings.TextY;
            numQRX.Value = Settings.QRCodeX;
            numQRY.Value = Settings.QRCodeY;
            numQRSize.Value = Settings.QRSize;

            ShowPreview();

        }

        private void num_ValueChanged(object sender, EventArgs e)
        {
            return;

            Settings.TextX = (int)numTextX.Value;
            Settings.TextY = (int)numTextY.Value;
            Settings.QRCodeX = (int)numQRX.Value;
            Settings.QRCodeY = (int)numQRY.Value;
            Settings.QRSize = (int)numQRSize.Value;


            trkTextX.Value = Settings.TextX;
            trkTextY.Value = Settings.TextY;
            trkQRX.Value = Settings.QRCodeX;
            trkQRY.Value = Settings.QRCodeY;
            trQRSize.Value = Settings.QRSize;

            ShowPreview();


        }
        private void radioOutputType_CheckedChange(object sender, EventArgs e)
        {
            var selectedRadio = gbOutputType.Controls.OfType<RadioButton>().FirstOrDefault(n => n.Checked);

            if (selectedRadio.Name.Contains("Png", StringComparison.OrdinalIgnoreCase))
            {
                Settings.outputType = OutputType.Png;
            }
            else
            {
                Settings.outputType = OutputType.Pdf;
                // picPreview.Width = Constants.PdfWidth / Constants.PdfToPreviewRatio;
                // picPreview.Height = Constants.PdfHeight / Constants.PdfToPreviewRatio;
            }
        }


        private async void btnStart_ClickAsync(object sender, EventArgs e)
        {
            Settings.ColumnName = txtColName.Text;
            if (string.IsNullOrEmpty(txtExcel.Text))
            {
                MessageBox.Show("Select Excel File", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //if (string.IsNullOrEmpty(Settings.BackgroundImage) || !File.Exists(Settings.BackgroundImage))
            //{
            //    MessageBox.Show("Please select background image");
            //    return;
            //}

            btnStart.Enabled = false;
            var task = Task.Run(() => ReadExcelSheet());
            Stopwatch sp = new Stopwatch();
            sp.Start();
            try
            {
                await task;
                _logger.WriteLog($"Done 👍");
            }
            catch (Exception ex)
            {
                _logger.WriteLog($"Exception : {ex.Message}");
            }
            sp.Stop();

            btnStart.Enabled = true;
            _logger.WriteLog($"Elapsed Time For Process {progressBar.Maximum} items is {sp.Elapsed}");

        }

        private void txtExcel_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Excel Files |*.csv;*.xls;*.xlsx|CSV file|*.csv|XLS file|*.xls|XLSX file|*.xlsx";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtExcel.Text = openFileDialog.FileName;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Images | *.jpg;*.jpeg;*.png|JPG Image|*.jpg|JPEG Image|*.jpeg|PNG Image|*.png";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.BackgroundImage = openFileDialog.FileName;
                UpdateBackgroundImg();
                ShowPreview();
            }
        }

        #endregion

        #region Methods
        private void ShowPreview()
        {

            var img = DrawImage("HQC-B11-F1-R1-T1-K128", picPreview.Height, picPreview.Width);
            //img = ResizeImage(img, picPreview.Height, picPreview.Width) as Bitmap;
            picPreview.Image = img;

        }

        private Bitmap DrawImage(string data, int outputWidth, int outputHeight)
        {



            var img = _backgroundImg.Clone() as Bitmap;

            Graphics graph = Graphics.FromImage(img);
            //Draw Text ================================
            StringFormat strFormat = new StringFormat();
            strFormat.Alignment = StringAlignment.Center;
            strFormat.LineAlignment = StringAlignment.Center;

            var font = new Font(Constants.TextFont, 27, FontStyle.Bold, GraphicsUnit.Pixel);
            var pointText = new PointF();
            pointText.X = (img.Width * Settings.TextX) / picPreview.Width;
            pointText.Y = (img.Height * Settings.TextY) / picPreview.Height;
            graph.DrawString(data, font, Constants.ColorText, pointText, strFormat);



            img = ResizeImage(img, outputHeight, outputWidth) as Bitmap;
            graph = Graphics.FromImage(img);

            //Draw QR Code =============================
            //var qrImg = GenerateQRCode(data);
            //var img = _backgroundImg.Clone() as Bitmap;
            //graph.DrawImage(qrImg, new Point((img.Width - qrImg.Width) / 2, (img.Height - qrImg.Height) / 2));

            double scale = outputHeight > _backgroundImg.Height ? (double)_backgroundImg.Height / (double)outputHeight : (double)outputHeight / (double)_backgroundImg.Height;
            int qrImgHeight = Convert.ToInt32((double)AppConfig.HeightQRCode * scale);
            qrImgHeight = qrImgHeight + Convert.ToInt32((double)qrImgHeight * AppConfig.QRSizeFactor * scale * Settings.QRSize);
            var qrImg = ResizeImage(GenerateQRCode(data), qrImgHeight, qrImgHeight);
            var pointQR = new Point();
            pointQR.X = (img.Width * Settings.QRCodeX) / picPreview.Width;
            pointQR.Y = (img.Height * Settings.QRCodeY) / picPreview.Height;

            graph.DrawImage(qrImg, pointQR);





            return img as Bitmap;
        }

        private Bitmap GenerateQRCode(string data)
        {
            BarcodeWriter barcodeWriter = new BarcodeWriter();
            EncodingOptions encodingOptions = new EncodingOptions { Height = AppConfig.HeightQRCode, Width = AppConfig.WidthQRCode, Margin = 0, PureBarcode = false };
            encodingOptions.Hints.Add(EncodeHintType.ERROR_CORRECTION, ErrorCorrectionLevel.H);
            barcodeWriter.Renderer = new BitmapRenderer()
            {
                Foreground = Color.White,
                Background = Color.Green

            };
            barcodeWriter.Options = encodingOptions;
            barcodeWriter.Format = BarcodeFormat.QR_CODE;

            Bitmap qrBitmap = barcodeWriter.Write(data);
            qrBitmap.MakeTransparent(Color.Green);
            return qrBitmap;
        }

        private Image ResizeImage(Image image, int newHeight, int newWidth)
        {

            Bitmap newImage = new Bitmap(newWidth, newHeight);
            Graphics graph = Graphics.FromImage(newImage);
            graph.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
            graph.DrawImage(image, 0, 0, newWidth, newHeight);

            return newImage;

        }


        private async Task<bool> ReadExcelSheet()
        {

            if (AppConfig.ThreadCount > 1)
                return await MultiThread();

            return SingleThread();

        }

        private bool SingleThread()
        {
            _logger.WriteLog(txtExcel.Text);
            _logger.WriteLog("======================================================= ");
            using var reader = new ExcelHandler(_logger, txtExcel.Text);

            _logger.WriteLog($"Codes Count : {reader.RowCount}");
            progressBar?.Invoke((MethodInvoker)delegate { progressBar.Maximum = reader.RowCount; });
            progressBar?.Invoke((MethodInvoker)delegate { progressBar.Value = 0; });
            lblProgress?.Invoke((MethodInvoker)delegate { lblProgress.Text = $"{0}/{reader.RowCount}"; });



            var pageNo = 1;
            var count = 0;
            var pageSize = 100;


            while (count < reader.RowCount)
            {
                var list = reader.Read(Settings.ColumnName, pageNo, pageSize, out bool isExistCol);
                if (!isExistCol)
                {
                    MessageBox.Show("Target Column is not exsit in excel sheet, please enter valid column name in settings tab");
                    return false;
                }
                count += list.Length;
                pageNo++;



                if (list.Length == 0)
                {
                    break;
                }
            }
            _logger.WriteLog("======================================================= ");
            _logger.WriteLog($"Output Path : {AppConfig.DestinationPath}");


            return true;

        }


        private async Task<bool> MultiThread()
        {
            _logger.WriteLog(txtExcel.Text);
            _logger.WriteLog("======================================================= ");
            using var reader = new ExcelHandler(_logger, txtExcel.Text);

            _logger.WriteLog($"Codes Count : {reader.RowCount}");
            progressBar?.Invoke((MethodInvoker)delegate { progressBar.Maximum = reader.RowCount; });
            progressBar?.Invoke((MethodInvoker)delegate { progressBar.Value = 0; });
            lblProgress?.Invoke((MethodInvoker)delegate { lblProgress.Text = $"{0}/{reader.RowCount}"; });



            var pageNo = 1;
            var count = 0;
            var pageSize = 100;

            // Create a scheduler that uses two threads.
            var lcts = new LimitedConcurrencyLevelTaskScheduler(AppConfig.ThreadCount);
            var tasks = new List<Task<bool>>();
            // Create a TaskFactory and pass it our custom scheduler.
            var factory = new TaskFactory(lcts);
            var cts = new CancellationTokenSource();

            while (count < reader.RowCount)
            {
                var list = reader.Read(Settings.ColumnName, pageNo, pageSize, out bool isExistCol);
                if (!isExistCol)
                {
                    MessageBox.Show("Target Column is not exsit in excel sheet, please enter valid column name in settings tab");
                    return false;
                }
                count += list.Length;
                pageNo++;


                var t = factory.StartNew(() => ProcessList(list), cts.Token);
                tasks.Add(t);
                if (tasks.Count() >= AppConfig.ThreadCount)
                {
                    if (!await Task.WhenAny(tasks).Result)
                    {
                        cts.Cancel();
                        break;
                    }
                    tasks.Clear();
                }
            }
            await Task.WhenAll(tasks);
            _logger.WriteLog("======================================================= ");
            _logger.WriteLog($"Output Path : {AppConfig.DestinationPath}");


            return true;
        }


        private bool ProcessList(string[] list)
        {

            if (list.Length <= 0)
                return false;
            foreach (var code in list)
            {
                _logger.WriteLog(code);
                Bitmap image;

                switch (Settings.outputType)
                {

                    case OutputType.Png:
                        image = DrawImage(code, _backgroundImg.Width, _backgroundImg.Height);
                        image.Save($"{AppConfig.DestinationPath}\\{code}.png", System.Drawing.Imaging.ImageFormat.Png);
                        break;
                    default:
                        image = DrawImage(code, Constants.PdfWidth, Constants.PdfHeight);
                        // image.Save($"{AppConfig.DestinationPath}\\{code}.png", System.Drawing.Imaging.ImageFormat.Png);
                        SaveToPdf(code, image);
                        break;
                }



                progressBar?.Invoke((MethodInvoker)delegate { progressBar.Value++; });
                lblProgress?.Invoke((MethodInvoker)delegate { lblProgress.Text = $"{progressBar.Value}/{progressBar.Maximum}"; });


            }
            return true;
        }

        private static void SaveToPdf(string code, Bitmap image)
        {



            PdfDocument pdfFile = new PdfDocument();
            pdfFile.Info.Title = code;
            PdfPage page = pdfFile.AddPage();
            XGraphics graph = XGraphics.FromPdfPage(page);
            var memStrm = new MemoryStream();
            image.Save(memStrm, System.Drawing.Imaging.ImageFormat.Png);
            memStrm.Position = 0;
            var ximg = XImage.FromStream(memStrm);
            memStrm.Position = 0;
            graph.DrawImage(ximg, 0, 0, Constants.PdfWidth, Constants.PdfHeight);
            if (pdfFile.PageCount > 0) pdfFile.Save($"{AppConfig.DestinationPath}\\{code}.pdf");

            return;
        }



        #endregion


    }
}
