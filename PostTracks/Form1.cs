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
    public partial class Form1 : Form
    {
        public Form1()
        {
            //'error' : 'TooManyRequests'
            //В данный момент, стандартный лимит : 
            //10 запросов / сек (600 запросов / мин), 
            //1000 трек-кодов в сутки (на аккаунт / домен)
            //трек-код в формате AZ#########AZ

            InitializeComponent();
            Track24 tr24 = new Track24("RF499423428CN"); //RB166350968SG

            MessageBox.Show(tr24.ToString());
        }
    }
    
}