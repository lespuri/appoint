using AGE.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGE.Exceptions
{
    public class BusinessException : CustomException
    {
        private Email EmailBussinessException;

        public BusinessException(Exception prException, bool prEnviarEmail = true) : base(prException.Message, prException) 
        {
            var bla = this.GetType();
            if (prEnviarEmail)
            {
                //EnviarNotificacao(Notificacao.TipoNotificacao.BussinessException);
                //EmailBussinessException.enviar(prEnderecoEmail, prTituloEmail, prCorpoMEnsagem);
            }
        }

        public override void EnviarNotificacao(Notificacao.TipoNotificacao tipoNotificacao, Notificacao.MeioNotificacao meioNotificacao = Notificacao.MeioNotificacao.Email)
        {
            base.EnviarNotificacao(tipoNotificacao, meioNotificacao);
        }
    }
}
