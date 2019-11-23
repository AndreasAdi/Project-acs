using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;

namespace Proyek_ACS
{
    class Database
    {
        OracleConnection conn;
        public Database(OracleConnection oc)
        {
            conn = oc;
        }

        public List<Object> executeQuery(string query)
        {
            List<Object> obj = new List<object>();
            try
            {
                conn.Open();
                OracleCommand cmd = new OracleCommand(query, conn);
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Object[] row = new Object[reader.RowSize];
                    for (int i = 0; i < reader.RowSize; i++)
                    {
                        row[i] = reader.GetData(i);
                    }
                    obj.Add(row);
                }
                conn.Close();
                return obj;
            }
            catch
            {
                conn.Close();
                return null;
            }
        }

        public bool executeNonQuery(string query)
        {
            try
            {
                conn.Open();
                OracleCommand cmd = new OracleCommand(query, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch (Exception ex)
            {
                conn.Close();
                return false;
            }
        }

        public DataTable executeDataTable(string query)
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                OracleCommand cmd = new OracleCommand(query, conn);
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                adapter.Fill(dt);
                conn.Close();
                return dt;
            }
            catch
            {
                conn.Close();
                return null;
            }
        }
    }
}