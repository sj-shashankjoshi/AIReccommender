﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIReccommender.DataLoader
{
    internal interface IDataLoader
    {
        BookDetails Load();
    }
}
