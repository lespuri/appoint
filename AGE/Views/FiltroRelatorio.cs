using AGE.Relatorio.ProgramacaoDiaria.Atividades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AGE.Views
{
    public partial class FiltroRelatorio : MaterialSkin.Controls.MaterialForm
    {
        public FiltroRelatorio()
        {
            InitializeComponent();
        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            GerarRelatorioProgramacaoDiaria lGerarRelatorioProgramacaoDiaria = new GerarRelatorioProgramacaoDiaria();
            lGerarRelatorioProgramacaoDiaria.GerarRelatorio(DateTime.Now);
        }
    }
}
