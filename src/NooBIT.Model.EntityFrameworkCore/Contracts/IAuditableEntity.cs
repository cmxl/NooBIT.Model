using System;
using System.ComponentModel.DataAnnotations.Schema;
using NooBIT.Model.Entities;

namespace NooBIT.Model.Contracts
{
    public interface IAuditableEntity : IEntity
    {
        [Column(TypeName = "datetime2")]
        DateTime CreatedDateUtc { get; set; }

        string CreatedBy { get; set; }

        [Column(TypeName = "datetime2")]
        DateTime UpdatedDateUtc { get; set; }

        string UpdatedBy { get; set; }
    }
}