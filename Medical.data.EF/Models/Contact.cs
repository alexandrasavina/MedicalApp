using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Medical.data.EF.Models
{
        public class ContactDbModel : IEntity
        {
            public long Id { get; set; }

            public long PatientId { get; set; }

            public PatientDbModel Patient { get; set; }
            
            public string Phone { get; set; }
        
            public string Email { get; set; }

            public string NamePhoneOwner { get; set; }

            public string Relation { get; set; }
    }
}
