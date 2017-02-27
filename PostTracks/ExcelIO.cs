using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;

namespace PostTracks
{
    public class ExcelIO
    {
        //IPostTrackInfo
        internal Excel.Application ExcelApp;
        internal Excel.Workbook ExcelWB;
        internal Excel.Worksheet ExcelSheet;
        Excel.Range range;
        List<string> str_CurrentTrachInfo = new List<string>();
        string path { get; set; }
        public List<string> LoadedTracks = new List<string>();
        private void loadWorkBook(string str_path)
        {
            if (str_path == "")
            {
                path = System.IO.Directory.GetCurrentDirectory() + @"\Tracks.xlsx";
            }
            else
            {
                path = str_path;
            }
            try
            {
                ExcelApp = new Excel.Application();
                ExcelWB = ExcelApp.Workbooks.Open(path, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                ExcelSheet = (Excel.Worksheet)ExcelWB.Sheets["Список"];
                range = ExcelSheet.Range["O2"];
                //Excel.Range Range = ExcelSheet.Range["O2"].Offset[3, 0];
                if (String.IsNullOrEmpty(range.Value) || String.IsNullOrWhiteSpace(range.Value))
                {
                    //range.Select();
                }
                else
                {
                    int i = range.End[Microsoft.Office.Interop.Excel.XlDirection.xlDown].Row;
                    range = ExcelSheet.Range["O2:O" + i.ToString()];
                    //range.Select();
                    foreach (var ws in range)
                    {
                        LoadedTracks.Add(((Excel.Range)ws).Value);
                    }
                }
                ExcelApp.Visible = true;
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
            }
        }
        public void postDataToExcel(IPostTrackInfo postTrackInfo)
        {
            if (LoadedTracks.Count > 0)
            {
                ExcelSheet = (Excel.Worksheet)ExcelWB.Sheets[postTrackInfo.GetType().Name.ToString()];
                ExcelSheet.Activate();

            }
            else
            {
                //MessageBox.Show(""+ postTrackInfo.GetType().Name.ToString());
            }
        }
        public void track24dataToExcel()
        {
            ExcelWB.Sheets["Track24"].Activate();
            
            for (int i = 0; i< LoadedTracks.Count; i++)
            {
                Track24 tr24 = new Track24(LoadedTracks[i]);
                str_CurrentTrachInfo = ((IPostTrackInfo)tr24).getTrackInfoForExcel();
                for (int j = 0; j < str_CurrentTrachInfo.Count; j++)
                {
                    ExcelWB.Sheets["Track24"].Range["B2"].Offset[i, j].Value = str_CurrentTrachInfo[j];
                    //ExcelWB.Sheets["Track24"].Cells[i+2, j+1].Value = str_CurrentTrachInfo[j];

                    //MessageBox.Show(str_CurrentTrachInfo[j]);
                    //MessageBox.Show(str_CurrentTrachInfo[j]);
                }
                    
            }

        }
        public void ExcelAppQuit() {
            if (ExcelApp != null) ExcelApp.Quit();
        }
        public ExcelIO(string str_path)
        {
            loadWorkBook(str_path);
            //postDataToExcel(IPostTrackInfo postTrackInfo);
        }
    }
}
