using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace PostTracks
{
    public partial class Form1 : Form
    {
        ExcelIO xl = ExcelIO.getInstance();
        public Form1()
        {
            //https://www.aftership.com/docs/api/4/overview
            // TRACK24
            //'error' : 'TooManyRequests' 

            InitializeComponent();

            //Tracker_track24.getSingleTrackInfo("RB166350968SG"); //"RF499423428CN"
            //excel = ExcelIO.getInstance();
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Tracker_track24.getSingleTrackInfo(textBox1.Text);
            richTextBox1.Text = Tracker_track24.getTrackJSON(textBox1.Text);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(xl != null) { xl.ExcelAppQuit(); }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadTrackListInfo(xl);
        }
        private void loadTrackListInfo(ExcelIO _excel)
        {
            Tracker_track24.getManyTrackInfo(_excel.LoadedTracks);
            _excel.track24dataToExcel();
        }
    }
}
