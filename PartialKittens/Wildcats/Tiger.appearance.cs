using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartialKittens
{
    public partial class Tiger : IStripedWildCat
    {
        public string AverageStripeWidth { get; set; }
        public int NumberOfBlackStripes { get; set; }
        public int NumberOfWhiteStripes { get; set; }
    }
}
