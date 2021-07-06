using Microsoft.AspNetCore.Mvc;
using SalesWebMVC.Models;
using SalesWebMVC.Models.ViewModels;
using SalesWebMVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMVC.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;
        private readonly DepartmentService _departmentService;

        public SellersController(SellerService sellerService, DepartmentService departmentService)
        {
            _sellerService = sellerService;
            _departmentService = departmentService;
        }

        public IActionResult Index() /*IActionResult é o tipo de retorno de todas as ações*/ 
        {
            var list = _sellerService.FindAll();
            return View(list);
        }

        public IActionResult Create() /*IActionResult é o tipo de retorno de todas as ações*/
        {
            var departments = _departmentService.FindAll();
            var viewModel = new SellerFormViewModel { Departments = departments };
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller) /*IActionResult é o tipo de retorno de todas as ações*/
        {
            _sellerService.Insert(seller);
            return RedirectToAction(nameof(Index));
        }

        //Essa é a confirmação, não a ação de deleção propriamente dita
        public IActionResult Delete(int? id) //a interrogação indica que o parametro é opcional
        {
            if(id == null) { return NotFound(); }

            var obj = _sellerService.FindById(id.Value);
            if(obj == null) { return NotFound(); }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _sellerService.Remove(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
