﻿using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Entities;

namespace DataAccessLayer
{
    public interface IDALTablero
    {
        void JugarUnidad(Shared.Entities.InfoCelda infoCelda);
    }
}