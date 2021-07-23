using InventoryLibrary.Core.Entities;
using System.Collections;

namespace InventoryLibrary.Core.Interface
{
    public interface IRepository
    {
        IEnumerable GetallLibros();
        Autores GetAutorLibr(int id);
        Editoriale GetEditorial(int id);
    }
}
