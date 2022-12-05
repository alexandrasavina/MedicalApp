using Medical.data.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalWeb.Models
{
    public class SpecializeViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public UserDbModel User { get; set; }
    }
}
