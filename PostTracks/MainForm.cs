﻿using System;
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
    public partial class MainForm : Form
    {
        ExcelIO xl = ExcelIO.getInstance();
        AliAutoLoginer myAliAutoLoger;
        frmLoading loading_frame;
        public MainForm()
        {
            //https://www.aftership.com/docs/api/4/overview
            // TRACK24
            //'error' : 'TooManyRequests'  
            InitializeComponent();
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(xl != null) { xl.ExcelAppQuit(); }
            myAliAutoLoger.Quit();
        }
        private void loadTrackListInfo(ExcelIO _excel)
        {
            Tracker_track24.getManyTrackInfo(_excel.LoadedTracks);
            _excel.track24dataToExcel();
        }
        private void btn_web_Click(object sender, EventArgs e)
        {
            if(myAliAutoLoger == null) myAliAutoLoger = new AliAutoLoginer();
            //myAliAutoLoger.login("login", "pass");
        }
        /// <summary>
        /// Вывод информации на richTextBox rtb_TrackInformation на вкладке Track_JSON главного окна
        /// </summary>
        private void DisplayTrackInformation()
        {
            string track = tb_TrackCode.Text;
            Tracker_track24.getSingleTrackInfo(track);
            Dictionary<string, Dictionary<string, string>> TrackCodeInfoDictionary = Tracker_track24.getTrackInfoDictionary();
            string Text = String.Format(
                ">>>>>>>>>> {0} <<<<<<<<<< \n" +
                "===============================================\n" +
                "Статус:    {1}\n" +
                "Место изменения статуса:   {2}\n" +
                "Время изменения статуса:   {3}\n" +
                "Вес посылки:  {4}\n" +
                "Почтовая компания:     {5}\n" +
                "===============================================\n\n" +

                "===JSON========================================\n", 
                tb_TrackCode.Text, 
                TrackCodeInfoDictionary[track]["operationAttribute"],
                TrackCodeInfoDictionary[track]["operationPlaceName"],
                TrackCodeInfoDictionary[track]["eventDateTime"],
                TrackCodeInfoDictionary[track]["itemWeight"],
                TrackCodeInfoDictionary[track]["groupedCompanyNames"]
            );
            rtb_TrackInformation.Text = Text + Tracker_track24.getTrackJSON(tb_TrackCode.Text);
        }
        /// <summary>
        /// Открывает окно загрузки на время прогрузки екселя
        /// </summary>
        private void openLoadingFrame()
        {
            loading_frame = new frmLoading();
            loading_frame.Show();
        }
        /// <summary>
        /// Opening Ali Track Codes numbers grabber Frame
        /// </summary>
        private void btnTrackInfo_Click(object sender, EventArgs e)
        {
            openLoadingFrame();
            loadTrackListInfo(xl);
        }
        private void btn_TrackJSONInformation_Click(object sender, EventArgs e)
        {
            DisplayTrackInformation();
        }
    }
}
