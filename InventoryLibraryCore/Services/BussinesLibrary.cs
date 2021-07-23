using InventoryLibrary.Core.Entities;
using InventoryLibrary.Core.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace InventoryLibrary.Core.Services
{
    public class BussinesLibrary : IBussinesLibrary
    {
        IRepository _Repo;
        public BussinesLibrary(IRepository repo)
        {
            _Repo = repo;
        }

        public IEnumerable GetExistenciasLibros()
        {
            return _Repo.GetallLibros();
        }
    }
}
