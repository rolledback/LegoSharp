﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LegoSharp.PickABrick
{
    public class PickABrickQueryResult
    {
        public IEnumerable<Brick> elements;
        public int total;

        public PickABrickQueryResult(IEnumerable<Brick> elements, int total)
        {
            this.elements = elements;
            this.total = total;
        }
    }
}
