﻿using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public interface IBLJuego
    {
        Juego GetAllDataJuego(Int32 idJuego);
    }
}