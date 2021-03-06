﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;

namespace PostTracks
{
    public sealed class ExcelIO //Singleton
    {
        //IPostTrackInfo
        private ExcelIO() { loadWorkBook();  }
        private static ExcelIO instance = new ExcelIO();
        public static ExcelIO getInstance()
        {
            return instance;
        }
        internal Excel.Application ExcelApp;
        internal Excel.Workbook ExcelWB;
        internal Excel.Worksheet ExcelSheet;
        Excel.Range range;
        List<string> str_CurrentTrackInfo = new List<string>();
        string path { get; set; }
        public List<string> LoadedTracks = new List<string>();
        private void loadWorkBook()
        {
            try
            {
                path = System.IO.Directory.GetCurrentDirectory() + @"\Tracks.xlsx";
                ExcelApp = new Excel.Application();
                ExcelWB = ExcelApp.Workbooks.Open(path, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                ExcelSheet = (Excel.Worksheet)ExcelWB.Sheets["Список"];
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
                        string Track = ((Excel.Range)ws).Value.ToString();
                        Track = Track.Trim().ToUpper();
                        LoadedTracks.Add(Track);
                    }
                }
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
            }
        }
        public void track24dataToExcel()
        {
            Dictionary<string, Dictionary<string, string>> tmpDict = Tracker_track24.getTrackInfoDictionary();
            ExcelWB.Sheets["Track24"].Activate();
            ExcelWB.Sheets["Track24"].Select();
            int i = 0;
            foreach (string key in tmpDict.Keys)
            {
                i++;
                ExcelWB.Sheets["Track24"].Cells[i + 1, 1].Value = (i).ToString();
                ExcelWB.Sheets["Track24"].Cells[i + 1, 2].Value = key;
                ExcelWB.Sheets["Track24"].Cells[i + 1, 3].Value = tmpDict[key]["operationAttribute"];
                ExcelWB.Sheets["Track24"].Cells[i + 1, 4].Value = tmpDict[key]["operationPlaceName"];
                ExcelWB.Sheets["Track24"].Cells[i + 1, 5].Value = tmpDict[key]["eventDateTime"];
                ExcelWB.Sheets["Track24"].Cells[i + 1, 6].Value = tmpDict[key]["itemWeight"];
                ExcelWB.Sheets["Track24"].Cells[i + 1, 7].Value = tmpDict[key]["groupedCompanyNames"];
            }
            ExcelApp.Visible = true;
        }
        public void ExcelAppQuit() {
            if (ExcelApp != null) ExcelApp.Quit();
        }
    }
}
