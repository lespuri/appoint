using AGE.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AGE.Agendamento.DPW.Entidades
{
    public class RetiradaConteinerVazioRepositorio : Repositorio
    {
        public RetiradaConteinerVazioRepositorio() : base() { }

        public DbSet<RetiradaConteinerVazio> RetiradaConteinerVazioContext { get; set; }

        public void carregarGridVIew(DataGridView dgw, RetiradaConteinerVazio.eStatus prStatus)
        {
            var sql = string.Format("SELECT * FROM RetiradaConteinerVazio WHERE Status = {0}", (int)prStatus);
            DataTable dt = execSql(sql);
            dgw.DataSource = dt;
        }
        public List<RetiradaConteinerVazio> getConteinerVazioParaAgendar(RetiradaConteinerVazio.eStatus prStatus)
        {
            try
            {
                var sql =  string.Format("SELECT * FROM RetiradaConteinerVazio WHERE Status = {0}", (int)prStatus);

                var llsConfiguracao = (from rw in execSql(sql).AsEnumerable()
                                       select new RetiradaConteinerVazio()
                                       {
                                           Classificacao = rw["Classificacao"].ToString(),
                                           CodigoControle = rw["CodigoControle"].ToString(),
                                           DataHora = DateTime.Parse(rw["DataHora"].ToString().Trim()),
                                           ExportadorCNPJ = rw["ExportadorCNPJ"].ToString(),
                                           ExportadorNome = rw["ExportadorCNPJ"].ToString(),
                                           Navio = rw["Navio"].ToString(),
                                           RetiradaConteinerVazioId = int.Parse(rw["RetiradaConteinerVazioId"].ToString()),
                                           QuantidadeConteiner = int.Parse(rw["QuantidadeConteiner"].ToString()),
                                           Reserva = rw["Reserva"].ToString(),
                                           Tipo = rw["Tipo"].ToString(),
                                           PlacaVeiculo = rw["PlacaVeiculo"].ToString(),
                                           CPFMotorista = rw["CPFMotorista"].ToString(),
                                           Status = int.Parse(rw["Status"].ToString())
                                       }).ToList();

                return llsConfiguracao;
            }catch(Exception ex)        
            {
                throw new CustomException(ex.Message, ex);
            }
        }

        public void Insert(DataTable prDataTable)
        {
            RetiradaConteinerVazio lRetiradaConteinerVazio = new RetiradaConteinerVazio();
            try
            {
                foreach (DataRow row in prDataTable.Rows)
                {
                    lRetiradaConteinerVazio.Classificacao = row[0].ToString();

                    var Dia = row[2].ToString().Split('/')[0];
                    var Mes = row[2].ToString().Split('/')[1];
                    var Ano = row[2].ToString().Split('/')[2].Split(' ')[0];
                    var Hora = row[2].ToString().Split('/')[2].Split(' ')[1];

                    var DateTime = string.Format("{0}-{1}-{2} {3}", Ano, Mes, Dia, Hora);

                    var InsertCV = "INSERT INTO RetiradaConteinerVazio";
                    InsertCV += "(\"Classificacao\", \"CodigoControle\", \"DataHora\", \"ExportadorCNPJ\", \"ExportadorNome\", \"Navio\", \"QuantidadeConteiner\", \"Reserva\", \"Tipo\", \"PlacaVeiculo\", \"CPFMotorista\", \"Status\" )";
                    InsertCV += "VALUES";
                    InsertCV += string.Format("(\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\",\"{8}\",\"{9}\",\"{10}\", {11})", row[0], row[1], DateTime, row[3], row[4], row[5], row[6], row[7], row[8], row[9], row[10], (int)RetiradaConteinerVazio.eStatus.AguardandoAgendamento);

                    execNonSql(InsertCV);
                }
            }catch(Exception ex)
            {
                throw new CustomException(ex.Message,ex);
            }
        }

        public void Update(RetiradaConteinerVazio prRetiradaConteinerVazio)
        {
            try
            {
                var UpdateCV = "UPDATE RetiradaConteinerVazio";
                UpdateCV += " SET ";
                UpdateCV += String.Format("\"Classificacao\"=\"{0}\",", prRetiradaConteinerVazio.Classificacao);
                UpdateCV += String.Format("\"CodigoControle\"=\"{0}\",", prRetiradaConteinerVazio.CodigoControle);
                //UpdateCV += String.Format("\"DataHora\"=\"{0}\",", prRetiradaConteinerVazio.DataHora);
                UpdateCV += String.Format("\"ExportadorCNPJ\"=\"{0}\",", prRetiradaConteinerVazio.ExportadorCNPJ);
                UpdateCV += String.Format("\"ExportadorNome\"=\"{0}\",", prRetiradaConteinerVazio.ExportadorNome);
                UpdateCV += String.Format("\"Navio\"=\"{0}\",", prRetiradaConteinerVazio.Navio);
                UpdateCV += String.Format("\"QuantidadeConteiner\"=\"{0}\",", prRetiradaConteinerVazio.QuantidadeConteiner);
                UpdateCV += String.Format("\"Reserva\"=\"{0}\",", prRetiradaConteinerVazio.Reserva);
                UpdateCV += String.Format("\"Tipo\"=\"{0}\",", prRetiradaConteinerVazio.Tipo);
                UpdateCV += String.Format("\"PlacaVeiculo\"=\"{0}\",", prRetiradaConteinerVazio.PlacaVeiculo);
                UpdateCV += String.Format("\"CPFMotorista\"=\"{0}\",", prRetiradaConteinerVazio.CPFMotorista);
                UpdateCV += String.Format("\"Status\"={0}", prRetiradaConteinerVazio.Status);
                UpdateCV += String.Format(" WHERE \"RetiradaConteinerVazioId\"={0}", prRetiradaConteinerVazio.RetiradaConteinerVazioId);

                execNonSql(UpdateCV);
            }catch(Exception ex)
            {
                throw new CustomException(ex.Message, ex);
            }

        }
    }
}
