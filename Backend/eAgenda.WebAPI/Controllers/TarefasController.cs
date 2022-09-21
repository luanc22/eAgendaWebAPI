using AutoMapper;
using eAgenda.Aplicacao.ModuloTarefa;
using eAgenda.Dominio.Compartilhado;
using eAgenda.Dominio.ModuloTarefa;
using eAgenda.Infra.Configs;
using eAgenda.Infra.Orm;
using eAgenda.Infra.Orm.ModuloTarefa;
using eAgenda.WebAPI.AutoMapperConfig;
using eAgenda.WebAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace eAgenda.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        private readonly ServicoTarefa servicoTarefa;
        private IMapper mapeadorTarefas;

        public TarefasController()
        {
            var config = new ConfiguracaoAplicacaoeAgenda();

            var eAgendaDbContext = new eAgendaDbContext(config.ConnectionStrings);
            var repositorioTarefa = new RepositorioTarefaOrm(eAgendaDbContext);
            servicoTarefa = new ServicoTarefa(repositorioTarefa, eAgendaDbContext);

            var autoMapperConfig = new MapperConfiguration(config =>
            {
                config.AddProfile<TarefaProfile>();
            });

            mapeadorTarefas = autoMapperConfig.CreateMapper();
        }

        [HttpGet]
        public List<ListarTarefaViewModel> SelecionarTodos()
        {     
            var tarefaResult = servicoTarefa.SelecionarTodos(StatusTarefaEnum.Todos);

            if (tarefaResult.IsSuccess)
            {
                return mapeadorTarefas.Map<List<ListarTarefaViewModel>>(tarefaResult.Value);             
            }

            return null;
        }

        [HttpGet("visualiacao-completa/{id:guid}")]
        public VisualizarTarefaViewModel SelecionarPorId(Guid id)
        {
            var tarefaResult = servicoTarefa.SelecionarPorId(id);

            if (tarefaResult.IsSuccess)
            {
                return mapeadorTarefas.Map<VisualizarTarefaViewModel>(tarefaResult.Value);
            }
            
            return null;
        }

        [HttpPost]
        public FormsTarefaViewModel Inserir(InserirTarefaViewModel novaTarefaVM)
        {
            var tarefa = mapeadorTarefas.Map<Tarefa>(novaTarefaVM);

            var tarefaResult = servicoTarefa.Inserir(tarefa);

            if (tarefaResult.IsSuccess)
            {
                return novaTarefaVM;
            }

            return null;
        }

        [HttpPut("{id:guid}")]
        public FormsTarefaViewModel Editar(Guid id, EditarTarefaViewModel tarefaVM)
        {
            var tarefaSelecionada = servicoTarefa.SelecionarPorId(id).Value;

            var tarefa = mapeadorTarefas.Map(tarefaVM, tarefaSelecionada);

            var tarefaResult = servicoTarefa.Editar(tarefa);

            if (tarefaResult.IsSuccess)
                return tarefaVM;

            return null;
        }

        [HttpDelete("{id:guid}")]
        public void Excluir(Guid id)
        {
           servicoTarefa.Excluir(id);
        }
    }
}
