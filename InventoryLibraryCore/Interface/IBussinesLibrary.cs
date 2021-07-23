using InventoryLibrary.Core.Entities;
using System.Collections;

namespace InventoryLibrary.Core.Interface
{
    public interface IBussinesLibrary
    {
        IEnumerable GetExistenciasLibros();
    }
}
