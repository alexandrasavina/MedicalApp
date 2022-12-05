using Medical.data.EF.Models;
using MedicalWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalWeb.Extensions
{
    public static class PatientExtension
    {
        public static PatientViewModel ToViewModel(this PatientDbModel model)
        {
            return new PatientViewModel()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Address = model.Address,
                City = model.City,
                Gender = model.Gender,
                PassportNumber = model.PassportNumber,
                DateIssuePassport = model.DateIssuePassport,
                PlaceIssuePassport = model.PlaceIssuePassport,
                DateTimeRigist = model.DateTimeRigist,
                Contacts = model.Contacts == null ? new List<ContactDbModel>() : model.Contacts
            };
        }

        public static PatientDbModel ToDbModel(this PatientViewModel model)
        {
            return new PatientDbModel()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Address = model.Address,
                City = model.City,
                Gender = model.Gender,
                PassportNumber = model.PassportNumber,
                DateIssuePassport = model.DateIssuePassport,
                PlaceIssuePassport = model.PlaceIssuePassport,
                DateTimeRigist = model.DateTimeRigist,
                Contacts = model.Contacts
            };
        }
    }
}
