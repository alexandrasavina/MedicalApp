// <auto-generated />
using Medical.data.EF;
using Medical.data.EF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Medical.data.EF.Migrations
{
    [DbContext(typeof(EfUnitOfWork))]
    [Migration("20180212101639_contacts")]
    partial class contacts
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Medical.data.EF.Models.Contact", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("PatientId");

                    b.Property<string>("Phone");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("Medical.data.EF.Models.Patient", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("City");

                    b.Property<DateTime>("DateIssuePassport");

                    b.Property<DateTime>("DateTimeRigist");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("Gender");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("PassportNumber")
                        .IsRequired();

                    b.Property<string>("PlaceIssuePassport")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("Medical.data.EF.Models.Contact", b =>
                {
                    b.HasOne("Medical.data.EF.Models.Patient", "Patient")
                        .WithMany("Contacts")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
