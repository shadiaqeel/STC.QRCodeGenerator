
namespace STC.QRCodeGenerator.Tool
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtExcel = new System.Windows.Forms.TextBox();
            this.boxOutput = new System.Windows.Forms.RichTextBox();
            this.picPreview = new System.Windows.Forms.PictureBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblProgress = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.gbOutputType = new System.Windows.Forms.GroupBox();
            this.rdPDF = new System.Windows.Forms.RadioButton();
            this.rdPNG = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.txtColName = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.numQRY = new System.Windows.Forms.NumericUpDown();
            this.numQRX = new System.Windows.Forms.NumericUpDown();
            this.numTextY = new System.Windows.Forms.NumericUpDown();
            this.numTextX = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.trkQRY = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.trkQRX = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.trkTextY = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.trkTextX = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.gbOutputType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQRY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQRX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTextY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTextX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkQRY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkQRX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkTextY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkTextX)).BeginInit();
            this.SuspendLayout();
            // 
            // txtExcel
            // 
            this.txtExcel.Location = new System.Drawing.Point(121, 21);
            this.txtExcel.Name = "txtExcel";
            this.txtExcel.Size = new System.Drawing.Size(492, 23);
            this.txtExcel.TabIndex = 0;
            this.txtExcel.Click += new System.EventHandler(this.txtExcel_Click);
            // 
            // boxOutput
            // 
            this.boxOutput.Location = new System.Drawing.Point(35, 88);
            this.boxOutput.Name = "boxOutput";
            this.boxOutput.Size = new System.Drawing.Size(776, 318);
            this.boxOutput.TabIndex = 1;
            this.boxOutput.Text = "";
            // 
            // picPreview
            // 
            this.picPreview.Location = new System.Drawing.Point(531, 49);
            this.picPreview.Name = "picPreview";
            this.picPreview.Size = new System.Drawing.Size(327, 313);
            this.picPreview.TabIndex = 3;
            this.picPreview.TabStop = false;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(651, 23);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(160, 59);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_ClickAsync);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Excel File";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(35, 58);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(578, 23);
            this.progressBar.TabIndex = 6;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(883, 449);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Transparent;
            this.tabPage1.Controls.Add(this.lblProgress);
            this.tabPage1.Controls.Add(this.btnStart);
            this.tabPage1.Controls.Add(this.progressBar);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtExcel);
            this.tabPage1.Controls.Add(this.boxOutput);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(875, 421);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Export";
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.BackColor = System.Drawing.Color.Transparent;
            this.lblProgress.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblProgress.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblProgress.Location = new System.Drawing.Point(330, 59);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(17, 20);
            this.lblProgress.TabIndex = 7;
            this.lblProgress.Text = "0";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage2.Controls.Add(this.gbOutputType);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.txtColName);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.numQRY);
            this.tabPage2.Controls.Add(this.numQRX);
            this.tabPage2.Controls.Add(this.numTextY);
            this.tabPage2.Controls.Add(this.numTextX);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.trkQRY);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.trkQRX);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.trkTextY);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.trkTextX);
            this.tabPage2.Controls.Add(this.picPreview);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(875, 421);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Settings";
            // 
            // gbOutputType
            // 
            this.gbOutputType.Controls.Add(this.rdPDF);
            this.gbOutputType.Controls.Add(this.rdPNG);
            this.gbOutputType.Location = new System.Drawing.Point(336, 34);
            this.gbOutputType.Name = "gbOutputType";
            this.gbOutputType.Size = new System.Drawing.Size(152, 48);
            this.gbOutputType.TabIndex = 22;
            this.gbOutputType.TabStop = false;
            this.gbOutputType.Text = "Output Type";
            // 
            // rdPDF
            // 
            this.rdPDF.AutoSize = true;
            this.rdPDF.Checked = true;
            this.rdPDF.Location = new System.Drawing.Point(25, 22);
            this.rdPDF.Name = "rdPDF";
            this.rdPDF.Size = new System.Drawing.Size(46, 19);
            this.rdPDF.TabIndex = 20;
            this.rdPDF.TabStop = true;
            this.rdPDF.Text = "PDF";
            this.rdPDF.UseVisualStyleBackColor = true;
            this.rdPDF.CheckedChanged += new System.EventHandler(this.radioOutputType_CheckedChange);
            // 
            // rdPNG
            // 
            this.rdPNG.AutoSize = true;
            this.rdPNG.Location = new System.Drawing.Point(77, 22);
            this.rdPNG.Name = "rdPNG";
            this.rdPNG.Size = new System.Drawing.Size(49, 19);
            this.rdPNG.TabIndex = 21;
            this.rdPNG.Text = "PNG";
            this.rdPNG.UseVisualStyleBackColor = true;
            this.rdPNG.CheckedChanged += new System.EventHandler(this.radioOutputType_CheckedChange);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(39, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 15);
            this.label6.TabIndex = 18;
            this.label6.Text = "Body Column Name";
            // 
            // txtColName
            // 
            this.txtColName.Location = new System.Drawing.Point(160, 49);
            this.txtColName.Name = "txtColName";
            this.txtColName.Size = new System.Drawing.Size(156, 23);
            this.txtColName.TabIndex = 17;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(616, 382);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(148, 23);
            this.button1.TabIndex = 16;
            this.button1.Text = "Change Background";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // numQRY
            // 
            this.numQRY.Enabled = false;
            this.numQRY.Location = new System.Drawing.Point(449, 251);
            this.numQRY.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.numQRY.Name = "numQRY";
            this.numQRY.Size = new System.Drawing.Size(56, 23);
            this.numQRY.TabIndex = 15;
            this.numQRY.ValueChanged += new System.EventHandler(this.num_ValueChanged);
            // 
            // numQRX
            // 
            this.numQRX.Enabled = false;
            this.numQRX.Location = new System.Drawing.Point(449, 200);
            this.numQRX.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.numQRX.Name = "numQRX";
            this.numQRX.Size = new System.Drawing.Size(56, 23);
            this.numQRX.TabIndex = 14;
            this.numQRX.ValueChanged += new System.EventHandler(this.num_ValueChanged);
            // 
            // numTextY
            // 
            this.numTextY.Enabled = false;
            this.numTextY.Location = new System.Drawing.Point(449, 150);
            this.numTextY.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.numTextY.Name = "numTextY";
            this.numTextY.Size = new System.Drawing.Size(56, 23);
            this.numTextY.TabIndex = 13;
            this.numTextY.ValueChanged += new System.EventHandler(this.num_ValueChanged);
            // 
            // numTextX
            // 
            this.numTextX.Enabled = false;
            this.numTextX.Location = new System.Drawing.Point(449, 99);
            this.numTextX.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.numTextX.Name = "numTextX";
            this.numTextX.Size = new System.Drawing.Size(56, 23);
            this.numTextX.TabIndex = 12;
            this.numTextX.ValueChanged += new System.EventHandler(this.num_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(49, 253);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "QR Code Y";
            // 
            // trkQRY
            // 
            this.trkQRY.Location = new System.Drawing.Point(144, 253);
            this.trkQRY.Maximum = 300;
            this.trkQRY.Name = "trkQRY";
            this.trkQRY.Size = new System.Drawing.Size(299, 45);
            this.trkQRY.TabIndex = 10;
            this.trkQRY.TickFrequency = 5;
            this.trkQRY.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trkQRY.Scroll += new System.EventHandler(this.trk_Scroll);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(49, 202);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "QR Code X";
            // 
            // trkQRX
            // 
            this.trkQRX.Location = new System.Drawing.Point(144, 202);
            this.trkQRX.Maximum = 300;
            this.trkQRX.Name = "trkQRX";
            this.trkQRX.Size = new System.Drawing.Size(299, 45);
            this.trkQRX.TabIndex = 8;
            this.trkQRX.TickFrequency = 5;
            this.trkQRX.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trkQRX.Scroll += new System.EventHandler(this.trk_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(63, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Text Y";
            // 
            // trkTextY
            // 
            this.trkTextY.Location = new System.Drawing.Point(144, 151);
            this.trkTextY.Maximum = 300;
            this.trkTextY.Name = "trkTextY";
            this.trkTextY.Size = new System.Drawing.Size(299, 45);
            this.trkTextY.TabIndex = 6;
            this.trkTextY.TickFrequency = 5;
            this.trkTextY.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trkTextY.Scroll += new System.EventHandler(this.trk_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Text X ";
            // 
            // trkTextX
            // 
            this.trkTextX.Location = new System.Drawing.Point(144, 99);
            this.trkTextX.Maximum = 300;
            this.trkTextX.Name = "trkTextX";
            this.trkTextX.Size = new System.Drawing.Size(299, 45);
            this.trkTextX.TabIndex = 4;
            this.trkTextX.TickFrequency = 5;
            this.trkTextX.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trkTextX.Scroll += new System.EventHandler(this.trk_Scroll);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 478);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Stc QR Code Generator";
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.gbOutputType.ResumeLayout(false);
            this.gbOutputType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQRY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQRX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTextY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTextX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkQRY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkQRX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkTextY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkTextX)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtExcel;
        private System.Windows.Forms.RichTextBox boxOutput;
        private System.Windows.Forms.PictureBox picPreview;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TrackBar trkQRY;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar trkQRX;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar trkTextY;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar trkTextX;
        private System.Windows.Forms.NumericUpDown numQRY;
        private System.Windows.Forms.NumericUpDown numQRX;
        private System.Windows.Forms.NumericUpDown numTextY;
        private System.Windows.Forms.NumericUpDown numTextX;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtColName;
        private System.Windows.Forms.GroupBox gbOutputType;
        private System.Windows.Forms.RadioButton rdPDF;
        private System.Windows.Forms.RadioButton rdPNG;
    }
}

