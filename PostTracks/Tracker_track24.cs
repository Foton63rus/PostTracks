﻿using System;
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
        /// <summary>
        /// GET запрос по одному треккоду на track24.ru
        /// </summary>
        /// <param name="TrackCode"></param>
        public static void getSingleTrackInfo(string TrackCode)
        {
            string cUrl = @"https://track24.ru/api/tracking.json.php?apiKey=" + apiKey + "&domain=" + domain + "&code=" + TrackCode + "&rnd=" + (new Random()).Next(10000, 99999).ToString();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(cUrl);
            request.Method = "GET";
            request.Accept = "application/json";
            try
            {
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
                        JSON_Parsing(TrackCode, json);
                        JSON_Saving(TrackCode, json);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + Environment.NewLine + "Ошибка при загрузке треккода " + TrackCode);
            }
        }// \public static void getSingleTrackInfo(string TrackCode)
        /// <summary>
        /// сохраняем json чисто для лога ( коммандная строка "+json" )
        /// </summary>
        /// <param name="TrackCode"></param>
        /// <param name="json"></param>
        private static void JSON_Saving(string TrackCode, string json)
        {
            string json_directory = System.IO.Directory.GetCurrentDirectory() + @"\json\";
            if (!System.IO.Directory.Exists(json_directory)) System.IO.Directory.CreateDirectory(json_directory);
            if (Params.JSON_SAVING) System.IO.File.WriteAllText(json_directory + TrackCode.ToString() + ".json", json);
        }
        /// <summary>
        /// Парсинг JSON-ответа текущего трек кода
        /// </summary>
        /// <param name="TrackCode"></param>
        /// <param name="json"></param>
        private static void JSON_Parsing(string TrackCode, string json)
        {
            JObject jObject = JObject.Parse(json);
            Dictionary<string, string> tmpDict = new Dictionary<string, string>();
            if (jObject["data"]["lastPoint"].ToString() == "")
            {
                tmpDict.Add("operationAttribute", jObject["data"]["events"][0]["operationAttribute"].ToString() + "; " +
                                                    jObject["data"]["events"][0]["operationType"].ToString());
                tmpDict.Add("operationPlaceName", jObject["data"]["events"][0]["operationPlaceName"].ToString());
                tmpDict.Add("eventDateTime", jObject["data"]["events"][0]["eventDateTime"].ToString());
                tmpDict.Add("itemWeight", jObject["data"]["events"][0]["itemWeight"].ToString());
            }
            else
            {
                tmpDict.Add("operationAttribute", jObject["data"]["lastPoint"]["operationAttribute"].ToString() + "; " +
                                                    jObject["data"]["lastPoint"]["operationType"].ToString());
                tmpDict.Add("operationPlaceName", jObject["data"]["lastPoint"]["operationPlaceName"].ToString());
                tmpDict.Add("eventDateTime", jObject["data"]["lastPoint"]["eventDateTime"].ToString());
                tmpDict.Add("itemWeight", jObject["data"]["lastPoint"]["itemWeight"].ToString());
            }
            tmpDict.Add("groupedCompanyNames", jObject["data"]["groupedCompanyNames"][0].ToString());

            if (!TrackCodeInfoDictionary.ContainsKey(TrackCode)) TrackCodeInfoDictionary.Add(TrackCode, new Dictionary<string, string>());
            TrackCodeInfoDictionary[TrackCode] = tmpDict;
        }
        public static Dictionary<string, Dictionary<string, string>> getManyTrackInfo(List<string> trackList)
        {
            foreach (string track in trackList)
            {
                Task t = Task.Run(() => {
                    getSingleTrackInfo(track);
                });
                t.Wait();
            }
            Params.boolArgs["BOOL_TRACKLIST_LOADED"] = true;
            return TrackCodeInfoDictionary;
        }
        public static Dictionary<string, Dictionary<string, string>> getTrackInfoDictionary()
        {// для передачи всей инфы по трекам в эксель без обновления информации о трек-кодах
            return TrackCodeInfoDictionary;
        }

    }

}
