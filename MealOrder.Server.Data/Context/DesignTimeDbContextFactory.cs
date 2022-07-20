//using MealOrder.Server.Data.Context;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Design;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace MealOrder.Server.Data.Context
//{
//    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MealOrderDbContext>
//    {
//        public MealOrderDbContext CreateDbContext(string[] args)
//        {
//            String connectionString = "server=TUNAHANOZCAN;database=MealOrder;integrated security=true;";

//            var builder = new DbContextOptionsBuilder<MealOrderDbContext>();

//            builder.UseSqlServer(connectionString);

//            return new MealOrderDbContext(builder.Options);

//        }
//    }
//}
