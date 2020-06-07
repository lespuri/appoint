using AGE.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGE.Exceptions
{
    public class Notificacao
    {
        public string DestinatarioEmail;
        public string TituloNotificacao;
        public string Mensagem;
        public enum TipoNotificacao
        {
            SystemException,
            BussinessException
        }

        public enum MeioNotificacao
        {
            Email
        }

        public Notificacao()
        {

        }

        public void Enviar(TipoNotificacao tipoNotificacao, MeioNotificacao meioNotificacao, string configuracaoNotificacao)
        {
            switch (tipoNotificacao)
            {
                case TipoNotificacao.BussinessException:
                    EnviarBussinessException(meioNotificacao, configuracaoNotificacao);
                    break;
                case TipoNotificacao.SystemException:
                    EnviarSystemException(meioNotificacao, configuracaoNotificacao);
                    break;
                default:
                    break;
            }
        }

        private void EnviarBussinessException(MeioNotificacao meioNotificacao, string configuracaoNotificacao)
        {
            switch (meioNotificacao)
            {
                case MeioNotificacao.Email:
                    var objConfiguracaoNotificacao = JsonConvert.DeserializeObject<EnviarNotificacaoEmail.ConfiguracaoEmail>(configuracaoNotificacao);
                    EnviarNotificacaoEmail enviarNotificacaoEmail = new EnviarNotificacaoEmail();
                    
                    enviarNotificacaoEmail.Enviar(objConfiguracaoNotificacao);
                    break;
                default:
                    break;
            }
        }

        private void EnviarSystemException(MeioNotificacao meioNotificacao, string configuracaoNotificacao)
        {
            switch (meioNotificacao)
            {
                case MeioNotificacao.Email:
                    var objConfiguracaoNotificacao = JsonConvert.DeserializeObject<EnviarNotificacaoEmail.ConfiguracaoEmail>(configuracaoNotificacao);
                    EnviarNotificacaoEmail enviarNotificacaoEmail = new EnviarNotificacaoEmail();

                    enviarNotificacaoEmail.Enviar(objConfiguracaoNotificacao);
                    break;
                default:
                    break;
            }

        }
    }
}
