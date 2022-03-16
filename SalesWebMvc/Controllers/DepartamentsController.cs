using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using System.Collections.Generic;

namespace SalesWebMvc.Controllers
{
    public class DepartamentsController : Controller
    {
        public IActionResult Index()
        {
            List<Departament> departaments = new List<Departament>();

            departaments.Add(new Departament { Id = 1, Name = "Eletronics" });
            departaments.Add(new Departament { Id = 2, Name = "Fashion" });

            return View(departaments);
        }
    }
}
