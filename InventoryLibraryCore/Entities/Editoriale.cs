using System;
using System.Collections.Generic;

#nullable disable

namespace InventoryLibrary.Core.Entities
{
    public partial class Editoriale
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Sede { get; set; }

        public virtual Libro Libro { get; set; }
    }
}
