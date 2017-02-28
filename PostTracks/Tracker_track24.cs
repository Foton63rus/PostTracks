using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.IO;
using System.Windows.Forms;
using System.Text;
using Newtonsoft.Json;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace PostTracks
{
    public static class Tracker_track24
    {
        //'error' : 'TooManyRequests'
        //В данный момент, стандартный лимит : 
        //10 запросов / сек (600 запросов / мин), 1000 трек-кодов в сутки (на аккаунт / домен)
        //трек-код в формате AZ#########AZ
        private static string apiKey = "67a4ca1f23eff5627683b9c142db69de";
        private static string domain = "excel.vba.demo";
        private static Dictionary<string, Dictionary<string, string>> TrackCodeInfoDictionary = new Dictionary<string, Dictionary<string, string>>();
        private static Dictionary<string, string> jsonResponses = new Dictionary<string, string>();
        public static string getTrackJSON(string track)
        {
            return jsonResponses.ContainsKey(track) ? jsonResponses[track] : "json not exist";
        }
        public static void getSingleTrackInfo(string TrackCode)
        {
            //отправляем get запрос на track24.ru
            string cUrl = @"https://track24.ru/api/tracking.json.php?apiKey=" + apiKey + "&domain=" + domain + "&code=" + TrackCode.ToUpper() + "&rnd=" + (new Random()).Next(10000, 99999).ToString();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(cUrl);
            request.Method = "GET";
            request.Accept = "application/json";
            //пытаемся получить json ответ в новом потоке
            try
            {
                //Task t = Task.Run( () => {
                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    {
                        using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                        {
                            StringBuilder json_sb = (new StringBuilder()).Append(reader.ReadToEnd());
                            string json = json_sb.ToString();
                            if (jsonResponses.ContainsKey(TrackCode))
                            {
                                jsonResponses[TrackCode] = json;
                            }
                            else
                            {
                                jsonResponses.Add(TrackCode, json);
                            }
                            //parsing
                            JObject jObject = JObject.Parse(json);
                            Dictionary<string, string> tmpDict = new Dictionary<string, string>();
                            tmpDict.Add("operationAttribute", jObject["data"]["lastPoint"]["operationAttribute"].ToString());
                            tmpDict.Add("operationPlaceName", jObject["data"]["lastPoint"]["operationPlaceName"].ToString());
                            tmpDict.Add("eventDateTime", jObject["data"]["lastPoint"]["eventDateTime"].ToString());
                            tmpDict.Add("destinationCountry", jObject["data"]["destinationCountry"].ToString());
                            tmpDict.Add("trackCodeModified", jObject["data"]["trackCodeModified"].ToString());
                            tmpDict.Add("trackDeliveredDateTime", jObject["data"]["trackDeliveredDateTime"].ToString());
                            tmpDict.Add("itemWeight", jObject["data"]["lastPoint"]["itemWeight"].ToString());
                            tmpDict.Add("groupedCompanyNames", jObject["data"]["groupedCompanyNames"][0].ToString());

                            if (!TrackCodeInfoDictionary.ContainsKey(TrackCode)) TrackCodeInfoDictionary.Add(TrackCode, new Dictionary<string, string>());
                            TrackCodeInfoDictionary[TrackCode] = tmpDict;
                        }
                    }
                //});
                //t.Wait();
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message);
            }
        }// \public static void getSingleTrackInfo(string TrackCode)
        public static Dictionary<string, Dictionary<string, string>> getManyTrackInfo(List<string> trackList)
        {
            foreach (string track in trackList)
            {
                getSingleTrackInfo(track);

                Thread.Sleep(100); //ограничение 10 треков в сек
            }
            return TrackCodeInfoDictionary;
        }
        public static Dictionary<string, Dictionary<string, string>> getTrackInfoDictionary()
        {// для передачи всей инфы по трекам в эксель без обновления информации о трек-кодах
            return TrackCodeInfoDictionary;
        }

    }

}
