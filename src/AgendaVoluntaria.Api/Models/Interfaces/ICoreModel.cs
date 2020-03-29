using System;

namespace AgendaVoluntaria.Api.Models.Interfaces
{
    public interface ICoreModel
    {
        Guid Id { get; set; }
        DateTime CreateAt { get; set; }
        DateTime UpdateAt { get; set; }
    }
}
