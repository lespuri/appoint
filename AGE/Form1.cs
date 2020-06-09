using AGE.Agendamento.DPW.Atividades;
using AGE.Agendamento.DPW.Entidades;
using AGE.Helpers;
using log4net;
using MaterialSkin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using AGE.Views;
using System.Reflection;
using System.Threading;

namespace AGE
{
    public partial class Form1 : MaterialSkin.Controls.MaterialForm
    {
        
        private static readonly ILog Log =
             LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public Form1()
        {
            Thread t = new Thread(new ThreadStart(StartSplash));
            t.Start();
            Thread.Sleep(5000);
            InitializeComponent();
            t.Abort();

            var lVersion = "";

            var ver = Assembly.GetExecutingAssembly().GetName().Version;
            lVersion = string.Format("AppointPlus: [Beta Version] ");
            //var bla = System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion;
            //this.Text = lVersion;
            var skinManage = MaterialSkinManager.Instance;
            skinManage.AddFormToManage(this);
            skinManage.Theme = MaterialSkinManager.Themes.LIGHT;
            // Definindo um esquema de Cor para formulário com tom Azul            
            skinManage.ColorScheme = new ColorScheme(
                Primary.Grey100, Primary.LightBlue600,
                Primary.Blue500, Accent.Blue700,
                TextShade.BLACK
            );
            comboBox2.SelectedItem = "Retirada Conteiner Vazio";

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
            CarregarGrid();
        }

        private void StartSplash()
        {
            Application.Run(new SplashScreen());
        }

        private void CarregarGrid()
        {
            RetiradaConteinerVazioRepositorio lRetiradaConteinerVazioRepositorio = new RetiradaConteinerVazioRepositorio();
            lRetiradaConteinerVazioRepositorio = new RetiradaConteinerVazioRepositorio();

            lRetiradaConteinerVazioRepositorio.carregarGridVIew(this.dataGridView1, (RetiradaConteinerVazio.eStatus)comboBox1.SelectedValue);

            this.dataGridView1.Columns["RetiradaConteinerVazioId"].Visible = false;
            this.dataGridView1.Columns["CodigoControle"].Visible = false;
            this.dataGridView1.Columns["QuantidadeConteiner"].Visible = false;
            this.dataGridView1.Columns["DataHora"].DisplayIndex = 0;
            this.dataGridView1.Columns["DataHora"].HeaderText = "Data Hora";
            this.dataGridView1.Columns["Reserva"].DisplayIndex = 1;
            this.dataGridView1.Columns["Reserva"].HeaderText = "Booking";
            this.dataGridView1.Columns["CPFMotorista"].DisplayIndex = 2;
            this.dataGridView1.Columns["CPFMotorista"].HeaderText = "CPF Motorista";
            this.dataGridView1.Columns["PlacaVeiculo"].DisplayIndex = 3;
            this.dataGridView1.Columns["PlacaVeiculo"].HeaderText = "Placa do Veículo";
            this.dataGridView1.Columns["Tipo"].DisplayIndex = 4;
            this.dataGridView1.Columns["Tipo"].HeaderText = "Tipo";
            this.dataGridView1.Columns["Classificacao"].DisplayIndex = 5;
            this.dataGridView1.Columns["Classificacao"].HeaderText = "Classsificação";
            this.dataGridView1.Columns["Navio"].DisplayIndex = 6;
            this.dataGridView1.Columns["Navio"].HeaderText = "Navio";
            this.dataGridView1.Columns["ExportadorNome"].DisplayIndex = 7;
            this.dataGridView1.Columns["ExportadorNome"].HeaderText = "Nome Exportador";
            this.dataGridView1.Columns["ExportadorCNPJ"].DisplayIndex = 8;
            this.dataGridView1.Columns["ExportadorCNPJ"].HeaderText = "CNPJ Exportador";

        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "Arquivos do Excel |*.xlx;*.xlsx";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;


                    ExcelHelper lExcelHelper = new ExcelHelper("D:\\workspace\\Agendamento\\codigo\\AGE\\AGE\\bin\\Debug\\agendamentoVazio.xlsx");
                    var DataTableExcel = lExcelHelper.obterDadosAgendamento();

                    RetiradaConteinerVazioRepositorio lRetiradaConteinerVazioRepositorio = new RetiradaConteinerVazioRepositorio();
                    lRetiradaConteinerVazioRepositorio.Insert(DataTableExcel);
                }
            }

            CarregarGrid();

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            switch (comboBox.Text)
            {
                case "Retirada Conteiner Vazio":
                    
                    comboBox1.DataSource = Enum.GetValues(typeof(RetiradaConteinerVazio.eStatus))
                            .Cast<Enum>()
                            .Select(value => new
                            {
                                (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
                                value
                            })
                            .OrderBy(item => item.value)
                            .ToList();
                    comboBox1.DisplayMember = "Description";
                    comboBox1.ValueMember = "value";

                    break;
                default:
                    break;
            }
        }

        private void materialFlatButton2_Click(object sender, EventArgs e)
        {
            RetiradaConteinerVazioRepositorio lRetiradaConteinerVazioRepositorio = new RetiradaConteinerVazioRepositorio();            

            var lConteinerVazioParaAgendar = lRetiradaConteinerVazioRepositorio.getConteinerVazioParaAgendar((RetiradaConteinerVazio.eStatus)comboBox1.SelectedValue);

            foreach (var item in lConteinerVazioParaAgendar)
            {
                AgendarRetiradaConteinerVazio agendar = new AgendarRetiradaConteinerVazio(item);
                agendar.agendar();
            }

            CarregarGrid();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
        }

        private void materialFlatButton3_Click(object sender, EventArgs e)
        {
            Configuracao lConfiguracao = new Configuracao();
            lConfiguracao.Show();
        }

        private void materialLabel1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CarregarGrid();
            }
            catch { }
        }

        private void materialFlatButton4_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "Arquivos do Excel |*.xlx;*.xlsx";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;


                    ExcelHelper lExcelHelper = new ExcelHelper("D:\\workspace\\Agendamento\\codigo\\AGE\\AGE\\bin\\Debug\\agendamentoVazio.xlsx");
                    var DataTableExcel = lExcelHelper.obterDadosAgendamento();

                    RetiradaConteinerVazioRepositorio lRetiradaConteinerVazioRepositorio = new RetiradaConteinerVazioRepositorio();
                    lRetiradaConteinerVazioRepositorio.Insert(DataTableExcel);
                }
            }

            CarregarGrid();

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void configuraçõesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Configuracao lConfiguracao = new Configuracao();
            lConfiguracao.Show();
        }

        private void iniciarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RetiradaConteinerVazioRepositorio lRetiradaConteinerVazioRepositorio = new RetiradaConteinerVazioRepositorio();

            var lConteinerVazioParaAgendar = lRetiradaConteinerVazioRepositorio.getConteinerVazioParaAgendar((RetiradaConteinerVazio.eStatus)comboBox1.SelectedValue);

            foreach (var item in lConteinerVazioParaAgendar)
            {
                AgendarRetiradaConteinerVazio agendar = new AgendarRetiradaConteinerVazio(item);
                agendar.agendar();
            }

            CarregarGrid();
        }

        private void materialLabel3_Click(object sender, EventArgs e)
        {
            Point screenPoint = materialLabel3.PointToScreen(new Point(materialLabel3.Left, materialLabel3.Bottom));
            if (screenPoint.Y + contextMenuStrip1.Size.Height > Screen.PrimaryScreen.WorkingArea.Height)
            {
                contextMenuStrip1.Show(materialLabel3, new Point(0, -contextMenuStrip1.Size.Height));
            }
            else
            {
                contextMenuStrip1.Show(materialLabel3, new Point(0, materialLabel3.Height));
            }

        }
    }
}
