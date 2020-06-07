using AGE.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGE.Exceptions
{
    public class EnviarNotificacaoEmail
    {
        private Email EmailNotificacao;

        public struct ConfiguracaoEmail
        {
            public string Destinatario { get; set; }
            public string Mensagem { get; set; }
            public string Titulo { get; set; }
        }

        public EnviarNotificacaoEmail()
        {
            EmailNotificacao = new Email();         
        }

        public bool Enviar(ConfiguracaoEmail configuracaoEmail)
        {
            EmailNotificacao.enviar(configuracaoEmail.Destinatario, configuracaoEmail.Titulo, configuracaoEmail.Mensagem);

            return true;
        }
    }
}
