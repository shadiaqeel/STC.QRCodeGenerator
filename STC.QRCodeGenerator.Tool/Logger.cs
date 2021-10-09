using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace STC.QRCodeGenerator.Tool
{
    class Logger
    {
        public RichTextBox outputBox ;

        public Logger (RichTextBox outputBox)
        {

            this.outputBox = outputBox;
        }

        public void WriteLog(string text)
        {

            try
            {
                if (outputBox.InvokeRequired)
                {
                    outputBox?.Invoke((MethodInvoker)delegate { outputBox.AppendText(text + Environment.NewLine ); outputBox.ScrollToCaret(); });
                    return;
                }
                outputBox.AppendText(text + Environment.NewLine);
            }
            catch { }
        }

    }
}
