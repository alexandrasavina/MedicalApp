using Medical.data.EF.Models;
using Medical.data.EF.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Medical.data.EF
{
    public class EfUnitOfWork : DbContext , IUnitOfWork

    {
        private readonly EfRepository<PatientDbModel> _patientRepo;
        private readonly EfRepository<ContactDbModel> _contactRepo;
        private readonly EfRepository<UserDbModel> _userRepo;
        private readonly EfRepository<RoleDbModel> _roleRepo;
        private readonly EfRepository<SpecializeDbModel> _specialRepo;


        public DbSet<PatientDbModel> Patients { get; set; }
        public DbSet<ContactDbModel> Contacts { get; set; }
        public DbSet<UserDbModel> Users { get; set; }
        public DbSet<RoleDbModel> Roles { get; set; }
        public DbSet<SpecializeDbModel> Specializes { get; set; }

        public EfUnitOfWork() : base()
        {
            _patientRepo = new EfRepository<PatientDbModel>(Patients);
            _contactRepo = new EfRepository<ContactDbModel>(Contacts);
            _userRepo = new EfRepository<UserDbModel>(Users);
            _roleRepo = new EfRepository<RoleDbModel>(Roles);
           // _specialRepo = new EfRepository<SpecialtyDbModel>(Specialties);
        }

        public EfUnitOfWork(DbContextOptions<DbContext> options) : base(options)
        {
            _patientRepo = new EfRepository<PatientDbModel>(Patients);
            _contactRepo = new EfRepository<ContactDbModel>(Contacts);
            _userRepo = new EfRepository<UserDbModel>(Users);
            _roleRepo = new EfRepository<RoleDbModel>(Roles);
            //_specialRepo = new EfRepository<SpecialtyDbModel>(Specialties);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserSpecialize>()
                .HasKey(t => new { t.UserId, t.SpecializeId });

            modelBuilder.Entity<UserSpecialize>()
                .HasOne(us => us.User)
                .WithMany(t => t.UserSpecializes)
                .HasForeignKey(us => us.UserId);

            modelBuilder.Entity<UserSpecialize>()
                .HasOne(us => us.Specialize)
                .WithMany(t => t.UserSpecializes)
                .HasForeignKey(us => us.SpecializeId);
        }

        IRepository<PatientDbModel> IUnitOfWork.PatientRepository
        {
            get { return _patientRepo;  }
        }

        IRepository<ContactDbModel> IUnitOfWork.ContactRepository
        {
            get { return _contactRepo; }
        }

        IRepository<UserDbModel> IUnitOfWork.UserRepository
        {
            get { return _userRepo; }
        }

        IRepository<RoleDbModel> IUnitOfWork.RoleRepository
        {
            get { return _roleRepo; }
        }

        IRepository<SpecializeDbModel> IUnitOfWork.SpecializeRepository
        {
            get { return _specialRepo; }
        }

        public object Specialize { get; set; }

        void IUnitOfWork.Commit()
        {
            throw new NotImplementedException();
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=medicaldb;Trusted_Connection=True;MultipleActiveResultSets=true;");
            }
            base.OnConfiguring(optionsBuilder);
        }


    }
}
