﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Shared.Entities
{
    [DataContract]
    public class Juego
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string Imagen { get; set; }
        [DataMember]
        public int Estado { get; set; }
        [DataMember]
        public string Url { get; set; }
        [DataMember]
        public int IdDisenador { get; set; }
        [DataMember]
        public List<Accion> Acciones { get; set; }
        [DataMember]
        public List<Raza> Razas { get; set; }
        [DataMember]
        public List<Tecnologia> Tecnologias { get; set; }
        [DataMember]
        public List<TipoEntidad> TipoEntidad { get; set; }
        [DataMember]
        public List<TipoEdificio> TipoEdificios { get; set; }
        [DataMember]
        public List<TipoUnidad> TipoUnidades { get; set; }
        [DataMember]
        public List<TipoRecurso> TipoRecurso { get; set; }
        [DataMember]
        public Tablero Tablero { get; set; }

        //public ICollection<Accion> accions { get; set; }
        //public ICollection<arbol_tecnologias> arbol_tecnologias { get; set; }
        //public  ICollection<arbol_tecnologias> arbol_tecnologias1 { get; set; }
        //public  ICollection<arbol_tecnologias> arbol_tecnologias2 { get; set; }
        //public  ICollection<Raza> razas { get; set; }
        //public  ICollection<Tecnologia> tecnologias { get; set; }
        //public  ICollection<TipoEntidad> tipo_entidad { get; set; }
        //public  ICollection<TipoRecurso> tipo_recurso { get; set; }

    }
}
