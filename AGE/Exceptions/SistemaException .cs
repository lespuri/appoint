using AGE.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGE.Exceptions
{
    public class SistemaException : CustomException
    {
        private Email EmailBussinessException;

        public SistemaException(Exception prException, bool prEnviarEmail = true) : base(prException.Message, prException) 
        {
            var bla = this.GetType();
            if (prEnviarEmail)
            {
                EnviarNotificacao(Notificacao.TipoNotificacao.SystemException);
                //EmailBussinessException.enviar(prEnderecoEmail, prTituloEmail, prCorpoMEnsagem);
            }
        }

        public override void EnviarNotificacao(Notificacao.TipoNotificacao tipoNotificacao, Notificacao.MeioNotificacao meioNotificacao = Notificacao.MeioNotificacao.Email)
        {
            base.EnviarNotificacao(tipoNotificacao, meioNotificacao);
        }

        public override IDictionary Data
        {
            get
            {
                EnviarNotificacaoEmail.ConfiguracaoEmail cm = new EnviarNotificacaoEmail.ConfiguracaoEmail();
                cm.Destinatario = aXmlDoc.SelectSingleNode("//configuration/appSettings/add[@key='systemExceptionEmail']").Attributes["value"].Value;
                cm.Titulo = string.Format("AppointPlus - System Exception [{0}]", aXmlDoc.SelectSingleNode("//configuration/appSettings/add[@key='cnpjTransportadora']").Attributes["value"].Value); 
                cm.Mensagem = "Time, \n"; 
                cm.Mensagem += string.Format( "{0} - {1},", aException.Message, aException.StackTrace);

                return new Dictionary<string, string>() {
                    { "ConfiguracaoNotificacao",  JsonConvert.SerializeObject(cm)}
                };
            }
        }
    }
}
