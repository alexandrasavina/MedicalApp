using System;
using System.Collections.Generic;
using System.Text;

namespace Medical.data.EF.Models
{
    public class UserDbModel : IEntity
    {
        public long Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public string Name { get; set; }
        public DateTime Age { get; set; }
        public string Gender { get; set; }

        public List<UserSpecialize> UserSpecializes { get; set; }

        public UserDbModel()
        {
            UserSpecializes = new List<UserSpecialize>();
        }

        public RoleDbModel Role { get; set; }
    }
}
