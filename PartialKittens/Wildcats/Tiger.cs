using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartialKittens
{
    public partial class Tiger : WildCat
    {
        public override string Classification
        {
            get
            {
                return "Panthera Tigris";
            }
        }

        public override IucnCode ConservationStatus
        {
            get
            {
                return IucnCode.Endangered;
            }
        }

        public decimal ExtinctionRatePerDecade { get; set; }


        /*
        partial void Index(IEnumerable<WildCat> loadedRelatives)
        {
            Console.WriteLine("Indexing my tiger cousins...");
        }
        */

    }
}
