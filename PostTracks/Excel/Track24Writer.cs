using System;
using System.Collections.Generic;
using System.Linq;
using XL = Microsoft.Office.Interop.Excel;

namespace PostTracks.Excel
{
    class Track24Writer : IExcelWriter
    {
        private XL.Application ExcelApp;
        private XL.Workbook ExcelWB;
        public Track24Writer()
        {
            ExcelApp = ExcelHelper.GetExcelApplication();
            ExcelWB = ExcelHelper.GetExcelWorkBook();
        }
        
        public void write()
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
    }
}
