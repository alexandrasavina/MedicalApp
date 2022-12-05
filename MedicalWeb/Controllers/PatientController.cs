using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MedicalWeb.Models;
using Medical.data.EF;
using Medical.data.EF.Models;
using MedicalWeb.Extensions;
using StackExchange.Redis;
using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace MedicalWeb.Controllers
{
    public class PatientController : Controller
    {
        EfUnitOfWork unitOfWork;
        
        public PatientController()
        {
            unitOfWork = new EfUnitOfWork();
        }
        [Authorize]
        public IActionResult List()
        {   

            var viewModel = unitOfWork
                .Patients
                .OrderByDescending(s => s.DateTimeRigist)
                .Take(10).Select(x => x.ToViewModel()).ToList();

            return View(viewModel);
            //return View(User.Identity.Name);
        }
        [Authorize]
        public IActionResult Details(long ID)
        {   
            var dbPatient = unitOfWork.Patients.Include(x => x.Contacts).FirstOrDefault(x => x.Id == ID);
            var model = dbPatient.ToViewModel();
            
            return View(model);
        }
        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            return View(new PatientViewModel());
        }

        [HttpPost]
        public IActionResult Create(PatientViewModel viewModel,  List<string> phone, string email, string relativePhone, string namePhoneOwner,string relation)
        {
            viewModel.DateTimeRigist = DateTime.Now;
            viewModel.DateIssuePassport = DateTime.Now;

            if (ModelState.IsValid)
            {
                var dbModel = viewModel.ToDbModel();
                unitOfWork.Patients.Add(dbModel);
                unitOfWork.SaveChanges();
                foreach (var ph in phone)
                {
                    if (ph != null)
                    {
                        ContactViewModel contactViewMod = new ContactViewModel { PatientId = dbModel.Id, Phone = ph };
                        if (ModelState.IsValid)
                        { 
                            ContactDbModel contactDbMod = contactViewMod.ToViewModel();
                            //ContactDbModel contactDbMod = new ContactDbModel { PatientId = dbModel.Id, Phone = ph };
                            unitOfWork.Contacts.Add(contactDbMod);
                        }
                    }
                }
                if (email != null)
                {
                    ContactViewModel contactViewMod = new ContactViewModel { PatientId = dbModel.Id, Email = email };
                    if (ModelState.IsValid)
                    {
                        ContactDbModel contactDbMod2 = contactViewMod.ToViewModel();
                        unitOfWork.Contacts.Add(contactDbMod2);
                    }
                }
                if (relativePhone != null)
                { 
                    ContactDbModel contactDbMod3 = new ContactDbModel { PatientId = dbModel.Id, Phone = relativePhone, NamePhoneOwner = namePhoneOwner, Relation = relation };
                    unitOfWork.Contacts.Add(contactDbMod3);
                }
                unitOfWork.SaveChanges();
                return RedirectToAction("List");
            }

            return View(viewModel);
        }
        [Authorize]
        public IActionResult Edit(int id)
        {
            PatientDbModel dbModel = unitOfWork.Patients
                .Include(x => x.Contacts)
                .Where(x => x.Id == id)
                .SingleOrDefault();
            PatientViewModel viewModel = dbModel.ToViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(int id, IFormCollection fc) //[Bind (exclude: "DateTimeRigist")]
        {
            PatientViewModel patient = new PatientViewModel();
            patient.Id = id;
            patient.FirstName = fc["FirstName"];
            patient.LastName = fc["LastName"];
            //patient.Contacts.Email = "qwerty";

            ContactViewModel contact = new ContactViewModel();
            contact.PatientId = id;
            contact.Phone = fc["Phone"];
            contact.Email = fc["Email"];

            if (ModelState.IsValid)
            {
                PatientDbModel patientToUpdate = unitOfWork.Patients
                        .Include(x => x.Contacts)
                        .Where(x => x.Id == id)
                        .SingleOrDefault();
                unitOfWork.Entry(patientToUpdate).CurrentValues.SetValues(patient);
                unitOfWork.SaveChanges();
                return RedirectToAction("List");
            }
            return View(patient);
        }
        /*[HttpPost]
        public IActionResult Edit( PatientViewModel updViewModel, List<string> contacts) //[Bind (exclude: "DateTimeRigist")]
        {
            PatientDbModel patientToUpdate = unitOfWork.Patients
                .Include(x => x.Contacts)
                .Where(x => x.Id == updViewModel.Id)
                .SingleOrDefault();

            if (ModelState.IsValid)
            {
                PatientDbModel updDbModel = updViewModel.ToDbModel();
                unitOfWork.Entry(patientToUpdate).State = EntityState.Modified;
                unitOfWork.SaveChanges();
                return RedirectToAction("List");
            }
            return View(patientToUpdate);
        }*/
        [Authorize(Roles = "admin")]
        public IActionResult Delete(int id)
        {
            long ID = id;
            PatientDbModel dbModel = unitOfWork.Patients.Find(ID);
            PatientViewModel viewModel = dbModel.ToViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Delete(PatientViewModel delViewModel)
        {
            var patient = unitOfWork.Patients.Where(x => x.Id == delViewModel.Id).SingleOrDefault();
            if (patient != null)
            {
                unitOfWork.Patients.Remove(patient);
                unitOfWork.SaveChanges();
            }
            return RedirectToAction("List");
        }

    }
}
