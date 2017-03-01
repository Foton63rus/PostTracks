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
        ExcelIO excel;
        public Form1()
        {
            //https://www.aftership.com/docs/api/4/overview
            // TRACK24
            //'error' : 'TooManyRequests'
            //В данный момент, стандартный лимит : 
            //10 запросов / сек (600 запросов / мин), 
            //1000 трек-кодов в сутки (на аккаунт / домен)
            //трек-код в формате AZ#########AZ

            InitializeComponent();
            //Tracker_track24.getSingleTrackInfo("RB166350968SG");

            excel = new ExcelIO("");
            Tracker_track24.getManyTrackInfo(excel.LoadedTracks);
            excel.track24dataToExcel();

            //
            //excel.postDataToExcel( (IPostTrackInfo) );
            //excel.ExcelAppQuit();
            //Track24 tr24 = new Track24("RF499423428CN"); //RB166350968SG

            //MessageBox.Show(tr24.ToString());
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            richTextBox1.Text = new Track24(textBox1.Text).ToString();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(excel != null) { excel.ExcelAppQuit(); }
        }
    }
}
