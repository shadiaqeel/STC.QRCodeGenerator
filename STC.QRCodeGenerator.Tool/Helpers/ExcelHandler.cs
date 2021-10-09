using System;
using System.Collections.Generic;

using Excel = Microsoft.Office.Interop.Excel;

namespace STC.QRCodeGenerator.Tool.Helpers
{
    class ExcelHandler : IDisposable
    {
        private Logger logger { get; set; }

        private Excel.Application xlApp { get; set; }
        private Excel.Workbook xlWorkbook { get; set; }
        private Excel.Worksheet xlWorksheet { get; set; }
        private Excel.Range xRange { get; set; }


        public int RowCount { get; set; }
        public int ColCount { get; set; }

        public ExcelHandler(Logger logger, string filePath)
        {
            this.logger = logger;


            //Create COM Objects. Create a COM object for everything that is referenced
            xlApp = new Excel.Application();
            if (xlApp == null) throw new Exception("Failed to create a COM object");
            xlWorkbook = xlApp.Workbooks.Open(filePath);
            xlWorksheet = (Excel.Worksheet)xlWorkbook.Worksheets[1];
            xRange = xlWorksheet.UsedRange;

            RowCount = xRange.Rows.Count - 1;
            ColCount = xRange.Columns.Count;
        }
        public string[] Read(string columnName, int pageNumber, int pageSize , out bool IsExistCol)
        {
            var list = new List<string>();

            IsExistCol = false;

            try
            {
                var offset = ((pageNumber - 1) * pageSize) + 2;
                var toRow = offset + pageSize -1;

                //iterate over the rows and columns and print to the console as it appears in the file
                //excel is not zero based!!
                for (int col = 1; col <= ColCount; col++)
                {
                    if (GetCell(xRange, col, 1).Trim().Equals(columnName,StringComparison.OrdinalIgnoreCase))
                    {
                        IsExistCol = true;
                        for (int row = offset; row <= toRow && row <= RowCount + 1; row++)
                        {
                            var cell = GetCell(xRange, col, row);
                            if (!string.IsNullOrEmpty(cell))
                                list.Add(cell);

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
                //logger.WriteLog(ex.Message + Environment.NewLine + ex.StackTrace);
            }

            return list.ToArray();

        }


        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally
            {
                obj = null;
                GC.Collect();
            }
        }

        private string GetCell(Excel.Range xRange, int col, int row)
        {
            //write the value to the console
            if (xRange.Cells[row, col] != null)
                return (xRange.Cells[row, col] as Excel.Range).Value2.ToString();
            else
                return string.Empty;
        }

        public void Dispose()
        {
            //cleanup
            GC.Collect();
            GC.WaitForPendingFinalizers();

            //rule of thumb for releasing com objects:
            //  never use two dots, all COM objects must be referenced and released individually
            //  ex: [somthing].[something].[something] is bad

            //release com objects to fully kill excel process from running in the background

            xlWorkbook.Close(false, null, null);
            xlApp.Quit();

            releaseObject(xRange);
            releaseObject(xlWorksheet);
            releaseObject(xlApp);
        }
    }
}
