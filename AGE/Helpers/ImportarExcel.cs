using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGE.Helpers
{
    public class ExcelHelper
    {        
        private string ConnectionString;
        private string NomeArquivo;
        private DataTable DataTableExcel = new DataTable();
        public ExcelHelper(string prNomeArquivo)
        {
            NomeArquivo = prNomeArquivo;            

            if (Path.GetExtension(NomeArquivo) == ".xls")
            { //para o  Excel 97-03    
                ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source =" + NomeArquivo + "; Extended Properties = 'Excel 8.0;HDR=YES'";
            }
            else if (Path.GetExtension(NomeArquivo) == ".xlsx")
            { //para o  Excel 07 e superior
                ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source =" + NomeArquivo + "; Extended Properties = 'Excel 8.0;HDR=YES'";
            }
        }

        public DataTable obterDadosAgendamento()
        {
            OleDbConnection conn = new OleDbConnection(ConnectionString);
            OleDbCommand cmd = new OleDbCommand();
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter();
            cmd.Connection = conn;
            conn.Open();
            DataTable dtSchema;
            dtSchema = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            string nomePlanilha = dtSchema.Rows[0]["TABLE_NAME"].ToString();
            conn.Close();
            //le todos os dados da planilha para o Data Table    
            conn.Open();
            cmd.CommandText = "SELECT * From [" + nomePlanilha + "]";
            dataAdapter.SelectCommand = cmd;
            dataAdapter.Fill(DataTableExcel);
            conn.Close();

            return DataTableExcel;
        }
    }
}
