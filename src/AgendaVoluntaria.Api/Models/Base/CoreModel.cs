using AgendaVoluntaria.Api.Models.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace AgendaVoluntaria.Api.Models.Core
{
    public class CoreModel : ICoreModel
    {
        protected CoreModel()
        {
            Id = Guid.NewGuid();
        }
        [Key]
        public Guid Id { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
