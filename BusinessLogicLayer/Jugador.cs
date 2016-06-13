﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Entities;
using Newtonsoft.Json;

namespace BusinessLogicLayer
{
    public class Jugador
    {
        public string Id { get; set; }
        public string Clan { get; set; }
        public Dictionary<int,ConjuntoUnidades> Unidades { get; set; } = new Dictionary<int, ConjuntoUnidades>();
        public List<Edificio> Edificios { get; set; } = new List<Edificio>();
        private Dictionary<int, CantidadRecurso> Recursos { get; set; }  // clave Recurso.ID
        public Dictionary<int, TipoEntidad> tipos = new Dictionary<int, TipoEntidad>();

        public void Inicializar(Shared.Entities.Juego juego)
        {
            foreach(var entidad in juego.TipoEntidad)
            {
                this.tipos.Add(entidad.Id, entidad);
            }
            foreach(var recurso in juego.TipoRecurso)
            {
                this.Recursos.Add(recurso.Id,new CantidadRecurso() { acumulado = 0, porSegundo = 0 });
            }
        }

        public void CargarDesdeJuego(Juego jj)
        {
            foreach (var e in jj.TipoEdificios)
            {
                tipos [e.Id] = e;
            }
            foreach (var e in jj.TipoUnidades)
            {
                tipos[e.Id] = e;
            }
        }

        public void CargarEdificios(Tablero miBase)
        {
            var ocupadas = miBase.Celdas.Where(c => c.IdTipoEdificio.HasValue && c.IdTipoEdificio >= 0);
            foreach(TableroCelda tc in ocupadas)
            {
                TipoEdificio te = tipos.GetValueOrDefault(tc.IdTipoEdificio.Value) as TipoEdificio;
                if (te != null)
                {
                    Edificio e = new Edificio();
                    e.DesdeTipo(te);
                    e.jugador = this.Id;
                    e.posX = tc.PosColumna.Value * e.sizeX;
                    e.posY = tc.PosFila.Value * e.sizeY;
                }
            }
        }


        public Jugador()
        {
            // TODO: falta inicializar para cada recurso
            Recursos = new Dictionary<int, CantidadRecurso>();


        }

        public String GenerarJson(bool incluirEdificios,bool incluirRecursos)
        {
            InfoJugador copia = new InfoJugador();
            copia.Id = this.Id;
            copia.Clan = this.Clan;
            copia.Unidades = new List<ConjuntoUnidades>(this.Unidades.Values);
            if (incluirEdificios)
            {
                copia.Edificios = this.Edificios;
            }
            if (incluirRecursos)
            {
                copia.Recursos = this.Recursos;
            }
            string json  =JsonConvert.SerializeObject(copia);
            return json;
        }

        public void AgregarUnidad(int tipoId)
        {
            if (!Unidades.ContainsKey(tipoId))
            {
                Unidades.Add(tipoId, new ConjuntoUnidades() { UnidadId = tipoId, Cantidad = 1 });
            }
            else
            {
                Unidades[tipoId].Cantidad += 1;
            }
        }

    }


    public class InfoJugador
    {
        public string Id { get; set; }
        public string Clan { get; set; }
        public List< ConjuntoUnidades> Unidades { get; set; } = new List<ConjuntoUnidades>();
        public List<Edificio> Edificios { get; set; } = new List<Edificio>();
        public Dictionary<int, CantidadRecurso> Recursos { get; set; }  // clave Recurso.ID
    }




}

