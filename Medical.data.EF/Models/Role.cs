using System;
using System.Collections.Generic;
using System.Text;

namespace Medical.data.EF.Models
{
    public class RoleDbModel : IEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<UserDbModel> Users { get; set; }
        public RoleDbModel()
        {
            Users = new List<UserDbModel>();
        }
    }
}
