﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCAD.Core.Maths;

namespace OpenCAD.Core.Shapes
{
    public class Cube
    {
        public Vect3 Position { get; private set; }
        public double Size { get; private set; }
        public Cube(Vect3 position, double size)
        {
            Position = position;
            Size = size;
        }
    }
}
