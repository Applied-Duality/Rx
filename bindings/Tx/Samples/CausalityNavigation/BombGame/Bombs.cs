using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BombActor
{
    interface IBomb
    {
         
    }

    class TimeBomb : IBomb
    {
        public DateTime Target { get; set; }
    }
}
