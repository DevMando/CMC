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
        const string API_KEY = "b54bcf4d-1bca-4e8e-9a24-22ff2c3d462c"; // API KEY is okay if exposed - Sandbox.
        const string API_DOMAIN = "https://sandbox-api.coinmarketcap.com";
        public Payload cmcData;

        public CoinMarket() { }
       
        public void ApiCall()
        {
            string parameters = "start=1&limit=500&convert=USD";
            string endpoint = API_DOMAIN + "/v1/cryptocurrency/listings/latest";	
            WebRequest request = WebRequest.Create($"{endpoint}?{parameters}");
            request.Headers.Add("X-CMC_PRO_API_KEY", API_KEY);
            request.Headers.Add("Accepts", "application/json");
            request.Credentials = CredentialCache.DefaultCredentials;
            request.Method = "GET";
            
            // Get the response.
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Console.WriteLine(response.StatusDescription);
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            // Cleanup the streams and the response.
            reader.Close();
            dataStream.Close();
            response.Close();

            cmcData = JsonConvert.DeserializeObject<Payload>(responseFromServer);
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
    }

}
