using System;
using System.Collections.Generic;

namespace DL
{
    public partial class Pais
    {
        public Pais()
        {
            Estados = new HashSet<Estado>();
        }

        public int IdPais { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Estado> Estados { get; set; }
    }
}
