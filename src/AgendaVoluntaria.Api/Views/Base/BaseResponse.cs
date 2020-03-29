using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaVoluntaria.Api.Views.Core
{
    public class BaseResponse
    {
        /// <summary>
        /// Código identificador
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Data de criação do registro
        /// </summary>
        public DateTime CreateAt { get; set; }

        /// <summary>
        /// Data da ultima atualização do registro
        /// </summary>
        public DateTime UpdateAt { get; set; }
    }
}
