using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PostTracks
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Params.initParams(args);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
    static class Params
    {
        private static string _XLFilePath = System.IO.Directory.GetCurrentDirectory() + @"\Tracks.xlsx";
        public static string XLFilePath
        {
            get
            {
                return _XLFilePath;
            }
            set
            {
                _XLFilePath = value;
            }
        }
        public static readonly string XL_Tab_TrackList = "Список";
        internal static void initParams(string[] args)
        {
            boolArgs.Add("json", false);
            foreach (string arg in args)
            {
                if (arg == "+json") { boolArgs["json"] = true; }
            }
            boolArgs.Add("BOOL_TRACKLIST_LOADED", false);
        }
        internal static Dictionary<string, bool> boolArgs = new Dictionary<string, bool>() { };
        static Dictionary<string, int> intArgs = new Dictionary<string, int>() { };
        /// <summary>
        /// Параметр отвечающий за необходимость сохранения json ответов от треккодов
        /// в отдельную папку
        /// <value>bool</value>
        /// </summary>
        public static bool JSON_SAVING => boolArgs["json"];
        /// <summary>
        /// Переменная для окна загрузка
        /// true - окно закроется
        /// <value>bool</value>
        /// </summary>
        public static bool BOOL_TRACKLIST_LOADED => boolArgs["BOOL_TRACKLIST_LOADED"];
    }// Class Params
}
