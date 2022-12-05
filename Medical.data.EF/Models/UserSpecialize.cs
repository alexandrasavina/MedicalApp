using System;
using System.Collections.Generic;
using System.Text;

namespace Medical.data.EF.Models
{
    public class UserSpecialize : IEntity
    {
        public long Id { get; set; }

        public long UserId { get; set; } 
        public UserDbModel User { get; set; }

        public long SpecializeId { get; set; }
        public SpecializeDbModel Specialize { get; set; }
    }
}
