using Medical.data.EF.Models;
using MedicalWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalWeb.Extensions
{
    public static class ContactExtension
    {
        public static ContactDbModel ToViewModel(this ContactViewModel model)
        {
            return new ContactDbModel()
            {
                Id = model.Id,
                PatientId = model.PatientId,
                Patient = model.Patient,
                Phone = model.Phone    
            };
        }

        public static ContactViewModel ToDbModel(this ContactDbModel model)
        {
            return new ContactViewModel()
            {
                Id = model.Id,
                PatientId = model.PatientId,
                Patient = model.Patient,
                Phone = model.Phone
            };
        }
    }
}
