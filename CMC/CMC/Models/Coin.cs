using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMC.Models
{
    public class Coin
    {
        public int id { set; get; }
        public string name { set; get; }
        public string symbol { set; get; }
        public string slug { set; get; }
        public int num_market_pairs { set; get; }
        public DateTime date_added { set; get; }
        public string[] tags { set; get; }
        public Nullable<float> max_supply { set; get; }
        public Nullable<float> circulating_supply { set; get; }
        public int cmc_rank { set; get; }
        public DateTime last_updated { set; get; }

        public USD quote {get;set;}


    }

}
