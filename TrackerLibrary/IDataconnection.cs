﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary
{
    public interface IDataconnection
    {
        PrizeModel CreatePrize(PrizeModel model);

    }
}
