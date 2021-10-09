using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using PdfSharp.Drawing;
using PdfSharp.Pdf;

using STC.QRCodeGenerator.Tool.Helpers;

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
            var enc1252 = Encoding.GetEncoding(1252);

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


            numTextX.Value = Settings.TextX;
            numTextY.Value = Settings.TextY;
            numQRX.Value = Settings.QRCodeX;
            numQRY.Value = Settings.QRCodeY;

            ShowPreview();

        }

        private void num_ValueChanged(object sender, EventArgs e)
        {
            return;

            Settings.TextX = (int)numTextX.Value;
            Settings.TextY = (int)numTextY.Value;
            Settings.QRCodeX = (int)numQRX.Value;
            Settings.QRCodeY = (int)numQRY.Value;


            trkTextX.Value = Settings.TextX;
            trkTextY.Value = Settings.TextY;
            trkQRX.Value = Settings.QRCodeX;
            trkQRY.Value = Settings.QRCodeY;

            ShowPreview();


        }
        private void radioOutputType_CheckedChange(object sender, EventArgs e)
        {
            var selectedRadio = gbOutputType.Controls.OfType<RadioButton>().FirstOrDefault(n => n.Checked);

            if (selectedRadio.Name.Contains("Png", StringComparison.OrdinalIgnoreCase))
                Settings.outputType = OutputType.Png;
            else
                Settings.outputType = OutputType.Pdf;

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
            await task;
            btnStart.Enabled = true;

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

            var img = DrawImage("HQC-B11-F1-R1-T1-K128");
            img = ResizeImage(img, picPreview.Height, picPreview.Width) as Bitmap;
            picPreview.Image = img;

        }

        private Bitmap DrawImage(string data)
        {

            var qrImg = GenerateQRCode(data);
            var img = _backgroundImg.Clone() as Bitmap;
            Graphics graph = Graphics.FromImage(img);


            //Draw QR Code =============================
            //graph.DrawImage(qrImg, new Point((img.Width - qrImg.Width) / 2, (img.Height - qrImg.Height) / 2));
            graph.DrawImage(qrImg, new Point(Settings.QRCodeX, Settings.QRCodeY));


            //Draw Text ================================
            StringFormat strFormat = new StringFormat();
            strFormat.Alignment = StringAlignment.Center;
            strFormat.LineAlignment = StringAlignment.Center;

            var font = new Font("Tahoma", 27, FontStyle.Bold, GraphicsUnit.Pixel);
            var point = new PointF(Settings.TextX, Settings.TextY);
            graph.DrawString(data, font, Brushes.DarkViolet, point, strFormat);

            return img;
        }

        private Bitmap GenerateQRCode(string data)
        {
            BarcodeWriter barcodeWriter = new BarcodeWriter();
            EncodingOptions encodingOptions = new EncodingOptions { Height = AppConfig.HeightQRCode, Width = AppConfig.WidthQRCode, Margin = 0, PureBarcode = false };
            encodingOptions.Hints.Add(EncodeHintType.ERROR_CORRECTION, ErrorCorrectionLevel.H);
            barcodeWriter.Renderer = new BitmapRenderer()
            {
                Foreground = Color.White,
                Background = Color.DarkViolet

            };
            barcodeWriter.Options = encodingOptions;
            barcodeWriter.Format = BarcodeFormat.QR_CODE;

            Bitmap qrBitmap = barcodeWriter.Write(data);
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


        private bool ReadExcelSheet()
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
                if (!ProcessList(list))
                    break;
            }

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
                var image = DrawImage(code);


                switch (Settings.outputType)
                {

                    case OutputType.Png:
                        image.Save($"{AppConfig.DestinationPath}\\{code}.png", System.Drawing.Imaging.ImageFormat.Png);
                        break;
                    default:
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
            graph.DrawImage(ximg, 0, 0, 612, 792);
            if (pdfFile.PageCount > 0) pdfFile.Save($"{AppConfig.DestinationPath}\\{code}.pdf");

            return;
        }


        #endregion

        
    }
}
