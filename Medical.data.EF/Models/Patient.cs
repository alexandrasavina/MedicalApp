using System;
using System.Collections.Generic;
using Medical.data.EF.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Medical.data.EF.Models
{
    
    public class PatientDbModel : IEntity
    {
        public long Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Gender Gender { get; set; }

        public string PassportNumber { get; set; }

        public DateTime DateIssuePassport { get; set; }

        public string PlaceIssuePassport { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        public DateTime DateTimeRigist { get; set; } 

        public List<ContactDbModel> Contacts { get; set; }
    }
}
