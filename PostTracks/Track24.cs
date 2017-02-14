using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostTracks
{
    public class Track24
    {
        private string apiKey = "67a4ca1f23eff5627683b9c142db69de";
        private string domain = "excel.vba.demo";
        Random rnd = new Random();
        public string getTrackCodeInfo(string currentTrackCode, string apiKey, string domain)
        {
            string cUrl = @"https://track24.ru/api/tracking.json.php?apiKey=" + apiKey + "&domain=" + domain + "&code=" + currentTrackCode + "&rnd=" + rnd.Next(10000,99999).ToString();
            return "Track24.getTrackCodeInfo() _  return";
        }
    }
}
