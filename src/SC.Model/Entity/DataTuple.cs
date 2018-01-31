using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SC.Model.Entity
{
    public class DataTuple : AuditableEntity<long>
    {

        public DateTime Date { get; set; }

        public byte[] Buffer { get; set; }

        [ForeignKey("Scanner")]
        public long ScannerId { get; set; }

        public virtual Scanner Scanner { get; set; }

        public virtual ICollection<TupleItem> Items { get; set; }

        public DataTuple()
        {
            Items = new HashSet<TupleItem>();
        }

    }
}
