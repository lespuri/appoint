using AGE.Helpers;
using log4net;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGE.Exceptions
{
    public class BookingNaoEncontradoException : Exception
    {
        protected static readonly ILog Log =
             LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private Email EmailException;

        public override string Message
        {
            get
            {
                return "Booking não encontrado.";
            }
        }

        public BookingNaoEncontradoException(Exception prException) : base()
        {            
        }
    }
}
