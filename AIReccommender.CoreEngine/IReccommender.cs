﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIReccommender.CoreEngine
{
    public interface IReccommender
    {
        double GetCorelation(int[] BaseData, int[] OtherData);
    }
}