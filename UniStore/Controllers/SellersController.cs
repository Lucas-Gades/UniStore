using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using UniStore.Data;
using UniStore.Models;
using UniStore.Models.ViewModels;

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
            //var sellers = _context.Seller.ToList();
            var sellers = _context.Seller.Include("Department").ToList();
            return View(sellers);
        }

        [HttpGet]
        public IActionResult Create() {
            //Instanciar um SellerFormViewModel
            //Essa instância vai ter 2 propriedades
            //um vendedor e uma lista de departamentos
            var viewModel = new SellerFormViewModel();
            viewModel.Departments = _context.Department.ToList();
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Create(Seller seller) { 
            //Testa se foi passado um objeto Seller
            if (seller == null)
            {
                //Retorna Página não encontrada
                return NotFound();
            }
            //Retorna o primeiro registro de departamento
            //seller.Department = _context.Department.FirstOrDefault();
            //seller.DepartmentId = seller.Department.Id;
            //Adiciona o objeto vendedor (seller) ao banco
            //_context.Seller.Add(seller);
            //Adiciona objeto vendedor ao banco
            _context.Add(seller);
            //Confirma/Persiste as alterações na base de dados
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
