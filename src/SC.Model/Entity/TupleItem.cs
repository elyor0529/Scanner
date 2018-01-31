using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SC.Model.Entity
{
    public class TupleItem : AuditableEntity<long>
    {

        public string Name { get; set; }

        public int Distance { get; set; }

        public int XAxis { get; set; }

        public int YAxis { get; set; }

        [ForeignKey("Tuple")]
        public long TupleId { get; set; }

        public virtual DataTuple Tuple { get; set; }

    }
}
