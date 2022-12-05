using Medical.data.EF.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalWeb.Models
{
    public class ContactViewModel
    {
        public long Id { get; set; }

        public long PatientId { get; set; }

        public PatientDbModel Patient { get; set; }

        [Required(ErrorMessage = "Введите номер телефона")]
        [RegularExpression(pattern: @"\d{12}", ErrorMessage = "Поле должно содержать 12 цифр")]
        public string Phone { get; set; }

        [Required(AllowEmptyStrings = true)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = true)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string NamePhoneOwner { get; set; }

        [Required(AllowEmptyStrings = true)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Relation { get; set; }
    }
}
