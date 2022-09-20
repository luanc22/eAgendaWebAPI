using eAgenda.Aplicacao.ModuloTarefa;
using eAgenda.Dominio.ModuloTarefa;
using eAgenda.Infra.Configs;
using eAgenda.Infra.Orm;
using eAgenda.Infra.Orm.ModuloTarefa;
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

        public TarefasController()
        {
            var config = new ConfiguracaoAplicacaoeAgenda();

            var eAgendaDbContext = new eAgendaDbContext(config.ConnectionStrings);
            var repositorioTarefa = new RepositorioTarefaOrm(eAgendaDbContext);
            servicoTarefa = new ServicoTarefa(repositorioTarefa, eAgendaDbContext);
        }

        [HttpGet]
        public List<Tarefa> SelecionarTodos()
        {     
            var tarefaResult = servicoTarefa.SelecionarTodos(StatusTarefaEnum.Todos);

            if (tarefaResult.IsSuccess)
                return tarefaResult.Value;

            return null;
        }

        [HttpGet("{id:guid}")]
        public Tarefa SelecionarPorId(Guid id)
        {
            var tarefaResult = servicoTarefa.SelecionarPorId(id);

            if (tarefaResult.IsSuccess)
                return tarefaResult.Value;

            return null;
        }

        [HttpPost]
        public Tarefa Inserir(Tarefa novaTarefa)
        {
            var tarefaResult = servicoTarefa.Inserir(novaTarefa);

            if (tarefaResult.IsSuccess)
                return tarefaResult.Value;

            return null;
        }

        [HttpPut("{id:guid}")]
        public Tarefa Editar(Guid id, Tarefa tarefa)
        {
            var tarefaEditada = servicoTarefa.SelecionarPorId(id).Value;

            tarefaEditada.Titulo = tarefa.Titulo;
            tarefaEditada.Prioridade = tarefa.Prioridade;

            var tarefaResult = servicoTarefa.Editar(tarefaEditada);

            if (tarefaResult.IsSuccess)
                return tarefaResult.Value;

            return null;
        }

        [HttpDelete("{id:guid}")]
        public void Excluir(Guid id)
        {
           servicoTarefa.Excluir(id);
        }
    }
}
