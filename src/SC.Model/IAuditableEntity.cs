using System;

namespace SC.Model
{
    public interface IAuditableEntity
    {

        DateTime AddedDate { get; set; }

        DateTime? ModifiedDate { get; set; }

        bool IsDeleted { get; set; }
    }
}
