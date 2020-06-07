using AGE.Agendamento.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGE.Agendamento.DPW.Entidades
{
    public class RetiradaConteinerVazioLog
    {
        public int RetiradaConteinerVazioLogId { get; set; }
        public int RetiradaConteinerVazioId { get; set; }
        public DateTime DataHora { get; set; }
        public string Menssagem { get; set; }
    }
}
