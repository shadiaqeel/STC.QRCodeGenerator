using System;
using System.Collections.Generic;
using System.Text;

namespace STC.QRCodeGenerator.Tool
{
    public  class Settings
    {
        public static int TextX { get; set; } = 81;
        public static int TextY { get; set; } = 70;
        public static int QRCodeX { get; set; } = 103;
        public static int QRCodeY { get; set; } = 109;
        public static int QRSize { get; set; } = 1;
        public static string ColumnName { get; set; } = string.Empty;

        public static string BackgroundImage { get; set; } = string.Empty;
        public static  OutputType  outputType = OutputType.Pdf ;



    }
}
