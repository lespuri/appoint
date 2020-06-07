using AGE.Helpers;
using log4net;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace AGE.Exceptions
{
    public class CustomException : Exception
    {
        protected static readonly ILog Log =
             LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected XmlDocument aXmlDoc = new XmlDocument();
        protected Exception aException;

        protected Notificacao aNotificacao;
        public CustomException() : base() { }

        public CustomException(string prMensagem, Exception prException) : base(prMensagem, prException)
        {
            Log.Error(String.Format("{0}", prException.Message));            
            aNotificacao = new Notificacao();
            aXmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
            aException = prException;
        }

        public virtual void EnviarNotificacao(Notificacao.TipoNotificacao tipoNotificacao, Notificacao.MeioNotificacao meioNotificacao = Notificacao.MeioNotificacao.Email) {
            
            aNotificacao.Enviar(tipoNotificacao, meioNotificacao, this.Data["ConfiguracaoNotificacao"].ToString());
        }
    }
}
