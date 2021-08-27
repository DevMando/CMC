using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.IO;
using Newtonsoft.Json;

namespace CMC.Models
{
    public class CoinMarket
    {
       
        public Payload cryptoData;

        public CoinMarket() { }
       
        public void ApiCall()
        {
            var URL = new UriBuilder("https://coinranking1.p.rapidapi.com/coins");
            var queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString["x-rapidapi-key"] = "5c5a12cde5msh58a7f7754bbdc31p10baf5jsn45bba28ab00";
            URL.Query = queryString.ToString();
            var client = new WebClient();
            client.Headers.Add("x-rapidapi-host", "coinranking1.p.rapidapi.com");
            client.Headers.Add("x-rapidapi-key", "5c5a12cde5msh58a7f7754bbdc31p10baf5jsn45bba28ab004"); // API KEY (SANDBOX) - It is okay to expose.

            cryptoData = new Payload(JsonConvert.DeserializeObject(client.DownloadString(URL.ToString())));
        }
    }

    public class Status
    {
        DateTime timestamp { set; get; }
        int error_code { get; set; }
        string error_message { get; set; }
        int elapsted { get; set; }
        int credit_count { get; set; }
        string notice { get; set; }
        int total_count { get; set; }
    }

    public class Payload
    {
        dynamic data;
        public Payload(dynamic t_data)
        {
            data = t_data;
        }

        public dynamic getData()
        {
            return data;
        }
    }

}
