using System;
using XL = Microsoft.Office.Interop.Excel;

namespace PostTracks.Excel
{
    static class ExcelTrackReader
    {
        //private static 
        private static XL.Worksheet ExcelSheet;
        private static XL.Range range;
        public static void read(Microsoft.Office.Interop.Excel.Workbook ExcelWB)
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
                    ExcelHelper.getTrackNumsList().Add(Track);
                }
            }
        }
    }
}
