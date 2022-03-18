using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using SalesWebMvc.Models.ViewModels;
using SalesWebMvc.Services;
using SalesWebMvc.Services.Exceptions;
using System.Collections.Generic;

namespace SalesWebMvc.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;
        private readonly DepartamentService _departamentService;

        public SellersController(SellerService sellerService, DepartamentService departamentService)
        {
            _sellerService = sellerService;
            _departamentService = departamentService;
        }

        public IActionResult Index()
        {
            return View(_sellerService.FindAll());
        }

        public IActionResult Create()
        {
            var departaments = _departamentService.FindAll();
            var viewModel = new SellerFormViewModel
            {
                Departaments = departaments
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
            _sellerService.Insert(seller);

            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _sellerService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seller = _sellerService.FindById(id.Value);
            if (seller == null)
            {
                return NotFound();
            }

            return View(seller);
        }

        public IActionResult Details(int? id)
        {
            return View(_sellerService.FindById(id.Value));
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seller = _sellerService.FindById(id.Value);
            if (seller == null)
            {
                return NotFound();
            }

            List<Departament> departaments = _departamentService.FindAll();
            _sellerService.Update(seller);

            var sellerFormViewModel = new SellerFormViewModel
            {
                Departaments = departaments,
                Seller = seller
            };

            return View(sellerFormViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id, Seller seller)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (id != seller.Id)
            {
                return BadRequest();
            }

            try
            {
                _sellerService.Update(seller);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch(DbConcurrencyException)
            {
                return BadRequest();
            }

        }
    }
}
