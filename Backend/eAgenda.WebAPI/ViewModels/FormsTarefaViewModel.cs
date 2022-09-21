using eAgenda.Dominio.ModuloTarefa;
using System.Collections.Generic;

namespace eAgenda.WebAPI.ViewModels
{
    public class FormsTarefaViewModel
    {
        public string Titulo { get; set; }

        public PrioridadeTarefaEnum Prioridade { get; set; }

        public List<FormsItemTarefaViewModel> Itens { get; set; }
    }

    public class InserirTarefaViewModel : FormsTarefaViewModel
    {

    }

    public class EditarTarefaViewModel : FormsTarefaViewModel
    {

    }
}
