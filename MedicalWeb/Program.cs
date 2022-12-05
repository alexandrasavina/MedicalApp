using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Medical.data.EF;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace MedicalWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);

            /* using (var unitOfWork = new EfUnitOfWork())
             {
                 for (int i = 0; i < 10; i++)
                 {
                     Patient patient = new Patient() {

                         FirstName = "PFName" + i,
                         LastName = "PLName" + i,
                         DateTimeRigist = DateTime.Now.AddMonths(i),
                         PassportNumber = "12546" + i,
                         DateIssuePassport = DateTime.Now.AddMonths(i),
                         PlaceIssuePassport = "Place" + i,
                         City = "City" + i,
                         Address = "Address" + i,
                         Gender = Medical.data.EF.Models.Gender.Male
                     };

                     unitOfWork.Patients.Add(patient);
                     unitOfWork.SaveChanges();
                 }
             }
             using (var scope = host.Services.CreateScope())
             {
                 var services = scope.ServiceProvider;
                 try
                 {
                     var context = services.GetRequiredService<EfUnitOfWork>();

                 }
                 catch (Exception ex)
                 {
                     var logger = services.GetRequiredService<ILogger<Program>>();
                     logger.LogError(ex, "An error occurred while seeding the database.");
                 }
             }*/

            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
