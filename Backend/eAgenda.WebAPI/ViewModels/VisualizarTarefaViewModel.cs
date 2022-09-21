using System;
using System.Collections.Generic;

namespace eAgenda.WebAPI.ViewModels
{
    public class VisualizarTarefaViewModel
    {
        public VisualizarTarefaViewModel()
        {
            Itens = new List<VisualizarItemTarefaViewModel>();
        }

        public string Titulo { get; set; }

        public DateTime DataCriacao { get; set; }

        public int QuantidadeDeItens { get; set; }

        public decimal PercentualConcluido { get; set; }

        public string Prioridade { get; set; }

        public string Situacao { get; set; }

        public List<VisualizarItemTarefaViewModel> Itens { get; set; }
    }
}
