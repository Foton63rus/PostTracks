using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.IO;
using System.Windows.Forms;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace PostTracks
{
    public class Track24
    {
        //'error' : 'TooManyRequests'
        //В данный момент, стандартный лимит : 
        //10 запросов / сек (600 запросов / мин), 
        //1000 трек-кодов в сутки (на аккаунт / домен)
        //трек-код в формате AZ#########AZ
        private string apiKey = "67a4ca1f23eff5627683b9c142db69de";
        private string domain = "excel.vba.demo";
        private string TrackCode = "";
        Random rnd = new Random();
        string json;
        string operationAttribute { get; set; } = "";
        string operationPlaceName { get; set; } = "";
        string eventDateTime { get; set; } = "";
        string destinationCountry { get; set; } = "";
        string trackCodeModified { get; set; } = "";
        string trackDeliveredDateTime { get; set; } = "";
        string itemWeight { get; set; } = "";
        string groupedCompanyNames { get; set; } = "";

        //string fromCountry { get; set; } = "";

        public override string ToString()
        {
            string NEW_LINE = Environment.NewLine;
            return operationAttribute + NEW_LINE + operationPlaceName + NEW_LINE + eventDateTime + NEW_LINE + destinationCountry + NEW_LINE + trackCodeModified + NEW_LINE + trackDeliveredDateTime + NEW_LINE + itemWeight + NEW_LINE + groupedCompanyNames;
        }
        public Track24(string currentTrackCode)
        {
            TrackCode = currentTrackCode;
            string cUrl = @"https://track24.ru/api/tracking.json.php?apiKey=" + apiKey + "&domain=" + domain + "&code=" + currentTrackCode.ToUpper() + "&rnd=" + rnd.Next(10000, 99999).ToString();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(cUrl);
            request.Method = "GET";
            request.Accept = "application/json";
            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        StringBuilder json_sb = new StringBuilder();
                        json_sb.Append(reader.ReadToEnd());
                        json = json_sb.ToString();
                        Clipboard.SetText(json);
                        JObject jObject = JObject.Parse(json);

                        operationAttribute      = jObject["data"]["lastPoint"]["operationAttribute"].ToString();
                        operationPlaceName      = jObject["data"]["lastPoint"]["operationPlaceName"].ToString();
                        eventDateTime           = jObject["data"]["lastPoint"]["eventDateTime"].ToString();
                        destinationCountry      = jObject["data"]["destinationCountry"].ToString();
                        trackCodeModified       = jObject["data"]["trackCodeModified"].ToString();
                        trackDeliveredDateTime  = jObject["data"]["trackDeliveredDateTime"].ToString();
                        itemWeight              = jObject["data"]["lastPoint"]["itemWeight"].ToString();
                        groupedCompanyNames     = jObject["data"]["groupedCompanyNames"][0].ToString();

                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + 
                                Environment.NewLine +
                                " class Track24 => Ошибка создания объекта "+
                                Environment.NewLine +
                                " Возможные причины => неверный запрос трека, глючный парсинг json ответа с сервера, нашествие инопланетян");
            }

        }

    }

}
