using AGE.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AGE.Agendamento.DPW.Entidades;
using System.Collections;
using Newtonsoft.Json;

namespace AGE.Agendamento.ProcessoAgendamentoTerminal.DPW.ConteinerVazio.Exceptions
{
    public class BookingNaoEncontradoException : BusinessException
    {
        private RetiradaConteinerVazioRepositorio aRetiradaConteinerVazioRepositorio;
        private RetiradaConteinerVazio aRetiradaConteinerVazio;
        public BookingNaoEncontradoException(string prMessage, RetiradaConteinerVazio prRetiradaConteinerVazio) 
            : base(new Exception(prMessage))
        {
            aRetiradaConteinerVazioRepositorio = new RetiradaConteinerVazioRepositorio();
            aRetiradaConteinerVazio = prRetiradaConteinerVazio;

            aRetiradaConteinerVazio.Status = (int)RetiradaConteinerVazio.eStatus.ErroBookingNaoEncontrado;
            aRetiradaConteinerVazioRepositorio.Update(aRetiradaConteinerVazio);
            EnviarNotificacao(Notificacao.TipoNotificacao.BussinessException, Notificacao.MeioNotificacao.Email);
            AtualizarStatus();
        }        

        private void AtualizarStatus()
        {
            aRetiradaConteinerVazio.Status = (int)RetiradaConteinerVazio.eStatus.ErroBookingNaoEncontrado;
            aRetiradaConteinerVazioRepositorio.Update(aRetiradaConteinerVazio);
        }

        public override IDictionary Data
        {
            get
            {
                EnviarNotificacaoEmail.ConfiguracaoEmail cm = new EnviarNotificacaoEmail.ConfiguracaoEmail();
                cm.Destinatario = aXmlDoc.SelectSingleNode("//configuration/appSettings/add[@key='bussinessExceptionEmail']").Attributes["value"].Value;
                cm.Titulo = "AppointPlus - Retirada de Vazio"; //TODO: Deixar o titulo configuravel
                cm.Mensagem = "Time, \n"; //TODO: Deixar a forma de tratamento configuravel. o Email será direcionado ao time ou uma pessoa, configurar um tratamento mais formal etc...
                cm.Mensagem = string.Format("O Booking {0} não foi encontrado, \n", aRetiradaConteinerVazio.Reserva);
 
                return new Dictionary<string, string>() {                    
                    { "ConfiguracaoNotificacao",  JsonConvert.SerializeObject(cm)}                                        
                };
            }
        }
    }
}
