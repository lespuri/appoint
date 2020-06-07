using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGE
{
    public class Repositorio : DbContext
    {
        protected SQLiteConnection conn;
        private SQLiteDataAdapter da = null;
        private DataTable dt = new DataTable();

        public Repositorio()
        {            
            conn = new SQLiteConnection("Data Source=appointplusdb.db");
            conn.Open();
        }

        public DataTable execSql(string sql)
        {
            var cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            da = new SQLiteDataAdapter(cmd.CommandText, conn);
            da.Fill(dt);

            return dt;
        }

        public void execNonSql(string sql)
        {
            var cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();            
        }
    }
}
