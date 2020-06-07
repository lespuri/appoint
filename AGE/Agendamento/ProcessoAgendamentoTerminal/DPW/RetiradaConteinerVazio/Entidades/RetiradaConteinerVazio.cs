using AGE.Agendamento.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGE.Agendamento.DPW.Entidades
{
    public class RetiradaConteinerVazio 
    {
        public enum eStatus
        {
            [Description("Aguardando Agendamento")]
            AguardandoAgendamento = 0,
            [Description("Agendado")]
            Agendado = 1,
            [Description("Booking não encontrado")]
            ErroBookingNaoEncontrado = 2,
            [Description("Elemento não encontrado")]
            ErroElementoNaoEncontrado = 3,
            [Description("Motorista não encontrado")]
            ErroMotoristaNaoEncontrado = 4,
            [Description("Janela Indisponível")]
            ErroJanelaIndisponivel = 5
        }

        public int RetiradaConteinerVazioId { get; set; }
        public string CodigoControle { get; set; }
        public DateTime DataHora { get; set; }
        public int QuantidadeConteiner { get; set; }
        public string Tipo { get; set; }
        public string Classificacao { get; set; }
        public string Reserva { get; set; }
        public string Navio { get; set; }
        public string ExportadorNome {get; set; }
        public string ExportadorCNPJ { get; set; }
        public string PlacaVeiculo { get; set; }
        public string CPFMotorista { get; set; }
        public int Status { get; set; }
    }
}
