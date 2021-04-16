using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMC.Models
{
    public class USD
    {
        public float price { set; get; }
        public float volume_24h { set; get; }
        public float percent_change_1h { set; get; }
        public float percent_change_24h { set; get; }
        public float perecnt_change_7d { set; get; }
        public DateTime last_update { set; get; }
    }
}
