using System;
using System.Data.Entity.Migrations;
using SC.Model.Entity;

namespace SC.Test.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<SC.Model.StorageDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        /// <inheritdoc />
        /// <summary>
        ///  This method will be called after migrating to the latest version.
        /// </summary>
        /// <param name="context"></param>
        protected override void Seed(SC.Model.StorageDbContext context)
        {

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            var scanners = new Scanner[]
            {
                new Scanner {Id = 1,Name = "Scanner1"},
                //new Scanner {Id = 2, Name = "LG"},
                //new Scanner {Id = 3, Name = "GT"},
                //new Scanner {Id = 4, Name = "RM"},
                //new Scanner {Id = 5, Name = "MT"},
                //new Scanner {Id = 6, Name = "IY"},
                //new Scanner {Id = 7, Name = "PR"},
                //new Scanner {Id = 8, Name = "WI"},
                //new Scanner {Id = 9, Name = "QP"},
                //new Scanner {Id = 10, Name = "CB"}
            };
            context.Scanners.AddOrUpdate(a => a.Id, scanners);
            context.SaveChanges();

            //foreach (var scanner in scanners)
            //{
            //    var tuples = new DataTuple[]
            //    {
            //        new DataTuple  {  ScannerId = scanner.Id, Date = DateTime.Now.AddDays(1)},
            //        new DataTuple  {  ScannerId = scanner.Id, Date = DateTime.Now.AddDays(2)},
            //        new DataTuple  {  ScannerId = scanner.Id, Date = DateTime.Now.AddDays(3)},
            //    };
            //    context.Tuples.AddRange(tuples);
            //    context.SaveChanges();

            //    foreach (var tuple in tuples)
            //    {
            //        var items = new TupleItem[1800];
            //        for (var i = 0; i < items.Length; i++)
            //        {
            //            items[i] = new TupleItem
            //            {
            //                TupleId = tuple.Id,
            //                Name = "Tuple#" + i,
            //                Distance = 1.0 + i,
            //                XAxis = i,
            //                YAxis = i
            //            };
            //        }

            //        context.Items.AddRange(items);
            //        context.SaveChanges();
            //    }
            //}

        }
    }
}
