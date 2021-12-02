using CommonServiceLocator;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MVCSingleton.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCSingleton.Business
{
  public  class MySingletonService
    {
        private static int creationCount = 0;

        private static readonly MySingletonService _mySingletonServiceInstance = new MySingletonService();



        //private static readonly string _connectionString = ServiceLocator.Current.GetInstance<IConfiguration>().GetConnectionString("DefaultConnection"); // or conn.string
        private static readonly string _connectionString = ServiceLocator.Current.GetInstance<IConfiguration>().GetConnectionString("DefaultConnection"); // or conn.string
        private static readonly ApplicationDbContext _dbContext = new ApplicationDbContext(new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer(_connectionString).Options);
        //private static readonly IDictionary<int, string> departments = _dbContext.Departments.ToDictionary(p => p.DepartmentId, p => p.Name);

        public string texto1 = "";
        public string texto2 = "";
        public string texto3 = "";


        // se pone privada para que no se pueda usar externamente
        private MySingletonService()
        {

            var listLabels = _dbContext.Labels.ToList();

            texto1 = listLabels.Where(d => d.Id == 1).First().Text;
            texto2 = listLabels.Where(d => d.Id == 2).First().Text;
            texto3 = listLabels.Where(d => d.Id == 3).First().Text;

            creationCount++;
        }

        public static MySingletonService GetInstance() => _mySingletonServiceInstance;

        public int GetCreationCount() => creationCount;
    }


}
