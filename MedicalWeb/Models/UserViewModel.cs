using Medical.data.EF.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalWeb.Models
{
    public class UserViewModel
    {
        public long Id;

        [Required(ErrorMessage = "Поле не должно быть пустым")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым")]
        public string Password { get; set; }


        public string Name { get; set; }
        public DateTime Age { get; set; }
        public string Gender { get; set; }

        //public List<SpecialtyDbModel> Specialties { get; set; }

        public RoleDbModel Role { get; set; }
    }
}
