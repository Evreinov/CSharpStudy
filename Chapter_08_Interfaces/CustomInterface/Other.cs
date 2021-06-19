﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomInterface
{
    class Fork : IPointy
    {
        public byte Points => 123;
    }

    class PitchFork : IPointy
    {
        public byte Points => 222;
    }

    class Knife : IPointy
    {
        public byte Points => 111;
    }
}
