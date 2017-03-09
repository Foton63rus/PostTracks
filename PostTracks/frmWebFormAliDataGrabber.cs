using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PostTracks
{
    public partial class frmWebFormAliDataGrabber : Form
    {
        string str_login = "login.aliexpress.com/express/mulSiteLogin.htm?return=https%3A%2F%2Fru.aliexpress.com%2Fru_home.htm%3Faff_platform%3Dlink-c-tool%26cpt%3D1486301113777%26sk%3DuR7uBY3Rz%26aff_trace_key%3D85ca5ec7fb5145a3af197994e3cb7c98-1486301113777-00123-uR7uBY3Rz";
        public frmWebFormAliDataGrabber()
        {
            InitializeComponent();
            this.webBrowser1.ScriptErrorsSuppressed = true;
            this.webBrowser1.Navigate(new Uri("https://" + str_login));
        }
        private void Navigate(String address)
        {
            if (String.IsNullOrEmpty(address)) return;
            if (address.Equals("about:blank")) return;
            if (!address.StartsWith("http://") &&
                !address.StartsWith("https://"))
            {
                address = "http://" + address;
            }
            try
            {
                webBrowser1.Navigate( (new Uri(address)) );
            }
            catch (System.UriFormatException)
            {
                return;
            }
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            /*webBrowser1.Document.GetElementById("fm-login-id").InvokeMember("click");
            webBrowser1.Document.GetElementById("fm-login-id").SetAttribute("value", "1");
            webBrowser1.Document.GetElementById("fm-login-password").InvokeMember("Click");
            webBrowser1.Document.GetElementById("fm-login-id").SetAttribute("value", "ololo");
            webBrowser1.Document.GetElementById("fm-login-submit").InvokeMember("Click");*/
            foreach (HtmlElement el in webBrowser1.Document.GetElementsByTagName("fm-text"))
            {
                MessageBox.Show(el.ToString());
            }
            
        }
    }
    public static partial class AliLoger
    {
        
    }
}
