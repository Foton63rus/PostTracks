using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace PostTracks
{
    class AliAutoLoginer
    {
        /// <summary>
        /// Класс для автоматического входа на Ali с разных логинов (когда их несколько)
        /// Необходимо добавить выгрузку трек кодов по всем товарам
        /// </summary>

        //OpenQA.Selenium.Chrome.ChromeOptions co = new OpenQA.Selenium.Chrome.ChromeOptions();
        //co.AddArgument(@"user-data-dir=C:\Users\PC\AppData\Local\Google\Chrome\User Data");
        //WB = new OpenQA.Selenium.Chrome.ChromeDriver(co);
        private static IWebDriver WB;
        public static string URL_AliStartPage => "https://ru.aliexpress.com";
        public static string URL_AliHomePage => "https://home.aliexpress.com/index.htm";
        public static string URL_AliLoginPage => "https://login.aliexpress.com/?flag=1&return_url=http%3A%2F%2Fhome.aliexpress.com%2Findex.htm%3Fspm%3D2114.11020108.1000002.6.UUq7GF%26tracelog%3Dws_topbar";
        public static string URL_AliLogoutPage => "https://login.aliexpress.com/xman/xlogout.htm?return_url=https%3A%2F%2Fhome.aliexpress.com%2Findex.htm";
        public AliAutoLoginer()
        {
            if (WB == null) WB = new OpenQA.Selenium.Chrome.ChromeDriver();
            WB.Manage().Window.Maximize();
        }
        ~AliAutoLoginer()
        {
            Quit();
        }
        /// <summary>
        /// Закрывает браузер Google Chrome
        /// </summary>
        public void Quit()
        {
            WB.Quit();
        }
        /// <summary>
        /// автоматический вход на али
        /// </summary>
        /// <param name="login"></param>
        /// <param name="pass"></param>
        public void login(string login, string pass)
        {
            WB.Navigate().GoToUrl(URL_AliLoginPage);
            IWebElement frame_login = WB.FindElement(By.TagName("iframe"));
            WB.SwitchTo().Frame(frame_login);
            IWebElement txt_login = WB.FindElement(By.Name("loginId"));
            txt_login.SendKeys(login);
            IWebElement txt_pass = WB.FindElement(By.Name("password"));
            txt_pass.SendKeys(pass);
            txt_pass.SendKeys(OpenQA.Selenium.Keys.Return);
        }
        /// <summary>
        /// Закрытие окна приветсвия после удачного логина
        /// </summary>
        public void closeBoxAfterLogin()
        {
            IWebElement btnBoxClose = WB.FindElement(By.ClassName("ui-window-close"));
            btnBoxClose.Click();
        }
        /// <summary>
        /// Открыть домашнюю страницу и закрыть окно приветствия
        /// </summary>
        public void openHomePage()
        {
            WB.Navigate().GoToUrl(URL_AliHomePage);
            if (WB.FindElement(By.ClassName("ui-window-close")) != null ) closeBoxAfterLogin();
        }
        /// <summary>
        /// Закрыть текущую учетную запись
        /// </summary>
        public void logout()
        {
            WB.Navigate().GoToUrl(URL_AliLogoutPage);
        }
    }
}
