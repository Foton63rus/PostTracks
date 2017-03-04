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
            ExcelIO ex;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frmLoading());
            Application.Run(new Form1());
            
        }
    }
    static class Params
    {
        internal static void initParams(string[] args)
        {
            boolArgs.Add("json", false);
            foreach (string arg in args)
            {
                if (arg == "+json") { boolArgs["json"] = true; }
            }
        }
        static Dictionary<string, bool> boolArgs = new Dictionary<string, bool>() { };
        public static bool JSON_SAVING
        {
            get
            {
                return boolArgs["json"];
            }
        }
    }
}
