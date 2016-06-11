﻿using DataAccessLayer;
using EpPathFinding;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.Redis;
using Microsoft.AspNet.SignalR.Client.Hubs;
using System.ServiceModel;
using Shared.Entities;

namespace BusinessLogicLayer
{
    public class BLJuego : IBLJuego
    {
        private IDALJuego _dal;

        private Dictionary<int, Juego> cacheJuegos = new Dictionary<int, Juego>();

        public BLJuego(IDALJuego dal)
        {
            _dal = dal;
        }

        public Juego GetAllDataJuego(int idJuego)
        {
            if (cacheJuegos.ContainsKey(idJuego)){
                return cacheJuegos[idJuego]; // retorno de memoria
            }
            var res = _dal.GetJuego(idJuego);
            cacheJuegos[idJuego] = res;
            return res;
        }


    }
}
