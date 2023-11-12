using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DAL.Model
{
    public class PlayerRankingData
    {
        public int Occurances { get; set; }
        public int Goals { get; set; }
        public int YellowCards { get; set; }
    }
}
