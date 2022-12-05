using Medical.data.EF;
using MedicalWeb.Extensions;
using MedicalWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalWeb.Controllers
{
    public class SpecializeController : Controller
    {
        private EfUnitOfWork _unitOfWork;

        public IActionResult List()
        {
            var special = _unitOfWork
                .Specializes
                .OrderBy(x => x.Name)
                .Select(x => x.ToViewModel())
                .ToList();

            return View(special);
        }

        public IActionResult Create()
        {
            return View(new SpecializeViewModel());
        }
        [HttpPost]
        public IActionResult Create(SpecializeViewModel model)
        {
            _unitOfWork.Specializes.Add(model.ToDbModel());
            _unitOfWork.SaveChanges();

            return View();
        }
    }
}
