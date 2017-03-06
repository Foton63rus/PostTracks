using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PostTracks
{
    /// <summary>
    /// Всплывающее окно загрузки приложения
    /// </summary>
    public partial class frmLoading : Form
    {
        Timer timer = new Timer();
        public frmLoading()
        {
            InitializeComponent();
            timer.Interval = 500;
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        private void checkLoading()
        {
            if (Params.BOOL_TRACKLIST_LOADED)
            {
                this.Close();
                return;
            }else
            {
                timer.Start();
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            checkLoading();
        }
    }
    
}
