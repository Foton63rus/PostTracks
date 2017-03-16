using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XL = Microsoft.Office.Interop.Excel;

namespace PostTracks.Excel
{
    public static  class ExcelHelper
    {
        private static XL.Application ExcelApp = new XL.Application();
        private static XL.Workbook ExcelWB = loadWorkBook(Params.XLFilePath);
        private static XL.Worksheet ExcelSheet;
        private static XL.Range range;
        private static List<string> LoadedTracks = new List<string>();
        public static List<string> getTrackNumsList()
        {
            return LoadedTracks;
        }
        public static Microsoft.Office.Interop.Excel.Application GetExcelApplication()
        {
            return ExcelApp;
        }
        public static Microsoft.Office.Interop.Excel.Workbook GetExcelWorkBook()
        {
            return ExcelWB;
        }
        private static Microsoft.Office.Interop.Excel.Workbook loadWorkBook(string path)
        {
            try
            {
                ExcelWB = ExcelApp.Workbooks.Open(path, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                loadTrackList();
                return ExcelWB;
            }
            catch
            {
                return null;
            }
        }
        public static void loadTrackList()
        {
            ExcelSheet = (XL.Worksheet)ExcelWB.Sheets[Params.XL_Tab_TrackList];
            // можно будет сделать автоопределение столбца с треками по названию колонки
            range = ExcelSheet.Range["B2"];
            if (String.IsNullOrEmpty(range.Value) || String.IsNullOrWhiteSpace(range.Value))
            {
                range = ExcelSheet.Range["B2"]; // пустая ячейка
            }
            else
            {
                int i = range.End[Microsoft.Office.Interop.Excel.XlDirection.xlDown].Row;
                range = ExcelSheet.Range["B2:B" + i.ToString()];
                //range.Select();
                foreach (var ws in range)
                {
                    string Track = ((XL.Range)ws).Value.ToString();
                    Track = Track.Trim().ToUpper();
                    LoadedTracks.Add(Track);
                }
            }
        }
        private static void Write(IExcelWriter xlwriter)
        {
            xlwriter.write();
        }
        private static void Load(IExcelReader xlreader)
        {
            xlreader.read();
        }
        public static void ReadTrackCodes()
        {
            ExcelTrackReader.read(ExcelWB);
        }
        public static void ExcelAppQuit()
        {
            if (ExcelApp != null) ExcelApp.Quit();
        }
    }
}
