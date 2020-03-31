using AgendaVoluntaria.Api.Models.Interfaces;
using AgendaVoluntaria.Api.Services.Interfaces;
using AgendaVoluntaria.Api.Utils.Interfaces;
using AgendaVoluntaria.Api.Views.Core;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgendaVoluntaria.Api.Controllers.Core
{
    public class CoreCrudController<TService, TEntityRequest, TEntityResponse, TEntity> : CoreController
        where TEntityRequest : BaseRequest
        where TEntityResponse : BaseResponse
        where TService : ICoreCrudService<TEntity>
        where TEntity : ICoreModel
    {
        private readonly TService _service;
        private readonly IMapper _mapper;
        public CoreCrudController(INotifier notifier, IMapper mapper, TService service) : base(notifier)
        {
            _service = service;
            _mapper = mapper;
        }
        /// <summary> 
        /// Cadastra uma nova entidade
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpPost]
        public virtual async Task<ActionResult<TEntityResponse>> Post(TEntityRequest entityViewModel)
        {
            if (!ModelState.IsValid) return CustomBadRequest(ModelState);
            var entity = _mapper.Map<TEntity>(entityViewModel);
            await _service.CreateAsync(entity);
            return CustomResponse("Entidade Cadastrada com Sucesso", _mapper.Map<TEntityResponse>(entity));
        }

        [HttpGet]
        public virtual async Task<ActionResult<List<TEntityResponse>>> GetAllAsync()
        {
            var registros = await _service.GetAllAsync();
            var result = _mapper.Map<List<TEntityResponse>>(registros);
            return CustomResponse("Registros encontrados!", result);
        }

        /// <summary>
        /// Lista os parametros de acordo o codigo passado
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id:guid}")]
        public virtual async Task<ActionResult<TEntityResponse>> GetByIdAsync(Guid id)
        {
            if (!ModelState.IsValid) return CustomBadRequest(ModelState);
            var resultado = await _service.GetByIdAsync(id);
            return CustomResponse("Registros encontrados!", _mapper.Map<TEntityResponse>(resultado));
        }

        /// <summary>
        /// Atualiza os dados de acordo com os parametros passados
        /// </summary>
        /// <returns></returns>
        [HttpPut("{id:guid}")]
        public virtual async Task<ActionResult<TEntityResponse>> Put([FromRoute]Guid id, [FromBody]TEntityRequest request)
        {
            if (!ModelState.IsValid) return CustomBadRequest(ModelState);
            var entity = _mapper.Map<TEntity>(request);
            entity.Id = id;
            return CustomResponse("Registro Atualizado com Sucesso!", await _service.UpdateAsync(entity));
        }

        /// <summary>
        /// Remove o registro da base de dados
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id:guid}")]
        public virtual async Task<ActionResult> Delete(Guid id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _service.DeleteAsync(id);
            return CustomResponse("Registro deletado!", null); ;
        }
    }
}
