using System;

namespace PartialKittens
{
    public partial class Prey
    {
        private int _speed = 0;

        public void Run(byte acceleration, short timeSeconds)
        {
            _speed += (acceleration*timeSeconds);
        }

        partial void LoadPredators()
        {
            Console.Write("Too fast for any predators!");
        }
    }
}