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
        private static string API_KEY = "b54bcf4d-1bca-4e8e-9a24-22ff2c3d462c"; // API KEY is okay if exposed - Sandbox.
        const string API_DOMAIN = "https://sandbox-api.coinmarketcap.com";
        public Payload cmcData;

        public CoinMarket() { }
       
        public void ApiCall()
        {
            const string API_KEY_HEADER_VALUE = "X-CMC_PRO_API_KEY";
            string endpoint = $"{API_DOMAIN}/v1/cryptocurrency/listings/latest";

            var URL = new UriBuilder($"{API_DOMAIN}/v1/cryptocurrency/listings/latest");

            var queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString["start"] = "1";
            queryString["limit"] = "5000";
            queryString["convert"] = "USD";
            queryString["sort"] = "market_cap";
            queryString["sort_dir"] = "desc";

            URL.Query = queryString.ToString();

            var client = new WebClient();
            client.Headers.Add(API_KEY_HEADER_VALUE, API_KEY);
            client.Headers.Add("Accepts", "application/json");
            cmcData= JsonConvert.DeserializeObject<Payload>(client.DownloadString(URL.ToString()));
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
        public Status status;
        public Coin[] data;
        public int pages = 0;

        public void calculatePages()
        {
            pages = (data.Count() / 20) + (data.Count()%20 == 0 ? 0 : 1);
        }
    }

}
