using System;
using System.Collections;
using System.Collections.Generic;
using InventoryLibrary.Core.Entities;
using InventoryLibrary.Core.Interface;
using InventoryLibrary.Infrastructure.Data;
using System.Linq;

namespace InventoryLibrary.Infrastructure.Repositories
{
    public class BaseRepository : IRepository
    {
        private readonly EvaluationForDeveloperContext _context;

        public BaseRepository(EvaluationForDeveloperContext context)
        {
            _context = context;
        }

        public IEnumerable GetallLibros()
        {
          return _context.Libros.AsEnumerable();
        }

        public Autores GetAutorLibr(int id)
        {
            throw new NotImplementedException();
        }

        public Editoriale GetEditorial(int id)
        {
            throw new NotImplementedException();
        }
    }
}
