using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SC.Model.Entity
{
    public class Scanner : AuditableEntity<long>
    {

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public virtual ICollection<DataTuple> Tuples { get; set; }

        public Scanner()
        {
            Tuples = new HashSet<DataTuple>();
        }
    }
}
