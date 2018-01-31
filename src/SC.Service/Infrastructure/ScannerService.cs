using System;
using System.Globalization;
using System.IO;
using SC.Common.Extensions;
using SC.Model.Entity;
using SC.Repository;
using SC.Repository.Infrastructure;

namespace SC.Service.Infrastructure
{
    public class ScannerService : EntityService<Scanner>, IScannerService
    {
        private readonly IScannerRepository _repository;

        public ScannerService(IUnitOfWork unitOfWork, IScannerRepository repository)
            : base(unitOfWork, repository)
        {
            _repository = repository;
        }

        public void Import(long id, string file)
        {
            var ent = _repository.GetById(id);

            if (ent == null)
                throw new NullReferenceException("Entry is null");

            if (!File.Exists(file))
                throw new FileNotFoundException("Log file not found");

            //iterate lines
            var lines = File.ReadLines(file);

            //read lines
            var bulkSize = 10;
            var counter = 0;
            foreach (var line in lines)
            {
                var values = line.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                DateTime dt;

                if (!DateTime.TryParseExact(values[0], "yyyy-MM-dd hh:mm:ss:fff", null, DateTimeStyles.None, out dt))
                    continue;

                var tuple = new DataTuple
                {
                    Date = dt,
                    ScannerId = id
                };

                var position = 0;
                for (var row = 1; row < values.Length - 1; row++)
                {
                    position++;

                    //x,y and distance size
                    if (position == 3)
                    {
                        tuple.Items.Add(new TupleItem
                        {
                            XAxis = values[row - 2].ToType<int>(),
                            YAxis = values[row - 1].ToType<int>(),
                            Distance = values[row].ToType<int>()
                        });

                        position = 0;
                    }
                }
                ent.Tuples.Add(tuple);

                counter++;

                if (counter == bulkSize)
                {
                    _repository.Edit(ent);
                    _repository.Save();

                    counter = 0;
                }
            }

            if (counter > 0)
            {
                _repository.Edit(ent);
                _repository.Save();
            }

        }

    }
}
