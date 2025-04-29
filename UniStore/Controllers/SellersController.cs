using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using UniStore.Data;
using UniStore.Models;

namespace UniStore.Controllers
{
    public class SellersController : Controller
    {
        public readonly UniStoreContext _context;

        public SellersController(UniStoreContext context) { 
            _context = context;
        }

        /*localhost/Sellers/Index*/
        public IActionResult Index()
        {
            /*List<Seller> sellers = _context.Seller.ToList();*/
            var sellers = _context.Seller.ToList();
            return View(sellers);
        }
    }
}
