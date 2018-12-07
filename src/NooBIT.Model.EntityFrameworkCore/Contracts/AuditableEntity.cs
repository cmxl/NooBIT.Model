using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NooBIT.Model.Entities;

namespace NooBIT.Model.Contracts
{
    public abstract class AuditableEntity<T> : Entity<T>, IAuditableEntity
    {
        [ScaffoldColumn(false)]
        [Column(TypeName = "datetime2")]
        public virtual DateTime CreatedDateUtc { get; set; }

        [MaxLength(256)]
        [ScaffoldColumn(false)]
        public virtual string CreatedBy { get; set; }

        [ScaffoldColumn(false)]
        [Column(TypeName = "datetime2")]
        public virtual DateTime UpdatedDateUtc { get; set; }

        [MaxLength(256)]
        [ScaffoldColumn(false)]
        public virtual string UpdatedBy { get; set; }
    }

    public abstract class AuditableEntity : BaseEntity, IAuditableEntity
    {
        [ScaffoldColumn(false)]
        [Column(TypeName = "datetime2")]
        public virtual DateTime CreatedDateUtc { get; set; }

        [MaxLength(256)]
        [ScaffoldColumn(false)]
        public virtual string CreatedBy { get; set; }

        [ScaffoldColumn(false)]
        [Column(TypeName = "datetime2")]
        public virtual DateTime UpdatedDateUtc { get; set; }

        [MaxLength(256)]
        [ScaffoldColumn(false)]
        public virtual string UpdatedBy { get; set; }
    }
}