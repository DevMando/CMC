using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMC.Models
{
    public class USD
    {
        float price { set; get; }
        float volume_24h { set; get; }
        float percent_change_1h { set; get; }
        float percent_change_24h { set; get; }
        float perecnt_change_7d { set; get; }
        DateTime last_update { set; get; }
    }
}
