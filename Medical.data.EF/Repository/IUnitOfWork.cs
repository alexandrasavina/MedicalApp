using Medical.data.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Medical.data.EF.Repository
{
    interface IUnitOfWork
    {
        IRepository<PatientDbModel> PatientRepository { get; } 
        IRepository<ContactDbModel> ContactRepository { get; }
        IRepository<UserDbModel> UserRepository { get; }
        IRepository<RoleDbModel> RoleRepository { get; }
        IRepository<SpecializeDbModel> SpecializeRepository { get; }
        void Commit();
    }
}
