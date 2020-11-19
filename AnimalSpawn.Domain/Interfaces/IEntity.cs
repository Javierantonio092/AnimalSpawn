using System;

namespace AnimalSpawn.Domain.Interfaces
{
    public interface IEntity
    {
        int Id { get; set; }
        bool Status { get; set; }
        DateTime? CreateAt { get; set; }
        int? CreatedBy { get; set; }
        DateTime? UpdateAt { get; set; }
        int? UpdatedBy { get; set; }
    }
}
