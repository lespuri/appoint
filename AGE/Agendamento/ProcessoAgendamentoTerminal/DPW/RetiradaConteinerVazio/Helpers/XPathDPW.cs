using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGE.Agendamento.DPW.RetiradaVazio.Helpers
{
    public static class XPathRetiradaVazioDPW
    {
        public const string USARIO_NOME = "/html/body/section/section[2]/section/form/section/table/tbody/tr[4]/td/div/input";
        public const string USARIO_SENHA = "/html/body/section/section[2]/section/form/section/table/tbody/tr[6]/td/div/input";
        public const string BOTAO_LOGIN = "/html/body/section/section[2]/section/form/section/table/tbody/tr[10]/td/table/tbody/tr[1]/td[1]/button";
        public const string LINK_AGENDAMENTO_RAPIDO_EOL = "/html/body/section/section[2]/section/article[1]/nav/ul/li[8]/a";
        public const string AC_TRANSPORTADORA = "/html/body/section[2]/section/article[1]/fieldset/table/tbody/tr[1]/td[2]/table/tbody/tr/td/div/div/input";
        public const string CB_GATE = "/html/body/section[2]/section/article[1]/fieldset/table/tbody/tr[2]/td[2]/select";
        public const string BT_ADICIONAR_CONTEINER = "/html/body/section[2]/section/article[2]/fieldset/table[1]/tbody/tr/td/button";
        public const string CB_TIPO_MOVIMENTO = "/html/body/section[3]/section/article[1]/fieldset/table/tbody/tr/td[2]/select";
        public const string AC_BOOKING = "/html/body/section[3]/section/article[2]/fieldset/div/section/table/tbody/tr[1]/td[2]/table/tbody/tr/td/div/div/input";
        public const string BT_SELECINAR_TRANSACAO = "/html/body/section[3]/section/article[2]/fieldset/div/section/center/button";
        public const string BT_JANELAS = "/html/body/section[2]/section/article[2]/fieldset/table[3]/tbody/tr/td/button";
        public const string CB_JANELAS_HORARIO = "/html/body/section[2]/section/article[5]/fieldset/center/table/tbody/tr[2]/td[4]/select";
        public const string PLACA_MOTORISTA = "/html/body/section[2]/section/article[6]/fieldset/table/tbody/tr[1]/td/table/tbody/tr/td[2]/input";
        public const string AC_CPF_MOTORISTA = "/html/body/section[2]/section/article[6]/fieldset/table/tbody/tr[10]/td/table/tbody/tr[1]/td[2]/div/div/input";
        public const string BT_AGENDAR = "/html/body/section[2]/section/article[7]/fieldset/table/tbody/tr/td/center/button";
    }
}
