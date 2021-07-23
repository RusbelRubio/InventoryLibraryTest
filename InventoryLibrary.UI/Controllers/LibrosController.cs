using InventoryLibrary.Core.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventoryLibrary.Controllers
{
    [Authorize]
    public class LibrosController : Controller
    {
        private readonly IBussinesLibrary _BussinesLibrary;
        public LibrosController(IBussinesLibrary bussinesLibrary)
        {
            _BussinesLibrary = bussinesLibrary;
        }
        public IActionResult BookList()
        {
            return View(_BussinesLibrary.GetExistenciasLibros());
        }
    }
}
