using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartialKittens
{
    public abstract class Felidae
    {
        public abstract string Classification { get; }
        public virtual void Stalk() { }
    }

    public abstract class HouseCat : Felidae
    {
        public override string Classification
        {
            get
            {
                return "Felis catus";
            }
        }

        public virtual string Meow()
        {
            return "Meowww....";
        }

        public virtual string Purr()
        {
            return "Purr...";
        }
    }

    public abstract class WildCat : Felidae
    {
        public virtual string Roar()
        {
            return "ROARRRR!!!...";
        }

        public virtual IucnCode ConservationStatus { get { return IucnCode.LeastConcern; } }
    }
}
