using Medical.data.EF.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MedicalWeb.Models
{
    public class PatientViewModel
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "Введите имя")]
        [StringLength(50, ErrorMessage = "Поле не может содержать больше 50-ти символов")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Введите фамилию")]
        [StringLength(50, ErrorMessage = "Поле не может содержать больше 50-ти символов")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public Gender Gender { get; set; }

        [Required(ErrorMessage = "Введите серию и номер паспорта")]
        [RegularExpression(pattern: @"^[A-Z]{2}\d{6}", ErrorMessage = "Неправильно введен номер и/или серия паспорта")]
        [Display(Name = "PassportNumber")]
        public string PassportNumber { get; set; }

        [Required(ErrorMessage = "Введите дату выдачи паспорта")]
        public DateTime DateIssuePassport { get; set; }

        [Required(ErrorMessage = "Введите место выдачи паспорта")]
        public string PlaceIssuePassport { get; set; }

        [Required(ErrorMessage = "Введите город проживания")]
        public string City { get; set; }

        [Required(ErrorMessage = "Введите адрес проживания")]
        public string Address { get; set; }

        public DateTime DateTimeRigist { get; set; }

        public List<ContactDbModel> Contacts { get; set; } 
    }
}
