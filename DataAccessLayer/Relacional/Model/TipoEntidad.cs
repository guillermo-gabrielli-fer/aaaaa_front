//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccessLayer.Relacional.Model
{
    using System;
    using System.Collections.Generic;
    
    public abstract partial class TipoEntidad
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TipoEntidad()
        {
            this.EntidadRecursoCostos = new HashSet<EntidadRecursoCostos>();
        }
    
        public string Nombre { get; set; }
        public int Id { get; set; }
        public Nullable<int> Vida { get; set; }
        public Nullable<int> Ataque { get; set; }
        public Nullable<int> Defensa { get; set; }
        public string Imagen { get; set; }
        public Nullable<int> TiempoConstruccion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EntidadRecursoCostos> EntidadRecursoCostos { get; set; }
    }
}