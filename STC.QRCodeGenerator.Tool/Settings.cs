using System;
using System.Collections.Generic;
using System.Text;

namespace STC.QRCodeGenerator.Tool
{
    public  class Settings
    {
        public static int TextX { get; set; } = 180;
        public static int TextY { get; set; } = 150;
        public static int QRCodeX { get; set; } = 237;
        public static int QRCodeY { get; set; } = 257;
        public static string ColumnName { get; set; } = string.Empty;

        public static string BackgroundImage { get; set; } = string.Empty;
        public static  OutputType  outputType = OutputType.Pdf ;



    }
}
