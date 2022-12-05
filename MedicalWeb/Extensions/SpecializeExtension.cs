using Medical.data.EF.Models;
using MedicalWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalWeb.Extensions
{
    public static class SpecializeExtension
    {
        public static SpecializeDbModel ToDbModel(this SpecializeViewModel model)
        {
            return new SpecializeDbModel
            {
                Id = model.Id,
                Name = model.Name
            };
        }

        public static SpecializeViewModel ToViewModel(this SpecializeDbModel model)
        {
            return new SpecializeViewModel
            {
                Id = model.Id,
                Name = model.Name
            };
        }
    }
}
