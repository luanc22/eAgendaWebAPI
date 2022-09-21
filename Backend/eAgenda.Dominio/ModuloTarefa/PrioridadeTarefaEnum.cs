using System.ComponentModel;

namespace eAgenda.Dominio.ModuloTarefa
{
    public enum PrioridadeTarefaEnum : int
    {
        [Description("Baixa")]
        Baixa = 0,

        [Description("Normal")]
        Normal = 1,

        [Description("Alta")]
        Alta = 2
    }
}