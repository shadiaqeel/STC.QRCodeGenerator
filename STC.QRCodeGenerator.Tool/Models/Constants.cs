using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace STC.QRCodeGenerator.Tool
{
    public  class Constants
    {
        public static int PdfWidth { get; set; } = 612;
       // public static int PdfHeight { get; set; } = 612;
        public static int PdfHeight { get; set; } = 792;
        public static Brush ColorText => Brushes.DarkViolet;

        public static string TextFont => "Tahoma";

        public static int PdfToPreviewRatio => 10;
    }
}
