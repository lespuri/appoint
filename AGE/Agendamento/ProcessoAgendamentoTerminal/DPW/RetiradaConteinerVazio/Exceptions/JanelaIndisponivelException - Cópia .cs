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
    public class JanelaIndisponivelException : BusinessException
    {
        private RetiradaConteinerVazioRepositorio aRetiradaConteinerVazioRepositorio;
        private RetiradaConteinerVazio aRetiradaConteinerVazio;
        public JanelaIndisponivelException(string prMessage, RetiradaConteinerVazio prRetiradaConteinerVazio) 
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
            aRetiradaConteinerVazio.Status = (int)RetiradaConteinerVazio.eStatus.ErroJanelaIndisponivel;
            aRetiradaConteinerVazioRepositorio.Update(aRetiradaConteinerVazio);
        }

        public override IDictionary Data
        {
            get
            {
                EnviarNotificacaoEmail.ConfiguracaoEmail cm = new EnviarNotificacaoEmail.ConfiguracaoEmail();
                cm.Destinatario = aXmlDoc.SelectSingleNode("//configuration/appSettings/add[@key='bussinessExceptionEmail']").Attributes["value"].Value;
                cm.Titulo = "AppointPlus - Retirada de Vazio";                
                cm.Mensagem = "Time, \n";
                cm.Mensagem = string.Format("A Janela {0:dd/MM/yyy HH:mm} indicada para o booking {1} não está disponível", aRetiradaConteinerVazio.DataHora, aRetiradaConteinerVazio.Reserva);
 
                return new Dictionary<string, string>() {                    
                    { "ConfiguracaoNotificacao",  JsonConvert.SerializeObject(cm)}                                        
                };
            }
        }
    }
}
