using System;
using System.Collections.Generic;
using System.Text;

namespace Medical.data.EF.Models
{
    public class SpecializeDbModel : IEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public List<UserSpecialize> UserSpecializes { get; set; }
        public SpecializeDbModel()
        {
            UserSpecializes = new List<UserSpecialize>();
        }
    }
}
