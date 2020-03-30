using AgendaVoluntaria.Api.Models.Interfaces;
using MassTransit;
using System;
using System.ComponentModel.DataAnnotations;

namespace AgendaVoluntaria.Api.Models.Core
{
    public class CoreModel : ICoreModel
    {
        protected CoreModel()
        {
            Id = NewId.NextGuid();
        }
        [Key]
        public Guid Id { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
