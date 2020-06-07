using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGE.Agendamento.Entidades
{
    public abstract class ProcessoAgendamento
    {
        public int ProcessoAgendamentoId { get; set; }
        public string CodigoControle { get; set; }
        public DateTime DataHora { get; set; }
    }
}
