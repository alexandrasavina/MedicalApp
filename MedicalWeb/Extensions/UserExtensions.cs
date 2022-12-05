using Medical.data.EF.Models;
using MedicalWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalWeb.Extensions
{
    public static class UserExtensions
    {
        public static UserViewModel ToViewModel(this UserDbModel model)
        {
            return new UserViewModel()
            {
                Id = model.Id,
                Name = model.Name,
                Age = model.Age,
                Role = model.Role,
                //Specialties = model.Specialties,
                Login = model.Login,
                Password = model.Password,
                Gender = model.Gender
            };
        }

        public static UserDbModel ToDbModel(this UserViewModel model)
        {
            return new UserDbModel()
            {
                Id = model.Id,
                Name = model.Name,
                Age = model.Age,
                Role = model.Role,
                //Specialties = model.Specialties,
                Login = model.Login,
                Password = model.Password,
                Gender = model.Gender
            };
        }
    }
}
